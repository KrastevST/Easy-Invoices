namespace EasyInvoices.Framework.UnitTests.ProvidersTests.InvoiceParserTests
{
    using EasyInvoices.Framework.Providers;
    using Moq;
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    [TestFixture]
    public class SeparateInvoiceStrings_Should
    {
        [TestCase("str&1&&str&2&&str&3")]
        [TestCase("&&str&1&&str&2&&str&3")]
        [TestCase("str&1&&str&2&&str&3&&")]
        [TestCase("&&str&1&&str&2&&str&3&&")]
        public void SplitTheInputStringIntoIndividualInvoiceStrings_WhenTheCorrectSeparatingCharIsProvided(string input)
        {
            char separator = '/';
            // Modify the input for faster testing of different separators
            string updatedInput = input.Replace('&', separator);
            string[] invoiceStrings = new string[] { $"str{separator}1", $"str{separator}2", $"str{separator}3"};

            var invParser = new InvoiceParser(separator);

            var result = invParser.SeparateInvoiceStrings(updatedInput);

            Assert.IsTrue(invoiceStrings[0].Equals(result[0]) &&
                          invoiceStrings[1].Equals(result[1]) &&
                          invoiceStrings[2].Equals(result[2]));
        }
    }
}
