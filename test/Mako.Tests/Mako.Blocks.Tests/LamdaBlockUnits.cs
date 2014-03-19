// ---------------------------------------------------------------------------------------------------------------------
//  <copyright file="LamdaBlockUnits.cs" company="Hedron Interactive">
//      Copyright (c) Hedron Interactive. All rights reserved.
//  </copyright>
// ---------------------------------------------------------------------------------------------------------------------

namespace Hedron.Mako.Blocks.Tests
{
    using Hedron.Mako;
    using Hedron.Mako.Blocks;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public sealed class LamdaBlockUnits
    {
        [TestMethod, TestCategory("unit"), TestCategory("unit: block")]
        public void UseLambdaBlock()
        {
            Demand.Result(LambdaBlock.Create(() => 1), 1);
            Demand.Result(LambdaBlock.Create((int a) => a), 1, 1);
            Demand.Result(LambdaBlock.Create((int a, int b) => a + b), 1, 1, 2);
            Demand.Result(LambdaBlock.Create((int a, int b, int c) => a + b + c), 1, 1, 2, 4);
        }
    }
}
