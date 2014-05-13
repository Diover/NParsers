using Core;
using Core.Parsers;
using Core.Parsers.Combinators;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class JustShould
    {
        [Test]
        public void ReturnAllSuccessResultsIfParsingFinished()
        {
            var parser = new Just<char, char>(new Symbol('a'));

            var result = parser.Parse("a".ToCharArray());

            Assert.That(result.Count, Is.EqualTo(1));
            Assert.That(result[0].Remain, Is.Empty);
        }

        [Test]
        public void ReturnEmptyListIfParsingNotFinished()
        {
            var parser = new Just<char, char>(new Symbol('a'));

            var result = parser.Parse("abder".ToCharArray());

            Assert.That(result, Is.Empty);
        }

        [Test]
        public void ReturnEmptyListIfParsingFail()
        {
            var parser = new Just<char, char>(new Symbol('a'));

            var result = parser.Parse("bder".ToCharArray());

            Assert.That(result, Is.Empty);
        }
    }
}