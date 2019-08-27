namespace EasyInvoices.Framework.Providers
{
    using EasyInvoices.Framework.Providers.Contracts;
    using System.Globalization;

    public class PrimitiveParser : IPrimitiveParser
    {
        public decimal parseDecimal(string value)
        {
            decimal result;
            decimal.TryParse(value, NumberStyles.Any, CultureInfo.CurrentCulture, out result);
            decimal.TryParse(value, NumberStyles.Any, CultureInfo.InvariantCulture, out result);
            decimal.TryParse(value, NumberStyles.Any, CultureInfo.GetCultureInfo("en-GB"), out result);

            return result;
        }
    }
}
