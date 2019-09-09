namespace EasyInvoices.Framework.UnitTests.ProvidersTests.DateParserTests
{
    using EasyInvoices.Framework.Models;
    using EasyInvoices.Framework.Providers;
    using Moq;
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    [TestFixture]
    public class ParseInvoiceDate_Should
    {
        [Test]
        public void ReturnStringInTheCorrectFormat_WhenInvoiceWithValidNumberIsPassed()
        {
            string expected = "05-21 3";

            var dateParser = new DateParser();
            var invoiceMock = new Mock<IInvoice>();

            invoiceMock.Setup(i => i.Number).Returns("21053");

            string output = dateParser.ParseInvoiceDate(invoiceMock.Object);

            Assert.IsTrue(output.Equals(expected));
        }

        [Test]
        public void ThrowArgumentNullException_WhenPassedInvoiceIsNull()
        {
            var dateParser = new DateParser();
            IInvoice invoice = null;

            Assert.Throws<ArgumentNullException>(() => dateParser.ParseInvoiceDate(invoice));
        }
    }
}
