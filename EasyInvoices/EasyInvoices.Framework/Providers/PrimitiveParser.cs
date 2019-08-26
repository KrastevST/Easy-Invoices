namespace EasyInvoices.Framework.Providers
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

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
