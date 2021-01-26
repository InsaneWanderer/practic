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
    public partial class Film : Form
    {
        Form previous;

        public Film()
        {
            InitializeComponent();
        }

        public Film(Form previous)
        {
            InitializeComponent();
            this.previous = previous;
        }

        private void Film_Load(object sender, EventArgs e)
        {
            Controls.Add(Header.Get());
            Controls.Add(Header.GetGenresPanel());
            Controls[Controls.Count - 2].BringToFront();
            Controls[Controls.Count - 1].BringToFront();

            lblActors.Text = FilmData.actors;
            lblDirector.Text = FilmData.director;
            lblGenres.Text = FilmData.genres;
            lblName.Text = FilmData.name;
            lblType.Text = FilmData.type;
            lblYear.Text = FilmData.year;
            lblDuration.Text = FilmData.duration + " мин.";
            picPoster.Image = Image.FromFile(Directory.GetParent("..").FullName + "\\Resources\\" + FilmData.posterName);
            lblText.Text = FilmData.text;

            btnWatch.BringToFront();
        }

        private void btnWatch_Click(object sender, EventArgs e)
        {
            Video video = new Video(FilmData.videoName, this);
            video.Show();
            Hide();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            previous.Show();
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
    }
}
