// ---------------------------------------------------------------------------------------------------------------------
//  <copyright file="TaskExtensions.cs" company="Hedron Interactive">
//      Copyright (c) Hedron Interactive. All rights reserved.
//  </copyright>
// ---------------------------------------------------------------------------------------------------------------------

namespace Hedron.Mako.Concurrency
{
    using System;
    using System.Threading.Tasks;

    public static class TaskExtensions
    {
        public static IAwaitable<T> AsAwaitable<T>(this Task<T> task)
        {
            if (null == task)
            {
                throw new ArgumentNullException("task");
            }

            return new TaskAwaitable<T>(task);
        }
    }
}