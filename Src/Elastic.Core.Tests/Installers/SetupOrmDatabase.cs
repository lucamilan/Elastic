// //-----------------------------------------------------------------------
// // <copyright file="SetupOrmDatabase.cs" company="Luca Milan">
// //     Copyright (c) Luca Milan All rights reserved.
// // </copyright>
// //-----------------------------------------------------------------------

using Elastic.Core.Registry;
using NHibernate.Cfg;
using NHibernate.Context;
using NHibernate.Dialect;

namespace Elastic.Core.Tests.Installers
{
    #region

    

    #endregion

    [ExportInstaller(typeof (IInstaller<Configuration>))]
    public class SetupOrmDatabase : InstallerBase<Configuration>
    {
        #region Overrides of InstallerBase<Configuration>

        /// <summary>
        /// </summary>
        /// <param name = "object"></param>
        protected override void Configure(Configuration @object)
        {
            @object.Properties["connection.release_mode"] = "on_close";
            @object.CurrentSessionContext<ThreadStaticSessionContext>();
            @object.DataBaseIntegration(x =>
                                            {
                                                x.LogSqlInConsole = true;
                                                x.Dialect<MsSqlCe40Dialect>();
                                                x.ConnectionString = @"Data Source=./test.sdf";
                                                x.SchemaAction = SchemaAutoAction.Update;
                                            });
        }

        #endregion
    }
}