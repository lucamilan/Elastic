// //-----------------------------------------------------------------------
// // <copyright file="Registry.cs" company="Luca Milan">
// //     Copyright (c) Luca Milan All rights reserved.
// // </copyright>
// //-----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Threading;
using Elastic.Core.Logging;

namespace Elastic.Core.Registry
{
    #region

    

    #endregion

    /// <summary>
    ///   Class that act a registry for  <see cref = "Action{T}" /> actions, and apply all on target object
    /// </summary>
    public sealed class Registry<T> : Disposable, IRegistry<T>, IHideObjectMembers where T : class
    {
        private readonly Lazy<T> result;
        private readonly ReaderWriterLockSlim rwls = new ReaderWriterLockSlim();
        private bool applied;

        /// <summary>
        ///   Prevents a default instance of the <see cref = "Registry{T}" /> class from being created.
        /// </summary>
        /// <param name = "builder">The factoryFunc func.</param>
        private Registry(Func<T> builder)
        {
            if (builder == null) throw new ArgumentNullException("builder");
            ActionsContainer = ActionList<T>.Null;
            result = new Lazy<T>(builder, true);
        }

        /// <summary>
        ///   Gets or sets the actions holder.
        /// </summary>
        /// <value>
        ///   The actions holder.
        /// </value>
        private Func<ActionList<T>> ActionsContainer { get; set; }

        /// <summary>
        /// </summary>
        [ImportMany]
        public IEnumerable<Lazy<IInstaller<T>, IInstallerMetadata>> Installers { get; internal set; }

        /// <summary>
        /// </summary>
        internal T Result
        {
            get
            {
                EnsureValueIsCreated();

                return result.Value;
            }
        }

        #region IRegistry<T> Members

        /// <summary>
        ///   Adds the specified actions.
        /// </summary>
        /// <param name = "actions">The actions.</param>
        /// <returns></returns>
        IRegistry<T> IRegistry<T>.Register(params Action<T>[] actions)
        {
            ActionList<T> actionList = new ActionList<T>(actions) + ActionsContainer();

            ActionsContainer = () => actionList;

            return this;
        }

        #endregion

        /// <summary>
        ///   Prepares this instance.
        /// </summary>
        /// <returns></returns>
        private void ComposeInstallers()
        {
            using (PerformaceMeasurer("ComposeInstallers"))
            {
                Bootstrap.CompositionServiceActivator().SatisfyImportsOnce(this);

                foreach (var installer in Installers.Where(_ => _.Value.CanHaveAnOpinion())
                    .OrderBy(_ => _.Metadata.Order))
                {
                    installer.Value.Install(this);
                }
            }
        }

        /// <summary>
        ///   Applies registred <see cref = "Action{T}" /> actions and build target object.
        /// </summary>
        /// <returns></returns>
        internal void Run()
        {
            using (PerformaceMeasurer("Run"))
            {
                EnsureNotDisposed();

                if (!applied)
                {
                    using (rwls.WriteLock())
                    {
                        EnsureValueIsNotCreated();

                        ComposeInstallers();

                        Action<T>[] actions = ActionsContainer().Reverse().ToArray();

                        if (actions.Length == 0)
                        {
                            return;
                        }

                        T subject = result.Value;

                        foreach (var action in actions)
                        {
                            Type declaringType = action.Method.DeclaringType;

                            bool isInstaller = typeof (IInstaller<T>).IsAssignableFrom(declaringType);

                            var arg = new InstallerEventArg(declaringType);

                            if (isInstaller)
                            {
                                Bootstrap.NotifyBeforeInstall(arg);
                            }

                            try
                            {
                                Stopwatch watch = Stopwatch.StartNew();
                                action(subject);
                                watch.Stop();
                                arg.InstallDuration = TimeSpan.FromMilliseconds(watch.ElapsedMilliseconds).TotalSeconds;
                            }
                            catch (Exception ex)
                            {
                                arg.Exception = ex;

                                Bootstrap.NotifyFailInstall(arg);

                                if (arg.Exception != null)
                                {
                                    throw;
                                }
                            }

                            if (isInstaller)
                            {
                                Bootstrap.NotifyAfterInstall(arg);
                            }
                        }

                        applied = true;
                    }
                }
            }
        }

        /// <summary>
        ///   Fors the specified factoryFunc.
        /// </summary>
        /// <param name = "factoryFunc">The factoryFunc.</param>
        /// <returns></returns>
        public static Registry<T> CreateFor(Func<T> factoryFunc)
        {
            using (PerformaceMeasurer("CreateFor"))
            {
                return new Registry<T>(factoryFunc);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        private static IDisposable PerformaceMeasurer(string message)
        {
            ILogger logger = LogService.Current(typeof (T));

            return
                logger.Perf(string.Format(CultureInfo.InvariantCulture, "Registry<{0}> => {1}", typeof (T).FullName,
                                          message));
        }

        /// <summary>
        /// </summary>
        private void EnsureNotDisposed()
        {
            if (IsDisposed)
            {
                throw new ObjectDisposedException(string.Format("{0}<{1}>", GetType().Name.Split('`').First(),
                                                                PrettyName()));
            }
        }

        /// <summary>
        /// </summary>
        private void EnsureValueIsNotCreated()
        {
            if (result.IsValueCreated)
            {
                throw new RegistryException(string.Format("Value of type {0} is already created", PrettyName()));
            }
        }

        /// <summary>
        /// </summary>
        private void EnsureValueIsCreated()
        {
            if (!result.IsValueCreated)
            {
                throw new RegistryException(string.Format(
                    "Value of type {0} is not created. Cause: missing installers.", PrettyName()));
            }
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        private string PrettyName()
        {
            return string.Join(", ", GetType().GetGenericArguments().Select(_ => _.Name)).TrimEnd();
        }

        #region Implementation of IDisposable

        /// <summary>
        ///   Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        protected override void DisposeCore()
        {
            rwls.Dispose();
        }

        #endregion
    }
}