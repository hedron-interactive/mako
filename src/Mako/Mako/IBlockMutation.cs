// ---------------------------------------------------------------------------------------------------------------------
//  <copyright file="IBlockMutation.cs" company="Hedron Interactive">
//      Copyright (c) Hedron Interactive. All rights reserved.
//  </copyright>
// ---------------------------------------------------------------------------------------------------------------------

namespace Hedron.Mako
{
    /// <summary>
    /// Represents a mutation operation against a single block. 
    /// </summary>
    /// <remarks>Mutations offer high utility in AOP and decoration scenarios.</remarks>
    public interface IBlockMutation
    {
        /// <summary>
        /// Performs a mutation against an original value and or its clone.
        /// </summary>
        /// <typeparam name="TBlock">Type associated with block.</typeparam>
        /// <param name="original">Original block.</param>
        /// <returns>Returns an instance of the mutated block.</returns>
        TBlock Mutate<TBlock>(TBlock original) where TBlock : IBlock;
    }
}