using Core;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class ParallelShould
    {
        [Test]
        public void ParseSymbolAFromTwoAlternatives()
        {
            var parser = new Parallel<char, char>(new Symbol('a'),
                                                  new Symbol('b'));

            var result = parser.Parse("a".ToCharArray());

            Assert.That(result[0].Tree, Is.EqualTo('a'));
        }

        [Test]
        public void ParseSymbolBFromTwoAlternatives()
        {
            var parser = new Parallel<char, char>(new Symbol('a'),
                                                  new Symbol('b'));

            var result = parser.Parse("b".ToCharArray());

            Assert.That(result[0].Tree, Is.EqualTo('b'));
        }
    }
}