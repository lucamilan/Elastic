// //-----------------------------------------------------------------------
// // <copyright file="IHideObjectMembers.cs" company="Luca Milan">
// //     Copyright (c) Luca Milan All rights reserved.
// // </copyright>
// //-----------------------------------------------------------------------

using System;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;

namespace Elastic.Core
{
    #region

    

    #endregion

    /// <summary>
    ///   Helper interface used to hide the base <see cref = "object" /> 
    ///   members from the fluent API to make it much cleaner 
    ///   in Visual Studio intellisense.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IHideObjectMembers
    {
        /// <summary>
        ///   Equalses the specified value.
        /// </summary>
        /// <param name = "value">The value.</param>
        /// <returns></returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        bool Equals(object value);

        /// <summary>
        ///   Gets the hash code.
        /// </summary>
        /// <returns></returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        int GetHashCode();

        /// <summary>
        ///   Gets the type.
        /// </summary>
        /// <returns></returns>
        [SuppressMessage("Microsoft.Naming", "CA1716:IdentifiersShouldNotMatchKeywords", MessageId = "GetType",
            Justification =
                "This should not be visible in auto complete list of VS, distracts when writing fluent syntax.")]
        [SuppressMessage("Microsoft.Design", "CA1024:UsePropertiesWhereAppropriate",
            Justification = "In that case it is an issue of the .NET Framework itself")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        Type GetType();

        /// <summary>
        ///   Toes the string.
        /// </summary>
        /// <returns></returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        string ToString();
    }
}