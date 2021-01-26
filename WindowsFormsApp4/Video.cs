using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp4
{
    public partial class Video : Form
    {
        string videoName;
        Form previous;

        public Video()
        {
            InitializeComponent();
        }

        public Video(string videoName, Form previous)
        {
            InitializeComponent();
            this.videoName = videoName;
            this.previous = previous;
        }

        private void Test_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (button2.Text == "Start")
            {
                vlcControl1.Play(new FileInfo(Directory.GetParent("..").FullName + "\\Resources\\" + videoName));
                button2.Text = "Pause";
            }
            else if(button2.Text == "Pause")
            {
                vlcControl1.Pause();
                button2.Text = "Play";
            }
            else if(button2.Text == "Play")
            {
                vlcControl1.Play();
                button2.Text = "Pause";
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            vlcControl1.Stop();
        }

        private void Test_Resize(object sender, EventArgs e)
        {
            vlcControl1.Size = Size;
            button1.Location = new System.Drawing.Point(Size.Width - 48, 12);
            button2.Location = new System.Drawing.Point((Size.Width - 180)/2, Size.Height - 100);
            button3.Location = new System.Drawing.Point(button2.Location.X + 120, Size.Height - 100);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            vlcControl1.Stop();
            previous.Show();
            Hide();
        }
    }
}
