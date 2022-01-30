using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using System.Windows.Shapes;

namespace introduction_cs_municipalities
{
    /// <summary>
    /// Interaction logic for TableWindow.xaml
    /// </summary>
    public partial class TableWindow : Window
    {
        private Data<string, string, string, string, string>[] dataArray;
        public Data<string, string, string, string, string>[] GetDataArray()
        {
            return dataArray;
        }
        public TableWindow(Data<string, string, string, string, string>[] _dataArray)
        {
            InitializeComponent();
            dataArray = _dataArray;
            DataGrid.Items.Clear();
            DataGrid.ItemsSource = _dataArray;
        }

        private void ShowReport(object sender, RoutedEventArgs e)
        {

        }
    }
}
