using System;
using System.Collections.Generic;
using System.Linq;

namespace Core.Parsers.Combinators
{
    public class Apply<TIn, TA, TB> : IParser<TIn, TB>
    {
        private readonly IParser<TIn, TA> _p;
        private readonly Func<TA, TB> _f;

        public Apply(IParser<TIn, TA> p, Func<TA, TB> f)
        {
            _p = p;
            _f = f;
        }

        public IList<ParseResult<IList<TIn>, TB>> Parse(IList<TIn> input)
        {
            return _p.Parse(input).Select(r => new ParseResult<IList<TIn>, TB>(r.Remain, _f(r.Tree))).ToList();
        }
    }
}