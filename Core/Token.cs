using System;
using System.Collections.Generic;
using System.Linq;

namespace Core
{
    public class Token : Token<string, string>
    {
        public Token(string token)
            : base(ToListString(token), ToListString(token))
        {
        }

        public static IList<string> ToListString(string value)
        {
            return value.Select(c => c.ToString()).ToList();
        }
    }

    public class Token<TIn, TOut> : IParser<TIn, IList<TOut>> where TIn : IEquatable<TIn>
    {
        private readonly IList<TIn> _token;
        private readonly IList<TOut> _tree;

        public Token(IList<TIn> token, IList<TOut> tree)
        {
            _token = token;
            _tree = tree;
        }

        public IList<ParseResult<IList<TIn>, IList<TOut>>> Parse(IList<TIn> input)
        {
            if(input.Count < _token.Count)
                return new List<ParseResult<IList<TIn>, IList<TOut>>>();

            if(ContainsTokens(input))
                return new List<ParseResult<IList<TIn>, IList<TOut>>>
                    {
                        new ParseResult<IList<TIn>, IList<TOut>>(input.Skip(_token.Count).ToList(), _tree)
                    };

            return new List<ParseResult<IList<TIn>, IList<TOut>>>();
        }

        private bool ContainsTokens(IEnumerable<TIn> input)
        {
            return _token.Zip(input.Take(_token.Count), (t, s) => new {Token = t, Symbol = s}).All(ts => ts.Token.Equals(ts.Symbol));
        }
    }
}