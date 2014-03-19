// ---------------------------------------------------------------------------------------------------------------------
//  <copyright file="BlockUsage.cs" company="Hedron Interactive">
//      Copyright (c) Hedron Interactive. All rights reserved.
//  </copyright>
// ---------------------------------------------------------------------------------------------------------------------

namespace Hedron.Mako.Usage
{
    using Hedron.Mako;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            IBlock block = default(IBlock);
            IBlockVisitor visitor = null;

            block.Visit(visitor, string.Empty);
        }
    }
}
