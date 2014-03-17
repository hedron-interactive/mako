namespace Mako.Blocks.Attributes
{
    public static class BlockAttributeExtensions
    {
        public static bool IsSynchronousBlock(IBlock block)
        {
            return false;
        }

        public static bool IsSynchronousComposition(IBlock block)
        {
            return false;
        }
    }
}