using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp4
{
    public partial class Start : Form
    {
        public Start()
        {
            InitializeComponent();
        }

        DataGridView dgvContent;

        private void Form3_Load(object sender, EventArgs e)
        {
            Controls.Add(Header.Get());
            Controls.Add(Header.GetGenresPanel());
            Controls[Controls.Count - 2].BringToFront();
            Controls[Controls.Count - 1].BringToFront();

            try
            {
                dgvContent = new DataGridView();
                Actions.ContentDataGridViewFill(dgvContent);
                ComponentResourceManager resources = new ComponentResourceManager(typeof(Start));

                int x = 0, y = 35;
                for (int Row = 0; Row < dgvContent.Rows.Count; Row++)
                {                    
                    string contentName = dgvContent.Rows[Row].Cells[1].Value.ToString();
                    int filmRow = Row;
                    PictureBox pic = new PictureBox();
                    ((System.ComponentModel.ISupportInitialize)(pic)).BeginInit();
                    Label lb = new Label();

                    pic.Image = Image.FromFile(Directory.GetParent("..").FullName + "\\Resources\\" + dgvContent.Rows[Row].Cells[10].Value.ToString());
                    pic.Location = new System.Drawing.Point(x, y);
                    pic.Name = "pic" + filmRow;
                    pic.Size = new System.Drawing.Size(190, 125);
                    pic.SizeMode = PictureBoxSizeMode.StretchImage;
                    pic.Click += new EventHandler(Film_Clicked);

                    lb.AutoSize = false;
                    lb.Location = new System.Drawing.Point(x -5 , y + 128);
                    lb.Name = "lb" + filmRow;
                    lb.Size = new System.Drawing.Size(190, 30);
                    lb.TabIndex = 0;
                    lb.Text = contentName;
                    lb.TextAlign = System.Drawing.ContentAlignment.TopLeft;
                    lb.Click += new EventHandler(Film_Clicked);
                    lb.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
                    lb.ForeColor = System.Drawing.Color.White;

                    x += 210;
                    if(x>630)
                    {
                        x = 0;
                        y += 200;
                    }

                    panel3.Controls.Add(pic);
                    panel3.Controls.Add(lb);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            
        }

        private void Film_Clicked(object sender, EventArgs e)
        {
            int row = 0;
            if (sender.GetType() == typeof(Label))
            {
                Label triggeredLabel = (Label)sender;
                row = Convert.ToInt32(triggeredLabel.Name.Remove(0, 2));
            }
            else
            {
                PictureBox triggeredPicture = (PictureBox)sender;
                row = Convert.ToInt32(triggeredPicture.Name.Remove(0, 3));
            }

            FilmData.name = dgvContent.Rows[row].Cells[1].Value.ToString();
            FilmData.type = dgvContent.Rows[row].Cells[2].Value.ToString();
            FilmData.year = dgvContent.Rows[row].Cells[3].Value.ToString();
            FilmData.director = dgvContent.Rows[row].Cells[4].Value.ToString();
            FilmData.actors = dgvContent.Rows[row].Cells[5].Value.ToString();
            FilmData.genres = dgvContent.Rows[row].Cells[6].Value.ToString();
            FilmData.posterName = dgvContent.Rows[row].Cells[10].Value.ToString();
            FilmData.duration = dgvContent.Rows[row].Cells[11].Value.ToString();
            FilmData.text = dgvContent.Rows[row].Cells[12].Value.ToString();
            FilmData.videoName = dgvContent.Rows[row].Cells[13].Value.ToString();

            Film film = new Film(this);
            film.Show();
            Hide();
        }

        private void lbGenre_Clicked(object sender, EventArgs e)
        {
            Label triggeredGenre = (Label)sender;
            GenreData.id = Convert.ToInt16(triggeredGenre.Name.Remove(0, 2));
            GenreContent genreContent = new GenreContent();
            genreContent.Show();
            Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Authentication auth = new Authentication();
            auth.Show();
            Hide();
        }        

        private void lbCollections_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label25_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel5_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void lbSubscriptions_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lbCatalog_Click(object sender, EventArgs e)
        {

        }

        private void lbCatalog_MouseEnter(object sender, EventArgs e)
        {

        }

        private void lbCatalog_MouseLeave(object sender, EventArgs e)
        {

        }

        private void lbCollections_MouseEnter(object sender, EventArgs e)
        {

        }

        private void lbCollections_MouseLeave(object sender, EventArgs e)
        {

        }

        private void lbSubscriptions_MouseEnter(object sender, EventArgs e)
        {

        }

        private void lbSubscriptions_MouseLeave(object sender, EventArgs e)
        {

        }
    }
}
