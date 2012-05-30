// //-----------------------------------------------------------------------
// // <copyright file="BootstrapOrm.cs" company="Luca Milan">
// //     Copyright (c) Luca Milan All rights reserved.
// // </copyright>
// //-----------------------------------------------------------------------

using Elastic.Core.Registry;
using NHibernate;
using NHibernate.Cfg;
using StructureMap;

namespace Elastic.Core.Tests.Installers
{
    #region

    

    #endregion

    /// <summary>
    /// </summary>
    [ExportInstaller(0, typeof (IInstaller<IContainer>))]
    public class BootstrapOrm : InstallerBase<IContainer>
    {
        #region Overrides of InstallerBase<IContainer>

        /// <summary>
        /// </summary>
        /// <param name = "object"></param>
        protected override void Configure(IContainer @object)
        {
            //bootstrap nhibernate configuration
            Configuration cfg = Bootstrap.This(() => new Configuration());

            //configure nhibernate in container
            @object.Configure(_ => _.For<Configuration>().Singleton().Use(cfg));
            @object.Configure(_ => _.For<ISessionFactory>().Use(__ => cfg.BuildSessionFactory()));
            @object.Configure(
                _ =>
                _.For<ISession>().HybridHttpOrThreadLocalScoped().Use(
                    __ => __.GetInstance<ISessionFactory>().OpenSession()));
            @object.Configure(
                _ =>
                _.For<IStatelessSession>().HybridHttpOrThreadLocalScoped().Use(
                    __ => __.GetInstance<ISessionFactory>().OpenStatelessSession()));
        }

        #endregion
    }
}