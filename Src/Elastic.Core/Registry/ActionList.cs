// //-----------------------------------------------------------------------
// // <copyright file="ActionList.cs" company="Luca Milan">
// //     Copyright (c) Luca Milan All rights reserved.
// // </copyright>
// //-----------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;

namespace Elastic.Core.Registry
{
    #region

    

    #endregion

    /// <summary>
    /// </summary>
    /// <typeparam name = "T"></typeparam>
    public class ActionList<T> : IEnumerable<Action<T>> where T : class
    {
        /// <summary>
        /// </summary>
        private readonly IEnumerable<Action<T>> source;

        /// <summary>
        ///   Initializes a new instance of the <see cref = "ActionList{T}" /> class.
        /// </summary>
        private ActionList()
        {
        }

        /// <summary>
        ///   Initializes a new instance of the <see cref = "ActionList{T}" /> class.
        /// </summary>
        /// <param name = "source">The source.</param>
        public ActionList(Action<T> source)
        {
            if (source == null) throw new ArgumentNullException("source");
            this.source = new[] {source};
        }

        /// <summary>
        ///   Initializes a new instance of the <see cref = "T:System.Object" /> class.
        /// </summary>
        public ActionList(IEnumerable<Action<T>> source)
        {
            if (source == null) throw new ArgumentNullException("source");
            this.source = source;
        }

        /// <summary>
        ///   Initializes a new instance of the <see cref = "ActionList{T}" /> class.
        /// </summary>
        /// <param name = "first">The first.</param>
        /// <param name = "second">The second.</param>
        private ActionList(IEnumerable<Action<T>> first, IEnumerable<Action<T>> second)
        {
            if (first == null) throw new ArgumentNullException("first");
            if (second == null) throw new ArgumentNullException("second");
            source = Merge(first, second);
        }

        /// <summary>
        ///   Empty instance.
        /// </summary>
        /// <returns></returns>
        internal static ActionList<T> Null()
        {
            return new EmptyActionList();
        }

        /// <summary>
        ///   Merges the specified first.
        /// </summary>
        /// <param name = "first">The first.</param>
        /// <param name = "second">The second.</param>
        /// <returns></returns>
        private static IEnumerable<Action<T>> Merge(IEnumerable<Action<T>> first,
                                                    IEnumerable<Action<T>> second)
        {
            foreach (var item in first)
            {
                yield return item;
            }

            foreach (var item in second)
            {
                yield return item;
            }
        }

        /// <summary>
        /// </summary>
        /// <param name = "s1"></param>
        /// <param name = "s2"></param>
        /// <returns></returns>
        public static ActionList<T> operator +(ActionList<T> s1, ActionList<T> s2)
        {
            if (s2 != null && s1 != null)
            {
                return new ActionList<T>(s1, s2);
            }
            if (s1 != null)
            {
                return new ActionList<T>(s1);
            }
            if (s2 != null)
            {
                return new ActionList<T>(s2);
            }

            throw new InvalidOperationException("Sources are null!");
        }

        #region Nested type: EmptyActionList

        /// <summary>
        /// </summary>
        private sealed class EmptyActionList : ActionList<T>
        {
            /// <summary>
            ///   Gets the enumerator.
            /// </summary>
            /// <returns></returns>
            public override IEnumerator<Action<T>> GetEnumerator()
            {
                yield break;
            }
        }

        #endregion

        #region Implementation of IEnumerable

        /// <summary>
        ///   Returns an enumerator that iterates through the collection.
        /// </summary>
        /// <returns>
        ///   A <see cref = "T:System.Collections.Generic.IEnumerator`1" /> that can be used to iterate through the collection.
        /// </returns>
        /// <filterpriority>1</filterpriority>
        public virtual IEnumerator<Action<T>> GetEnumerator()
        {
            return source.GetEnumerator();
        }

        /// <summary>
        ///   Returns an enumerator that iterates through a collection.
        /// </summary>
        /// <returns>
        ///   An <see cref = "T:System.Collections.IEnumerator" /> object that can be used to iterate through the collection.
        /// </returns>
        /// <filterpriority>2</filterpriority>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        #endregion
    }
}