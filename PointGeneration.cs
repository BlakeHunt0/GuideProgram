using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Text;
using System.Data.SQLite;
using System.Runtime.CompilerServices;

namespace GuideProgram
{
    public class PointGeneration
    {
        //latitude are the lines on the x axis
        //lat lines are horizontal
        //6 lat lines encompass the US, from Canada to Mexixo

        //longitude are the lines on the y axis
        //lon lines are vertical
        //8 lon lines encompass the US vertically, from the Atlantic to the Pacific

        //x pixel count for latitude
        private List<(int latitude, int pixel)> US_latToPix = new List<(int latitude, int pixel)>
        {
            //there are six lat lines here
            (50, 0),
            (45, 160),
            (40, 289),
            (35, 423),
            (30, 547),
            (25, 700)
        };

        //y pixel count for longitude
        private List<(int longitude, int pixel)> US_lonToPix = new List<(int longitude, int pixel)>
        {
            //there are 8 lon lines here
            (-130, 0),
            (-120, 197),
            (-110, 408),
            (-100, 624),
            (-90, 818),
            (-80, 1022),
            (-70, 1236),
            (-60, 1400)
        };

        /// <summary>
        /// Gives you a pixel coordinate based on latitude and longitude. Returns a Point.
        /// </summary>
        /// <param name="lat"></param>
        /// <param name="lon"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public Point PlacePoint(double lat, double lon)
        {
            //point pixel coordinates
            double latpix = 0;
            double lonpix = 0;

            //find min/max of the lists
            int minLat = US_latToPix.Min(p => p.latitude);
            int maxLat = US_latToPix.Max(p => p.latitude);

            int minLon = US_lonToPix.Min(p => p.longitude);
            int maxLon = US_lonToPix.Max(p => p.longitude);

            //throw exception if out of range
            if (lat < minLat || lat > maxLat)
            {
                throw new ArgumentOutOfRangeException("Latitude is out of range.");
            }
            if (lon < minLon || lon > maxLon)
            {
                throw new ArgumentOutOfRangeException("Longitude is out of range.");
            }

            //find lat pixel coordinates
            for (int i = 0; i < US_latToPix.Count - 1; i++)
            {
                if (lat <= US_latToPix[i].latitude && lat >= US_latToPix[i + 1].latitude)
                {
                    //relative position between two known lat lines
                    double relpos = ((lat - US_latToPix[i].latitude) / (US_latToPix[i + 1].latitude - US_latToPix[i].latitude));
                    //find the pixel equivalent of the relative position
                    latpix = (US_latToPix[i].pixel + (US_latToPix[i + 1].pixel - US_latToPix[i].pixel) * relpos);

                    break;
                }
            }

            //find lon pixel coordinates
            for (int i = 0; i < US_lonToPix.Count - 1; i++)
            {
                if (lon >= US_lonToPix[i].longitude && lon <= US_lonToPix[i + 1].longitude)
                {
                    //relative position between two known lon lines
                    double relpos = ((lon - US_lonToPix[i].longitude) / (US_lonToPix[i + 1].longitude - US_lonToPix[i].longitude));
                    //find the pixel equivalent of the relative position
                    lonpix = (US_lonToPix[i].pixel + (US_lonToPix[i + 1].pixel - US_lonToPix[i].pixel) * relpos);

                    break;
                }
            }

            //return the point with the pixel coordinates
            return new Point((int)latpix, (int)lonpix);
        }

        //TODO: this is completely outdated, I need to connect it to the cities list, find the cities with a 1 boolean value in is_capital, then get their lat/lon and place those points with the place point method.
        public static void ShowCapitals(List<Point> points)
        {
            PointGeneration pointGen = new PointGeneration();
            DBMethods dhijkstras = new DBMethods();

            string src = dhijkstras.dbSource;

            using (var connection = new SQLiteConnection(src))
            {
                connection.Open();
                using (var cmd = new SQLiteCommand("SELECT * FROM cities;", connection))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string city = reader["city_name"].ToString();
                            string state = reader["state"].ToString();
                            int lat = Convert.ToInt32(reader["latitude"]);
                            int lon = Convert.ToInt32(reader["longitude"]);

                            //get latlon (done)
                            //create point with city name
                            //find decimal percentage between two lat lines
                            //move point to that percentage
                            //find decimal percentage between two lon lines
                            //move point to that percentage

                        }
                    }
                }
            }
        }
    }
}

