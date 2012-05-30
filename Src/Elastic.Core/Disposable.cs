// //-----------------------------------------------------------------------
// // <copyright file="Disposable.cs" company="Luca Milan">
// //     Copyright (c) Luca Milan All rights reserved.
// // </copyright>
// //-----------------------------------------------------------------------

using System;

namespace Elastic.Core
{
    #region

    

    #endregion

    /// <summary>
    /// Represent a Disposable implemtation base class.
    /// </summary>
    public abstract class Disposable : IDisposable
    {
        /// <summary>
        /// Null Disposable object
        /// </summary>
        public static readonly IDisposable Null = new NullDisposable();

        /// <summary>
        /// </summary>
        protected bool IsDisposed { get; private set; }

        #region IDisposable Members

        /// <summary>
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion

        /// <summary>
        /// </summary>
        ~Disposable()
        {
            Dispose(false);
        }

        /// <summary>
        /// </summary>
        /// <param name = "disposing"></param>
        private void Dispose(bool disposing)
        {
            if (!IsDisposed && disposing)
            {
                DisposeCore();
            }

            IsDisposed = true;
        }


        /// <summary>
        ///   Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        /// <filterpriority>2</filterpriority>
        protected virtual void DisposeCore()
        {
        }

        #region Nested type: NullDisposable

        /// <summary>
        /// </summary>
        private sealed class NullDisposable : IDisposable
        {
            #region Implementation of IDisposable

            /// <summary>
            ///   Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
            /// </summary>
            /// <filterpriority>2</filterpriority>
            void IDisposable.Dispose()
            {
            }

            #endregion
        }

        #endregion
    }
}