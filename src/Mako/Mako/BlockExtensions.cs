// ---------------------------------------------------------------------------------------------------------------------
//  <copyright file="BlockExtensions.cs" company="Hedron Interactive">
//      Copyright (c) Hedron Interactive. All rights reserved.
//  </copyright>
// ---------------------------------------------------------------------------------------------------------------------

namespace Mako
{
    using System;

    public static class BlockExtensions
    {
        private static readonly Type[] BlockGenericInterfaces = new Type[] { typeof(IBlock<>), typeof(IBlock<,>), typeof(IBlock<,,>), typeof(IBlock<,,,>) };
        private static readonly object[] EmptyArguments = new object[0];

        #region Visitor Related

        public static TVisitor Visit<TVisitor>(this TVisitor visitor, IBlock block, string tag) 
            where TVisitor : IBlockVisitor
        {
            if (object.ReferenceEquals(null, visitor))
            {
                throw new ArgumentNullException("visitor");
            }

            if (null == block)
            {
                throw new ArgumentNullException("block");
            }

            visitor.Block(block, tag);

            return visitor;
        }

        public static TBlock Visit<TBlock>(this TBlock block, IBlockVisitor visitor, string tag)
        {
            if (object.ReferenceEquals(null, visitor))
            {
                throw new ArgumentNullException("visitor");
            }

            if (null == visitor)
            {
                throw new ArgumentNullException("visitor");
            }

            return block;
        }

        #endregion
    }
}