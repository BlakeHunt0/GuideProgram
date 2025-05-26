using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Text;
using System.Data.SQLite;

namespace GuideProgram
{
    //ISSUES:
    //latitude doesn't seem to be going to the right location, it is placed very low when you input centralia's lat coordintates. It appears to be around 150, but should be at 138 which is the number it gets, but the actual object is being placed at ~150.
    //longitude doesn't work at all, I put in -122.95, which is between -130 and -60, but it doesn't see it as being in this range
    public class PointGeneration
    {
        //latitude is the horrizonatal lines (i messed this up originally)
        //x pixel count for latitude
        private List<(int latitude, int pixel)> US_latToPix = new List<(int latitude, int pixel)>
        {
            (45, 160),
            (40, 289),
            (35, 423),
            (30, 547)
        };
        //y pixel count for longitude
        private List<(int longitude, int pixel)> US_lonToPix = new List<(int longitude, int pixel)>
        {
            (-130, 0),
            (-120, 197),
            (-110, 408),
            (-100, 624),
            (-90, 818),
            (-80, 1022),
            (-70, 1236),
            (-60, 1400)
        };

        public Point PlacePoint(double lat, double lon)
        {
            double latpix = 0;
            double lonpix = 0;

            //longitude has worked fine this entire time
            //I have been trying to fix the wrong part of the code

            int i = 0;
            while (latpix == 0)
            {
                //make sure it is in range
                if (lat >= 30 && lat <= 45)
                {
                    //got error "index was out of range when 40, 35.89 was input
                    if (lat >= US_latToPix[i].latitude && lat <= US_latToPix[i + 1].latitude)
                    {
                        double relpos = ((lat - US_latToPix[i].latitude) / (US_latToPix[i + 1].latitude - US_latToPix[i].latitude));
                        latpix = (US_latToPix[i].pixel + (US_latToPix[i + 1].pixel - US_latToPix[i].pixel) * relpos);
                    }
                    else
                    {
                        i++;
                    }
                }
                //need to make an out of range error/alert
                else
                {
                    latpix = 10;
                }
            }
            i = 0;
            while (lonpix == 0)
            {
                if (lon >= -130 && lon <= -60)
                {
                    if (lon >= US_lonToPix[i].longitude && lon <= US_lonToPix[i + 1].longitude)
                    {
                        double relpos = ((lon - US_lonToPix[i].longitude) / (US_lonToPix[i + 1].longitude - US_lonToPix[i].longitude));
                        lonpix = (US_lonToPix[i].pixel + (US_lonToPix[i + 1].pixel - US_lonToPix[i].pixel) * relpos);
                    }
                    else
                    {
                        i++;
                    }
                }
                else
                {
                    lonpix = 10;
                }

            }

            Point point = new Point((int)latpix, (int)lonpix);
            return point;
        }

        //TODO: this is completely outdated, I need to connect it to the cities list, find the cities with a 1 boolean value in is_capital, then get their lat/lon and place those points with the place point method.
        public static void ShowCapitals(List<Point> points)
        {
            PointGeneration pointGen = new PointGeneration();
            Dhijkstras dhijkstras = new Dhijkstras();

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

