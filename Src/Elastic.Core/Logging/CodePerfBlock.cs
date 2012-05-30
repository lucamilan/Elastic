// //-----------------------------------------------------------------------
// // <copyright file="CodePerfBlock.cs" company="Luca Milan">
// //     Copyright (c) Luca Milan All rights reserved.
// // </copyright>
// //-----------------------------------------------------------------------

using System;
using System.Diagnostics;
using System.Globalization;
using System.Text;

namespace Elastic.Core.Logging
{
    #region

    

    #endregion

    /// <summary>
    /// Represent a class that measure Code Execution Performance.
    /// </summary>
    public class CodePerfBlock : Disposable
    {
        private readonly ILogger logger;
        private readonly string name;
        private readonly Stopwatch stopwatch;

        /// <summary>
        /// </summary>
        public CodePerfBlock(ILogger logger, string name)
        {
            stopwatch = Stopwatch.StartNew();
            this.logger = logger;
            this.name = name;
        }

        /// <summary>
        /// 
        /// </summary>
        protected Stopwatch Stopwatch
        {
            get { return stopwatch; }
        }

        /// <summary>
        /// </summary>
        protected override void DisposeCore()
        {
            Stopwatch.Stop();

            var sb = new StringBuilder();

#if DEBUG
            var stackTrace = new StackTrace(false);

            if (stackTrace.FrameCount > 2)
            {
                StackFrame stackFrame = stackTrace.GetFrame(3);
                sb.Append(stackFrame.GetMethod().DeclaringType.FullName)
                    .Append(" : ");
            }
#endif
            if (!string.IsNullOrWhiteSpace(name))
            {
                sb.Append(name);
            }

            TimeSpan timeSpan = TimeSpan.FromMilliseconds(Stopwatch.ElapsedMilliseconds);
            string messageWithTimingInfo = string.Format(CultureInfo.InvariantCulture, "{0} [{1}, {2}ms]", name,
                                                         Stopwatch.Elapsed, timeSpan);
            logger.Log(MessageLevel.Trace, "{0} : {1}", sb, messageWithTimingInfo);
            sb.Length = 0;
        }
    }
}