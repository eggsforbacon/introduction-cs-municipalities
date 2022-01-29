using Microsoft.Win32;
using System.Collections.Generic;
using System.IO;
using System.Windows;

namespace introduction_cs_municipalities
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

        private void LoadDataButton(object sender, RoutedEventArgs e)
        {
            IEnumerable<string> csv_data = new List<string>();
            OpenFileDialog openfileDialog = new OpenFileDialog();
            if (openfileDialog.ShowDialog() == true)
            {
                openfileDialog.Title = "Select a File";
                openfileDialog.Filter = "csv files (*.csv)|*.csv|All files (*.*)|*.*";
                openfileDialog.InitialDirectory = @"introduction-cs-municipalities/data";
                csv_data = File.ReadLines(openfileDialog.FileName);
            }

            foreach (string item in csv_data)
            {
                System.Diagnostics.Debug.WriteLine(item);
            }
        }

        private void Exit(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
