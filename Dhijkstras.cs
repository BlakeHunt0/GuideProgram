using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace GuideProgram
{
    public class Dhijkstras
    {


        //TODO: make this a relative path
        public string dbSource = @"Data Source=C:\Users\Brine\source\perltests\Capstone\Map_Database.db;Version=3;";

        //TODO: this gets all of the cities, this needs to be optimized. I will have to talk to Jesse about making sure that I don't make several large lists left uncontroled in ram.

        //the reader will close on its own.
        /// <summary>
        /// Load cities from the database into a List<>.
        /// </summary>
        /// <returns></returns>
        public List<City> LoadCitiesFromDB()
        {
            var cities = new List<City>();

            using (var connection = new SQLiteConnection(dbSource))
            {
                connection.Open();

                string query = "SELECT * FROM Cities;";

                using (var cmd = new SQLiteCommand(query, connection))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            cities.Add(new City
                            {
                                city_id = reader.GetInt32(0),
                                city_name = reader.GetString(1),
                                latitude = reader.GetDouble(2),
                                longitude = reader.GetDouble(3),
                                state = reader.GetString(4),
                                is_capital = reader.GetBoolean(5)
                            });
                        }
                    }
                }
            }

            return cities;
        }

        /// <summary>
        /// Load roads from the database into a List<>.
        /// </summary>
        /// <returns></returns>
        public List<Road> LoadRoadsFromDB()
        {
            var roads = new List<Road>();

            using (var connection = new SQLiteConnection(dbSource))
            {
                connection.Open();

                string query = "SELECT * FROM Roads;";

                using (var cmd = new SQLiteCommand(query, connection))
                {
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            roads.Add(new Road
                            {
                                road_id = reader.GetInt32(0),
                                start_city_id = reader.GetString(1),
                                end_city_id = reader.GetString(2),
                                distance = reader.GetDouble(3)
                            });
                        }
                    }
                }
            }

            return roads;
        }

        //I could make an adjacencies method to specifically connect the lists in code. The roads already have foreign keys connected to the cities. 
        //an adjacencies method could give me better directional controls for roads based one what i have seen online.
    }
}
