using System.Drawing.Text;
using System.Data.SQLite;

namespace GuideProgram
{
    //when refering to MainPage here use "this"
    public partial class MainPage : Form
    {
        //coordinate/pixel equivalents
        //120W 	197
        //110W 	407
        //100W 	619
        //90W	819
        //80W 	1022
        //70W 	1237

        //50N	0
        //45N	159
        //40N	289
        //35N 	423
        //30N	547
        //25N	700 <-- should be the bottom of the screen, this is unchecked
        public MainPage()
        {

            //start page
            //this must be done before using the database since none of the objects exist before this point
            InitializeComponent();
            this.Size = new Size(1400, 700);
            timer1.Start();

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
                            testDataBox.AppendText(cityName + Environment.NewLine);
                        }
                    }
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
            //the intersection between 45N and 120W
            //screenClock.Location = new Point(197, 159);
            //IT WORKS
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {
            DateTime now = DateTime.Now;
            screenClock.Text = now.ToString("hh:mm:ss");
        }

        private void testDataBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
