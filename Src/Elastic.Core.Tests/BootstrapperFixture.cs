// //-----------------------------------------------------------------------
// // <copyright file="BootstrapperFixture.cs" company="Luca Milan">
// //     Copyright (c) Luca Milan All rights reserved.
// // </copyright>
// //-----------------------------------------------------------------------

using System;
using System.ComponentModel.Composition.Hosting;
using AutoMapper;
using Elastic.Core.Logging;
using Elastic.Core.Registry;
using Elastic.Core.Tests.Model;
using NUnit.Framework;
using StructureMap;

namespace Elastic.Core.Tests
{
    #region

    

    #endregion

    /// <summary>
    /// 
    /// </summary>
    [TestFixture]
    public class BootstrapperFixture
    {
        #region Setup/Teardown

        /// <summary>
        /// Tears down.
        /// </summary>
        [TearDown]
        public void TearDown()
        {
            Bootstrap.AfterInstall -= Print;
        }

        /// <summary>
        /// Sets up.
        /// </summary>
        [SetUp]
        public void SetUp()
        {
            LogService.Current += _ => new ConsoleLogger(typeof (BootstrapperFixture));
            SUT = new Container();
            Bootstrap.AfterInstall += Print;
        }

        #endregion

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Print(object sender, InstallerEventArg e)
        {
            Console.WriteLine("{0} : {1} secs", e.Installer.FullName, e.InstallDuration);
        }

        private IContainer SUT;
        private static readonly Guid Id = Guid.NewGuid();

        /// <summary>
        /// 
        /// </summary>
        [Test(Description = "Se ci sono installers allora posso effettuare il bootstrap dell'applicazione")]
        public void Should_Bootstrapp_Application_When_Installers_Is_Found()
        {
            new DescribeBootstrapper().Describe();

            //act
            var compositionService = new CompositionContainer(new DirectoryCatalog(@"."));
            Bootstrap.DiscoveryInstallerWith(()=>compositionService);

            //arrange
            Bootstrap.This(() => SUT);

            //assert
            var mappingEngine = SUT.GetInstance<IMappingEngine>();
            Assert.IsNotNull(mappingEngine);

            var entity = new SimpleEntity {FirstName = "Luca", LastName = "Milan", Id = Id};
            var viewModel = mappingEngine.Map<SimpleViewModel>(entity);

            Assert.AreEqual(viewModel.FullName, string.Format("{0} {1}", entity.FirstName, entity.LastName));
        }

        /// <summary>
        /// 
        /// </summary>
        [Test(
            Description =
                "Viene sollevata un'eccezione quando non vengono trovati installers dal servizio di composizione"),
         ExpectedException(typeof (RegistryException))]
        public void Should_Throw_Exception_When_Bootstrapp_Application_And_No_Installers_Is_Found()
        {
            //act
            var directoryCatalog = new DirectoryCatalog(@"c:\");
            var compositionService = new CompositionContainer(directoryCatalog);
            Bootstrap.DiscoveryInstallerWith(() => compositionService);

            //arrange
            Bootstrap.This(() => SUT);

            //assert
        }
    }
}