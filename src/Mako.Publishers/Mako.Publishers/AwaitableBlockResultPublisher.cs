﻿// ---------------------------------------------------------------------------------------------------------------------
//  <copyright file="AwaitableBlockResultPublisher.cs" company="Hedron Interactive">
//      Copyright (c) Hedron Interactive. All rights reserved.
//  </copyright>
// ---------------------------------------------------------------------------------------------------------------------

namespace Mako.Publishers
{
    using System.Threading.Tasks;
    using global::Mako.Concurrency;

    public sealed class AwaitableBlockResultPublisher<TResult> : BlockResultPublisher<TResult>, IAwaitable<BlockResult<TResult>>
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

        public override void YieldError(object receiverState, CompositionError error)
        {
            this.resultCompletion.TrySetResult(BlockResult.FromError<TResult>(receiverState, error));
        }

        public override void YieldResult(object receiverState, TResult result)
        {
            this.resultCompletion.TrySetResult(BlockResult.FromResult<TResult>(receiverState, result));
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