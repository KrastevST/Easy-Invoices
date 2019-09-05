using EasyInvoices.Framework;
using EasyInvoices.Framework.Providers;
using EasyInvoices.Framework.Providers.Contracts;
using EasyInvoices.UI.HardCodedProviders;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace EasyInvoices.UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private const char separator = '/';
        private const string invoiceTemplatePath = "../../Invoice Template.doc";
        private const string fileNameTemplate = "Invoice_{0}_{1}.doc";
        private const string defaultSheet = "1";
        private const string defaultRow = "2";

        public MainWindow()
        {
            InitializeComponent();
        }

        private void SelectFileBtn_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new Microsoft.Win32.OpenFileDialog
            {
                DefaultExt = ".xlsx",
                Filter = "Excel Files|*.xls;*.xlsx;*.xlsm"
            };

            bool? result = dialog.ShowDialog();

            if (result == true)
            {
                selectFileValue.Text = dialog.FileName;
            }
        }

        private void ChoseDestinationBtn_Click(object sender, RoutedEventArgs e)
        {
            using (var dialog = new System.Windows.Forms.FolderBrowserDialog())
            {
                var result = dialog.ShowDialog();
                chooseDestinationValue.Text = dialog.SelectedPath;
            }
        }

        private void GenerateInvoicesBtn_Click(object sender, RoutedEventArgs e)
        {
            string readPath = selectFileValue.Text;
            // TODO - validate
            int sheet = int.Parse(sheetValue.Text);
            // TODO - validate
            int row = int.Parse(rowValue.Text);
            string saveDirectory = chooseDestinationValue.Text;
            string fullSavePath = $"{saveDirectory}\\{fileNameTemplate}";
            // TODO - validate (no unalowed chars for filenames)
            string company = companyNameValue.Text;

            IInvoiceParser invParser = new InvoiceParser(separator);
            IPrimitiveParser primParser = new PrimitiveParser();
            IDateParser dateParser = new DateParser();
            IReader reader = new ExcelReader(readPath, sheet, row, separator);
            IWriterToWord writer = new WriterToWord();

            var engine = new Engine(invParser, primParser, dateParser, reader, writer, invoiceTemplatePath, fullSavePath, company);
            engine.Start();


            selectFileValue.Text = string.Empty;
            chooseDestinationValue.Text = string.Empty;
            sheetValue.Text = defaultSheet;
            rowValue.Text = defaultRow;
        }

        private void EditTemplateBtn_Click(object sender, RoutedEventArgs e)
        {
            string fullPath;

            if (File.Exists(invoiceTemplatePath))
            {
                fullPath = System.IO.Path.GetFullPath(invoiceTemplatePath);
                System.Diagnostics.Process.Start(fullPath);
            }
            else
            {
                MessageBox.Show("Template file could not be found.");
            }

        }
    }
}
