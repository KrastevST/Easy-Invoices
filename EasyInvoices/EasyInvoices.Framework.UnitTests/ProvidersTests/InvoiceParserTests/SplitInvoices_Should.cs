using EasyInvoices.Framework.Providers;
using EasyInvoices.Framework.Providers.Contracts;
using Moq;
using NUnit.Framework;
using System;

namespace EasyInvoices.Framework.UnitTests.ProvidersTests.InvoiceParserTests
{
    [TestFixture]
    public class SplitInvoices_Should
    {
        [TestCase("str/1//str/2//str/3")]
        [TestCase("//str/1//str/2//str/3")]
        [TestCase("str/1//str/2//str/3//")]
        [TestCase("//str/1//str/2//str/3//")]
        public void SplitInputIntoInvoiceStrings_WhenCorrectStringPassed(string input)
        {
            char separator = '/';
            // uncomment and change separator for quick testing (not all separating characters work)
            //input = input.Replace('/', separator);

            var expectedInvoiceStrings = new string[] { $"str{separator}1", $"str{separator}2", $"str{separator}3"};

            var invoiceParser = new InvoiceParser(separator);

            var result = invoiceParser.SplitInvoices(input);

            Assert.IsTrue(expectedInvoiceStrings[0].Equals(result[0]) &&
                          expectedInvoiceStrings[1].Equals(result[1]) &&
                          expectedInvoiceStrings[2].Equals(result[2]));
        }

        [Test]
        public void ThrowArgumentNullException_WhenPassedStringIsNull()
        {
            var invParser = new InvoiceParser('/');
            var decParserMock = new Mock<IDecimalParser>();
            string invoiceAsStr = null;

            Assert.Throws<ArgumentNullException>(() => invParser.ParseInvoice(invoiceAsStr, decParserMock.Object));
        }

        [TestCase(" ")]
        [TestCase("")]
        public void ThrowArgumentException_WhenPassedStringIsWhiteSpaceOrEmptyString(string input)
        {
            var invParser = new InvoiceParser('/');
            var decParserMock = new Mock<IDecimalParser>();
            string invoiceAsStr = input;

            Assert.Throws<ArgumentException>(() => invParser.ParseInvoice(invoiceAsStr, decParserMock.Object));
        }
    }
}
