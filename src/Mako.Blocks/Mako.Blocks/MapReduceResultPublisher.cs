// ---------------------------------------------------------------------------------------------------------------------
//  <copyright file="MapReduceResultPublisher.cs" company="Hedron Interactive">
//      Copyright (c) Hedron Interactive. All rights reserved.
//  </copyright>
// ---------------------------------------------------------------------------------------------------------------------

namespace Hedron.Mako.Blocks
{
    using System.Threading;
    using global::Mako;

    internal sealed class MapReduceResultPublisher<TMapResult, TReduceResult> : IBlockResultPublisher<TMapResult>
    {
        public IBlockResultPublisher<TReduceResult> ExternalPublisher;
        public IBlock<TMapResult[], TReduceResult> Reducer;

        private TMapResult[] mapResults;
        private int resultCount;
        private int writerIndex;
        private int failbit;

        public MapReduceResultPublisher<TMapResult, TReduceResult> Reset(TMapResult[] results)
        {
            this.mapResults = results;
            this.resultCount = 0;
            this.writerIndex = -1;
            this.failbit = 0;

            return this;
        }

        public void YieldError(CompositionError error)
        {
            if (0 == Interlocked.Exchange(ref this.failbit, 1))
            {
                this.ExternalPublisher.YieldError(error);
            }
        }

        public void YieldResult(TMapResult result)
        {
            var index = Interlocked.Increment(ref this.writerIndex);

            this.mapResults[index] = result;

            index = Interlocked.Increment(ref this.resultCount);

            if (index == this.mapResults.Length)
            {
                this.Reducer.Apply(this.ExternalPublisher, this.mapResults);
            }
        }
    }
}