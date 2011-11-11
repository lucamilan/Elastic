// //-----------------------------------------------------------------------
// // <copyright file="GlobalSuppressions.cs" company="Luca Milan">
// //     Copyright (c) Luca Milan All rights reserved.
// // </copyright>
// //-----------------------------------------------------------------------

#region

using System.Diagnostics.CodeAnalysis;

#endregion

[assembly:
    SuppressMessage("Microsoft.Design", "CA1009:DeclareEventHandlersCorrectly", Scope = "member",
        Target = "Elastic.Skeleton.Registry.Registry`1.#BeforeInstall")]
[assembly:
    SuppressMessage("Microsoft.Design", "CA1009:DeclareEventHandlersCorrectly", Scope = "member",
        Target = "Elastic.Skeleton.Registry.Registry`1.#AfterInstall")]
[assembly:
    SuppressMessage("Microsoft.Design", "CA1009:DeclareEventHandlersCorrectly", Scope = "member",
        Target = "Elastic.Skeleton.Registry.Registry`1.#FailInstall")]