namespace Mako.Blocks
{
    using System;

    public static class MapReduceBlock
    {
        public static MapReduceBlock<T1, TMapResult, TReduceResult> Create<T1, TMapResult, TReduceResult>(IBlock<T1, int, TMapResult> mapper, IBlock<TMapResult[], TReduceResult> reducer, Func<T1, int> mapNodeSizeSelector)
        {
            return new MapReduceBlock<T1, TMapResult, TReduceResult>(mapper, reducer, mapNodeSizeSelector);   
        }

        public static MapReduceBlock<T1, TMapResult, TReduceResult> Create<T1, TMapResult, TReduceResult>(IBlock<T1, int, TMapResult> mapper, IBlock<TMapResult[], TReduceResult> reducer, int staticMapNodeSize)
        {
            return new MapReduceBlock<T1, TMapResult, TReduceResult>(mapper, reducer, t => staticMapNodeSize);
        }

        internal static void AcceptVisitor<TMapperBlock, TReducerBlock>(TMapperBlock mapperBlock, TReducerBlock reducerBlock, IBlockVisitor visitor)
            where TMapperBlock : IBlock
            where TReducerBlock : IBlock
        {
            visitor.StartComposite();

            visitor.Block(mapperBlock, "mapper");
            mapperBlock.Accept(visitor);

            visitor.Block(reducerBlock, "reducer");
            reducerBlock.Accept(visitor);

            visitor.EndComposite();
        }
    }

    public sealed class MapReduceBlock<T1, TMapResult, TReduceResult> : Block<T1, TReduceResult>
    {
        private static readonly TMapResult[] EmptyResults = new TMapResult[0];

        private readonly IBlock<T1, int, TMapResult> mapper;
        private readonly IBlock<TMapResult[], TReduceResult> reducer;
        private readonly Func<T1, int> mapNodeSizeSelector;

        public MapReduceBlock(IBlock<T1, int, TMapResult> mapper, IBlock<TMapResult[], TReduceResult> reducer, Func<T1, int> mapNodeSizeSelector)
        {
            if (null == mapper)
            {
                throw new ArgumentNullException("mapper");
            }

            if (null == reducer)
            {
                throw new ArgumentNullException("reducer");
            }

            if (null == mapNodeSizeSelector)
            {
                throw new ArgumentNullException("mapNodeSizeSelector");
            }

            this.mapper = mapper;
            this.reducer = reducer;
            this.mapNodeSizeSelector = mapNodeSizeSelector;
        }

        /// <summary>
        /// Accepts the specified visitor. The visitor is applied to each block in the composite structure.
        /// </summary>
        /// <param name="visitor">Performs operations on the visited blocks.</param>
        /// <returns>A reference to this block.</returns>
        public override void Accept(IBlockVisitor visitor)
        {
            base.Accept(visitor);

            MapReduceBlock.AcceptVisitor(this.mapper, this.reducer, visitor);
        }

        /// <summary>
        /// Function application method. This method does the work associated with this block.
        /// </summary>
        /// <param name="publisher">Used to publish the blocks result.</param>
        /// <param name="input1">First input parameter.</param>
        public override void Apply(IBlockResultPublisher<TReduceResult> publisher, T1 input1)
        {
            var size = this.mapNodeSizeSelector(input1);

            if (size <= 0)
            {
                this.reducer.Apply(publisher, EmptyResults);
            }
            else
            {
                var mapPublisher = new MapReduceResultPublisher<TMapResult, TReduceResult>
                {
                    ExternalPublisher = publisher,
                    Reducer = this.reducer
                }
                .Reset(new TMapResult[size]);

                for (var c = 0; c < size; c++)
                {
                    this.mapper.Apply(mapPublisher, input1, c);
                }
            }
        }
    }

    public sealed class MapReduceBlock<T1, T2, TMapResult, TReduceResult> : Block<T1, T2, TReduceResult>
    {
        private static readonly TMapResult[] EmptyResults = new TMapResult[0];

        private readonly IBlock<T1, T2, int, TMapResult> mapper;
        private readonly IBlock<TMapResult[], TReduceResult> reducer;
        private readonly Func<T1, T2, int> mapNodeSizeSelector;

        public MapReduceBlock(IBlock<T1, T2, int, TMapResult> mapper, IBlock<TMapResult[], TReduceResult> reducer, Func<T1, T2, int> mapNodeSizeSelector)
        {
            if (null == mapper)
            {
                throw new ArgumentNullException("mapper");
            }

            if (null == reducer)
            {
                throw new ArgumentNullException("reducer");
            }

            if (null == mapNodeSizeSelector)
            {
                throw new ArgumentNullException("mapNodeSizeSelector");
            }

            this.mapper = mapper;
            this.reducer = reducer;
            this.mapNodeSizeSelector = mapNodeSizeSelector;
        }

        /// <summary>
        /// Accepts the specified visitor. The visitor is applied to each block in the composite structure.
        /// </summary>
        /// <param name="visitor">Performs operations on the visited blocks.</param>
        /// <returns>A reference to this block.</returns>
        public override void Accept(IBlockVisitor visitor)
        {
            base.Accept(visitor);

            MapReduceBlock.AcceptVisitor(this.mapper, this.reducer, visitor);
        }

        /// <summary>
        /// Function application method. This method does the work associated with this block.
        /// </summary>
        /// <param name="publisher">Used to publish the blocks result.</param>
        /// <param name="input1">First input parameter.</param>
        /// <param name="input2">Second input parameter.</param>
        public override void Apply(IBlockResultPublisher<TReduceResult> publisher, T1 input1, T2 input2)
        {
            var size = this.mapNodeSizeSelector(input1, input2);

            if (size <= 0)
            {
                this.reducer.Apply(publisher, EmptyResults);
            }
            else
            {
                var mapPublisher = new MapReduceResultPublisher<TMapResult, TReduceResult>
                {
                    ExternalPublisher = publisher,
                    Reducer = this.reducer
                }
                .Reset(new TMapResult[size]);

                for (var c = 0; c < size; c++)
                {
                    this.mapper.Apply(mapPublisher, input1, input2, c);
                }
            }
        }
    }
}
