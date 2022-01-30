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
            FillComboBox();
            
        }

        private void FillComboBox()
        {
            ArrayList comboOption = new ArrayList();
            Boolean added = false;
            ComboBox.Items.Add("NO FILTER");
            for (int i = 0; i < GetDataArray().Length; i++)
            {
                added = false;
                for (int j = 0; j < comboOption.Count && !added; j++)
                {
                    if (GetDataArray()[i].c == comboOption[j] as string)
                    {
                        added = true;
                    }
                }

                if (!added)
                {
                    comboOption.Add(GetDataArray()[i].c);
                }
            }
            foreach (var item in comboOption)
            {
                ComboBox.Items.Add(item);
            }
        }

        private void SelectionChange(object sender, SelectionChangedEventArgs e)
        {
            if(ComboBox.SelectedItem.Equals("NO FILTER"))
            {
                DataGrid.ItemsSource = GetDataArray();
            }
            else
            {
                ArrayList tempDeparment = new ArrayList();
                foreach (var item in GetDataArray())
                {
                    if (item.c.Equals(ComboBox.SelectedItem))
                    {
                        tempDeparment.Add(item);
                    }
                }
                DataGrid.ItemsSource = tempDeparment;
            }
        }

        private void ShowReport(object sender, RoutedEventArgs e)
        {
            Report report = new Report(dataArray);
            report.Owner = this;
            report.ShowDialog();
        }
    }
}
