namespace EasyInvoices.Framework.Providers.Contracts
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public interface IDecimalParser
    {
        decimal? ParseDecimal(string value);
    }
}
