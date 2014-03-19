// ---------------------------------------------------------------------------------------------------------------------
//  <copyright file="IBlock.cs" company="Hedron Interactive">
//      Copyright (c) Hedron Interactive. All rights reserved.
//  </copyright>
// ---------------------------------------------------------------------------------------------------------------------

namespace Hedron.Mako
{
    /// <summary>
    /// Responsible for producing a single output from n-ary input in a composable manor.
    /// </summary>
    public interface IBlock
    {
        /// <summary>
        /// Accepts the specified visitor. The visitor is applied to each block in the composite structure.
        /// </summary>
        /// <param name="visitor">Performs operations on the visited blocks.</param>
        void Accept(IBlockVisitor visitor);
        
        /// <summary>
        /// Produces a mutated version of this block.
        /// </summary>
        /// <param name="mutation">Interface associated with driving the mutation.</param>
        /// <returns>A reference to a mutated version of this block.</returns>
        IBlock Mutate(IBlockMutation mutation);
    }

    /// <summary>
    /// Responsible for producing a single output from 0-ary input (a generator).
    /// </summary>
    /// <typeparam name="TResult">Type associated with output</typeparam>
    public interface IBlock<out TResult> : IBlock
    {
        /// <summary>
        /// Function application method. This method does the work associated with this block.
        /// </summary>
        /// <param name="publisher">Used to publish the blocks result.</param>
        void Apply(IBlockResultPublisher<TResult> publisher);
    }

    /// <summary>
    /// Responsible for producing a single output from 1-ary input.
    /// </summary>
    /// <typeparam name="TResult">Type associated with output</typeparam>
    /// <typeparam name="T1">Type of the first input.</typeparam>
    public interface IBlock<in T1, out TResult> : IBlock
    {
        /// <summary>
        /// Function application method. This method does the work associated with this block.
        /// </summary>
        /// <param name="publisher">Used to publish the blocks result.</param>
        /// <param name="input1">First input parameter.</param>
        void Apply(IBlockResultPublisher<TResult> publisher, T1 input1);
    }

    /// <summary>
    /// Responsible for producing a single output from 2-ary input.
    /// </summary>
    /// <typeparam name="TResult">Type associated with output</typeparam>
    /// <typeparam name="T1">Type of the first input.</typeparam>
    /// <typeparam name="T2">Type of the second input.</typeparam>
    public interface IBlock<in T1, in T2, out TResult> : IBlock
    {
        /// <summary>
        /// Function application method. This method does the work associated with this block.
        /// </summary>
        /// <param name="publisher">Used to publish the blocks result.</param>
        /// <param name="input1">First input parameter.</param>
        /// <param name="input2">Second input parameter.</param>
        void Apply(IBlockResultPublisher<TResult> publisher, T1 input1, T2 input2);
    }

    /// <summary>
    /// Responsible for producing a single output from 3-ary input.
    /// </summary>
    /// <typeparam name="TResult">Type associated with output</typeparam>
    /// <typeparam name="T1">Type of the first input.</typeparam>
    /// <typeparam name="T2">Type of the second input.</typeparam>
    /// <typeparam name="T3">Type of the third input.</typeparam>
    public interface IBlock<in T1, in T2, in T3, out TResult> : IBlock
    {
        /// <summary>
        /// Function application method. This method does the work associated with this block.
        /// </summary>
        /// <param name="publisher">Used to publish the blocks result.</param>
        /// <param name="input1">First input parameter.</param>
        /// <param name="input2">Second input parameter.</param>
        /// <param name="input3">Third input parameter.</param>
        void Apply(IBlockResultPublisher<TResult> publisher, T1 input1, T2 input2, T3 input3);
    }
}