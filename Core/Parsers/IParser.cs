using System.Collections.Generic;

namespace Core.Parsers
{
    public interface IParser<TIn, TOut>
    {
        IList<ParseResult<IList<TIn>, TOut>> Parse(IList<TIn> input);
    }
}
