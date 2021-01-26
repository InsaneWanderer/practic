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
    public partial class Admin : Form
    {
        public Admin()
        {
            InitializeComponent();
        }

        private void btnAddContent_Click(object sender, EventArgs e)
        {
            AddContent add = new AddContent();
            add.Show();
            Hide();
        }

        private void btnUpdateGenres_Click(object sender, EventArgs e)
        {
            Genres genres = new Genres();
            genres.Show();
            Hide();
        }

        private void btnUpdateCollections_Click(object sender, EventArgs e)
        {
            Collections form13 = new Collections();
            form13.Show();
            Hide();
        }

        private void btnAllContent_Click(object sender, EventArgs e)
        {
            AllContent f = new AllContent();
            f.Show();
            Hide();
        }
    }
}
