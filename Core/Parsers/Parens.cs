using System;
using System.Collections.Generic;
using Core.Parsers.Combinators;

namespace Core.Parsers
{
    public class Parens : IParser<char, ITree>
    {
        public IList<ParseResult<IList<char>, ITree>> Parse(IList<char> input)
        {
            var s1 = new Sequential<char, ITree, ITree>(new Left<char, ITree, char>(new Right<char, char, ITree>(new Symbol('('),
                                                                                                                 new Parens()),
                                                                                    new Symbol(')')),
                                                        new Parens());

            var a = new Apply<char, Tuple<ITree, ITree>, ITree>(s1,
                                                                tuple => new Branch(tuple.Item1,
                                                                                    tuple.Item2));

            var p = new Parallel<char, ITree>(a,
                                              new Epsilon<char, ITree>(new Nil()));
            return p.Parse(input);
        }
    }
}