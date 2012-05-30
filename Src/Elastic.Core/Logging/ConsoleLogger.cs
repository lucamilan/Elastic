using System;

namespace Elastic.Core.Logging
{
    /// <summary>
    /// 
    /// </summary>
    public class ConsoleLogger : ILogger
    {
        private readonly Type type;

        /// <summary>
        /// 
        /// </summary>
        public ConsoleLogger() : this(typeof (Console))
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        public ConsoleLogger(Type type)
        {
            this.type = type;
        }

        #region Implementation of ILogger

        /// <summary>
        /// </summary>
        /// <param name = "level"></param>
        /// <param name = "message"></param>
        /// <param name = "args"></param>
        public virtual void Log(MessageLevel level, string message, params object[] args)
        {
            Console.WriteLine(message, args);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="level"></param>
        /// <returns></returns>
        public virtual bool IsEnabled(MessageLevel level)
        {
            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public IDisposable Perf(string name)
        {
            return new CodePerfBlock(this, name);
        }

        #endregion
    }
}