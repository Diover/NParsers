using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public interface IParser<TIn, TOut>
    {
        IList<ParseResult<IList<TIn>, TOut>> Parse(IList<TIn> input);
    }
}
