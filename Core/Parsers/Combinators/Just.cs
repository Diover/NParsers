using System.Collections.Generic;
using System.Linq;

namespace Core.Parsers.Combinators
{
    public class Just<TIn, TOut> : IParser<TIn, TOut>
    {
        private readonly IParser<TIn, TOut> _p;

        public Just(IParser<TIn, TOut> p)
        {
            _p = p;
        }

        public IList<ParseResult<IList<TIn>, TOut>> Parse(IList<TIn> input)
        {
            return _p.Parse(input).Where(result => result.Remain.Count == 0).ToList();
        }
    }
}