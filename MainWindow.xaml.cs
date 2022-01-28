using Microsoft.Win32;
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

namespace introduction_cs_municipalities
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // The lines of all csv document
        public const int AllLines = 1127;
        // Lines to read of the document
        public const int LinesToRead = 1122;
        Data<string,string,string,string,string>[] dataArray = new Data<string, string, string, string, string>[LinesToRead];
        public MainWindow()
        {
            InitializeComponent();
        }

        /*
         * Event of load button
         * Load a csv file using the class Data,the data save in an array
         */
        private void LoadDataButton(object sender, RoutedEventArgs e)
        {
            string[] csv_data = new string[AllLines];
            OpenFileDialog openfileDialog = new OpenFileDialog();
            if (openfileDialog.ShowDialog() == true)
            {
                openfileDialog.Title = "Select a File";
                openfileDialog.Filter = "csv files (*.csv)|*.csv|All files (*.*)|*.*";
                openfileDialog.InitialDirectory = @"introduction-cs-municipalities/data";
                csv_data = File.ReadAllLines(openfileDialog.FileName);
            }

            /*
             * Create a object data in each line of the csv_data array
             * put the objects in the dataArray
             */
            for (int i = 0; i < LinesToRead; i++)
            {
                var dataSplit = csv_data[i + 1].Split(",");
                Data<string, string, string, string, string> data;
                data = new Data<string, string, string, string, string>(dataSplit[0], dataSplit[1], dataSplit[2], dataSplit[3], dataSplit[4]);
                dataArray[i] = data;
            }
        }

        private void Exit(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
