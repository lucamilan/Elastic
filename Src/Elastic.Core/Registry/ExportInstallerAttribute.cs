// //-----------------------------------------------------------------------
// // <copyright file="ExportInstallerAttribute.cs" company="Luca Milan">
// //     Copyright (c) Luca Milan All rights reserved.
// // </copyright>
// //-----------------------------------------------------------------------

using System;
using System.ComponentModel.Composition;

namespace Elastic.Core.Registry
{
    #region

    

    #endregion

    /// <summary>
    /// </summary>
    [MetadataAttribute]
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class ExportInstallerAttribute : ExportAttribute
    {
        /// <summary>
        ///   Initializes a new instance of the <see cref = "ExportInstallerAttribute" /> class.
        /// </summary>
        public ExportInstallerAttribute(Type contract)
            : this(0, contract)
        {
        }

        /// <summary>
        ///   Initializes a new instance of the <see cref = "ExportInstallerAttribute" /> class.
        /// </summary>
        /// <param name = "order">The order.</param>
        /// <param name = "contract"></param>
        public ExportInstallerAttribute(int order, Type contract)
            : base(contract)
        {
            Order = order;
        }

        /// <summary>
        /// </summary>
        public int Order { get; private set; }
    }
}