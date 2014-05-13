namespace Core
{
    public class ParseResult<TIn, TOut>
    {
        public TIn Remain { get; set; }
        public TOut Tree { get; set; }

        public ParseResult(TIn remain, TOut tree)
        {
            Remain = remain;
            Tree = tree;
        }

        public ParseResult()
        {
        }
    }
}