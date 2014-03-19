// ---------------------------------------------------------------------------------------------------------------------
//  <copyright file="BlockResult.cs" company="Hedron Interactive">
//      Copyright (c) Hedron Interactive. All rights reserved.
//  </copyright>
// ---------------------------------------------------------------------------------------------------------------------

namespace Hedron.Mako
{
    using System;

    public static class BlockResult
    {
        public static BlockResult<TResult> FromResult<TResult>(TResult result)
        {
            return new BlockResult<TResult>(result, null);
        }

        public static BlockResult<TResult> FromError<TResult>(CompositionError error)
        {
            return new BlockResult<TResult>(default(TResult), error);
        }
    }

    public sealed class BlockResult<TResult>
    {
        private readonly TResult result;
        private readonly CompositionError? error;

        public BlockResult(TResult result, CompositionError? error)
        {
            this.result = result;
            this.error = error;
        }

        public bool HasResult
        {
            get { return !this.error.HasValue; }
        }

        public TResult Result
        {
            get
            {
                if (this.error.HasValue)
                {
                    throw new InvalidOperationException("This BlockResult does not contain a result.");
                }

                return this.result;
            }
        }

        public CompositionError Error
        {
            get
            {
                if (!this.error.HasValue)
                {
                    throw new InvalidOperationException("This BlockResult does not contain an error.");
                }

                return this.error.Value;
            }
        }
    }
}