namespace EasyInvoices.Framework.UnitTests.Providers.PrimitiveParserTests
{
    using EasyInvoices.Framework.Providers;
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    [TestFixture]
    public class ParseDecimalShould
    {
        [TestCase("10566,01")]
        [TestCase("10 566,01")]
        [TestCase("10.566,01")]
        [TestCase("10566.01")]
        [TestCase("10 566.01")]
        [TestCase("10,566.01")]
        public void ParseDecimalRegardlessOfFormat_WhenValidStringIsProvided(string input)
        {
            var parser = new PrimitiveParser();

            var result = parser.ParseDecimal(input);

            Assert.AreEqual(10566.01m, result);
        }
    }
}
