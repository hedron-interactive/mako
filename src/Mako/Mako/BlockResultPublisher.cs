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
        public abstract void YieldError(CompositionError error);

        public abstract void YieldResult(TResult result);

        public virtual async void YieldResult(IAwaitable<TResult> result)
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
                this.YieldError(error.AsError(CompositionErrorCode.TrappedAsyncException));
                return;
            }

            this.YieldResult(value);
        }
    }
}