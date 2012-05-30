// //-----------------------------------------------------------------------
// // <copyright file="SetupOrmMapping.cs" company="Luca Milan">
// //     Copyright (c) Luca Milan All rights reserved.
// // </copyright>
// //-----------------------------------------------------------------------

using Elastic.Core.Registry;
using NHibernate.Cfg;
using NHibernate.Cfg.MappingSchema;
using NHibernate.Mapping.ByCode;

namespace Elastic.Core.Tests.Installers
{
    #region

    

    #endregion

    [ExportInstaller(1, typeof (IInstaller<Configuration>))]
    public class SetupOrmMapping : InstallerBase<Configuration>
    {
        #region Overrides of InstallerBase<Configuration>

        /// <summary>
        /// </summary>
        /// <param name = "object"></param>
        protected override void Configure(Configuration @object)
        {
            var mapper = new ModelMapper();
            mapper.AddMappings(GetType().Assembly.GetExportedTypes());
            HbmMapping mapping = mapper.CompileMappingForAllExplicitlyAddedEntities();
            @object.AddDeserializedMapping(mapping, GetType().Name);
        }

        #endregion
    }
}