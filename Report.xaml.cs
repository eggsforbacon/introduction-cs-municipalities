﻿using System;
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
    /// Interaction logic for Report.xaml
    /// </summary>
    public partial class Report : Window 
    { 
        static Data<string, string, string, string, string>[] dataArray = default!;

        public Report(Data<string, string, string, string, string>[] _dataArray, int[] quants)
        {
            dataArray = _dataArray;

            InitializeComponent();

            int municipalitiesWidth = (int)((Locality)lBox.Items[0]).Quantity * 2;
            int islesWidth = (int)((Locality) lBox.Items[1]).Quantity;
            int nonMunipAreasWidth = (int)((Locality) lBox.Items[2]).Quantity * 2;

            Mun.Content = municipalitiesWidth + " localidades";
            Isle.Content = islesWidth + " localidades";
            nMun.Content = nonMunipAreasWidth + " localidades";

        }

        public static Data<string, string, string, string,string>[] GetData()
        {
            return dataArray;
        }
    }

    public class Locality
    {
        public const double INCREMENT = 0.5;
        public string Type { get; set; } = default!;
        public double Quantity { get; set; }
    }

    public class Localities
    {
        const double INCREMENT = 0.5;

        public static string munString = "Me mide", isleString = " más ", nMunString = " que a Kennet";
        public List<Locality> LocalitiesList
        {
            get
            {
                return GetLocalitiesList();
            }

            set
            {

            }
        }
        
        List<Locality> LocalitiesRet = new List<Locality>();
        Data<string, string, string, string, string>[] dataArray = Report.GetData();
        
        Locality municipality = new Locality() { Type = "Municipio", Quantity = 0};
        Locality isle = new Locality() { Type = "Isla", Quantity = 0};
        Locality nonMunicipalityArea = new Locality() { Type = "Área no municipalizada", Quantity = 0};

        public List<Locality> GetLocalitiesList()
        {

            foreach (Data<string, string, string, string, string> data in dataArray)
            {
                if (data.e.Equals(municipality.Type))
                {
                    municipality.Quantity += INCREMENT;
                }
                else if (data.e.Equals(isle.Type))
                {
                    isle.Quantity += INCREMENT;
                }
                else if (data.e.Equals(nonMunicipalityArea.Type))
                {
                    nonMunicipalityArea.Quantity += INCREMENT;
                }
            }

            if (municipality.Quantity < 1) municipality.Quantity = 1;
            if (isle.Quantity < 1) isle.Quantity = 1;
            if (nonMunicipalityArea.Quantity < 1) nonMunicipalityArea.Quantity = 1;

            
            LocalitiesRet.Add(municipality);
            LocalitiesRet.Add(isle);
            LocalitiesRet.Add(nonMunicipalityArea);
            return LocalitiesRet.ToList();
        }

    }
}
