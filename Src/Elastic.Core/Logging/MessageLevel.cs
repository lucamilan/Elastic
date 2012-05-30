// //-----------------------------------------------------------------------
// // <copyright file="MessageLevel.cs" company="Luca Milan">
// //     Copyright (c) Luca Milan All rights reserved.
// // </copyright>
// //-----------------------------------------------------------------------

using System;

namespace Elastic.Core.Logging
{
    /// <summary>
    /// </summary>
    [Flags]
    public enum MessageLevel : byte
    {
        /// <summary>
        /// </summary>
        Trace = 0,

        /// <summary>
        /// </summary>
        Debug = 2,

        /// <summary>
        /// </summary>
        Info = 4,

        /// <summary>
        /// </summary>
        Warn = 8,

        /// <summary>
        /// </summary>
        Error = 16,

        /// <summary>
        /// </summary>
        Fatal = 24
    }
}