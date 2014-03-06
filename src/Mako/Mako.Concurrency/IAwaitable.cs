namespace Mako.Concurrency
{
    using System;

    public interface IAwaitable<out T>
    {
        IAwaiter<T> GetAwaiter();
    }
}