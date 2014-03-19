// ---------------------------------------------------------------------------------------------------------------------
//  <copyright file="BlockExtensions.cs" company="Hedron Interactive">
//      Copyright (c) Hedron Interactive. All rights reserved.
//  </copyright>
// ---------------------------------------------------------------------------------------------------------------------

namespace Hedron.Mako
{
    using System;

    public static class BlockExtensions
    {
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
            where TBlock : IBlock
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

        public static TPublisher Apply<TPublisher, TResult>(this TPublisher publisher, IBlock<TResult> block, object receiverState)
            where TPublisher : class, IBlockResultPublisher<TResult>
        {
            if (null == publisher)
            {
                throw new ArgumentNullException("publisher");
            }

            if (null == block)
            {
                throw new ArgumentNullException("block");
            }

            block.Apply(publisher);

            return publisher;
        }

        public static TPublisher Apply<TPublisher, T1, TResult>(this TPublisher publisher, IBlock<T1, TResult> block, object receiverState, T1 input1)
            where TPublisher : class, IBlockResultPublisher<TResult>
        {
            if (null == publisher)
            {
                throw new ArgumentNullException("publisher");
            }

            if (null == block)
            {
                throw new ArgumentNullException("block");
            }

            block.Apply(publisher, input1);

            return publisher;
        }

        public static TPublisher Apply<TPublisher, T1, T2, TResult>(this TPublisher publisher, IBlock<T1, T2, TResult> block, object receiverState, T1 input1, T2 input2)
            where TPublisher : class, IBlockResultPublisher<TResult>
        {
            if (null == publisher)
            {
                throw new ArgumentNullException("publisher");
            }

            if (null == block)
            {
                throw new ArgumentNullException("block");
            }

            block.Apply(publisher, input1, input2);

            return publisher;
        }

        public static TPublisher Apply<TPublisher, T1, T2, T3, TResult>(this TPublisher publisher, IBlock<T1, T2, T3, TResult> block, object receiverState, T1 input1, T2 input2, T3 input3)
            where TPublisher : class, IBlockResultPublisher<TResult>
        {
            if (null == publisher)
            {
                throw new ArgumentNullException("publisher");
            }

            if (null == block)
            {
                throw new ArgumentNullException("block");
            }

            block.Apply(publisher, input1, input2, input3);

            return publisher;
        }
    }
}