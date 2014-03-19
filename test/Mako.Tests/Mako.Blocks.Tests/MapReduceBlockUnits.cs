// ---------------------------------------------------------------------------------------------------------------------
//  <copyright file="MapReduceBlockUnits.cs" company="Hedron Interactive">
//      Copyright (c) Hedron Interactive. All rights reserved.
//  </copyright>
// ---------------------------------------------------------------------------------------------------------------------

namespace Hedron.Mako.Blocks.Tests
{
    using System.Linq;
    using global::Mako.Blocks;
    using Hedron.Mako;
    using Hedron.Mako.Blocks;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public sealed class MapReduceBlockUnits
    {
        [TestMethod, TestCategory("unit"), TestCategory("unit: block")]
        public void MapReduceBlockSupportsBasicUsage()
        {
            var block = MapReduceBlock.Create(
                LambdaBlock.Create((int[][] input, int partition) => input[partition].Sum()),
                LambdaBlock.Create((int[] input) => input.Sum()),
                input => input.Length);

            Demand.Result(block, new int[0][], 0);
            Demand.Result(block, new[] { new[] { 0, 1, 2}, new [] { 2, 4, 6} }, 15);
        }

        [TestMethod, TestCategory("unit"), TestCategory("unit: block")]
        public void MapReduceSurfacesMapperFailure()
        {
            var block = MapReduceBlock.Create(
                new FailBlock<int[][], int, int>(),
                LambdaBlock.Create((int[] input) => input.Sum()),
                input => input.Length);

            Demand.Result(block, new int[0][], 0);
            Demand.Failure(block, new[] { new[] { 1 } });
            Demand.Failure(block, new[] { new[] { 1 }, new[] { 1 } });
        }

        [TestMethod, TestCategory("unit"), TestCategory("unit: block")]
        public void MapReduceSurfacesReducerFailure()
        {
            var block = MapReduceBlock.Create(
                LambdaBlock.Create((int[][] input, int partition) => input[partition].Sum()),
                new FailBlock<int[], int>(),
                input => input.Length);

            Demand.Failure(block, new int[0][]);
            Demand.Failure(block, new[] { new[] { 1 } });
            Demand.Failure(block, new[] { new[] { 1 }, new[] { 1 } });
        }
    }
}
