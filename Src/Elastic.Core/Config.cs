// //-----------------------------------------------------------------------
// // <copyright file="Config.cs" company="Luca Milan">
// //     Copyright (c) Luca Milan All rights reserved.
// // </copyright>
// //-----------------------------------------------------------------------

namespace Elastic.Core
{
    #region

    using System.Configuration;
    using System.Dynamic;

    #endregion

    /// <summary>
    /// </summary>
    public class Config : DynamicObject
    {
        /// <summary>
        /// </summary>
        private static readonly Config config = new Config();

        /// <summary>
        ///   Enables derived types to initialize a new instance of the <see cref = "T:System.Dynamic.DynamicObject" /> type.
        /// </summary>
        private Config()
        {
        }

        /// <summary>
        /// </summary>
        public static dynamic Current
        {
            get { return config; }
        }

        /// <summary>
        /// </summary>
        /// <param name = "binder"></param>
        /// <param name = "result"></param>
        /// <returns></returns>
        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            result = ConfigurationManager.AppSettings[binder.Name];

            if (result == null && ConfigurationManager.ConnectionStrings[binder.Name] != null)
            {
                result = ConfigurationManager.ConnectionStrings[binder.Name].ConnectionString;
            }

            return result != null;
        }
    }
}