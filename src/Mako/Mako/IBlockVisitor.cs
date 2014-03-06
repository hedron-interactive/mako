// ---------------------------------------------------------------------------------------------------------------------
//  <copyright file="IBlockVisitor.cs" company="Hedron Interactive">
//      Copyright (c) Hedron Interactive. All rights reserved.
//  </copyright>
// ---------------------------------------------------------------------------------------------------------------------

namespace Mako
{
    /// <summary>
    /// Represents an operation to be performed against a composite block structure.
    /// </summary>
    public interface IBlockVisitor
    {
        /// <summary>
        /// Performs an operation against the specified block. 
        /// </summary>
        /// <typeparam name="TBlock">Interface type specification.</typeparam>
        /// <param name="block">Instance of block.</param>
        /// <param name="tag">Tag associated with block.</param>
        /// <remarks>Visitor implementations should save a reference to this block and mark it as current.</remarks>
        void Block<TBlock>(TBlock block, string tag) where TBlock : IBlock;

        /// <summary>
        /// Indicates the start of a composite block. This composition pertains to the
        /// block specified by the previous Block call.
        /// </summary>
        /// <remarks>
        /// Until EndComposite is called, subsequent calls to Block are to be considered children
        /// of the current composite. Composition is recursive.
        /// </remarks>
        void StartComposite();

        /// <summary>
        /// Indicates the end of a composite block.
        /// </summary>
        void EndComposite();

        /// <summary>
        /// Indicates the linkage between two blocks within a composition; note that source
        /// or target may refer to the composite block.
        /// </summary>
        /// <param name="source">Antecedent block whose output is feed into the target block.</param>
        /// <param name="target">Receipient of <paramref name="source"/> block output.</param>
        /// <param name="linkage">Provide linkage information; i.e. specifying the input argument.</param>
        void LinkBlocks(IBlock source, IBlock target, BlockLinkage linkage);
    }
}