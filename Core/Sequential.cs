using System;
using System.Collections.Generic;
using System.Linq;

namespace Core
{
    public class Sequential<TIn, TOut1, TOut2, TOut3, TOut4> : IParser<TIn, Tuple<TOut1, Tuple<TOut2, Tuple<TOut3, TOut4>>>>
    {
        private readonly Sequential<TIn, TOut1, Tuple<TOut2, Tuple<TOut3, TOut4>>> _p;

        public Sequential(IParser<TIn, TOut1> p1, IParser<TIn, TOut2> p2, IParser<TIn, TOut3> p3, IParser<TIn, TOut4> p4)
        {
            _p = new Sequential<TIn, TOut1, Tuple<TOut2, Tuple<TOut3, TOut4>>>(p1,
                                                                               new Sequential<TIn, TOut2, TOut3, TOut4>(
                                                                                   p2,
                                                                                   p3,
                                                                                   p4));
        }

        public IList<ParseResult<IList<TIn>, Tuple<TOut1, Tuple<TOut2, Tuple<TOut3, TOut4>>>>> Parse(IList<TIn> input)
        {
            return _p.Parse(input);
        }
    }

    public class Sequential<TIn, TOut1, TOut2, TOut3> : IParser<TIn, Tuple<TOut1, Tuple<TOut2, TOut3>>>
    {
        private readonly Sequential<TIn, TOut1, Tuple<TOut2, TOut3>> _p;

        public Sequential(IParser<TIn, TOut1> p1, IParser<TIn, TOut2> p2, IParser<TIn, TOut3> p3)
        {
            _p = new Sequential<TIn, TOut1, Tuple<TOut2, TOut3>>(p1,
                                                                 new Sequential<TIn, TOut2, TOut3>(p2,
                                                                                                   p3));
        }

        public IList<ParseResult<IList<TIn>, Tuple<TOut1, Tuple<TOut2, TOut3>>>> Parse(IList<TIn> input)
        {
            return _p.Parse(input);
        }
    }

    public class Sequential<TIn, TOut1, TOut2> : IParser<TIn, Tuple<TOut1, TOut2>>
    {
        private readonly IParser<TIn, TOut1> _p1;
        private readonly IParser<TIn, TOut2> _p2;

        public Sequential(IParser<TIn, TOut1> p1, IParser<TIn, TOut2> p2)
        {
            _p1 = p1;
            _p2 = p2;
        }

        public IList<ParseResult<IList<TIn>, Tuple<TOut1, TOut2>>> Parse(IList<TIn> input)
        {
            var result1 = _p1.Parse(input);
            return result1.SelectMany(ParseSequentially).ToList();
        }

        private IList<ParseResult<IList<TIn>, Tuple<TOut1, TOut2>>> ParseSequentially(ParseResult<IList<TIn>, TOut1> r1)
        {
            var result2 = _p2.Parse(r1.Remain);
            return result2.Select(
                r2 => new ParseResult<IList<TIn>, Tuple<TOut1, TOut2>>(r2.Remain, new Tuple<TOut1, TOut2>(r1.Tree, r2.Tree)))
                          .ToList();
        }
    }
}