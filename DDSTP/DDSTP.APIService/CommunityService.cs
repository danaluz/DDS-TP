using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DDSTP.APIService
{
    public class CommunityService
    {
        const string UrlService = "https://recursos-data.buenosaires.gob.ar/ckan2/comunas/comunas.csv";

        public List<CSVCommunityData> GetAllCommunities()
        {
            var csv = GetCSV(UrlService);
            var lista = new List<CSVCommunityData>();

            //separa las lineas del archivo CSV completo, que ya estaba en csv.
            var records = csv.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

            for (int index = 1; index < records.Length; index++)
            {
                var r = records[index];

                //separa los campos
                var field =r.Split(';');

                if (field.Length != 10)
                {
                    continue;
                }

                //barrio;perimetro;area;comuna;calle_sede;altura_sede;tel_sede;lat_sede;long_sede;geojson
                var CSVC = new CSVCommunityData();
                CSVC.Neighborhood = field[0];
                CSVC.Perimeter = StringToDouble(field[1]);
                CSVC.Area = StringToDouble(field[2]);
                CSVC.CommunityNumber = Convert.ToInt32(field[3]);
                CSVC.HeadquartersStreet = field[4];
                CSVC.HeadquartersNumber = Convert.ToInt32(field[5]);
                CSVC.HeadquartersTelephone = field[6];
                CSVC.Latitude = StringToDouble(field[7]);
                CSVC.Longitude = StringToDouble(field[8]);
                CSVC.GeoJsonString = field[9];

                //agrego a la lista
                lista.Add(CSVC);
            }

            return lista;
        }


        private string GetCSV(string url)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            StreamReader stream = new StreamReader(response.GetResponseStream());
            string results = stream.ReadToEnd();
            stream.Close();

            return results;
        }

        private static double StringToDouble(string value)
        {
            double retVal;
            double.TryParse(value, NumberStyles.Any, new NumberFormatInfo() { NumberDecimalSeparator = "." }, out retVal);

            return retVal;
        }
    }
}
