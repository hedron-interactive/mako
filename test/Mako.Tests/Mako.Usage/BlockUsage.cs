namespace Mako.Usage
{
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
