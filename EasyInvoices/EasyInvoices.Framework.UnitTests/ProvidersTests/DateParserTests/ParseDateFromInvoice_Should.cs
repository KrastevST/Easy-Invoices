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
    public class ParseDateFromInvoice_Should
    {
        [Test]
        public void ReturnStringInTheCorrectFormat_WhenInvoiceWithAValidNumberIsPassed()
        {
            var dateParser = new DateParser();
            var invoice = new Mock<IInvoice>();
            string expected = "05-21 3";

            invoice.Setup(i => i.InvoiceNumber).Returns("21053");

            string output = dateParser.ParseDateFromInvoice(invoice.Object);

            Assert.IsTrue(output.Equals(expected));
        }
    }
}
