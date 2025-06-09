using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace GuideProgram
{
    public class DBMethods
    {
        //TODO: make this a relative path
        public string dbSource = @"Data Source=C:\Users\Brine\source\perltests\Capstone\Map_Database.db;Version=3;";

        /// <summary>
        /// Load cities from the database into a List<>.
        /// </summary>
        /// <returns></returns>
        private List<City> LoadCitiesFromDB()
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
        private List<Road> LoadRoadsFromDB()
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

        //TODO: Look into this more, I don't understand it enough
        //what is Dictionary
        //why not just use a list
        Dictionary<int, List<(int neighborId, double distance)>> _adjacencyList = new Dictionary<int, List<(int neighborId, double distance)>>();

        //put roads and cities into a cache list so there are hopefully no memory problems.
        private List<City> _citiesCache;
        private List<Road> _roadsCache;

        /// <summary>
        /// Get the existing cities list
        /// </summary>
        /// <returns></returns>
        public List<City> GetCities()
        {
            if (_citiesCache == null)
            {
                _citiesCache = LoadCitiesFromDB();
            }
            return _citiesCache;
        }

        /// <summary>
        /// Get the existing roads list
        /// </summary>
        /// <returns></returns>
        public List<Road> GetRoads()
        {
            if (_roadsCache == null)
            {
                _roadsCache = LoadRoadsFromDB();
            }
            return _roadsCache;
        }
    }
}
