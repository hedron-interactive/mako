// ---------------------------------------------------------------------------------------------------------------------
//  <copyright file="OnErrorBlock.cs" company="Hedron Interactive">
//      Copyright (c) Hedron Interactive. All rights reserved.
//  </copyright>
// ---------------------------------------------------------------------------------------------------------------------

namespace Hedron.Mako.Blocks
{
    using System;
    using global::Mako;

    /// <summary>
    /// Block associated with producing a result from an error response.
    /// </summary>
    /// <typeparam name="TResult">Type associated with block response.</typeparam>
    public sealed class OnErrorBlock<TResult> : Block<TResult>
    {
        private readonly IBlock<TResult> inner;
        private readonly Func<CompositionError, TResult> onError;

        /// <summary>
        /// Initialize new OnErrorBlock instance.
        /// </summary>
        /// <param name="inner">Underlying block to execute.</param>
        /// <param name="onError">Function used to produce a result from an error.</param>
        public OnErrorBlock(IBlock<TResult> inner, Func<CompositionError, TResult> onError)
        {
            if (null == inner)
            {
                throw new ArgumentNullException("inner");
            }

            if (null == onError)
            {
                throw new ArgumentNullException("onError");
            }

            this.inner = inner;
            this.onError = onError;
        }

        /// <summary>
        /// Function application method. This method does the work associated with this block.
        /// </summary>
        /// <param name="publisher">Used to publish the blocks result.</param>
        public override void Apply(IBlockResultPublisher<TResult> publisher)
        {
            var innerPublisher = new OnErrorBlockResultPublisher<TResult>
            {
                ExternalPublisher = publisher,
                OnError = this.onError
            };

            this.inner.Apply(innerPublisher);
        }
    }

    /// <summary>
    /// Block associated with producing a result from an error response.
    /// </summary>
    /// <typeparam name="T1">Type associated with first input.</typeparam>
    /// <typeparam name="TResult">Type associated with block response.</typeparam>
    public sealed class OnErrorBlock<T1, TResult> : Block<T1, TResult>
    {
        private readonly IBlock<T1, TResult> inner;
        private readonly Func<CompositionError, TResult> onError;

        /// <summary>
        /// Initialize new OnErrorBlock instance.
        /// </summary>
        /// <param name="inner">Underlying block to execute.</param>
        /// <param name="onError">Function used to produce a result from an error.</param>
        public OnErrorBlock(IBlock<T1, TResult> inner, Func<CompositionError, TResult> onError)
        {
            if (null == inner)
            {
                throw new ArgumentNullException("inner");
            }

            if (null == onError)
            {
                throw new ArgumentNullException("onError");
            }

            this.inner = inner;
            this.onError = onError;
        }

        /// <summary>
        /// Function application method. This method does the work associated with this block.
        /// </summary>
        /// <param name="publisher">Used to publish the blocks result.</param>
        /// <param name="input1">First block input parameter.</param>
        public override void Apply(IBlockResultPublisher<TResult> publisher, T1 input1)
        {
            var innerPublisher = new OnErrorBlockResultPublisher<TResult>
            {
                ExternalPublisher = publisher,
                OnError = this.onError
            };

            this.inner.Apply(innerPublisher, input1);
        }
    }

    /// <summary>
    /// Block associated with producing a result from an error response.
    /// </summary>
    /// <typeparam name="T1">Type associated with first input.</typeparam>
    /// <typeparam name="T2">Type associated with second input.</typeparam>
    /// <typeparam name="TResult">Type associated with block response.</typeparam>
    public sealed class OnErrorBlock<T1, T2, TResult> : Block<T1, T2, TResult>
    {
        private readonly IBlock<T1, T2, TResult> inner;
        private readonly Func<CompositionError, TResult> onError;

        /// <summary>
        /// Initialize new OnErrorBlock instance.
        /// </summary>
        /// <param name="inner">Underlying block to execute.</param>
        /// <param name="onError">Function used to produce a result from an error.</param>
        public OnErrorBlock(IBlock<T1, T2, TResult> inner, Func<CompositionError, TResult> onError)
        {
            if (null == inner)
            {
                throw new ArgumentNullException("inner");
            }

            if (null == onError)
            {
                throw new ArgumentNullException("onError");
            }

            this.inner = inner;
            this.onError = onError;
        }

        /// <summary>
        /// Function application method. This method does the work associated with this block.
        /// </summary>
        /// <param name="publisher">Used to publish the blocks result.</param>
        /// <param name="input1">First block input parameter.</param>
        /// <param name="input2">Second block input parameter.</param>
        public override void Apply(IBlockResultPublisher<TResult> publisher, T1 input1, T2 input2)
        {
            var innerPublisher = new OnErrorBlockResultPublisher<TResult>
            {
                ExternalPublisher = publisher,
                OnError = this.onError
            };

            this.inner.Apply(innerPublisher, input1, input2);
        }
    }

    /// <summary>
    /// Block associated with producing a result from an error response.
    /// </summary>
    /// <typeparam name="T1">Type associated with first input.</typeparam>
    /// <typeparam name="T2">Type associated with second input.</typeparam>
    /// <typeparam name="T3">Type associated with third input.</typeparam>
    /// <typeparam name="TResult">Type associated with block response.</typeparam>
    public sealed class OnErrorBlock<T1, T2, T3, TResult> : Block<T1, T2, T3, TResult>
    {
        private readonly IBlock<T1, T2, T3, TResult> inner;
        private readonly Func<CompositionError, TResult> onError;

        /// <summary>
        /// Initialize new OnErrorBlock instance.
        /// </summary>
        /// <param name="inner">Underlying block to execute.</param>
        /// <param name="onError">Function used to produce a result from an error.</param>
        public OnErrorBlock(IBlock<T1, T2, T3, TResult> inner, Func<CompositionError, TResult> onError)
        {
            if (null == inner)
            {
                throw new ArgumentNullException("inner");
            }

            if (null == onError)
            {
                throw new ArgumentNullException("onError");
            }

            this.inner = inner;
            this.onError = onError;
        }

        /// <summary>
        /// Function application method. This method does the work associated with this block.
        /// </summary>
        /// <param name="publisher">Used to publish the blocks result.</param>
        /// <param name="input1">First block input parameter.</param>
        /// <param name="input2">Second block input parameter.</param>
        /// <param name="input3">Third block input parameter.</param>
        public override void Apply(IBlockResultPublisher<TResult> publisher, T1 input1, T2 input2, T3 input3)
        {
            var innerPublisher = new OnErrorBlockResultPublisher<TResult>
            {
                ExternalPublisher = publisher,
                OnError = this.onError
            };

            this.inner.Apply(innerPublisher, input1, input2, input3);
        }
    }
}
