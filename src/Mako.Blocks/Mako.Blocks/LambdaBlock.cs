// ---------------------------------------------------------------------------------------------------------------------
//  <copyright file="LambdaBlock.cs" company="Hedron Interactive">
//      Copyright (c) Hedron Interactive. All rights reserved.
//  </copyright>
// ---------------------------------------------------------------------------------------------------------------------

namespace Mako.Blocks
{
    using System;

    public sealed class LambdaBlock<TResult> : Block<TResult>
    {
        private readonly Func<TResult> function;

        public LambdaBlock(Func<TResult> function)
        {
            if (null == function)
            {
                throw new ArgumentNullException("function");
            }

            this.function = function;
        }

        public override void Apply(IBlockResultPublisher<TResult> publisher, object receiverState)
        {
            if (null == publisher)
            {
                throw new ArgumentNullException("publisher");
            }

            publisher.YieldResult(receiverState, function());
        }
    }

    public sealed class LambdaBlock<T1, TResult> : Block<T1, TResult>
    {
        private readonly Func<T1, TResult> function;

        public LambdaBlock(Func<T1, TResult> function)
        {
            if (null == function)
            {
                throw new ArgumentNullException("function");
            }

            this.function = function;
        }

        public override void Apply(IBlockResultPublisher<TResult> publisher, object receiverState, T1 input1)
        {
            if (null == publisher)
            {
                throw new ArgumentNullException("publisher");
            }

            publisher.YieldResult(receiverState, function(input1));
        }
    }

    public sealed class LambdaBlock<T1, T2, TResult> : Block<T1, T2, TResult>
    {
        private readonly Func<T1, T2, TResult> function;

        public LambdaBlock(Func<T1, T2, TResult> function)
        {
            if (null == function)
            {
                throw new ArgumentNullException("function");
            }

            this.function = function;
        }

        public override void Apply(IBlockResultPublisher<TResult> publisher, object receiverState, T1 input1, T2 input2)
        {
            if (null == publisher)
            {
                throw new ArgumentNullException("publisher");
            }

            publisher.YieldResult(receiverState, function(input1, input2));
        }
    }

    public sealed class LambdaBlock<T1, T2, T3, TResult> : Block<T1, T2, T3, TResult>
    {
        private readonly Func<T1, T2, T3, TResult> function;

        public LambdaBlock(Func<T1, T2, T3, TResult> function)
        {
            if (null == function)
            {
                throw new ArgumentNullException("function");
            }

            this.function = function;
        }

        public override void Apply(IBlockResultPublisher<TResult> publisher, object receiverState, T1 input1, T2 input2, T3 input3)
        {
            if (null == publisher)
            {
                throw new ArgumentNullException("publisher");
            }

            publisher.YieldResult(receiverState, function(input1, input2, input3));
        }
    }
}