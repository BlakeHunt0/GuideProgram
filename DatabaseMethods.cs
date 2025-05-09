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
        string DatabaseLocation = @"Data Source=C:\Users\Brine\source\perltests\Capstone\Map_Database.db;Version=3;";

        //i need to learn how to make this conection method reusable
        //i cant see any effective ways to get into the final while statement to work with the data

        public List<string> ConnectToDatabase(string script, string columnName)
        {
            List<string> columnData = new List<string>();
            using (var connection = new SQLiteConnection(DatabaseLocation))
            {
                connection.Open();
                using (var command = new SQLiteCommand(script, connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string data = reader[columnName].ToString();
                            columnData.Add(data);
                        }
                    }
                }
            }
            return columnData;
        }

        public string Map_dbsrc()
        {
            return DatabaseLocation;
        }
    }
}
