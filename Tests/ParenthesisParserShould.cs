using System;
using System.Threading.Tasks;
using Core;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class ParenthesisParserShould
    {
        [Test]
        public void Parse()
        {
            var p = new Just<char, ITree>(new Parens());

            var result = p.Parse("()(()())".ToCharArray());

            Assert.That(result.Count, Is.EqualTo(1));
        }
    }
}