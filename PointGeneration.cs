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

    public class PointGeneration
    {
        private List<(double min, double max)> us_lat = new List<(double min, double max)>
        {
            (25, 30),
            (30, 35),
            (35, 40),
            (40, 45),
            (45, 50)
        };
        private List<(double min, double max)> us_lon = new List<(double min, double max)>
        {
            (-120, -110),
            (-110, -100),
            (-100, -90),
            (-90, -80),
            (-80, -70)
        };

        public static void ShowCapitals(List<Point> points)
        {
            //what am i doing <:(
            PointGeneration pointGen = new PointGeneration();
            DatabaseMethods dbMethods = new DatabaseMethods();

            string src = dbMethods.Map_dbsrc();

            using (var connection = new SQLiteConnection(src))
            {
                connection.Open();
                using (var cmd = new SQLiteCommand("SELECT * FROM cities;", connection))
                {
                    using (var reader  = cmd.ExecuteReader())
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

