// //-----------------------------------------------------------------------
// // <copyright file="IRegistry.cs" company="Luca Milan">
// //     Copyright (c) Luca Milan All rights reserved.
// // </copyright>
// //-----------------------------------------------------------------------

using System;

namespace Elastic.Core.Registry
{
    #region

    

    #endregion

    /// <summary>
    ///   Contract that define a Registry.
    /// </summary>
    /// <typeparam name = "T"></typeparam>
    public interface IRegistry<out T> where T : class
    {
        /// <summary>
        ///   Adds the specified actions.
        /// </summary>
        /// <param name = "actions">The actions.</param>
        /// <returns></returns>
        IRegistry<T> Register(params Action<T>[] actions);
    }
}