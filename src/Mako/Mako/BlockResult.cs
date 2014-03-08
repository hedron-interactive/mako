namespace Mako
{
    using System;

    public static class BlockResult
    {
        public static BlockResult<TResult> FromResult<TResult>(object receiverState, TResult result)
        {
            return new BlockResult<TResult>(result, null, receiverState);
        }

        public static BlockResult<TResult> FromError<TResult>(object receiverState, CompositionError error)
        {
            return new BlockResult<TResult>(default(TResult), error, receiverState);
        }
    }

    public sealed class BlockResult<TResult>
    {
        private readonly TResult result;
        private readonly CompositionError? error;
        private readonly object state;

        public BlockResult(TResult result, CompositionError? error, object state)
        {
            this.result = result;
            this.error = error;
            this.state = state; 
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

        public object State
        {
            get { return this.state; }
        }
    }
}