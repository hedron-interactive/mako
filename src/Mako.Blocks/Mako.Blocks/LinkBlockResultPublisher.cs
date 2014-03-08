namespace Mako.Blocks
{
    internal sealed class LinkBlockResultPublisher<TResult, T1> : BlockResultPublisher<T1>
    {
        public IBlockResultPublisher<TResult> ExternalPublisher;
        public IBlock<T1, TResult> Consequent;

        public override void YieldError(object receiverState, CompositionError error)
        {
            this.ExternalPublisher.YieldError(receiverState, error);
        }

        public override void YieldResult(object receiverState, T1 result)
        {
            this.Consequent.Apply(this.ExternalPublisher, receiverState, result);
        }
    }
}