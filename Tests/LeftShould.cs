using Core.Parsers;
using Core.Parsers.Combinators;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class LeftShould
    {
        [Test]
        public void ReturnResultOnlyFromLeftParser()
        {
            var p = new Left<char, char, char>(new Symbol('a'),
                                               new Symbol(')'));

            var result = p.Parse("a)".ToCharArray());

            Assert.That(result.Count, Is.EqualTo(1));
            Assert.That(result[0].Tree, Is.EqualTo('a'));
            Assert.That(result[0].Remain, Is.Empty);
        }

        [Test]
        public void DontReturnResultIfNoMatches()
        {
            var p = new Left<char, char, char>(new Symbol('a'),
                                               new Symbol(')'));

            var result = p.Parse("b)".ToCharArray());

            Assert.That(result, Is.Empty);
        }
    }
}