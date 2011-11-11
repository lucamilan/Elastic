// //-----------------------------------------------------------------------
// // <copyright file="IInstallerMetadata.cs" company="Luca Milan">
// //     Copyright (c) Luca Milan All rights reserved.
// // </copyright>
// //-----------------------------------------------------------------------

namespace Elastic.Core.Registry
{
    /// <summary>
    /// </summary>
    public interface IInstallerMetadata
    {
        /// <summary>
        ///   Gets the order.
        /// </summary>
        int Order { get; }
    }
}