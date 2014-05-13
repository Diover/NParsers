using Core;
using Core.Parsers;
using Core.Parsers.Combinators;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class ParensShould
    {
        [Test]
        public void ParseCorrectSimpleExpression()
        {
            var p = new Just<char, ITree>(new Parens());

            var result = p.Parse("()".ToCharArray());

            Assert.That(result.Count, Is.EqualTo(1));
        }

        [Test]
        public void ParseCorrectNestedExpression()
        {
            var p = new Just<char, ITree>(new Parens());

            var result = p.Parse("()(()())".ToCharArray());

            Assert.That(result.Count, Is.EqualTo(1));
        }

        [Test]
        public void NotParseIncorrectExpression()
        {
            var p = new Just<char, ITree>(new Parens());

            var result = p.Parse("(".ToCharArray());

            Assert.That(result, Is.Empty);
        }
    }
}