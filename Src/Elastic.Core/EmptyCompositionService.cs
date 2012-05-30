// //-----------------------------------------------------------------------
// // <copyright file="EmptyCompositionService.cs" company="Luca Milan">
// //     Copyright (c) Luca Milan All rights reserved.
// // </copyright>
// //-----------------------------------------------------------------------

using System;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Primitives;

namespace Elastic.Core
{

    #region

    #endregion

    /// <summary>
    ///   Represent a class that do a composition.
    /// </summary>
    internal sealed class EmptyCompositionService : ICompositionService
    {
        #region Implementation of ICompositionService

        /// <summary>
        ///   Composes the specified part, with recomposition and validation disabled.
        /// </summary>
        /// <param name = "part">The part to compose.</param>
        void ICompositionService.SatisfyImportsOnce(ComposablePart part)
        {
        }

        #endregion
    }
}