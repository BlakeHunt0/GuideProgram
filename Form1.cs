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
            DBMethods dhijkstras = new DBMethods();
            List<City> cities = dhijkstras.GetCities();
            List<Road> roads = dhijkstras.GetRoads();

            //start the form
            //anything realated to the design of the page has to go bellow this, or you get a null object referance.
            InitializeComponent();

            testbox.Text = "Cities Loaded: " + cities.Count + "\n" + "Roads Loaded: " + roads.Count + "\n";

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
            //LAT MOVES ON THE Y AXIS, LON MOVES ON THE X AXIS

            //get lat/lon
            string inlat = latbox.Text;
            string inlon = lonbox.Text;

            //convert lat/lon to double
            double tlat = Convert.ToDouble(inlat);
            double tlon = Convert.ToDouble(inlon);

            //create a point generation object
            PointGeneration pointGen = new PointGeneration();

            //place the point using the lat/lon
            Point citpoint = pointGen.PlacePoint(tlat, tlon);

            //display output for testing
            //lat displays x because it is the virtical MARKERS on the x axis
            //lon displays y because it is the horizontal MARKERS on the y axis
            testbox.Text =
                "input lat: " + inlat + "\n" +
                "input lon: " + inlon + "\n" +
                "lat pix: " + citpoint.X + "\n" +
                "lon pix: " + citpoint.Y + "\n";

            //make the dot to display
            MakePoint((int)citpoint.Y, (int)citpoint.X);
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void testbox_TextChanged(object sender, EventArgs e)
        {

        }

        private void MakePoint(int lat, int lon)
        {
            PictureBox dot = new PictureBox();

            //why is it saved like that?
            dot.Image = Image.FromFile("Point.jpg.png");

            //we need to resize the image or there is a large black box
            dot.SizeMode = PictureBoxSizeMode.CenterImage;
            dot.Size = new Size(5, 5);

            //ok so it is the right size but still in the wrong spot

            this.Controls.Add(dot);

            dot.Location = new Point(lon, lat);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
