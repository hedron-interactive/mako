namespace Mako.Blocks
{
    using System;

    public sealed class LinkBlock<TAntecedentResult, TResult> : Block<TResult>
    {
        private readonly IBlock<TAntecedentResult> antecedent;
        private readonly IBlock<TAntecedentResult, TResult> consequent;

        public LinkBlock(IBlock<TAntecedentResult> antecedent, IBlock<TAntecedentResult, TResult> consequent)
        {
            if (null == antecedent)
            {
                throw new ArgumentNullException("antecedent");
            }

            if (null == consequent)
            {
                throw new ArgumentNullException("consequent");
            }

            this.antecedent = antecedent;
            this.consequent = consequent;
        }

        public override void Apply(IBlockResultPublisher<TResult> publisher, object receiverState)
        {
            if (null == publisher)
            {
                throw new ArgumentNullException("publisher");
            }

            var innerPublisher = new LinkBlockResultPublisher<TResult, TAntecedentResult>
            {
                ExternalPublisher = publisher,
                Consequent = this.consequent
            };

            this.antecedent.Apply(innerPublisher, receiverState);
        }
    }

    public sealed class LinkBlock<T1, TAntecedentResult, TResult> : Block<T1, TResult>
    {
        private readonly IBlock<T1, TAntecedentResult> antecedent;
        private readonly IBlock<TAntecedentResult, TResult> consequent;

        public LinkBlock(IBlock<T1, TAntecedentResult> antecedent, IBlock<TAntecedentResult, TResult> consequent)
        {
            if (null == antecedent)
            {
                throw new ArgumentNullException("antecedent");
            }

            if (null == consequent)
            {
                throw new ArgumentNullException("consequent");
            }

            this.antecedent = antecedent;
            this.consequent = consequent;
        }

        public override void Apply(IBlockResultPublisher<TResult> publisher, object receiverState, T1 input1)
        {
            if (null == publisher)
            {
                throw new ArgumentNullException("publisher");
            }

            var innerPublisher = new LinkBlockResultPublisher<TResult, TAntecedentResult>
            {
                ExternalPublisher = publisher,
                Consequent = this.consequent
            };

            this.antecedent.Apply(innerPublisher, receiverState, input1);
        }
    }

    public sealed class LinkBlock<T1, T2, TAntecedentResult, TResult> : Block<T1, T2, TResult>
    {
        private readonly IBlock<T1, T2, TAntecedentResult> antecedent;
        private readonly IBlock<TAntecedentResult, TResult> consequent;

        public LinkBlock(IBlock<T1, T2, TAntecedentResult> antecedent, IBlock<TAntecedentResult, TResult> consequent)
        {
            if (null == antecedent)
            {
                throw new ArgumentNullException("antecedent");
            }

            if (null == consequent)
            {
                throw new ArgumentNullException("consequent");
            }

            this.antecedent = antecedent;
            this.consequent = consequent;
        }

        public override void Apply(IBlockResultPublisher<TResult> publisher, object receiverState, T1 input1, T2 input2)
        {
            if (null == publisher)
            {
                throw new ArgumentNullException("publisher");
            }

            var innerPublisher = new LinkBlockResultPublisher<TResult, TAntecedentResult>
            {
                ExternalPublisher = publisher,
                Consequent = this.consequent
            };

            this.antecedent.Apply(innerPublisher, receiverState, input1, input2);
        }
    }

    public sealed class LinkBlock<T1, T2, T3, TAntecedentResult, TResult> : Block<T1, T2, T3, TResult>
    {
        private readonly IBlock<T1, T2, T3, TAntecedentResult> antecedent;
        private readonly IBlock<TAntecedentResult, TResult> consequent;

        public LinkBlock(IBlock<T1, T2, T3, TAntecedentResult> antecedent, IBlock<TAntecedentResult, TResult> consequent)
        {
            if (null == antecedent)
            {
                throw new ArgumentNullException("antecedent");
            }

            if (null == consequent)
            {
                throw new ArgumentNullException("consequent");
            }

            this.antecedent = antecedent;
            this.consequent = consequent;
        }

        public override void Apply(IBlockResultPublisher<TResult> publisher, object receiverState, T1 input1, T2 input2, T3 input3)
        {
            if (null == publisher)
            {
                throw new ArgumentNullException("publisher");
            }

            var innerPublisher = new LinkBlockResultPublisher<TResult, TAntecedentResult>
            {
                ExternalPublisher = publisher,
                Consequent = this.consequent
            };

            this.antecedent.Apply(innerPublisher, receiverState, input1, input2, input3);
        }
    }
}