using System.Collections.Generic;
using System.Linq;

namespace Core.Parsers.Combinators
{
    public class Parallel<TIn, TOut> : IParser<TIn, TOut>
    {
        private readonly IParser<TIn, TOut>[] _ps;

        public Parallel(params IParser<TIn, TOut>[] ps)
        {
            _ps = ps;
        }

        public IList<ParseResult<IList<TIn>, TOut>> Parse(IList<TIn> input)
        {
            return _ps.Skip(1)
                      .Aggregate(_ps[0].Parse(input), (result, parser) => result.Union(parser.Parse(input)).ToList())
                      .ToList();
        }
    }
}