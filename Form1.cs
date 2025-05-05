using System.Drawing.Text;

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
        //TODO: im tired, 45 = 159, 40 = 289. if the coordinates are 43 put it the correct amount in between 159 and 289
        //we could subtract the difference of the lesser coordinate from the larger coordinate line we have, then place the line ate that new lesser point
        //what am i doing.
        //have to find the ratio between my pixel count and the real world coordinates on a map that is stretched
        public MainPage()
        {
            InitializeComponent();
            this.Size = new Size(1400, 700);
            timer1.Start();
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
    }
}
