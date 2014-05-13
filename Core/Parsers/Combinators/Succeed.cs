using System.Collections.Generic;

namespace Core.Parsers.Combinators
{
    public class Succeed<TIn, TOut> : IParser<TIn, TOut>
    {
        private readonly TOut _result;

        public Succeed(TOut result)
        {
            _result = result;
        }

        public IList<ParseResult<IList<TIn>, TOut>> Parse(IList<TIn> input)
        {
            return new List<ParseResult<IList<TIn>, TOut>>
                {
                    new ParseResult<IList<TIn>, TOut>(input, _result)
                };
        }
    }
}