// ---------------------------------------------------------------------------------------------------------------------
//  <copyright file="BlockResultPublisher.cs" company="Hedron Interactive">
//      Copyright (c) Hedron Interactive. All rights reserved.
//  </copyright>
// ---------------------------------------------------------------------------------------------------------------------

namespace Mako
{
    using System;
    using Mako.Concurrency;

    public abstract class BlockResultPublisher<TResult> : IBlockResultPublisher<TResult>
    {
        public abstract void YieldError(object receiverState, CompositionError error);

        public abstract void YieldResult(object receiverState, TResult result);

        public virtual async void YieldResult(object receiverState, IAwaitable<TResult> result)
        {
            TResult value;

            if (null == result)
            {
                throw new ArgumentNullException("result");
            }

            try
            {
                value = await result;
            }
            catch (Exception error)
            {
                this.YieldError(receiverState, error.AsError(CompositionErrorCode.TrappedAsyncException));
                return;
            }

            this.YieldResult(receiverState, value);
        }
    }
}