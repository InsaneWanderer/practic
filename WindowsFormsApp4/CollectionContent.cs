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
    public partial class CollectionContent : Form
    {
        public CollectionContent()
        {
            InitializeComponent();
        }

        private void CollectionContent_Load(object sender, EventArgs e)
        {
            SqlConnection conn = DBUtils.GetDBConnection();
            try
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT * FROM AllContent " +
                    "JOIN CollectionsContent ON CollectionsContent.ContentId = AllContent.Id AND CollectionsContent.CollectionId = " + CollectionData.id;
                SqlDataReader reader = cmd.ExecuteReader();

                int x = 0, y = 35;
                while (reader.Read())
                {
                    string contentName = reader.GetString(1);
                    int contentId = reader.GetInt32(0);
                    PictureBox pic = new PictureBox();
                    ((System.ComponentModel.ISupportInitialize)(pic)).BeginInit();
                    Label lb = new Label();

                    pic.Location = new System.Drawing.Point(x, y);
                    pic.Name = "pic" + contentId;
                    pic.Size = new System.Drawing.Size(190, 125);
                    pic.SizeMode = PictureBoxSizeMode.StretchImage;
                    pic.Image = Image.FromFile(Directory.GetParent("..").FullName + "\\Resources\\" + reader.GetString(7));
                    pic.Click += new EventHandler(Film_Clicked);


                    lb.AutoSize = false;
                    lb.Location = new System.Drawing.Point(x, y + 125);
                    lb.Name = "lb" + contentId;
                    lb.Size = new System.Drawing.Size(190, 30);
                    lb.TabIndex = 0;
                    lb.Text = contentName;
                    lb.TextAlign = System.Drawing.ContentAlignment.TopCenter;
                    lb.Click += new EventHandler(Film_Clicked);

                    x += 210;
                    if (x > 630)
                    {
                        x = 0;
                        y += 200;
                    }

                    panelContent.Controls.Add(pic);
                    panelContent.Controls.Add(lb);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                conn.Close();
            }
        }

        private void Film_Clicked(object sender, EventArgs e)
        {
            int id;
            if (sender.GetType() == typeof(Label))
            {
                Label triggeredLabel = (Label)sender;
                id = Convert.ToInt32(triggeredLabel.Name.Remove(0, 2));
            }
            else
            {
                PictureBox triggeredPicture = (PictureBox)sender;
                id = Convert.ToInt32(triggeredPicture.Name.Remove(0, 3));
            }
            SqlConnection conn = DBUtils.GetDBConnection();
            try
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT * FROM AllContent WHERE Id = " + id;
                SqlDataReader reader = cmd.ExecuteReader();

                reader.Read();
                FilmData.name = reader.GetString(1);
                FilmData.year = reader.GetString(5);
                FilmData.text = reader.GetString(6);
                FilmData.posterName = reader.GetString(7);
                FilmData.duration = reader.GetValue(10).ToString();
                FilmData.videoName = reader.GetString(11);
                reader.Close();

                cmd.CommandText = "SELECT ContentTypes.ContentType FROM AllContent " +
                    "JOIN ContentTypes ON AllContent.ContentTypeId = ContentTypes.TypeId AND AllContent.Id = " + id;
                FilmData.type = cmd.ExecuteScalar().ToString();

                cmd.CommandText = "SELECT (ContentWorkers.Name + ' ' + ContentWorkers.Surname) FROM AllContent " +
                    "JOIN DirectorsAndContent ON DirectorsAndContent.ContentId = AllContent.Id AND AllContent.Id = " + id +
                    " JOIN ContentWorkers ON ContentWorkers.Id = DirectorsAndContent.ContentDirectorId";
                FilmData.director = cmd.ExecuteScalar().ToString();

                cmd.CommandText = "SELECT STRING_AGG(ContentWorkers.Name + ' ' + ContentWorkers.Surname, ', ') FROM ContentWorkers " +
                    "JOIN ActorsAndContent ON ActorsAndContent.ActorId = ContentWorkers.Id " +
                    "JOIN AllContent ON ActorsAndContent.ContentId = AllContent.Id AND AllContent.Id = " + id +
                    " GROUP BY AllContent.Id";
                FilmData.actors = cmd.ExecuteScalar().ToString();

                cmd.CommandText = "SELECT STRING_AGG(Genres.Genre, ', ') FROM Genres " +
                    "JOIN GenreAndContent ON GenreAndContent.GenreId = Genres.Id " +
                    "JOIN AllContent ON GenreAndContent.ContentId = AllContent.Id AND AllContent.Id = " + id +
                    " GROUP BY AllContent.Id";
                FilmData.genres = cmd.ExecuteScalar().ToString();

                Film film = new Film(this);
                film.Show();
                Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                conn.Close();
            }
        }
    }
}
