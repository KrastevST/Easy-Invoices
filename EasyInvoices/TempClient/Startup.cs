namespace TempClient
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Startup
    {
        static void Main()
        {
            var er = new ExcelReader(@"C:\Users\Wayfahrer\Desktop\2019 Financials IT&F.xlsx", 1);
            
        }
    }
}
