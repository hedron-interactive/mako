namespace Mako
{
    using Mako.Concurrency;

    // TODO: consider separation of publisher from receiver.
    // TODO: consider how that might impact block reusability

    /// <summary>
    /// Responsible for publishing the outcome of a block.
    /// </summary>
    public interface IBlockResultPublisher<in TResult>
    {
        void YieldError(object receiverState, CompositionError error);

        void YieldResult(object receiverState, TResult result);

        void YieldResult(object receiverState, IAwaitable<TResult> result);
    }

    /// <summary>
    /// Responsible for receiving the outcome of a block.
    /// </summary>
    public interface IBlockResultReceiver
    {
        /// <summary>
        /// Creates a publisher that can be used to produce results for this receiver.
        /// </summary>
        /// <typeparam name="TResult">Type associated with the results.</typeparam>
        /// <param name="receiverState">Receives the receiver state.</param>
        /// <returns>A reference to a publisher.</returns>
        IBlockResultPublisher<TResult> CreatePublisher<TResult>(out object receiverState);
    }
}