using EasyInvoices.Framework;
using EasyInvoices.Framework.Providers;
using EasyInvoices.Framework.Providers.Contracts;
using EasyInvoices.UI.ReferenceDependantProviders;
using EasyInvoices.UI.Utils;
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
        // TODO - move to separate class
        private const char separator = '/';
        private const string docTemplatePath = "../../Invoice Template.doc";
        private const string fileNameTemplate = "Invoice_{0}_{1}.doc";
        private const string defaultSheet = "1";
        private const string defaultRow = "2";

        public MainWindow()
        {
            InitializeComponent();
        }

        private void SelectFileBtn_Click(object sender, RoutedEventArgs e)
        {
            // TODO - enclose in using
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

        private void SelectDestinationBtn_Click(object sender, RoutedEventArgs e)
        {
            using (var dialog = new System.Windows.Forms.FolderBrowserDialog())
            {
                var result = dialog.ShowDialog();
                selectDestinationValue.Text = dialog.SelectedPath;
            }
        }

        private void GenerateInvoicesBtn_Click(object sender, RoutedEventArgs e)
        {
            var validator = new InputValidator();
            if (!validator.IsValidInput(
                selectFileValue.Text,
                sheetValue.Text,
                rowValue.Text,
                selectDestinationValue.Text,
                companyNameValue.Text))
            {
                return;
            }
            

            string readPath = selectFileValue.Text;
            int sheet = int.Parse(sheetValue.Text);
            int row = int.Parse(rowValue.Text);
            string savePathDir = selectDestinationValue.Text;
            string fullSavePath = $"{savePathDir}\\{fileNameTemplate}";
            string company = companyNameValue.Text;

            IInvoiceParser invParser = new InvoiceParser(separator);
            IDecimalParser primParser = new DecimalParser();
            IDateParser dateParser = new DateParser();
            IReader reader = new ExcelReader(readPath, sheet, row, separator);
            IDocWriter writer = new DocWriter();

            var engine = new Engine(invParser, primParser, dateParser, reader, writer, docTemplatePath, fullSavePath, company);
            engine.Start();

            MessageBox.Show("Invoices created successfully.");

            selectFileValue.Text = string.Empty;
            selectDestinationValue.Text = string.Empty;
            sheetValue.Text = defaultSheet;
            rowValue.Text = defaultRow;
        }

        private void EditTemplateBtn_Click(object sender, RoutedEventArgs e)
        {
            string fullPath;

            if (File.Exists(docTemplatePath))
            {
                fullPath = System.IO.Path.GetFullPath(docTemplatePath);
                System.Diagnostics.Process.Start(fullPath);
            }
            else
            {
                MessageBox.Show("Template file could not be found.");
            }

        }
    }
}
