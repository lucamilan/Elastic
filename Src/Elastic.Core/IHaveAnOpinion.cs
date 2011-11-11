// //-----------------------------------------------------------------------
// // <copyright file="IHaveAnOpinion.cs" company="Luca Milan">
// //     Copyright (c) Luca Milan All rights reserved.
// // </copyright>
// //-----------------------------------------------------------------------

namespace Elastic.Core
{
    /// <summary>
    ///   Define a opinionated interface.
    /// </summary>
    public interface IHaveAnOpinion
    {
        /// <summary>
        /// </summary>
        /// <returns></returns>
        bool CanHaveAnOpinion();
    }

    /// <summary>
    ///   Define a typed opinionated interface.
    /// </summary>
    public interface IHaveAnOpinion<T> where T : class
    {
        /// <summary>
        /// </summary>
        /// <returns></returns>
        bool CanHaveAnOpinion();
    }
}