using Core;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class TokenShould
    {
        [Test]
        public void ParseBeginToken()
        {
            var parserA = new Token("begin");

            var result = parserA.Parse(Token.ToListString("begin"));

            Assert.That(result[0].Tree, Is.EqualTo(Token.ToListString("begin")));
            Assert.That(result[0].Remain, Is.Empty);
        }

        [Test]
        public void DontParseBeginToken()
        {
            var parserA = new Token("begin");

            var result = parserA.Parse(Token.ToListString("endless parenthesis"));

            Assert.That(result, Is.Empty);
        }
    }
}