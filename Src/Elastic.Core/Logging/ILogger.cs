// //-----------------------------------------------------------------------
// // <copyright file="ILogger.cs" company="Luca Milan">
// //     Copyright (c) Luca Milan All rights reserved.
// // </copyright>
// //-----------------------------------------------------------------------

namespace Elastic.Core.Logging
{
    #region

    using System;

    #endregion

    /// <summary>
    /// </summary>
    public interface ILogger
    {
        /// <summary>
        /// </summary>
        /// <param name = "level"></param>
        /// <param name = "message"></param>
        /// <param name = "args"></param>
        void Log(MessageLevel level, string message, params object[] args);

        /// <summary>
        /// </summary>
        /// <param name = "level"></param>
        /// <param name = "exception"></param>
        void Log(MessageLevel level, Exception exception);
    }
}