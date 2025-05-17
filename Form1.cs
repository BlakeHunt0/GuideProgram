using System.Drawing.Text;
using System.Data.SQLite;

namespace GuideProgram
{
    //when refering to MainPage here use "this"
    public partial class MainPage : Form
    {
        public MainPage()
        {
            InitializeComponent();
            this.Size = new Size(1400, 700);
            this.TopMost = false;
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
            string inlat = latbox.Text;
            string inlon = lonbox.Text;

            double tlat = Convert.ToDouble(inlat);
            double tlon = Convert.ToDouble(inlon);

            PointGeneration pointGen = new PointGeneration();

            Point citpoint = pointGen.PlacePoint(tlat, tlon);

            testbox.Text =
                "input lat: " + inlat + "\n" +
                "input lon: " + inlon + "\n" +
                "lat pix: " + citpoint.X + "\n" +
                "lon pix: " + citpoint.Y + "\n";

            hw.Location = new Point(citpoint.X, citpoint.Y);
        }
    }
}
