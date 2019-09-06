namespace EasyInvoices.Framework.UnitTests.ProvidersTests.DecimalParserTests
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
        public void ConvertStringToDecimalRegardlessOfFormat_WhenValidStringIsProvided(string input)
        {
            var parser = new DecimalParser();

            var result = parser.ParseDecimal(input);

            Assert.AreEqual(10566.01m, result);
        }
    }
}
