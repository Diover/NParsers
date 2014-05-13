namespace Core
{
    public class Epsilon<TIn, TOut> : Succeed<TIn, TOut>
    {
        public Epsilon(TOut tree)
            : base(tree)
        {
        }
    }
}