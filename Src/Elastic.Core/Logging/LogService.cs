// //-----------------------------------------------------------------------
// // <copyright file="LogService.cs" company="Luca Milan">
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
    public sealed class LogService : ILogger
    {
        /// <summary>
        /// </summary>
        public static Func<Type, ILogger> Current = _ => new LogService();

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
        /// 
        /// </summary>
        /// <param name="level"></param>
        /// <returns></returns>
        bool ILogger.IsEnabled(MessageLevel level)
        {
            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        IDisposable ILogger.Perf(string name)
        {
            return Disposable.Null;
        }

        #endregion
    }
}