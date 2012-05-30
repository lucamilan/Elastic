// //-----------------------------------------------------------------------
// // <copyright file="ILogger.cs" company="Luca Milan">
// //     Copyright (c) Luca Milan All rights reserved.
// // </copyright>
// //-----------------------------------------------------------------------

using System;

namespace Elastic.Core.Logging
{
    #region

    

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
        /// 
        /// </summary>
        /// <param name="level"></param>
        /// <returns></returns>
        bool IsEnabled(MessageLevel level);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        IDisposable Perf(string name);
    }
}