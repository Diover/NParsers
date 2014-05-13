using System;
using System.Collections.Generic;
using System.Linq;

namespace Core
{
    public class Symbol : Symbol<char, char>
    {
        public Symbol(char symbol) : base(symbol, symbol)
        {
        }
    }

    public class Symbol<TIn, TOut> : IParser<TIn, TOut> where TIn : IEquatable<TIn>
    {
        private readonly TIn _symbol;
        private readonly TOut _tree;

        public Symbol(TIn symbol, TOut tree)
        {
            _symbol = symbol;
            _tree = tree;
        }

        public IList<ParseResult<IList<TIn>, TOut>> Parse(IList<TIn> input)
        {
            if(input.Count == 0)
                return new List<ParseResult<IList<TIn>, TOut>>();

            if(input[0].Equals(_symbol))
                return new List<ParseResult<IList<TIn>, TOut>>
                    {
                        new ParseResult<IList<TIn>, TOut>(input.Skip(1).ToList(), _tree)
                    };

            return new List<ParseResult<IList<TIn>, TOut>>();
        }
    }
}