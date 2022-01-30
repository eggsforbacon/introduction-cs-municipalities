using System;
using System.Collections;
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
            fillComboBox(_dataArray);
            
        }

        private void fillComboBox(Data<string, string, string, string, string>[] _dataArray)
        {
            ArrayList comboOption = new ArrayList();
            Boolean added = false;
            for (int i = 0; i < _dataArray.Length; i++)
            {
                added = false;
                for (int j = 0; j < comboOption.Count && !added; j++)
                {
                    if (_dataArray[i].c == comboOption[j] as string)
                    {
                        added = true;
                    }
                }

                if (!added)
                {
                    comboOption.Add(_dataArray[i].c);
                }
            }
            foreach (var item in comboOption)
            {
                ComboBox.Items.Add(item);
            }
        }
        private void ShowReport(object sender, RoutedEventArgs e)
        {

        }
    }
}
