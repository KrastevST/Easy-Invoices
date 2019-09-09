namespace EasyInvoices.Framework.Providers
{
    using Bytes2you.Validation;
    using EasyInvoices.Framework.Providers.Contracts;
    using System;
    using System.Globalization;

    public class DecimalParser : IDecimalParser
    {
        public decimal ParseDecimal(string value)
        {
            Guard.WhenArgument(value, "value").IsNullOrWhiteSpace().Throw();

            if (decimal.TryParse(
                value.Replace(",", "").Replace(".", "").Replace(" ", ""), NumberStyles.Number, CultureInfo.InvariantCulture,
                out decimal result) == false)
            {
                throw new ArgumentException("value is not a number", "value");
            }

            var splitValue = value.Split( ',', '.' );
            int numsAfterDelimiter = splitValue[splitValue.Length - 1].Length;

            if (splitValue.Length == 1)
            {
                numsAfterDelimiter = 0;
            }

            for (int i = 0; i < numsAfterDelimiter; i++)
            {
                result /= 10;
            }

            return result;
        }
    }
}
