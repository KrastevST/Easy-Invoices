namespace EasyInvoices.UI.Utils
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public interface IValidator
    {
        bool IsValidInput(string readPath, string sheet, string row, string savepath, string company);
    }
}
