using System;
using System.Collections.Generic;
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
        public MainWindow()
        {
            InitializeComponent();
        }

        private void SelectFileBtn_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog
            {
                DefaultExt = ".xlsx",
                Filter = "Excel Files|*.xls;*.xlsx;*.xlsm"
            };

            bool? result = dlg.ShowDialog();

            if (result == true)
            {
                selectFileValue.Text = dlg.FileName;
            }

        }

        private void ChoseDestinationBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void GenerateInvoicesBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void EditTemplateBtn_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
