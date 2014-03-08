// ---------------------------------------------------------------------------------------------------------------------
//  <copyright file="IBlockResultPublisher.cs" company="Hedron Interactive">
//      Copyright (c) Hedron Interactive. All rights reserved.
//  </copyright>
// ---------------------------------------------------------------------------------------------------------------------

namespace Mako
{
    using Mako.Concurrency;

    /// <summary>
    /// Responsible for publishing the outcome of a block.
    /// </summary>
    public interface IBlockResultPublisher<in TResult>
    {
        /// <summary>
        /// Publishes error information.
        /// </summary>
        /// <param name="receiverState">Extrinsic state supplied by the receiver.</param>
        /// <param name="error">Information describing the error.</param>
        /// <remarks>An application developer should not assume control will be returned from this call immediately or ever.</remarks>
        void YieldError(object receiverState, CompositionError error);

        /// <summary>
        /// Publishes a result.
        /// </summary>
        /// <param name="receiverState">Extrinsic state supplied by the receiver.</param>
        /// <param name="result">Result to publish.</param>
        /// <remarks>An application developer should not assume control will be returned from this call immediately or ever.</remarks>
        void YieldResult(object receiverState, TResult result);

        /// <summary>
        /// Publishes a result asynchronously.
        /// </summary>
        /// <param name="receiverState">Extrinsic state supplied by the receiver.</param>
        /// <param name="result">Promise carrying the result to publish.</param>
        /// <remarks>An application developer should not assume control will be returned from this call immediately or ever.</remarks>
        void YieldResult(object receiverState, IAwaitable<TResult> result);
    }
}