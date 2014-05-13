using System;
using System.Collections.Generic;

namespace Core
{
    public class Parens : IParser<char, ITree>
    {
        public IList<ParseResult<IList<char>, ITree>> Parse(IList<char> input)
        {
            var s = new Sequential<char, char, ITree, char, ITree>(new Symbol('('),
                                                                   new Parens(),
                                                                   new Symbol(')'),
                                                                   new Parens());

            var a = new Apply<char, Tuple<char, Tuple<ITree, Tuple<char, ITree>>>, ITree>(s,
                                                                                          tuple => new Branch(tuple.Item2.Item1,
                                                                                                              tuple.Item2.Item2.Item2));

            var p = new Parralel<char, ITree>(a,
                                              new Epsilon<char, ITree>(new Nil()));
            return p.Parse(input);
        }
    }
}