namespace Mako
{
    using Mako.Concurrency;

    /// <summary>
    /// Responsible for publishing the outcome of a block.
    /// </summary>
    public interface IBlockResultPublisher<in TResult>
    {
        void YieldError(object receiverState, CompositionError error);

        void YieldResult(object receiverState, TResult result);

        void YieldResult(object receiverState, IAwaitable<TResult> result);
    }
}