using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp4
{
    public partial class Form9 : Form
    {
        public Form9()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form10 form10 = new Form10();
            form10.Show();
            Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form11 form11 = new Form11();
            form11.Show();
            Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form13 form13 = new Form13();
            form13.Show();
            Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form15 f = new Form15();
            f.Show();
            Hide();
        }
    }
}
