namespace EasyInvoices.Framework.UnitTests.ModelsTests.InvoiceTests
{
    using EasyInvoices.Framework.Models;
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    [TestFixture]
    public class Constructor_Should
    {
        [Test]
        public void NotThrowException_WhenValidArgumentsPassed()
        {
            string invoiceNumber = "12345";
            decimal days = 1;
            decimal rate = 1;
            string currency = "EUR";
            decimal vatPercent = 1;

            Assert.DoesNotThrow(() => new Invoice(invoiceNumber, days, rate, currency, vatPercent));
        }

        [TestCase(null)]
        public void ThrowArgumentNullException_WhenPassedInvoiceNumberIsNull(string input)
        {
            string invoiceNumber = input;

            decimal days = 1;
            decimal rate = 1;
            string currency = "EUR";
            decimal vatPercent = 1;

            Assert.Throws<ArgumentNullException>(() => new Invoice(invoiceNumber, days, rate, currency, vatPercent));
        }

        [TestCase(" ")]
        [TestCase("")]
        public void ThrowArgumentException_WhenPassedInvoiceNumberIsWhiteSpaceOrEmptyString(string input)
        {
            string invoiceNumber = input;

            decimal days = 1;
            decimal rate = 1;
            string currency = "EUR";
            decimal vatPercent = 1;

            Assert.Throws<ArgumentException>(() => new Invoice(invoiceNumber, days, rate, currency, vatPercent));
        }


        [TestCase(-1)]
        public void ThrowWArgumentNullException_WhenNegativeDaysPassed(decimal input)
        {
            decimal days = input;

            string invoiceNumber = "12345";
            decimal rate = 1;
            string currency = "EUR";
            decimal vatPercent = 1;

            Assert.Throws<ArgumentOutOfRangeException>(() => new Invoice(invoiceNumber, days, rate, currency, vatPercent));
        }

        [TestCase(0)]
        [TestCase(-1)]
        public void ThrowArgumentOutOfRangeException_WhenRateLessThanOrEqualToZeroPassed(decimal input)
        {
            decimal rate = input;

            string invoiceNumber = "12345";
            decimal days = 1;
            string currency = "EUR";
            decimal vatPercent = 1;

            Assert.Throws<ArgumentOutOfRangeException>(() => new Invoice(invoiceNumber, days, rate, currency, vatPercent));
        }

        [TestCase(null)]
        public void ThrowArgumentNullException_WhenPassedCurrencyIsNull(string input)
        {
            string currency = input;

            string invoiceNumber = "12345";
            decimal days = 1;
            decimal rate = 1;
            decimal vatPercent = 1;

            Assert.Throws<ArgumentNullException>(() => new Invoice(invoiceNumber, days, rate, currency, vatPercent));
        }

        [TestCase(" ")]
        [TestCase("")]
        public void ThrowArgumentException_WhenPassedCurrencyIsWhiteSpaceOrEmptyString(string input)
        {
            string currency = input;

            string invoiceNumber = "12345";
            decimal days = 1;
            decimal rate = 1;
            decimal vatPercent = 1;

            Assert.Throws<ArgumentException>(() => new Invoice(invoiceNumber, days, rate, currency, vatPercent));
        }

        [TestCase(0)]
        [TestCase(-1)]
        public void ThrowArgumentOutOfRangeException_WhenVatPercentLessThanOrEqualToZeroPassed(decimal input)
        {
            decimal vatPercent = input;

            string invoiceNumber = "12345";
            decimal days = 1;
            decimal rate = 1;
            string currency = "EUR";

            Assert.Throws<ArgumentOutOfRangeException>(() => new Invoice(invoiceNumber, days, rate, currency, vatPercent));
        }

        [TestCase(101)]
        public void ThrowArgumentOutOfRangeException_WhenVatPercentGreaterThan100Passed(decimal input)
        {
            decimal vatPercent = input;

            string invoiceNumber = "12345";
            decimal days = 1;
            decimal rate = 1;
            string currency = "EUR";

            Assert.Throws<ArgumentOutOfRangeException>(() => new Invoice(invoiceNumber, days, rate, currency, vatPercent));
        }

        [TestCase("1234T")]
        public void ThrowArgumentException_WhenInvoiceNumberContainingNonNumericCharactersPassed(string input)
        {
            string invoiceNumber = input;

            decimal days = 1;
            decimal rate = 1;
            string currency = "EUR";
            decimal vatPercent = 1;

            Assert.Throws<ArgumentException>(() => new Invoice(invoiceNumber, days, rate, currency, vatPercent));
        }

        [TestCase("123456")]
        [TestCase("1234")]
        public void ThrowArgumentException_WhenInvoiceNumberWithLengthDifferentThan5Passed(string input)
        {
            string invoiceNumber = input;

            decimal days = 1;
            decimal rate = 1;
            string currency = "EUR";
            decimal vatPercent = 1;

            Assert.Throws<ArgumentException>(() => new Invoice(invoiceNumber, days, rate, currency, vatPercent));
        }

        [TestCase("1SD")]
        public void ThrowArgumentException_WhenCurrencyContainingNonLetterCharactersPassed(string input)
        {
            string currency = input;

            string invoiceNumber = "12345";
            decimal days = 1;
            decimal rate = 1;
            decimal vatPercent = 1;

            Assert.Throws<ArgumentException>(() => new Invoice(invoiceNumber, days, rate, currency, vatPercent));
        }

        [TestCase("Euro")]
        public void ThrowArgumentException_WhenCurrencyWithLengthDifferentThan3Passed(string input)
        {
            string currency = input;

            string invoiceNumber = "12345";
            decimal days = 1;
            decimal rate = 1;
            decimal vatPercent = 1;

            Assert.Throws<ArgumentException>(() => new Invoice(invoiceNumber, days, rate, currency, vatPercent));
        }
    }
}
