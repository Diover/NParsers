using System;
using System.Collections.Generic;

namespace Core.Parsers.Combinators
{
    public class Right<TIn, TOut1, TOut2> : IParser<TIn, TOut2>
    {
        private readonly IParser<TIn, TOut2> _p;

        public Right(IParser<TIn, TOut1> left, IParser<TIn, TOut2> right)
        {
            _p = new Apply<TIn, Tuple<TOut1, TOut2>, TOut2>(new Sequential<TIn, TOut1, TOut2>(left, right),
                                                            tuple => tuple.Item2);
        }

        public IList<ParseResult<IList<TIn>, TOut2>> Parse(IList<TIn> input)
        {
            return _p.Parse(input);
        }
    }
}