// //-----------------------------------------------------------------------
// // <copyright file="SimpleEntity.cs" company="Luca Milan">
// //     Copyright (c) Luca Milan All rights reserved.
// // </copyright>
// //-----------------------------------------------------------------------

using System;

namespace Elastic.Core.Tests.Model
{
    /// <summary>
    /// 
    /// </summary>
    public class SimpleEntity
    {
        public virtual Guid Id { get; set; }
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }
    }
}