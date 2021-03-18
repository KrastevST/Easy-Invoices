using EasyInvoices.Framework.Providers;
using EasyInvoices.Framework.Providers.Contracts;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace EasyInvoices.Framework.UnitTests.ProvidersTests.InvoiceParserTests
{
    [TestFixture]
    public class ParseInvoice_Should
    {
        [TestCase("12345/14.23/300.00/usD/0.21")]
        [TestCase("//12345/14.23/300/usd/0.21")]
        [TestCase("//12345/14.23/300.0/USD/0.21//")]
        [TestCase("12345/14.23/300.00/USD/0.21//")]
        public void ReturnInvoiceWithCorrectProperties_WhenValidStringPassed(string input)
        {
            char separator = '/';
            var invParser = new InvoiceParser(separator);
            var decParserMock = new Mock<IDecimalParser>();

            string numExpected = "12345";
            string currExpected = "USD";
            decimal daysExpected = 14.23m;
            decimal rateExpected = 300;
            decimal vatExpected = 21;

            var queue = new Queue<decimal>();

            queue.Enqueue(daysExpected);
            queue.Enqueue(rateExpected);
            queue.Enqueue(vatExpected / 100);

            decParserMock.Setup(x => x.ParseDecimal(It.IsAny<string>())).Returns(queue.Dequeue);

            var parsedInv = invParser.ParseInvoice(input, decParserMock.Object);

            Assert.AreEqual(numExpected, parsedInv.Number);
            Assert.AreEqual(currExpected, parsedInv.Currency);
            Assert.AreEqual(daysExpected, parsedInv.Days);
            Assert.AreEqual(rateExpected, parsedInv.Rate);
            Assert.AreEqual(vatExpected , parsedInv.VatPercent);
        }

        [Test]
        public void ThrowArgumentNullException_WhenPassedInvoiceAsStringIsNull()
        {
            var invParser = new InvoiceParser('/');
            var decParserMock = new Mock<IDecimalParser>();
            string invoiceAsStr = null;

            Assert.Throws<ArgumentNullException>(() => invParser.ParseInvoice(invoiceAsStr, decParserMock.Object));
        }

        [TestCase(" ")]
        [TestCase("")]
        public void ThrowArgumentException_WhenPassedInvoiceAsStringIsWhiteSpaceOrEmptyString(string input)
        {
            var invParser = new InvoiceParser('/');
            var decParserMock = new Mock<IDecimalParser>();
            string invoiceAsStr = null;

            Assert.Throws<ArgumentNullException>(() => invParser.ParseInvoice(invoiceAsStr, decParserMock.Object));
        }
    }
}
