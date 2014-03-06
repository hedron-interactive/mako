// ---------------------------------------------------------------------------------------------------------------------
//  <copyright file="Block.cs" company="Hedron Interactive">
//      Copyright (c) Hedron Interactive. All rights reserved.
//  </copyright>
// ---------------------------------------------------------------------------------------------------------------------

namespace Mako
{
    using System;

    /// <summary>
    /// Responsible for producing a single output from n-ary input in a composable manor.
    /// </summary>
    public abstract class Block : IBlock, IDynamicBlock
    {
        /// <summary>
        /// Accepts the specified visitor. The visitor is applied to each block in the composite structure.
        /// </summary>
        /// <param name="visitor">Performs operations on the visited blocks.</param>
        /// <returns>A reference to this block.</returns>
        public void Accept(IBlockVisitor visitor)
        {
            if (null == visitor)
            {
                throw new ArgumentNullException("visitor");
            }
        }

        /// <summary>
        /// Produces a mutated version of this block.
        /// </summary>
        /// <param name="mutation">Interface associated with driving the mutation.</param>
        /// <returns>A reference to a mutated version of this block.</returns>
        public IBlock Mutate(IBlockMutation mutation)
        {
            if (null == mutation)
            {
                throw new ArgumentNullException("mutation");
            }

            return mutation.Mutate(this);
        }

        /// <summary>
        /// Dynamic function application method. This method does the work associated with this block.
        /// </summary>
        /// <param name="receiver">Receiver used to create a producer.</param>
        /// <param name="inputs">Array of input arguments.</param>
        public abstract void DynamicApply(IBlockResultReceiver receiver, params object[] inputs);
    }

    /// <summary>
    /// Responsible for producing a single output from 0-ary input (a generator).
    /// </summary>
    /// <typeparam name="TResult">Type associated with output</typeparam>
    public abstract class Block<TResult> : Block, IBlock<TResult>
    {
        /// <summary>
        /// Function application method. This method does the work associated with this block.
        /// </summary>
        /// <param name="publisher">Used to publish the blocks result.</param>
        /// <param name="receiverState">Capture extrinsic state used by the receiver.</param>
        public abstract void Apply(IBlockResultPublisher<TResult> publisher, object receiverState);

        /// <summary>
        /// Dynamic function application method. This method does the work associated with this block.
        /// </summary>
        /// <param name="receiver">Receiver used to create a producer.</param>
        /// <param name="inputs">Array of input arguments.</param>
        public override void DynamicApply(IBlockResultReceiver receiver, params object[] inputs)
        {
            if (null == receiver)
            {
                throw new ArgumentNullException("receiver");
            }

            if (null != inputs && inputs.Length != 0)
            {
                throw new ArgumentException("Invalid number of inputs: 0 expected", "inputs");
            }

            object receiverState;
            this.Apply(receiver.CreatePublisher<TResult>(out receiverState), receiverState);
        }
    }

    /// <summary>
    /// Responsible for producing a single output from 1-ary input.
    /// </summary>
    /// <typeparam name="TResult">Type associated with output</typeparam>
    /// <typeparam name="T1">Type of the first input.</typeparam>
    public abstract class Block<T1, TResult> : Block, IBlock<T1, TResult>
    {
        /// <summary>
        /// Function application method. This method does the work associated with this block.
        /// </summary>
        /// <param name="publisher">Used to publish the blocks result.</param>
        /// <param name="receiverState">Capture extrinsic state used by the receiver.</param>
        /// <param name="input1">First input parameter.</param>
        public abstract void Apply(IBlockResultPublisher<TResult> publisher, object receiverState, T1 input1);

        /// <summary>
        /// Dynamic function application method. This method does the work associated with this block.
        /// </summary>
        /// <param name="receiver">Receiver used to create a producer.</param>
        /// <param name="inputs">Array of input arguments.</param>
        public override void DynamicApply(IBlockResultReceiver receiver, params object[] inputs)
        {
            if (null == receiver)
            {
                throw new ArgumentNullException("receiver");
            }

            if (null == inputs || inputs.Length != 1)
            {
                throw new ArgumentException("Invalid number of inputs: 0 expected", "inputs");
            }

            object receiverState;
            this.Apply(receiver.CreatePublisher<TResult>(out receiverState), receiverState, (T1)inputs[0]);
        }
    }

    /// <summary>
    /// Responsible for producing a single output from 2-ary input.
    /// </summary>
    /// <typeparam name="TResult">Type associated with output</typeparam>
    /// <typeparam name="T1">Type of the first input.</typeparam>
    /// <typeparam name="T2">Type of the second input.</typeparam>
    public abstract class Block<T1, T2, TResult> : Block, IBlock<T1, T2, TResult>
    {
        /// <summary>
        /// Function application method. This method does the work associated with this block.
        /// </summary>
        /// <param name="publisher">Used to publish the blocks result.</param>
        /// <param name="receiverState">Capture extrinsic state used by the receiver.</param>
        /// <param name="input1">First input parameter.</param>
        /// <param name="input2">Second input parameter.</param>
        public abstract void Apply(IBlockResultPublisher<TResult> publisher, object receiverState, T1 input1, T2 input2);

        /// <summary>
        /// Dynamic function application method. This method does the work associated with this block.
        /// </summary>
        /// <param name="receiver">Receiver used to create a producer.</param>
        /// <param name="inputs">Array of input arguments.</param>
        public override void DynamicApply(IBlockResultReceiver receiver, params object[] inputs)
        {
            if (null == receiver)
            {
                throw new ArgumentNullException("receiver");
            }

            if (null == inputs || inputs.Length != 2)
            {
                throw new ArgumentException("Invalid number of inputs: 0 expected", "inputs");
            }

            object receiverState;
            this.Apply(receiver.CreatePublisher<TResult>(out receiverState), receiverState, (T1)inputs[0], (T2)inputs[1]);
        }
    }

    /// <summary>
    /// Responsible for producing a single output from 3-ary input.
    /// </summary>
    /// <typeparam name="TResult">Type associated with output</typeparam>
    /// <typeparam name="T1">Type of the first input.</typeparam>
    /// <typeparam name="T2">Type of the second input.</typeparam>
    /// <typeparam name="T3">Type of the third input.</typeparam>
    public abstract class Block<T1, T2, T3, TResult> : Block, IBlock<T1, T2, T3, TResult>
    {
        /// <summary>
        /// Function application method. This method does the work associated with this block.
        /// </summary>
        /// <param name="publisher">Used to publish the blocks result.</param>
        /// <param name="receiverState">Capture extrinsic state used by the receiver.</param>
        /// <param name="input1">First input parameter.</param>
        /// <param name="input2">Second input parameter.</param>
        /// <param name="input3">Third input parameter.</param>
        public abstract void Apply(IBlockResultPublisher<TResult> publisher, object receiverState, T1 input1, T2 input2, T3 input3);

        /// <summary>
        /// Dynamic function application method. This method does the work associated with this block.
        /// </summary>
        /// <param name="receiver">Receiver used to create a producer.</param>
        /// <param name="inputs">Array of input arguments.</param>
        public override void DynamicApply(IBlockResultReceiver receiver, params object[] inputs)
        {
            if (null == receiver)
            {
                throw new ArgumentNullException("receiver");
            }

            if (null == inputs || inputs.Length != 3)
            {
                throw new ArgumentException("Invalid number of inputs: 0 expected", "inputs");
            }

            object receiverState;
            this.Apply(receiver.CreatePublisher<TResult>(out receiverState), receiverState, (T1)inputs[0], (T2)inputs[1], (T3)inputs[2]);
        }
    }
}