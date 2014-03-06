// ---------------------------------------------------------------------------------------------------------------------
//  <copyright file="IAwaitable.cs" company="Hedron Interactive">
//      Copyright (c) Hedron Interactive. All rights reserved.
//  </copyright>
// ---------------------------------------------------------------------------------------------------------------------

namespace Mako.Concurrency
{
    public interface IAwaitable<out T>
    {
        IAwaiter<T> GetAwaiter();
    }
}