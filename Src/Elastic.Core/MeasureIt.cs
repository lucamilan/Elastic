// //-----------------------------------------------------------------------
// // <copyright file="MeasureIt.cs" company="Luca Milan">
// //     Copyright (c) Luca Milan All rights reserved.
// // </copyright>
// //-----------------------------------------------------------------------

namespace Elastic.Core
{
    #region

    using System;
    using System.Diagnostics;
    using System.Text;
    using Logging;

    #endregion

    /// <summary>
    /// </summary>
    internal sealed class MeasureIt : Disposable
    {
        /// <summary>
        /// </summary>
        /// <param name = "title"></param>
        /// <returns></returns>
        public static MeasureIt Start(string title)
        {
            return new MeasureIt(title);
        }

#if DEBUG
        private readonly Stopwatch watch;
        private readonly string name;
#endif

        /// <summary>
        /// </summary>
        public MeasureIt(string name)
        {
#if DEBUG
            watch = Stopwatch.StartNew();
            this.name = name;
#endif
        }

        /// <summary>
        /// </summary>
        protected override void DisposeCore()
        {
#if DEBUG
            watch.Stop();

            var stackTrace = new StackTrace(false);

            var sb = new StringBuilder();

            if (stackTrace.FrameCount > 3)
            {
                sb.Append(stackTrace.GetFrame(3).GetMethod().DeclaringType.FullName);
            }

            if (!string.IsNullOrWhiteSpace(name))
            {
                sb.Append(" : ").Append(name);
            }

            var timeSpan = TimeSpan.FromMilliseconds(watch.ElapsedMilliseconds);

            LogManager.Current().Log(MessageLevel.Trace, "{0} : {1}", sb, timeSpan.TotalSeconds);

            sb.Length = 0;
#endif
        }
    }
}