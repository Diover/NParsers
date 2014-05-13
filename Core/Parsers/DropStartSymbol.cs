using System.Collections.Generic;
using System.Linq;

namespace Core.Parsers
{
    public class DropStartSymbol : DropStartSymbol<char, char>
    {
        public DropStartSymbol(IParser<char, char> p, char symbol)
            : base(p, symbol)
        {
        }
    }

    public class DropStartSymbol<TIn, TOut> : IParser<TIn, TOut>
    {
        private readonly IParser<TIn, TOut> _p;
        private readonly TIn _symbol;

        public DropStartSymbol(IParser<TIn, TOut> p, TIn symbol)
        {
            _p = p;
            _symbol = symbol;
        }

        public IList<ParseResult<IList<TIn>, TOut>> Parse(IList<TIn> input)
        {
            return _p.Parse(input.SkipWhile(s => s.Equals(_symbol)).ToList()).ToList();
        }
    }
}