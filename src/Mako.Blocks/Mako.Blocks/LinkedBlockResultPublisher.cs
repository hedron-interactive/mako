namespace Mako.Blocks
{
    internal sealed class LinkedBlockResultPublisher<TResult, T1> : BlockResultPublisher<T1>
    {
        public IBlockResultPublisher<TResult> ExternalPublisher;
        public IBlock<T1, TResult> Consequent;

        public override void YieldError(CompositionError error)
        {
            this.ExternalPublisher.YieldError(error);
        }

        public override void YieldResult(T1 result)
        {
            this.Consequent.Apply(this.ExternalPublisher, result);
        }
    }
}