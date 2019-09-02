namespace EasyInvoices.Client.HardCodedProviders
{
    using System;
    using System.Text;
    using EasyInvoices.Framework.Providers.Contracts;
    using Microsoft.Office.Interop.Excel;
    using _Excel = Microsoft.Office.Interop.Excel;

    public class ExcelReader : IReader
    {
        private readonly char separatorChar;
        private readonly string path = "";
        private readonly int startingRow;
        private readonly _Application excel;
        private readonly Workbook wb;
        private readonly Worksheet ws;

        public ExcelReader(string path, int sheet, char separatorCh, int startingRow)
        {
            this.separatorChar = separatorCh;
            this.path = path;
            this.startingRow = startingRow;
            this.excel = new _Excel.Application();
            this.wb = excel.Workbooks.Open(path);
            this.ws = (Worksheet)wb.Worksheets[sheet];
        }

        public string Read()
        {
            int currentRow = this.startingRow;
            var result = new StringBuilder();

            var rowAsString = this.GetRow(currentRow);
            while (rowAsString != null)
            {
                result.Append(separatorChar + rowAsString);
                currentRow++;
                rowAsString = GetRow(currentRow);
            }

            this.Close();

            return result.ToString();
        }

        private void Close()
        {
            this.wb.Close();
        }

        private string GetRow(int row)
        {
            var result = new StringBuilder();
            for (int i = row, j = 1; j <= 5; j++)
            {
                var cell = this.GetCell(i, j);
                if (string.IsNullOrWhiteSpace(cell))
                {
                    // TODO fix this
                    if (j == 1 
                        && string.IsNullOrWhiteSpace(this.GetCell(i, j + 1))
                        && string.IsNullOrWhiteSpace(this.GetCell(i, j + 2))
                        && string.IsNullOrWhiteSpace(this.GetCell(i, j + 3))
                        && string.IsNullOrWhiteSpace(this.GetCell(i, j + 4))
                        )
                    {
                        return null;
                    }
                    //TODO Fix this
                    this.Close();
                    throw new ArgumentNullException("Missing data");
                }
                result.Append(separatorChar + cell);
            }

            return result.ToString();
        }

        private string GetCell(int i, int j)
        {
            if (ws.Cells[i, j].Value2 != null)
            {
                return ws.Cells[i, j].Value2.ToString().Trim();
            }

            return "";
        }
    }
}
