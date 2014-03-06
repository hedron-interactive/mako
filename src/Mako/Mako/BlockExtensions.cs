// ---------------------------------------------------------------------------------------------------------------------
//  <copyright file="BlockExtensions.cs" company="Hedron Interactive">
//      Copyright (c) Hedron Interactive. All rights reserved.
//  </copyright>
// ---------------------------------------------------------------------------------------------------------------------

namespace Mako
{
    using System;
    using System.Linq;
    using System.Reflection;

    public static class BlockExtensions
    {
        private static readonly Type[] BlockGenericInterfaces = new Type[] { typeof(IBlock<>), typeof(IBlock<,>), typeof(IBlock<,,>), typeof(IBlock<,,,>) };
        private static readonly object[] EmptyArguments = new object[0];

        #region Dynamic Dispatch Related

        public static TBlock Apply<TBlock>(this TBlock block, IBlockResultReceiver receiver, params object[] arguments)
            where TBlock : IBlock
        {
            if (object.ReferenceEquals(null, block))
            {
                throw new ArgumentNullException("block");
            }

            var dynamicBlock = block as IDynamicBlock;

            if (null != dynamicBlock)
            {
                dynamicBlock.DynamicApply(receiver, arguments);
            }
            else
            {
                throw new NotSupportedException("Support for reflection based dynamic dispatch is coming soon.");
            }

            return block;
        }

        public static MethodInfo GetBlockInterfaceMethod(IBlock block, params object[] arguments)
        {
            if (null == block)
            {
                throw new ArgumentNullException("block");
            }

            if ((arguments = arguments ?? EmptyArguments).Length >= BlockGenericInterfaces.Length)
            {
                throw new ArgumentOutOfRangeException("arguments", "too many arguments specified.");
            }

            var generic = BlockGenericInterfaces[arguments.Length];

            var candidates = block.GetType().GetTypeInfo().ImplementedInterfaces
                .Where(t => t.IsConstructedGenericType && t.GetGenericTypeDefinition() == generic);

            // Generally candidates will contain exactly one element
            foreach (var candidate in candidates)
            {
                // DynamicApply method is present
                var method = candidate.GetTypeInfo().GetDeclaredMethod("DynamicApply");
                var parameters = method.GetParameters();

                // DynamicApply parameter arity is larger by 1 due to the IBlockPublisherResult<> parameter.
                for (var c = 0; c < arguments.Length; c++)
                {
                    var paramTypeInfo = parameters[c + 1].GetType().GetTypeInfo();
                    var argTypeInfo = arguments[c] != null ? arguments[c].GetType().GetTypeInfo() : null;

                    if ((argTypeInfo == null && paramTypeInfo.IsValueType) || !paramTypeInfo.IsAssignableFrom(argTypeInfo))
                    {
                        method = null;
                        break;
                    }

                    // Generally only a single result will exist, though technically it is possible for multiple.
                    // TODO: address the corner case
                    if (null != method)
                    {
                        return method;
                    }
                }
            }

            return null;
        }

        #endregion

        #region Visitor Related

        public static TVisitor Visit<TVisitor>(this TVisitor visitor, IBlock block, string tag) 
            where TVisitor : IBlockVisitor
        {
            if (object.ReferenceEquals(null, visitor))
            {
                throw new ArgumentNullException("visitor");
            }

            if (null == block)
            {
                throw new ArgumentNullException("block");
            }

            visitor.Block(block, tag);

            return visitor;
        }

        public static TBlock Visit<TBlock>(this TBlock block, IBlockVisitor visitor, string tag)
        {
            if (object.ReferenceEquals(null, visitor))
            {
                throw new ArgumentNullException("visitor");
            }

            if (null == visitor)
            {
                throw new ArgumentNullException("visitor");
            }

            return block;
        }

        #endregion

        #region Receiver Related

        public static IBlockResultReceiver ApplyTo<TOut>(this IBlockResultReceiver receiver, IBlock<TOut> block)
        {
            if (null == receiver)
            {
                throw new ArgumentNullException("receiver");
            }

            if (null == block)
            {
                throw new ArgumentNullException("block");
            }

            object receiverState;

            block.Apply(receiver.CreatePublisher<TOut>(out receiverState), receiverState);

            return receiver;
        }

        #endregion
    }
}