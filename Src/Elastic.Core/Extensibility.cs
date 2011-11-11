// //-----------------------------------------------------------------------
// // <copyright file="Extensibility.cs" company="Luca Milan">
// //     Copyright (c) Luca Milan All rights reserved.
// // </copyright>
// //-----------------------------------------------------------------------

namespace Elastic.Core
{
    #region

    using System;
    using System.ComponentModel.Composition;

    #endregion

    /// <summary>
    ///   Class that support exensibility
    /// </summary>
    public static class Extensibility
    {
        /// <summary>
        ///   Composition Service.
        /// </summary>
        /// <example>
        ///   In web environment:
        ///   var catalog = new DirectoryCatalog(@".\bin");
        ///   var service = new CompositionContainer(catalog);
        ///   Extensibility.Composer = () => service
        /// </example>
        public static Func<ICompositionService> Composer =
            () => { throw new NotImplementedException("Build a CompositionContainer with MEF"); };

        /// <summary>
        ///   Get current time
        /// </summary>
        public static Func<DateTime> TimeCreator = () => DateTime.Now;
    }
}