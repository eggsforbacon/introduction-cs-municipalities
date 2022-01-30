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
using System.Windows.Shapes;

namespace introduction_cs_municipalities
{
    /// <summary>
    /// Interaction logic for Report.xaml
    /// </summary>
    public partial class Report : Window
    {
        static Data<string, string, string, string, string>[] dataArray = default!;

        public Report(Data<string, string, string, string, string>[] _dataArray)
        {
            dataArray = _dataArray;
            InitializeComponent();
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

        public string Times { get; set; } = default!;
    }

    public class Localities
    {
        const double INCREMENT = 0.5;
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

            municipality.Times = "(" + municipality.Quantity / INCREMENT + " " + municipality.Type.ToLower() + "s )";
            isle.Times = "(" + isle.Quantity / INCREMENT + " " + isle.Type.ToLower() + "s )";
            nonMunicipalityArea.Times = "(" + nonMunicipalityArea.Quantity / INCREMENT + " " + nonMunicipalityArea.Type.ToLower() + "s )";

            LocalitiesRet.Add(municipality);
            LocalitiesRet.Add(isle);
            LocalitiesRet.Add(nonMunicipalityArea);
            return LocalitiesRet.ToList();
        }

    }
}
