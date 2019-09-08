namespace EasyInvoices.Framework.Providers
{
    using EasyInvoices.Framework.Providers.Contracts;
    using System;
    using System.Globalization;

    public class DecimalParser : IDecimalParser
    {
        public decimal ParseDecimal(string value)
        {

            if (!decimal.TryParse(
                value.Replace(",", "").Replace(".", "").Replace(" ", ""), NumberStyles.Number, CultureInfo.InvariantCulture,
                out decimal result))
            {
                // TODO - fix this
                throw new ArgumentNullException();
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
