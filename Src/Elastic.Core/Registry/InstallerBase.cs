// //-----------------------------------------------------------------------
// // <copyright file="InstallerBase.cs" company="Luca Milan">
// //     Copyright (c) Luca Milan All rights reserved.
// // </copyright>
// //-----------------------------------------------------------------------

namespace Elastic.Core.Registry
{
    /// <summary>
    /// </summary>
    /// <typeparam name = "T"></typeparam>
    public abstract class InstallerBase<T> : IInstaller<T> where T : class
    {
        #region Implementation of IHaveAnOpinion

        /// <summary>
        ///   Installs the specified registry.
        /// </summary>
        /// <param name = "registry">The registry.</param>
        public void Install(IRegistry<T> registry)
        {
            registry.Register(Configure);
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public virtual bool CanHaveAnOpinion()
        {
            return true;
        }

        /// <summary>
        /// </summary>
        /// <param name = "object"></param>
        protected abstract void Configure(T @object);

        #endregion
    }
}