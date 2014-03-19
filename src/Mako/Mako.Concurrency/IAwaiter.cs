// ---------------------------------------------------------------------------------------------------------------------
//  <copyright file="IAwaiter.cs" company="Hedron Interactive">
//      Copyright (c) Hedron Interactive. All rights reserved.
//  </copyright>
// ---------------------------------------------------------------------------------------------------------------------

namespace Hedron.Mako.Concurrency
{
    using System.Runtime.CompilerServices;

    public interface IAwaiter<out T> : ICriticalNotifyCompletion, INotifyCompletion
    {
        bool IsCompleted { get; }

        T GetResult();
    }
}