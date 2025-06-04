using System.Drawing.Text;
using System.Data.SQLite;

namespace GuideProgram
{
    //when refering to MainPage here use "this"
    public partial class MainPage : Form
    {
        public MainPage()
        {
            //get cities and roads from the database
            Dhijkstras dhijkstras = new Dhijkstras();
            List<City> cities = dhijkstras.LoadCitiesFromDB();
            List<Road> roads = dhijkstras.LoadRoadsFromDB();

            //start the form
            InitializeComponent();

            // set the form properties
            this.Size = new Size(1400, 700);
            this.TopMost = false;

            //start the clock
            timer1.Start();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

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

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //LAT IS Y, LON IS X

            //this is meant to test the PointGeneration class
            //point generation does not work. I was not able to get help from a  tutor.
            //graphically i cannot show this to anyone without explination, as it does not show anyting to the user.
            string inlat = latbox.Text;
            string inlon = lonbox.Text;

            double tlat = Convert.ToDouble(inlat);
            double tlon = Convert.ToDouble(inlon);

            PointGeneration pointGen = new PointGeneration();

            Point citpoint = pointGen.PlacePoint(tlat, tlon);

            testbox.Text =
                "input lat: " + inlat + "\n" +
                "input lon: " + inlon + "\n" +
                "lat pix: " + citpoint.Y + "\n" +
                "lon pix: " + citpoint.X + "\n";

            hw.Location = new Point(citpoint.Y, citpoint.X);
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void testbox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
