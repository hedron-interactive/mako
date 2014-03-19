// ---------------------------------------------------------------------------------------------------------------------
//  <copyright file="OnErrorBlockResultPublisher.cs" company="Hedron Interactive">
//      Copyright (c) Hedron Interactive. All rights reserved.
//  </copyright>
// ---------------------------------------------------------------------------------------------------------------------

namespace Hedron.Mako.Blocks
{
    using System;
    using global::Mako;

    internal sealed class OnErrorBlockResultPublisher<TResult> : IBlockResultPublisher<TResult>
    {
        public IBlockResultPublisher<TResult> ExternalPublisher;
        public Func<CompositionError, TResult> OnError;

        /// <summary>
        /// Publishes error information.
        /// </summary>
        /// <param name="error">Information describing the error.</param>
        /// <remarks>An application developer should not assume control will be returned from this call immediately or ever.</remarks>
        public void YieldError(CompositionError error)
        {
            this.YieldResult(this.OnError(error));
        }

        /// <summary>
        /// Publishes a result.
        /// </summary>
        /// <param name="result">Result to publish.</param>
        /// <remarks>An application developer should not assume control will be returned from this call immediately or ever.</remarks>
        public void YieldResult(TResult result)
        {
            this.ExternalPublisher.YieldResult(result);
        }
    }
}