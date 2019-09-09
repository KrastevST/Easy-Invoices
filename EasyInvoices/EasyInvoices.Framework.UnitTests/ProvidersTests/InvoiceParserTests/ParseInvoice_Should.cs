namespace EasyInvoices.Framework.UnitTests.ProvidersTests.InvoiceParserTests
{
    using EasyInvoices.Framework.Providers;
    using EasyInvoices.Framework.Providers.Contracts;
    using Moq;
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

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
            var decParser = new Mock<IDecimalParser>();

            string num = "12345";
            string curr = "USD";
            decimal days = 14.23m;
            decimal rate = 300;
            decimal vat = 0.21m;

            var queue = new Queue<decimal>();

            queue.Enqueue(days);
            queue.Enqueue(rate);
            queue.Enqueue(vat);

            decParser.Setup(x => x.ParseDecimal(It.IsAny<string>())).Returns(queue.Dequeue);

            var parsedInv = invParser.ParseInvoice(input, decParser.Object);

            Assert.AreEqual(num, parsedInv.Number);
            Assert.AreEqual(curr, parsedInv.Currency);
            Assert.AreEqual(days, parsedInv.Days);
            Assert.AreEqual(rate, parsedInv.Rate);
            Assert.AreEqual(vat * 100, parsedInv.VatPercent);
        }
    }
}
