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
    public class SplitInvoices_Should
    {
        [TestCase("str/1//str/2//str/3")]
        [TestCase("//str/1//str/2//str/3")]
        [TestCase("str/1//str/2//str/3//")]
        [TestCase("//str/1//str/2//str/3//")]
        public void SplitTheInputStringIntoIndividualInvoiceStrings_WhenTheCorrectSeparatingCharIsProvided(string input)
        {
            char separator = '/';
            // uncomment and change separator for quick testing
            //input = input.Replace('/', separator);

            var individualStrings = new string[] { $"str{separator}1", $"str{separator}2", $"str{separator}3"};

            var invoiceParser = new InvoiceParser(separator);

            var result = invoiceParser.SplitInvoices(input);

            Assert.IsTrue(individualStrings[0].Equals(result[0]) &&
                          individualStrings[1].Equals(result[1]) &&
                          individualStrings[2].Equals(result[2]));
        }
    }
}
