using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class ParserShould
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
        public void DontParseOneSymbol()
        {
            var parserA = new Symbol('a');

            var result = parserA.Parse("b".ToCharArray());

            Assert.That(result, Is.Empty);
        }

        [Test]
        public void ParseBeginToken()
        {
            var parserA = new Token("begin");

            var result = parserA.Parse(Token.ToListString("begin"));

            Assert.That(string.Join("", result[0].Tree), Is.EqualTo("begin"));
            Assert.That(result[0].Remain, Is.Empty);
        }

        [Test]
        public void DontParseBeginToken()
        {
             var parserA = new Token("end");

            var result = parserA.Parse(Token.ToListString("begin"));

            Assert.That(result, Is.Empty);
        }
    }
}
