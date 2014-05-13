using System;
using Core;
using Core.Parsers;
using Core.Parsers.Combinators;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class ApplyShould
    {
        [Test]
        public void TransformParserOutputTreeFromCharToInt()
        {
            var charToInt = new Func<char, int>(c => c);
            var parser = new Apply<char, char, int>(new Symbol('a'), charToInt);

            var result = parser.Parse("a".ToCharArray());

            Assert.That(result[0].Tree, Is.EqualTo(charToInt('a')));
        }
    }
}