// ---------------------------------------------------------------------------------------------------------------------
//  <copyright file="ObservableBlockResultPublisher.cs" company="Hedron Interactive">
//      Copyright (c) Hedron Interactive. All rights reserved.
//  </copyright>
// ---------------------------------------------------------------------------------------------------------------------

namespace Mako.Publishers
{
    using System;
    using System.Threading;

    /// <summary>
    /// Responsible for publishing block results as an observable subscription.
    /// </summary>
    /// <typeparam name="TResult">Type associated with result data.</typeparam>
    public sealed class ObservableBlockResultPublisher<TResult> : BlockResultPublisher<TResult>, IObservable<BlockResult<TResult>>, IDisposable
    {
        private readonly object publishLock;

        private Action<BlockResult<TResult>> observerPublish;
        private Action observerComplete;
        private volatile bool disposed;

        /// <summary>
        /// Initializes a new ObservableBlockResultPublisher instance.
        /// </summary>
        public ObservableBlockResultPublisher()
        {
            this.publishLock = new object();
        }

        /// <summary>
        /// Publishes error information.
        /// </summary>
        /// <param name="error">Information describing the error.</param>
        /// <remarks>An application developer should not assume control will be returned from this call immediately or ever.</remarks>
        public override void YieldError(CompositionError error)
        {
            var publish = this.observerPublish;

            if (null != publish)
            {
                publish(BlockResult.FromError<TResult>(error));
            }
        }

        /// <summary>
        /// Publishes a result.
        /// </summary>
        /// <param name="result">Result to publish.</param>
        /// <remarks>An application developer should not assume control will be returned from this call immediately or ever.</remarks>
        public override void YieldResult(TResult result)
        {
            var publish = this.observerPublish;

            if (null != publish)
            {
                publish(BlockResult.FromResult(result));
            }
        }

        /// <summary>
        /// Creates and registers a subscription for the given observer.
        /// </summary>
        /// <param name="observer">Subscription observer, consumes the values.</param>
        /// <returns>A IDispoable responsible for unregistering the subscription.</returns>
        public IDisposable Subscribe(IObserver<BlockResult<TResult>> observer)
        {
            if (null == observer)
            {
                throw new ArgumentNullException("observer");
            }

            lock (this.publishLock)
            {
                if (this.disposed)
                {
                    throw new InvalidOperationException("ObservableBlockResultPublisher has already been disposed.");
                }

                return Subscription.Subscribe(this, observer);
            }
        }

        /// <summary>
        /// Unregisters all subscribers.
        /// </summary>
        public void Dispose()
        {
            lock (this.publishLock)
            {
                if (this.disposed)
                {
                    return;
                }

                this.disposed = true;

                this.observerComplete();

                Interlocked.Exchange(ref this.observerComplete, null);
                Interlocked.Exchange(ref this.observerPublish, null);
            }
        }

        /// <summary>
        /// Responsible for managing a single observers subscription.
        /// </summary>
        /// <summary>
        /// TODO: make this implementation completely thread safe without too much sacrifice to performance.
        /// </summary>
        private sealed class Subscription : IDisposable
        {
            private readonly ObservableBlockResultPublisher<TResult> owner;
            private readonly IObserver<BlockResult<TResult>> observer;
            private int completed;

            /// <summary>
            /// Initializes a new Subscription instance.
            /// </summary>
            /// <param name="owner">Subscription owner, produces the values.</param>
            /// <param name="observer">Subscription observer, consumes the values.</param>
            public Subscription(ObservableBlockResultPublisher<TResult> owner, IObserver<BlockResult<TResult>> observer)
            {
                this.owner = owner;
                this.observer = observer;
                this.completed = 0;
            }

            /// <summary>
            /// Registers a new subscription.
            /// </summary>
            /// <param name="owner">Subscription owner, produces the values.</param>
            /// <param name="observer">Subscription observer, consumes the values.</param>
            /// <returns>A new Subscription instance.</returns>
            public static Subscription Subscribe(ObservableBlockResultPublisher<TResult> owner, IObserver<BlockResult<TResult>> observer)
            {
                var subscription = new Subscription(owner, observer);

                lock (owner.publishLock)
                {
                    var newPublish = owner.observerPublish;
                    var newComplete = owner.observerComplete;

                    newPublish += subscription.Publish;
                    newComplete += subscription.Complete;

                    Interlocked.Exchange(ref owner.observerPublish, newPublish);
                    Interlocked.Exchange(ref owner.observerComplete, newComplete);
                }

                return subscription;
            }

            /// <summary>
            /// Unregisters the subscription.
            /// </summary>
            public void Dispose()
            {
                lock (this.owner.publishLock)
                {
                    var newPublish = this.owner.observerPublish;
                    var newComplete = this.owner.observerComplete;

                    newPublish -= this.Publish;
                    newComplete -= this.Complete;

                    Interlocked.Exchange(ref this.owner.observerPublish, newPublish);
                    Interlocked.Exchange(ref this.owner.observerComplete, newComplete);
                }

                this.Complete();
            }

            /// <summary>
            /// Send the new value to the observer.
            /// </summary>
            /// <param name="value">Value to send to the observer.</param>
            /// <summary>TODO: make thread safe, publish may happen after Complete - which violates the IObservable contract.</summary>
            public void Publish(BlockResult<TResult> value)
            {
                this.observer.OnNext(value);
            }

            /// <summary>
            /// Sends the complete signal to the observer.
            /// </summary>
            public void Complete()
            {
                if (0 == Interlocked.Exchange(ref this.completed, 1))
                {
                    this.observer.OnCompleted();
                }
            }
        }
    }
}