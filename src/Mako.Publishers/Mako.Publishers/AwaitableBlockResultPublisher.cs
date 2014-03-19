// ---------------------------------------------------------------------------------------------------------------------
//  <copyright file="AwaitableBlockResultPublisher.cs" company="Hedron Interactive">
//      Copyright (c) Hedron Interactive. All rights reserved.
//  </copyright>
// ---------------------------------------------------------------------------------------------------------------------

namespace Mako.Publishers
{
    using System.Threading.Tasks;
    using global::Mako.Concurrency;

    public sealed class AwaitableBlockResultPublisher<TResult> : IBlockResultPublisher<TResult>, IAwaitable<BlockResult<TResult>>
    {
        private readonly TaskCompletionSource<BlockResult<TResult>> resultCompletion;

        public AwaitableBlockResultPublisher()
        {
            this.resultCompletion = new TaskCompletionSource<BlockResult<TResult>>();
        }

        public Task<BlockResult<TResult>> Task
        {
            get { return this.resultCompletion.Task; }
        }

        public void YieldError(CompositionError error)
        {
            this.resultCompletion.SetResult(BlockResult.FromError<TResult>(error));
        }

        public void YieldResult(TResult result)
        {
            this.resultCompletion.SetResult(BlockResult.FromResult(result));
        }

        public bool TryGetResult(out BlockResult<TResult> result)
        {
            if (this.resultCompletion.Task.IsCompleted)
            {
                result = this.resultCompletion.Task.Result;
                return true;
            }

            result = null;
            return false;
        }

        public IAwaiter<BlockResult<TResult>> GetAwaiter()
        {
            return this.resultCompletion.Task.AsAwaitable().GetAwaiter();
        }
    }
}
