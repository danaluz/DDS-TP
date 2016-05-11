using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace DDSTP.APIService
{
    public class CSVCommunityData
    {
        private string _geoJsonString;

        public string Neighborhood { get; set; }
        public double Perimeter { get; set; }
        public double Area { get; set; }
        public int CommunityNumber { get; set; }
        public string HeadquartersStreet { get; set; }
        public int HeadquartersNumber { get; set; }
        public string HeadquartersTelephone { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }

        public string GeoJsonString
        {
            get { return _geoJsonString; }
            set
            {
                _geoJsonString = value;
                _geoJsonString = _geoJsonString.Replace("\"\"", "\"");
                _geoJsonString = _geoJsonString.Trim('"');
                //conversion de string de tipo Json a un objeto de C#
                GeoJson = JsonConvert.DeserializeObject<GeoJson>(_geoJsonString);
            }
        }

        public GeoJson GeoJson { get; set; }

    }
}
