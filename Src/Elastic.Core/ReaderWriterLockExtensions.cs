// //-----------------------------------------------------------------------
// // <copyright file="ReaderWriterLockExtensions.cs" company="Luca Milan">
// //     Copyright (c) Luca Milan All rights reserved.
// // </copyright>
// //-----------------------------------------------------------------------

using System;
using System.Threading;

namespace Elastic.Core
{

    #region

    #endregion

    /// <summary>
    /// </summary>
    public static class ReaderWriterLockExtensions
    {
        /// <summary>
        ///   Reads the lock.
        /// </summary>
        /// <param name = "rwls">The RWLS.</param>
        /// <returns></returns>
        public static IDisposable ReadLock(this ReaderWriterLockSlim rwls)
        {
            rwls.EnterReadLock();
            return new Disposable(rwls.ExitReadLock);
        }

        /// <summary>
        ///   Upgradables the read lock.
        /// </summary>
        /// <param name = "rwls">The RWLS.</param>
        /// <returns></returns>
        public static IDisposable UpgradableReadLock(this ReaderWriterLockSlim rwls)
        {
            rwls.EnterUpgradeableReadLock();
            return new Disposable(rwls.ExitUpgradeableReadLock);
        }

        /// <summary>
        ///   Writes the lock.
        /// </summary>
        /// <param name = "rwls">The RWLS.</param>
        /// <returns></returns>
        public static IDisposable WriteLock(this ReaderWriterLockSlim rwls)
        {
            rwls.EnterWriteLock();
            return new Disposable(rwls.ExitWriteLock);
        }

        #region Nested type: Disposable

        /// <summary>
        /// </summary>
        private struct Disposable : IDisposable
        {
            private readonly Action action;

            /// <summary>
            /// </summary>
            /// <param name = "action"></param>
            public Disposable(Action action)
            {
                this.action = action;
            }

            #region IDisposable Members

            /// <summary>
            /// </summary>
            void IDisposable.Dispose()
            {
                action();
            }

            #endregion
        }

        #endregion
    }
}