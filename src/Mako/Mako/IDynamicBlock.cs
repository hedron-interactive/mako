namespace Mako
{
    /// <summary>
    /// Responsible for promoting efficient dynamic block application.
    /// </summary>
    public interface IDynamicBlock
    {
        /// <summary>
        /// Dynamic function application method. This method does the work associated with this block.
        /// </summary>
        /// <param name="receiver">Receiver used to create a producer.</param>
        /// <param name="inputs">Array of input arguments.</param>
        void DynamicApply(IBlockResultReceiver receiver, params object[] inputs);
    }
}