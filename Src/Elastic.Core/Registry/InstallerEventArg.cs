// //-----------------------------------------------------------------------
// // <copyright file="InstallerEventArg.cs" company="Luca Milan">
// //     Copyright (c) Luca Milan All rights reserved.
// // </copyright>
// //-----------------------------------------------------------------------

using System;

namespace Elastic.Core.Registry
{
    #region

    

    #endregion

    /// <summary>
    /// </summary>
    public class InstallerEventArg : EventArgs
    {
        private readonly Type installer;

        /// <summary>
        ///   Initializes a new instance of the <see cref = "InstallerEventArg" /> class.
        /// </summary>
        /// <param name = "installer">The installer.</param>
        internal InstallerEventArg(Type installer)
        {
            this.installer = installer;
        }

        /// <summary>
        ///   Gets the installer action.
        /// </summary>
        public Type Installer
        {
            get { return installer; }
        }

        /// <summary>
        ///   Get the exception.
        /// </summary>
        public Exception Exception { get; internal set; }

        /// <summary>
        ///   Get the exception.
        /// </summary>
        public double InstallDuration { get; internal set; }
    }
}