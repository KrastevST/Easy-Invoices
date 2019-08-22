namespace TempClient
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using EasyInvoices.Framework.Providers;
    using Microsoft.Office.Interop.Excel;
    using _Excel = Microsoft.Office.Interop.Excel;

    public class ExcelReader : IReader
    {
        private const char separatorChar = '/';
        private string path = "";
        private _Application excel;
        private Workbook wb;
        private Worksheet ws;

        public ExcelReader(string path, int sheet)
        {
            this.path = path;
            excel = new _Excel.Application();
            wb = excel.Workbooks.Open(path);
            ws = (Worksheet)wb.Worksheets[sheet];
        }

        public string Read(int startingRow)
        {
            int currentRow = startingRow;
            var result = new StringBuilder();

            var rowAsString = this.GetRow(currentRow);
            while (rowAsString != null)
            {
                result.Append(separatorChar + rowAsString);
                currentRow++;
                rowAsString = GetRow(currentRow);
            }

            return result.ToString();
        }

        public void Close()
        {
            this.wb.Close();
        }

        private string GetRow(int row)
        {
            var result = new StringBuilder();
            for (int i = row, j = 1; j <= 6; j++)
            {
                var cell = this.GetCell(i, j);
                if (string.IsNullOrWhiteSpace(cell))
                {
                    if (j == 1 
                        && string.IsNullOrWhiteSpace(this.GetCell(i, j + 1))
                        && string.IsNullOrWhiteSpace(this.GetCell(i, j + 2))
                        && string.IsNullOrWhiteSpace(this.GetCell(i, j + 3))
                        && string.IsNullOrWhiteSpace(this.GetCell(i, j + 4))
                        && string.IsNullOrWhiteSpace(this.GetCell(i, j + 5))
                        )
                    {
                        return null;
                    }
                    //TODO Fix this
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
                return ws.Cells[i, j].Value2.Trim();
            }

            return "";
        }
    }
}
