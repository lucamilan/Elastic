// //-----------------------------------------------------------------------
// // <copyright file="BootstrapAutoMapper.cs" company="Luca Milan">
// //     Copyright (c) Luca Milan All rights reserved.
// // </copyright>
// //-----------------------------------------------------------------------

using AutoMapper;
using AutoMapper.Mappers;
using Elastic.Core.Registry;
using StructureMap;

namespace Elastic.Core.Tests.Installers
{
    #region

    

    #endregion

    /// <summary>
    /// </summary>
    [ExportInstaller(1, typeof (IInstaller<IContainer>))]
    public class BootstrapAutoMapper : InstallerBase<IContainer>
    {
        #region Overrides of InstallerBase<IContainer>

        /// <summary>
        /// </summary>
        /// <param name = "object"></param>
        protected override void Configure(IContainer @object)
        {
            //create automapper configuration object
            var cfg = new ConfigurationStore(new TypeMapFactory(), MapperRegistry.AllMappers());
            cfg.ConstructServicesUsing(@object.GetInstance);

            //configure automapper in container
            @object.Configure(_ =>
                                  {
                                      //bootstrap automapper
                                      Bootstrap.This(() => cfg);
                                      _.For<ConfigurationStore>().Singleton().Use(cfg);
                                      _.For<IMappingEngine>().Singleton().Use(new MappingEngine(cfg));
                                  });
        }

        #endregion
    }
}