using System;
using System.Collections.Generic;

namespace Core.Parsers.Combinators
{
    public class Left<TIn, TOut1, TOut2> : IParser<TIn, TOut1>
    {
        private readonly IParser<TIn, TOut1> _p;

        public Left(IParser<TIn, TOut1> left, IParser<TIn, TOut2> right)
        {
            _p = new Apply<TIn, Tuple<TOut1, TOut2>, TOut1>(new Sequential<TIn, TOut1, TOut2>(left, right),
                                                            tuple => tuple.Item1);
        }

        public IList<ParseResult<IList<TIn>, TOut1>> Parse(IList<TIn> input)
        {
            return _p.Parse(input);
        }
    }
}