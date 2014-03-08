using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mako.Blocks.Tests
{
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
