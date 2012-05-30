using System;

namespace Elastic.Core.Logging
{
    /// <summary>
    /// 
    /// </summary>
    public static class LogExtensions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="log"></param>
        /// <param name="message"></param>
        /// <param name="args"></param>
        public static void Info(this ILogger log, string message, params object[] args)
        {
            if (log.IsEnabled(MessageLevel.Info))
            {
                log.Log(MessageLevel.Info, message, args);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="log"></param>
        /// <param name="message"></param>
        /// <param name="args"></param>
        public static void Debug(this ILogger log, string message, params object[] args)
        {
            if (log.IsEnabled(MessageLevel.Debug))
            {
                log.Log(MessageLevel.Debug, message, args);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="log"></param>
        /// <param name="message"></param>
        /// <param name="args"></param>
        public static void Warn(this ILogger log, string message, params object[] args)
        {
            if (log.IsEnabled(MessageLevel.Warn))
            {
                log.Log(MessageLevel.Warn, message, args);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="log"></param>
        /// <param name="message"></param>
        /// <param name="args"></param>
        public static void Fatal(this ILogger log, string message, params object[] args)
        {
            if (log.IsEnabled(MessageLevel.Fatal))
            {
                log.Log(MessageLevel.Fatal, message, args);
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="log"></param>
        /// <param name="message"></param>
        /// <param name="args"></param>
        public static void Trace(this ILogger log, string message, params object[] args)
        {
            if (log.IsEnabled(MessageLevel.Trace))
            {
                log.Log(MessageLevel.Trace, message, args);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="log"> </param>
        /// <param name="exception"></param>
        public static void LogError(this ILogger log, Exception exception)
        {
            if (log.IsEnabled(MessageLevel.Error))
            {
                log.Log(MessageLevel.Error, string.Format("{0}", exception.Message));
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="log"> </param>
        /// <param name="exception"></param>
        public static void LogFatal(this ILogger log, Exception exception)
        {
            if (log.IsEnabled(MessageLevel.Fatal))
            {
                log.Log(MessageLevel.Fatal, string.Format("{0}", exception.Message));
            }
        }
    }
}