﻿// ---------------------------------------------------------------------------------------------------------------------
//  <copyright file="Demand.cs" company="Hedron Interactive">
//      Copyright (c) Hedron Interactive. All rights reserved.
//  </copyright>
// ---------------------------------------------------------------------------------------------------------------------

namespace Hedron.Mako
{
    using Hedron.Mako.Publishers;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    public static class Demand
    {
        public static void Result<TResult>(IBlock<TResult> block, TResult expected)
        {
            Assert.AreEqual(expected, new AwaitableBlockResultPublisher<TResult>().Apply(block, null).Task.Result.Result);
        }

        public static void Result<T1, TResult>(IBlock<T1, TResult> block, T1 in1, TResult expected)
        {
            Assert.AreEqual(expected, new AwaitableBlockResultPublisher<TResult>().Apply(block, null, in1).Task.Result.Result);
        }

        public static void Result<T1, T2, TResult>(IBlock<T1, T2, TResult> block, T1 in1, T2 in2, TResult expected)
        {
            Assert.AreEqual(expected, new AwaitableBlockResultPublisher<TResult>().Apply(block, null, in1, in2).Task.Result.Result);
        }

        public static void Result<T1, T2, T3, TResult>(IBlock<T1, T2, T3, TResult> block, T1 in1, T2 in2, T3 in3, TResult expected)
        {
            Assert.AreEqual(expected, new AwaitableBlockResultPublisher<TResult>().Apply(block, null, in1, in2, in3).Task.Result.Result);
        }

        public static void Failure<TResult>(IBlock<TResult> block, CompositionError? expected = null)
        {
            var result = new AwaitableBlockResultPublisher<TResult>().Apply(block, null).Task.Result;

            Assert.IsFalse(result.HasResult);

            if (expected.HasValue)
            {
                Assert.AreEqual(expected.Value, result.Result);
            }
        }

        public static void Failure<T1, TResult>(IBlock<T1, TResult> block, T1 in1, CompositionError? expected = null)
        {
            var result = new AwaitableBlockResultPublisher<TResult>().Apply(block, null, in1).Task.Result;

            Assert.IsFalse(result.HasResult);

            if (expected.HasValue)
            {
                Assert.AreEqual(expected.Value, result.Result);
            }
        }

        public static void Failure<T1, T2, TResult>(IBlock<T1, T2, TResult> block, T1 in1, T2 in2, CompositionError? expected = null)
        {
            var result = new AwaitableBlockResultPublisher<TResult>().Apply(block, null, in1, in2).Task.Result;

            Assert.IsFalse(result.HasResult);

            if (expected.HasValue)
            {
                Assert.AreEqual(expected.Value, result.Result);
            }
        }

        public static void Failure<T1, T2, T3, TResult>(IBlock<T1, T2, T3, TResult> block, T1 in1, T2 in2, T3 in3, CompositionError? expected = null)
        {
            var result = new AwaitableBlockResultPublisher<TResult>().Apply(block, null, in1, in2, in3).Task.Result;

            Assert.IsFalse(result.HasResult);

            if (expected.HasValue)
            {
                Assert.AreEqual(expected.Value, result.Result);
            }
        }
    }
}