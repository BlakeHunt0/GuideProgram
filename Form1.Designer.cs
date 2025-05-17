namespace GuideProgram
{
    partial class MainPage
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainPage));
            screenClock = new Label();
            exitButton = new Button();
            timer1 = new System.Windows.Forms.Timer(components);
            graphButton = new Button();
            hw = new RichTextBox();
            lonbox = new TextBox();
            latbox = new TextBox();
            label1 = new Label();
            label2 = new Label();
            testbox = new RichTextBox();
            SuspendLayout();
            // 
            // screenClock
            // 
            resources.ApplyResources(screenClock, "screenClock");
            screenClock.BackColor = SystemColors.ActiveCaptionText;
            screenClock.FlatStyle = FlatStyle.Flat;
            screenClock.ForeColor = Color.LimeGreen;
            screenClock.Name = "screenClock";
            screenClock.Click += label1_Click;
            // 
            // exitButton
            // 
            resources.ApplyResources(exitButton, "exitButton");
            exitButton.BackColor = Color.Black;
            exitButton.FlatAppearance.BorderSize = 0;
            exitButton.ForeColor = Color.LimeGreen;
            exitButton.Name = "exitButton";
            exitButton.UseVisualStyleBackColor = false;
            exitButton.Click += exitButton_Click;
            // 
            // timer1
            // 
            timer1.Interval = 1000;
            timer1.Tick += timer1_Tick_1;
            // 
            // graphButton
            // 
            resources.ApplyResources(graphButton, "graphButton");
            graphButton.Name = "graphButton";
            graphButton.UseVisualStyleBackColor = true;
            graphButton.Click += button1_Click;
            // 
            // hw
            // 
            resources.ApplyResources(hw, "hw");
            hw.Name = "hw";
            // 
            // lonbox
            // 
            resources.ApplyResources(lonbox, "lonbox");
            lonbox.Name = "lonbox";
            // 
            // latbox
            // 
            resources.ApplyResources(latbox, "latbox");
            latbox.Name = "latbox";
            latbox.TextChanged += textBox2_TextChanged;
            // 
            // label1
            // 
            resources.ApplyResources(label1, "label1");
            label1.ForeColor = SystemColors.ButtonFace;
            label1.Name = "label1";
            // 
            // label2
            // 
            resources.ApplyResources(label2, "label2");
            label2.ForeColor = SystemColors.ButtonFace;
            label2.Name = "label2";
            // 
            // testbox
            // 
            resources.ApplyResources(testbox, "testbox");
            testbox.Name = "testbox";
            // 
            // MainPage
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            ControlBox = false;
            Controls.Add(testbox);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(latbox);
            Controls.Add(lonbox);
            Controls.Add(hw);
            Controls.Add(graphButton);
            Controls.Add(exitButton);
            Controls.Add(screenClock);
            Cursor = Cursors.Cross;
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "MainPage";
            TopMost = true;
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label screenClock;
        private Button exitButton;
        private System.Windows.Forms.Timer timer1;
        private Button graphButton;
        private RichTextBox hw;
        private TextBox lonbox;
        private TextBox latbox;
        private Label label1;
        private Label label2;
        private RichTextBox testbox;
    }
}
