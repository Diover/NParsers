using Core.Parsers;
using Core.Parsers.Combinators;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class RightShould
    {
        [Test]
        public void ReturnResultOnlyFromRightParser()
        {
            var p = new Right<char, char, char>(new Symbol('('),
                                                new Symbol('a'));

            var result = p.Parse("(a".ToCharArray());

            Assert.That(result.Count, Is.EqualTo(1));
            Assert.That(result[0].Tree, Is.EqualTo('a'));
            Assert.That(result[0].Remain, Is.Empty);
        }

        [Test]
        public void DontReturnResultIfNoMatches()
        {
            var p = new Right<char, char, char>(new Symbol('('),
                                                new Symbol('a'));

            var result = p.Parse("(b".ToCharArray());

            Assert.That(result, Is.Empty);
        }
    }
}