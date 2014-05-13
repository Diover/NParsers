using System;
using System.Collections.Generic;
using System.Linq;

namespace Core
{
    public class Satisfy<TIn> : IParser<TIn, TIn> where TIn: IEquatable<TIn>
    {
        private readonly Func<TIn, bool> _p;

        public Satisfy(Func<TIn, bool> p)
        {
            _p = p;
        }

        public IList<ParseResult<IList<TIn>, TIn>> Parse(IList<TIn> input)
        {
            if(input.Count == 0)
                return new List<ParseResult<IList<TIn>, TIn>>();

            if(_p(input[0]))
                return new List<ParseResult<IList<TIn>, TIn>>
                    {
                        new ParseResult<IList<TIn>, TIn>(input.Skip(1).ToList(), input[0])
                    };

            return new List<ParseResult<IList<TIn>, TIn>>();
        }
    }
}