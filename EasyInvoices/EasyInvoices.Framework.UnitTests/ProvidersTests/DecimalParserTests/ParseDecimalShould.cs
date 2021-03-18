using EasyInvoices.Framework.Providers;
using NUnit.Framework;
using System;

namespace EasyInvoices.Framework.UnitTests.ProvidersTests.DecimalParserTests
{
    [TestFixture]
    public class ParseDecimalShould
    {
        [TestCase("10566,01")]
        [TestCase("10 566,01")]
        [TestCase("10.566,01")]
        [TestCase("10566.01")]
        [TestCase("10 566.01")]
        [TestCase("10,566.01")]
        public void ReturnCorrectValueRegardlessOfFormat_WhenValidStringPassed(string input)
        {
            var parser = new DecimalParser();

            var result = parser.ParseDecimal(input);

            Assert.AreEqual(10566.01m, result);
        }

        [Test]
        public void ReturnCorrectValue_WhenContentOfPassedStringIsWholeNumber()
        {
            var parser = new DecimalParser();
            string input = "424";

            var result = parser.ParseDecimal(input);

            Assert.AreEqual(424, result);
        }

        [Test]
        public void ThrowArgumentNullException_WhenPassedValueIsNull()
        {
            var parser = new DecimalParser();
            string input = null;

            Assert.Throws<ArgumentNullException>(() => parser.ParseDecimal(input));
        }

        [TestCase(" ")]
        [TestCase("")]
        public void ThrowArgumentException_WhenPassedValueIsWhiteSpaceOrEmptyString(string input)
        {
            var parser = new DecimalParser();

            Assert.Throws<ArgumentException>(() => parser.ParseDecimal(input));
        }
    }
}
