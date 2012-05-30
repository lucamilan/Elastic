// //-----------------------------------------------------------------------
// // <copyright file="SetupAutoMapperProfile.cs" company="Luca Milan">
// //     Copyright (c) Luca Milan All rights reserved.
// // </copyright>
// //-----------------------------------------------------------------------

using AutoMapper;
using Elastic.Core.Registry;
using Elastic.Core.Tests.Model;

namespace Elastic.Core.Tests.Installers
{
    #region

    

    #endregion

    /// <summary>
    /// </summary>
    [ExportInstaller(typeof (IInstaller<ConfigurationStore>))]
    public class SetupAutoMapperProfile : InstallerBase<ConfigurationStore>
    {
        #region Overrides of InstallerBase<IConfiguration>

        /// <summary>
        /// </summary>
        /// <param name = "object"></param>
        protected override void Configure(ConfigurationStore @object)
        {
            @object.CreateMap<SimpleEntity, SimpleViewModel>()
                .ForMember(_ => _.FullName, _ => _.MapFrom(__ => string.Format("{0} {1}", __.FirstName, __.LastName)));
        }

        #endregion
    }
}