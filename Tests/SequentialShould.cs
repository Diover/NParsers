using System;
using System.Collections.Generic;
using Core;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class SequentialShould
    {
        [Test]
        public void ParseSymbolAThenSymbolB()
        {
            var parser = new Sequential<char, char, char>(new Symbol('a'),
                                                          new Symbol('b'));

            var result = parser.Parse("ab".ToCharArray());

            Assert.That(result[0].Tree, Is.EqualTo(new Tuple<char, char>('a', 'b')));
            Assert.That(result[0].Remain, Is.Empty);
        }

        [Test]
        public void ParseBeginStringThenSpaceThenEndString()
        {
            var parser = new Sequential<string, IList<string>, IList<string>, IList<string>>(new Token("begin"),
                                                                                             new Token(" "),
                                                                                             new Token("end"));
            
            //without "Apply" combinator type of resulting tree will be quite difficult:
            //Tuple< IList<string>, Tuple< IList<string>, IList<string>>>
            var result = parser.Parse(Token.ToListString("begin end"));

            Assert.That(result[0].Remain, Is.Empty);
        }
    }
}