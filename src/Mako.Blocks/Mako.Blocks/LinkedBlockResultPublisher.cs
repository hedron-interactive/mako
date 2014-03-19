// ---------------------------------------------------------------------------------------------------------------------
//  <copyright file="LinkedBlockResultPublisher.cs" company="Hedron Interactive">
//      Copyright (c) Hedron Interactive. All rights reserved.
//  </copyright>
// ---------------------------------------------------------------------------------------------------------------------

namespace Hedron.Mako.Blocks
{
    using global::Mako;

    internal sealed class LinkedBlockResultPublisher<TResult, T1> : IBlockResultPublisher<T1>
    {
        public IBlockResultPublisher<TResult> ExternalPublisher;
        public IBlock<T1, TResult> Consequent;

        public void YieldError(CompositionError error)
        {
            this.ExternalPublisher.YieldError(error);
        }

        public void YieldResult(T1 result)
        {
            this.Consequent.Apply(this.ExternalPublisher, result);
        }
    }
}