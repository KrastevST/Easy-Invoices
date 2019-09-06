namespace EasyInvoices.Framework.Providers
{
    using EasyInvoices.Framework.Providers.Contracts;
    using System.Globalization;

    public class DecimalParser : IDecimalParser
    {
        public decimal? ParseDecimal(string value)
        {
            decimal result;

            if (!decimal.TryParse(value.Replace(",", "").Replace(".", "").Replace(" ", ""), NumberStyles.Number, CultureInfo.InvariantCulture, out result))
            {
                return null;
            }

            var splitValue = value.Split(',', '.');
            int numsAfterDelimiter = splitValue[splitValue.Length - 1].Length;

            for (int i = 0; i < numsAfterDelimiter; i++)
            {
                result /= 10;
            }

            return result;
        }
    }
}
