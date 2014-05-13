using System.Collections.Generic;

namespace Core.Parsers.Combinators
{
    public class Fail<TIn, TOut> : IParser<TIn, TOut>
    {
        public IList<ParseResult<IList<TIn>, TOut>> Parse(IList<TIn> input)
        {
            return new List<ParseResult<IList<TIn>, TOut>>();
        }
    }
}