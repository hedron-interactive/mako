// ---------------------------------------------------------------------------------------------------------------------
//  <copyright file="IdentityBlock.cs" company="Hedron Interactive">
//      Copyright (c) Hedron Interactive. All rights reserved.
//  </copyright>
// ---------------------------------------------------------------------------------------------------------------------

namespace Mako.Blocks
{
    using System;

    /// <summary>
    /// This block synchronously outputs the value that was supplied to it.
    /// </summary>
    /// <typeparam name="TResult">Type associated with input and output.</typeparam>
    public sealed class IdentityBlock<TResult> : Block<TResult, TResult>
    {
        /// <summary>
        /// Function application method. This method does the work associated with this block.
        /// </summary>
        /// <param name="publisher">Used to publish the blocks result.</param>
        /// <param name="input1">First input parameter.</param>
        public override void Apply(IBlockResultPublisher<TResult> publisher, TResult input1)
        {
            if (null == publisher)
            {
                throw new ArgumentNullException("publisher");
            }

            publisher.YieldResult(input1);
        }
    }
}