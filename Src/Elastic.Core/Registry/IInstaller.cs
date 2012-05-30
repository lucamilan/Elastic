// //-----------------------------------------------------------------------
// // <copyright file="IInstaller.cs" company="Luca Milan">
// //     Copyright (c) Luca Milan All rights reserved.
// // </copyright>
// //-----------------------------------------------------------------------

namespace Elastic.Core.Registry
{

    #region

    #endregion

    /// <summary>
    /// </summary>
    /// <typeparam name = "T"></typeparam>
    public interface IInstaller<in T> : IHaveAnOpinion where T : class
    {
        /// <summary>
        ///   Installs the specified registry.
        /// </summary>
        /// <param name = "registry">The registry.</param>
        void Install(IRegistry<T> registry);
    }
}