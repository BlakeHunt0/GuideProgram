using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace GuideProgram
{
    public class DatabaseMethods
    {
        public void ConnectToDatabase()
        {
            //I need a better way to work with this
            //connect to database
            string DatabaseConnection = @"Data Source=C:\Users\Brine\source\perltests\Capstone\Map_Database.db;Version=3;";
            using (var connection = new SQLiteConnection(DatabaseConnection))
            {
                connection.Open();
                string allCities = "SELECT * FROM cities;";
                using (var command = new SQLiteCommand(allCities, connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string cityName = reader["city_name"].ToString();
                        }
                    }
                }
            }
        }

        public string mapDatabase()
        {
            string DatabaseConnection = @"Data Source=C:\Users\Brine\source\perltests\Capstone\Map_Database.db;Version=3;";
            return DatabaseConnection;
        }
    }
}
