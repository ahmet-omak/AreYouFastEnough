using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Design;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WMPLib;

namespace The_End_Of_The_Fucking_Button
{
    public partial class Form1 : Form
    {
        Button cont;
        Button ex;

        bool gameover = true;

        int level = 0;

        int increment = 1000;

        int clickcount = 0;

        int formclickcount = 0;

        WindowsMediaPlayer shoot;

        WindowsMediaPlayer GameSound;
        public Form1()
        {
            InitializeComponent();
        }
        //Declarations
        Label pause;

        Form2 close;

        int picCount;

        //Declare button 
        PictureBox hello;
        Image pic = Image.FromFile(@"C:\Users\ahmet\OneDrive\Desktop\Are You Fast Enough\Pictures\player.png");
        Random Rnd;
        private void Form1_Load(object sender, EventArgs e)
        {
            //Start the Timer
            GameSound = new WindowsMediaPlayer();
            GameSound.URL = @"C:\Users\ahmet\OneDrive\Desktop\Are You Fast Enough\Assets\GameSong.mp3";
            GameSound.controls.play();
            GameSound.settings.setMode("loop", true);
            PopButton.Start();
        }
        private void PausetheGame()
        {
            pause = new Label();
            this.pause.BackColor = System.Drawing.Color.Black;
            this.pause.Font = new System.Drawing.Font("Mongolian Baiti", 50F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pause.ForeColor = System.Drawing.Color.Transparent;
            this.pause.Location = new System.Drawing.Point(-1, 1);
            this.pause.Name = "label1";
            this.pause.Size = new System.Drawing.Size(1036, 70);
            this.pause.TabIndex = 0;
            this.pause.Text = "PAUSED";
            this.pause.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.pause.Visible = true;
            this.Controls.Add(pause);
            buttons();
        }
        private void PopButton_Tick(object sender, EventArgs e)
        {
            PopButton.Interval = increment;
            Rnd = new Random();
            //Button Settings
            hello = new PictureBox();
            hello.Image = pic;
            hello.Size = new Size(100,100);
            hello.Location = new Point(Rnd.Next(5, 1030 - hello.Size.Width), Rnd.Next(110, 500 - hello.Size.Height));
            hello.BorderStyle = BorderStyle.None;
            hello.SizeMode = PictureBoxSizeMode.StretchImage;
            Controls.Add(hello);
            this.hello.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ClickCount);
            this.hello.MouseClick += new MouseEventHandler(this.Shoot);
            this.hello.DoubleClick += new EventHandler(this.isDoubleClicked);
            picCount++;
            //Delete buttons per 1 button
            if (picCount > 1)
            {
                this.Controls.Clear();
                isGameOver();
                picCount = 0;
                increaseLevel();
            }
        }
        private void ClickCount(object sender,EventArgs e)
        {
            clickcount++;
        }
        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                GameSound.controls.stop();
                this.Controls.Clear();
                PopButton.Stop();
                PausetheGame();
                if (hello!=null)
                {
                    hello.Enabled = false;
                }
            }
        }
        private string ShowPoint()
        {
            return (clickcount + " " + increment + " " + level).ToString();
        }
        public void Shoot(object sender, EventArgs e)
        {
            shoot = new WindowsMediaPlayer();
            shoot.URL = @"C:\Users\ahmet\OneDrive\Desktop\Are You Fast Enough\Assets\shoot.mp3";
            shoot.controls.play();
            gameover = false;
        }
        public void isGameOver()
        {
            PopButton.Stop();
            if (gameover==false)
            {
                gameover = true;
                PopButton.Start();
            }
            else
            {
                var x = ShowPoint();
                GameSound.controls.stop();
                close = new Form2(clickcount,this,formclickcount);
                close.Show();
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            //Delete Everything
            this.Controls.Clear();
            gameover = false;
            InitializeComponent();
            Form1_Load(e, e);
        }   //Continue
        private void button2_Click(object sender, EventArgs e)
        {
            Application.ExitThread();
        }   //Exit
        public void buttons()
        {
            cont = new Button();
            ex = new Button();
            #region Button 1
            this.cont.BackColor = System.Drawing.Color.White;
            this.cont.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cont.FlatAppearance.BorderColor = System.Drawing.Color.Maroon;
            this.cont.FlatAppearance.BorderSize = 2;
            this.cont.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cont.Font = new System.Drawing.Font("Microsoft YaHei", 15F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cont.Location = new System.Drawing.Point(355, 225);
            this.cont.Name = "button1";
            this.cont.Size = new System.Drawing.Size(263, 90);
            this.cont.TabIndex = 1;
            this.cont.TabStop = false;
            this.cont.Text = "Continue";
            this.cont.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.cont.UseVisualStyleBackColor = false;
            this.cont.Click += new System.EventHandler(this.button1_Click);
            this.Controls.Add(cont);
            #endregion

            #region Button2
            this.ex.BackColor = System.Drawing.Color.White;
            this.ex.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ex.FlatAppearance.BorderColor = System.Drawing.Color.Maroon;
            this.ex.FlatAppearance.BorderSize = 2;
            this.ex.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ex.Font = new System.Drawing.Font("Microsoft YaHei", 15F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ex.Location = new System.Drawing.Point(355, 339);
            this.ex.Name = "button2";
            this.ex.Size = new System.Drawing.Size(263, 90);
            this.ex.TabIndex = 1;
            this.ex.TabStop = false;
            this.ex.Text = "Exit";
            this.ex.UseVisualStyleBackColor = false;
            this.ex.Visible = true;
            this.ex.Click += new System.EventHandler(this.button2_Click);
            this.Controls.Add(ex);
            #endregion
        }
        public void increaseLevel()
        {
            if (clickcount>5 && clickcount%5==0)
            {
                increment -= 100;
                level += 1;
            }
        }
        public void isDoubleClicked(object sender,EventArgs e)
        {
            clickcount--;
        }

        private void Form1_Click(object sender, EventArgs e)
        {
            formclickcount++;
        }
    }   
}
