namespace Mako.Concurrency
{
    using System.Threading.Tasks;

    internal struct TaskAwaitable<T> : IAwaitable<T>
    {
        private readonly Task<T> task;

        public TaskAwaitable(Task<T> task)
            : this()
        {
            this.task = task;
        }

        public IAwaiter<T> GetAwaiter()
        {
            return new TaskAwaiter<T>(this.task.GetAwaiter());
        }

        public bool TryGetResult(out T result)
        {
            if (null != this.task && this.task.IsCompleted && false == (this.task.IsFaulted || this.task.IsCanceled))
            {
                result = this.task.Result;
                return true;
            }
            else
            {
                result = default(T);
                return false;
            }
        }
    }
}
