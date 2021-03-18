using System;
using System.Text;
using Bytes2you.Validation;
using EasyInvoices.Framework.Providers.Contracts;
using Microsoft.Office.Interop.Excel;
using _Excel = Microsoft.Office.Interop.Excel;

namespace EasyInvoices.UI.ReferenceDependantProviders
{
    public class ExcelReader : IReader
    {
        private readonly char separatorChar;
        private readonly int startingRow;
        private readonly _Application excel;
        private readonly Workbook wb;
        private readonly Worksheet ws;

        public ExcelReader(string readFilePath, int sheet, int startingRow, char separatorCh)
        {
            Guard.WhenArgument(readFilePath, "readFilePath").IsNullOrWhiteSpace().Throw();
            Guard.WhenArgument(sheet, "sheet").IsLessThan(1).Throw();
            Guard.WhenArgument(startingRow, "startingRow").IsLessThan(1).Throw();

            this.excel = new _Excel.Application();
            this.wb = excel.Workbooks.Open(readFilePath);
            this.ws = (Worksheet)wb.Worksheets[sheet];
            this.startingRow = startingRow;
            this.separatorChar = separatorCh;
        }

        public string Read()
        {
            int currentRow = this.startingRow;
            var result = new StringBuilder();

            var rowAsString = this.GetRowAsString(currentRow);
            while (rowAsString != null)
            {
                result.Append(separatorChar + rowAsString);
                currentRow++;
                rowAsString = GetRowAsString(currentRow);
            }

            this.CloseFileConnection();

            return result.ToString();
        }

        private void CloseFileConnection()
        {
            this.wb.Close();
            this.excel.Quit();
            System.Runtime.InteropServices.Marshal.ReleaseComObject(excel);
        }

        private string GetRowAsString(int row)
        {
            Guard.WhenArgument(row, "row").IsLessThan(1).Throw();

            var result = new StringBuilder();
            for (int i = row, j = 1; j <= 5; j++)
            {
                string cell = this.ReadCell(i, j);

                if (string.IsNullOrWhiteSpace(cell))
                {
                    if (j == 1 
                        && string.IsNullOrWhiteSpace(this.ReadCell(i, j + 1))
                        && string.IsNullOrWhiteSpace(this.ReadCell(i, j + 2))
                        && string.IsNullOrWhiteSpace(this.ReadCell(i, j + 3))
                        && string.IsNullOrWhiteSpace(this.ReadCell(i, j + 4))
                        )
                    {
                        return null;
                    }
                    this.CloseFileConnection();
                    throw new ArgumentNullException("Data is incomplete", "row");
                }

                result.Append(separatorChar + cell);
            }

            return result.ToString();
        }

        private string ReadCell(int i, int j)
        {
            if (ws.Cells[i, j].Value2 != null)
            {
                return ws.Cells[i, j].Value2.ToString().Trim();
            }

            return "";
        }
    }
}
