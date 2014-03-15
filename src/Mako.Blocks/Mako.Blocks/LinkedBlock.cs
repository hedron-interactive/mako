namespace Mako.Blocks
{
    using System;

    public static class LinkedBlock
    {
        public static IBlock<TResult> LinkTo<TAntecedentResult, TResult>(this IBlock<TAntecedentResult> antecedent, IBlock<TAntecedentResult, TResult> consequent)
        {
            return new LinkedBlock<TAntecedentResult, TResult>(antecedent, consequent);
        }

        public static IBlock<T1, TResult> LinkTo<T1, TAntecedentResult, TResult>(this IBlock<T1, TAntecedentResult> antecedent, IBlock<TAntecedentResult, TResult> consequent)
        {
            return new LinkedBlock<T1, TAntecedentResult, TResult>(antecedent, consequent);
        }

        public static IBlock<T1, T2, TResult> LinkTo<T1, T2, TAntecedentResult, TResult>(this IBlock<T1, T2, TAntecedentResult> antecedent, IBlock<TAntecedentResult, TResult> consequent)
        {
            return new LinkedBlock<T1, T2, TAntecedentResult, TResult>(antecedent, consequent);
        }

        public static IBlock<T1, T2, T3, TResult> LinkTo<T1, T2, T3, TAntecedentResult, TResult>(this IBlock<T1, T2, T3, TAntecedentResult> antecedent, IBlock<TAntecedentResult, TResult> consequent)
        {
            return new LinkedBlock<T1, T2, T3, TAntecedentResult, TResult>(antecedent, consequent);
        }
    }

    public sealed class LinkedBlock<TAntecedentResult, TResult> : Block<TResult>
    {
        private readonly IBlock<TAntecedentResult> antecedent;
        private readonly IBlock<TAntecedentResult, TResult> consequent;

        public LinkedBlock(IBlock<TAntecedentResult> antecedent, IBlock<TAntecedentResult, TResult> consequent)
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

        public override void Apply(IBlockResultPublisher<TResult> publisher)
        {
            if (null == publisher)
            {
                throw new ArgumentNullException("publisher");
            }

            var innerPublisher = new LinkedBlockResultPublisher<TResult, TAntecedentResult>
            {
                ExternalPublisher = publisher,
                Consequent = this.consequent
            };

            this.antecedent.Apply(innerPublisher);
        }
    }

    public sealed class LinkedBlock<T1, TAntecedentResult, TResult> : Block<T1, TResult>
    {
        private readonly IBlock<T1, TAntecedentResult> antecedent;
        private readonly IBlock<TAntecedentResult, TResult> consequent;

        public LinkedBlock(IBlock<T1, TAntecedentResult> antecedent, IBlock<TAntecedentResult, TResult> consequent)
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

        public override void Apply(IBlockResultPublisher<TResult> publisher, T1 input1)
        {
            if (null == publisher)
            {
                throw new ArgumentNullException("publisher");
            }

            var innerPublisher = new LinkedBlockResultPublisher<TResult, TAntecedentResult>
            {
                ExternalPublisher = publisher,
                Consequent = this.consequent
            };

            this.antecedent.Apply(innerPublisher, input1);
        }
    }

    public sealed class LinkedBlock<T1, T2, TAntecedentResult, TResult> : Block<T1, T2, TResult>
    {
        private readonly IBlock<T1, T2, TAntecedentResult> antecedent;
        private readonly IBlock<TAntecedentResult, TResult> consequent;

        public LinkedBlock(IBlock<T1, T2, TAntecedentResult> antecedent, IBlock<TAntecedentResult, TResult> consequent)
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

        public override void Apply(IBlockResultPublisher<TResult> publisher, T1 input1, T2 input2)
        {
            if (null == publisher)
            {
                throw new ArgumentNullException("publisher");
            }

            var innerPublisher = new LinkedBlockResultPublisher<TResult, TAntecedentResult>
            {
                ExternalPublisher = publisher,
                Consequent = this.consequent
            };

            this.antecedent.Apply(innerPublisher, input1, input2);
        }
    }

    public sealed class LinkedBlock<T1, T2, T3, TAntecedentResult, TResult> : Block<T1, T2, T3, TResult>
    {
        private readonly IBlock<T1, T2, T3, TAntecedentResult> antecedent;
        private readonly IBlock<TAntecedentResult, TResult> consequent;

        public LinkedBlock(IBlock<T1, T2, T3, TAntecedentResult> antecedent, IBlock<TAntecedentResult, TResult> consequent)
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

        public override void Apply(IBlockResultPublisher<TResult> publisher, T1 input1, T2 input2, T3 input3)
        {
            if (null == publisher)
            {
                throw new ArgumentNullException("publisher");
            }

            var innerPublisher = new LinkedBlockResultPublisher<TResult, TAntecedentResult>
            {
                ExternalPublisher = publisher,
                Consequent = this.consequent
            };

            this.antecedent.Apply(innerPublisher, input1, input2, input3);
        }
    }
}