// ---------------------------------------------------------------------------------------------------------------------
//  <copyright file="FailBlock.cs" company="Hedron Interactive">
//      Copyright (c) Hedron Interactive. All rights reserved.
//  </copyright>
// ---------------------------------------------------------------------------------------------------------------------

namespace Mako
{
    using System;
    using System.Threading.Tasks;

    public abstract class FailBlock : IBlock
    {
        private readonly TimeSpan asyncDelay;

        protected FailBlock(TimeSpan asyncDelay)
        {
            this.asyncDelay = asyncDelay;
        }

        void IBlock.Accept(IBlockVisitor visitor)
        {
        }

        IBlock IBlock.Mutate(IBlockMutation mutation)
        {
            return mutation.Mutate(this);
        }

        protected void Fail<TResult>(IBlockResultPublisher<TResult> publisher)
        {
            if (this.asyncDelay <= TimeSpan.Zero)
            {
                publisher.YieldError(CompositionError.Unknown);
            }
            else
            {
                Task.Delay(this.asyncDelay)
                    .ContinueWith(a => publisher.YieldError(CompositionError.Unknown));
            }
        }
    }

    public sealed class FailBlock<TResult> : FailBlock, IBlock<TResult>
    {
        public FailBlock()
            : this(TimeSpan.Zero)
        {
        }
        
        public FailBlock(TimeSpan asyncDelay)
            : base(asyncDelay)
        {
        }

        public void Apply(IBlockResultPublisher<TResult> publisher)
        {
            this.Fail(publisher);
        }
    }

    public sealed class FailBlock<T1, TResult> : FailBlock, IBlock<T1, TResult>
    {
        public FailBlock()
            : this(TimeSpan.Zero)
        {
        }
        
        public FailBlock(TimeSpan asyncDelay)
            : base(asyncDelay)
        {
        }

        public void Apply(IBlockResultPublisher<TResult> publisher, T1 input1)
        {
            this.Fail(publisher);
        }
    }

    public sealed class FailBlock<T1, T2, TResult> : FailBlock, IBlock<T1, T2, TResult>
    {
        public FailBlock()
            : this(TimeSpan.Zero)
        {
        }

        public FailBlock(TimeSpan asyncDelay)
            : base(asyncDelay)
        {
        }

        public void Apply(IBlockResultPublisher<TResult> publisher, T1 input1, T2 input2)
        {
            this.Fail(publisher);
        }
    }

    public sealed class FailBlock<T1, T2, T3, TResult> : FailBlock, IBlock<T1, T2, T3, TResult>
    {
        public FailBlock()
            : this(TimeSpan.Zero)
        {
        }

        public FailBlock(TimeSpan asyncDelay)
            : base(asyncDelay)
        {
        }

        public void Apply(IBlockResultPublisher<TResult> publisher, T1 input1, T2 input2, T3 input3)
        {
            this.Fail(publisher);
        }
    }
}