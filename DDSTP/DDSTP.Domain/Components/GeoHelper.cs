using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;
using System.Globalization;

namespace DDSTP.Domain.Components
{
    [NotMapped]
    public class GeoHelper
    {
        public const int SridGoogleMaps = 4326; // SridGps
        public const int SridCustomMap = 3857; // Srid2dPlane

        public static DbGeography PointFromLatLng(double lat, double lng)
        {
            return DbGeography.PointFromText(
                "POINT("
                + DoubleToString(lng) + " "
                + DoubleToString(lat) + ")",
                SridGoogleMaps);
        }

        public static DbGeography PolygonFromLatLng(List<Point> p)
        {
            string texto = "";

            foreach (var d in p)
            {
                if (!string.IsNullOrEmpty(texto))
                    texto += ",";

                texto += DoubleToString(d.Longitude) + " " + DoubleToString(d.Latitude);
            }

            return DbGeography.PolygonFromText(
                "POLYGON(("
                + texto + "))",
                SridGoogleMaps);
        }

        public static string DoubleToString(double value)
        {
            return value.ToString(new NumberFormatInfo() { NumberDecimalSeparator = "." });
        }

        public static double StringToDouble(string value)
        {
            double retVal;
            double.TryParse(value, NumberStyles.Any, new NumberFormatInfo() { NumberDecimalSeparator = "." }, out retVal);

            return retVal;
        }
    }
}
