using Core;
using Core.Parsers;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class SymbolShould
    {
        [Test]
        public void ParseOneSymbol()
        {
            var parserA = new Symbol('a');
            
            var result = parserA.Parse("a".ToCharArray());
            
            Assert.That(result[0].Tree, Is.EqualTo('a'));
            Assert.That(result[0].Remain, Is.Empty);
        }

        [Test]
        public void DontParseDifferentSymbol()
        {
            var parserA = new Symbol('a');

            var result = parserA.Parse("b".ToCharArray());

            Assert.That(result, Is.Empty);
        }

        [Test]
        public void ParseOneSymbolInBegginingOfString()
        {
            var parserA = new Symbol('a');

            var result = parserA.Parse("abcde".ToCharArray());

            Assert.That(result[0].Tree, Is.EqualTo('a'));
            Assert.That(result[0].Remain, Is.EqualTo("bcde".ToCharArray()));
        }
    }
}
