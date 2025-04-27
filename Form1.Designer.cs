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
            Clock = new System.Windows.Forms.Timer(components);
            exitButton = new Button();
            SuspendLayout();
            // 
            // screenClock
            // 
            resources.ApplyResources(screenClock, "screenClock");
            screenClock.BackColor = SystemColors.Control;
            screenClock.BorderStyle = BorderStyle.FixedSingle;
            screenClock.Name = "screenClock";
            screenClock.Click += label1_Click;
            // 
            // Clock
            // 
            Clock.Interval = 1000;
            Clock.Tag = "Seconds";
            Clock.Tick += timer1_Tick;
            // 
            // exitButton
            // 
            resources.ApplyResources(exitButton, "exitButton");
            exitButton.Name = "exitButton";
            exitButton.UseVisualStyleBackColor = true;
            exitButton.Click += exitButton_Click;
            // 
            // MainPage
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ControlBox = false;
            Controls.Add(exitButton);
            Controls.Add(screenClock);
            Cursor = Cursors.Cross;
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            HelpButton = true;
            Name = "MainPage";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label screenClock;
        public System.Windows.Forms.Timer Clock;
        private Button exitButton;
    }
}
