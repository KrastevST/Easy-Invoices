namespace EasyInvoices.Framework.Providers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public interface IPrimitiveParser
    {
        decimal parseDecimal(string value);
    }
}
