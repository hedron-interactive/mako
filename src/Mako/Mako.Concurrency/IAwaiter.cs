namespace Mako.Concurrency
{
    using System.Runtime.CompilerServices;

    public interface IAwaiter<out T> : ICriticalNotifyCompletion, INotifyCompletion
    {
        bool IsCompleted { get; }

        T GetResult();
    }
}