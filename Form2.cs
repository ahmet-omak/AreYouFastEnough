using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Management.Instrumentation;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WMPLib;

namespace The_End_Of_The_Fucking_Button
{
    public partial class Form2 : Form
    {
        #region Some Stuff
        //Declare a picturebox class
        PictureBox[] drops;

        //Drop Speed
        int dropspeed = 4;

        //Image for drop object
        Image drop;

        //Random Class
        Random rnd;
        int take;
        int take2;
        WindowsMediaPlayer closing;
        #endregion
        public Form2(int a,Form1 stop,int c)
        {
            InitializeComponent();
            stop.Visible = false;
            take = a;
            take2 = c;
        }
        private void Form2_Load_1(object sender, EventArgs e)
        {
            drop = Image.FromFile(@"C:\Users\ahmet\OneDrive\Desktop\Are You Fast Enough\Pictures\drop.png");
            //Create the drops
            CreateDrops();
            //Move Drops 
            MoveDrops();
            //Add the close screen song(metallica - Unforgiven)
            closing = new WindowsMediaPlayer();
            closing.URL = @"C:\Users\ahmet\OneDrive\Desktop\Are You Fast Enough\Assets\closeSound.mp3";
            closing.controls.play();
            closing.settings.setMode("loop", true);
            //Score The Player Made
            label2.Text = take.ToString();
            //Show How many times did the player missclick
            label5.Text = take2.ToString();
        }
        public void CreateDrops()
        {
            //Creates drop array in the screen
            rnd = new Random();
            drops = new PictureBox[10];
            for (int i = 0; i < drops.Length; i++)
            {
                drops[i] = new PictureBox();
                drops[i].Size = new Size(20, 20);
                drops[i].SizeMode = PictureBoxSizeMode.StretchImage;
                drops[i].Location = new Point(rnd.Next(0, 800), rnd.Next(150, 500));
                drops[i].BorderStyle = BorderStyle.None;
                drops[i].Image = drop;
                this.Controls.Add(drops[i]);
            }
        }
        public void MoveDrops()
        {
            //Drop Settings
            dropMove.Enabled = true;
            dropMove.Interval = 95;
            dropMove.Start();
        }
        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            closing.controls.stop();
            Application.ExitThread();
        }
        private void dropMove_Tick(object sender, EventArgs e)
        {
            //Drops Array falling down from top to bottom
            rnd = new Random();
            for (int i = 0; i < drops.Length; i++)
            {
                drops[i].Top += dropspeed;
                if (drops[i].Top>=500)
                {
                    drops[i].Location = new Point(rnd.Next(0, 800), rnd.Next(0, 200));
                }
            }
        }
    }
}
