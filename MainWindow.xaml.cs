﻿using Microsoft.Win32;
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
        // The lines of all csv document
        public const int AllLines = 1127;
        // Lines to read of the document
        public const int LinesToRead = 1121;
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


            int[] quant = {0, 0, 0};
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

                if (dataSplit[4].Equals("Municipio")) quant[0]++;
                else if (dataSplit[4].Equals("Isla")) quant[1]++;
                else if (dataSplit[4].Equals("Área no municipalizada")) quant[2]++;

                dataArray[i] = data;
            }

            TableWindow tableWindow = new TableWindow(dataArray, quant);
            this.Close();
            tableWindow.Show();
        }

        private void Exit(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
