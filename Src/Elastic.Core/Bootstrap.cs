// //-----------------------------------------------------------------------
// // <copyright file="Bootstrap.cs" company="Luca Milan">
// //     Copyright (c) Luca Milan All rights reserved.
// // </copyright>
// //-----------------------------------------------------------------------

using System;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Primitives;
using Elastic.Core.Registry;

namespace Elastic.Core
{

    #region

    #endregion

    /// <summary>
    ///   Class for setup complex objects by distributed installers.
    /// </summary>
    public class Bootstrap
    {
        /// <summary>
        /// </summary>
        internal static Func<ICompositionService> CompositionServiceActivator =
            () => new EmptyCompositionServiceActivator();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="activator"></param>
        public static void DiscoveryInstallerWith(Func<ICompositionService> activator)
        {
            if (activator == null) throw new ArgumentNullException("activator");
            CompositionServiceActivator = activator;
        }

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
            EventHandler<InstallerEventArg> tmp = FailInstall;

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
            EventHandler<InstallerEventArg> tmp = AfterInstall;
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
            EventHandler<InstallerEventArg> tmp = BeforeInstall;
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
            using (Registry<T> registry = Registry<T>.CreateFor(factoryFunc))
            {
                registry.Run();

                return registry.Result;
            }
        }

        #region Nested type: EmptyCompositionServiceActivator

        /// <summary>
        ///   Represent a class that do a composition.
        /// </summary>
        private sealed class EmptyCompositionServiceActivator : ICompositionService
        {
            #region Implementation of ICompositionService

            /// <summary>
            ///   Composes the specified part, with recomposition and validation disabled.
            /// </summary>
            /// <param name = "part">The part to compose.</param>
            void ICompositionService.SatisfyImportsOnce(ComposablePart part)
            {

            }

            #endregion
        }

        #endregion
    }
}