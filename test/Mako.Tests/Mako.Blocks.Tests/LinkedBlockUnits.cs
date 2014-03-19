// ---------------------------------------------------------------------------------------------------------------------
//  <copyright file="LinkedBlockUnits.cs" company="Hedron Interactive">
//      Copyright (c) Hedron Interactive. All rights reserved.
//  </copyright>
// ---------------------------------------------------------------------------------------------------------------------

namespace Hedron.Mako.Blocks.Tests
{
    using Hedron.Mako;
    using Hedron.Mako.Blocks;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public sealed class LinkedBlockUnits
    {
        [TestMethod, TestCategory("unit"), TestCategory("unit: block")]
        public void UseLinkedBlock()
        {
            Demand.Result(LambdaBlock.Create(() => 1).LinkTo(LambdaBlock.Create((int a) => a + 100)), 101);
            Demand.Result(LambdaBlock.Create((int a) => a).LinkTo(LambdaBlock.Create((int a) => a + 100)), 1, 101);
            Demand.Result(LambdaBlock.Create((int a, int b) => a + b).LinkTo(LambdaBlock.Create((int a) => a + 100)), 1, 1, 102);
            Demand.Result(LambdaBlock.Create((int a, int b, int c) => a + b + c).LinkTo(LambdaBlock.Create((int a) => a + 100)), 1, 1, 2, 104);
        }

        [TestMethod, TestCategory("unit"), TestCategory("unit: block")]
        public void FailLinkedBlock()
        {
            Demand.Failure(LambdaBlock.Create(() => 1).LinkTo(new FailBlock<int, int>()));
            Demand.Failure(LambdaBlock.Create((int a) => a).LinkTo(new FailBlock<int, int>()), 1);
            Demand.Failure(LambdaBlock.Create((int a, int b) => a + b).LinkTo(new FailBlock<int, int>()), 1, 1);
            Demand.Failure(LambdaBlock.Create((int a, int b, int c) => a + b + c).LinkTo(new FailBlock<int, int>()), 1, 1, 2);
        }
    }
}