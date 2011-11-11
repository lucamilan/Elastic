// //-----------------------------------------------------------------------
// // <copyright file="LogManager.cs" company="Luca Milan">
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
    public sealed class LogManager : ILogger
    {
        /// <summary>
        /// </summary>
        public static Func<ILogger> Current = () => new LogManager();

        #region ILogger Members

        /// <summary>
        /// </summary>
        /// <param name = "level"></param>
        /// <param name = "message"></param>
        /// <param name = "args"></param>
        void ILogger.Log(MessageLevel level, string message, params object[] args)
        {
        }

        /// <summary>
        /// </summary>
        /// <param name = "level"></param>
        /// <param name = "exception"></param>
        void ILogger.Log(MessageLevel level, Exception exception)
        {
        }

        #endregion
    }
}