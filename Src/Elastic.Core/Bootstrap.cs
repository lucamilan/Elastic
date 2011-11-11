// //-----------------------------------------------------------------------
// // <copyright file="Bootstrap.cs" company="Luca Milan">
// //     Copyright (c) Luca Milan All rights reserved.
// // </copyright>
// //-----------------------------------------------------------------------

namespace Elastic.Core
{
    #region

    using System;
    using Registry;

    #endregion

    /// <summary>
    ///   Class for setup complex objects via distributed installers.
    /// </summary>
    public class Bootstrap
    {
        /// <summary>
        ///   Occurs when [before install].
        /// </summary>
        public static event EventHandler<InstallerEventArg> BeforeInstall;

        /// <summary>
        ///   Occurs when [before install].
        /// </summary>
        public static event EventHandler<InstallerEventArg> FailInstall;

        /// <summary>
        ///   Occurs when [after install].
        /// </summary>
        public static event EventHandler<InstallerEventArg> AfterInstall;

        /// <summary>
        /// </summary>
        /// <param name = "eventArg"></param>
        internal static void NotifyFailInstall(InstallerEventArg eventArg)
        {
            var tmp = FailInstall;
            if (tmp != null)
            {
                tmp(null, eventArg);
            }
        }

        /// <summary>
        /// </summary>
        /// <param name = "eventArg"></param>
        internal static void NotifyAfterInstall(InstallerEventArg eventArg)
        {
            var tmp = AfterInstall;
            if (tmp != null)
            {
                tmp(null, eventArg);
            }
        }

        /// <summary>
        /// </summary>
        /// <param name = "eventArg"></param>
        internal static void NotifyBeforeInstall(InstallerEventArg eventArg)
        {
            var tmp = BeforeInstall;
            if (tmp != null)
            {
                tmp(null, eventArg);
            }
        }

        /// <summary>
        ///   Do (atomic) setup / composition.
        /// </summary>
        /// <typeparam name = "T"></typeparam>
        /// <param name = "factoryFunc">The factory func.</param>
        /// <returns></returns>
        public static T This<T>(Func<T> factoryFunc) where T : class
        {
            using (var registry = Registry<T>.CreateFor(factoryFunc))
            {
                registry.Run();

                return registry.Result;
            }
        }
    }
}