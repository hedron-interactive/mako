// ---------------------------------------------------------------------------------------------------------------------
//  <copyright file="TaskAwaiter.cs" company="Hedron Interactive">
//      Copyright (c) Hedron Interactive. All rights reserved.
//  </copyright>
// ---------------------------------------------------------------------------------------------------------------------

namespace Hedron.Mako.Concurrency
{
    using System;

    internal struct TaskAwaiter<T> : IAwaiter<T>
    {
        private System.Runtime.CompilerServices.TaskAwaiter<T> taskAwaiter;

        public TaskAwaiter(System.Runtime.CompilerServices.TaskAwaiter<T> taskAwaiter)
            : this()
        {
            this.taskAwaiter = taskAwaiter;
        }

        public bool IsCompleted
        {
            get { return this.taskAwaiter.IsCompleted; }
        }

        public T GetResult()
        {
            return this.taskAwaiter.GetResult();
        }

        public void UnsafeOnCompleted(Action continuation)
        {
            this.taskAwaiter.UnsafeOnCompleted(continuation);
        }

        public void OnCompleted(Action continuation)
        {
            this.taskAwaiter.OnCompleted(continuation);
        }
    }
}