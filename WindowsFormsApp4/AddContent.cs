using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp4
{
    public partial class AddContent : Form
    {
        public AddContent()
        {
            InitializeComponent();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Admin admin = new Admin();
            admin.Show();
            Hide();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string Name = txtName.Text;
            int TypeId = Convert.ToInt32(lbType.SelectedValue);

            int GenresCount = 0;
            int[] GenresId = new int[0];

            //Запись всех выбранных жанров в массив.
            while (Convert.ToInt32(lbGenres.SelectedIndex) != -1)
            {
                Array.Resize(ref GenresId, GenresCount + 1);
                GenresId[GenresCount++] = Convert.ToInt32(lbGenres.SelectedValue);
                lbGenres.SetSelected(Convert.ToInt32(lbGenres.SelectedIndex), false);
            }

            string Director = txtDirector.Text;
            string Actors = txtActors.Text + ", ";
            string Year = txtYear.Text;
            string Duration = TypeId == 1 ? "NULL" : "20";

            if (!txtDuration.ReadOnly)
            {
                Duration = txtDuration.Text;
            }

            int[] CollectionsId = new int[0];
            while (Convert.ToInt32(lbCollection.SelectedIndex) != -1)
            {
                Array.Resize(ref CollectionsId, CollectionsId.Length + 1);
                CollectionsId[CollectionsId.Length - 1] = Convert.ToInt32(lbCollection.SelectedValue);
                lbCollection.SetSelected(Convert.ToInt32(lbCollection.SelectedIndex), false);
            }
            string file = txtPoster.Text;
            string video = txtVideo.Text;

            string Price = "NULL";
            if (!txtPrice.ReadOnly)
            {
                Price = txtPrice.Text;
            }

            int SubscriptionId = 2;
            if (lbSubscription.Visible)
            {
                SubscriptionId = Convert.ToInt32(lbSubscription.SelectedValue);
            }
            string text = textBox1.Text == "" ? "NULL" : "'" + textBox1.Text + "'";

            if (!Regex.IsMatch(Name, @"^\s*$"))
            {
                if (GenresCount > 0)
                {
                    if (Regex.IsMatch(Director, @"^\w+\s\w+$"))
                    {
                        if (Regex.IsMatch(Actors, @"^(\w+\s\w+,\s)+$"))
                        {
                            if (Regex.IsMatch(Year, @"^\d{4}$"))
                            {
                                if ((!txtDuration.ReadOnly && Regex.IsMatch(Duration, @"^\d{1,3}$")) || txtDuration.ReadOnly)
                                {
                                    if (file != "")
                                    {
                                        if (video != "")
                                        {
                                            file = Path.GetFileName(file);
                                            video = Path.GetFileName(video);
                                            bool check = true; // переменная проверки возможности добавить.

                                            if (!txtPrice.ReadOnly)
                                            {
                                                if (Price == "NULL")
                                                {
                                                    MessageBox.Show("Введите цену");
                                                    check = false;
                                                }
                                            }

                                            if (check)
                                            {
                                                SqlConnection con = DBUtils.GetDBConnection();

                                                try
                                                {
                                                    con.Open();

                                                    SqlCommand cmd = con.CreateCommand();
                                                    File.Copy(txtPoster.Text, Directory.GetParent(@"..").FullName + "\\Resources\\" + file);
                                                    File.Copy(txtVideo.Text, Directory.GetParent(@"..").FullName + "\\Resources\\" + video);

                                                    if (radioPrice.Checked)
                                                        cmd.CommandText = "INSERT INTO AllContent VALUES ('" + Name + "'," + TypeId + ", NULL," + Price + ",'" + Year + "'," + text + ",'" + file + "', NULL, NULL, " + Duration + ", '" + video + "');";
                                                    else
                                                        cmd.CommandText = "INSERT INTO AllContent VALUES ('" + Name + "'," + TypeId + ", " + SubscriptionId + ", NULL,'" + Year + "'," + text + ",'" + file + "', NULL, NULL, " + Duration + ", '" + video + "');";
                                                    cmd.ExecuteNonQuery();

                                                    cmd.CommandText = "SELECT MAX(Id) FROM AllContent";
                                                    int ContentId = Convert.ToInt32(cmd.ExecuteScalar());

                                                    string DirectorName = Director.Split(' ')[0];
                                                    string DirectorSurname = Director.Split(' ')[1];

                                                    cmd.CommandText = "SELECT Id FROM ContentWorkers WHERE Name = '" + DirectorName + "' AND Surname = '" + DirectorSurname + "' AND WorkerTypeId = " + 1;

                                                    int DirectorId = Convert.ToInt32(cmd.ExecuteScalar());

                                                    if (DirectorId == 0)
                                                    {
                                                        cmd.CommandText = "INSERT INTO ContentWorkers VALUES ('" + DirectorName + "','" + DirectorSurname + "', 1);";
                                                        cmd.ExecuteNonQuery();

                                                        cmd.CommandText = "SELECT MAX(Id) FROM ContentWorkers";
                                                        DirectorId = Convert.ToInt32(cmd.ExecuteScalar());
                                                    }

                                                    cmd.CommandText = "INSERT INTO DirectorsAndContent VALUES (" + ContentId + "," + DirectorId + ");";
                                                    cmd.ExecuteNonQuery();

                                                    string[] Separator = new string[] { ", " }; //разделитель актеров для. Нужен для использования Split
                                                    foreach (string Actor in Actors.Remove(Actors.Length - 2).Split(Separator, StringSplitOptions.RemoveEmptyEntries))
                                                    {
                                                        string ActorName = Actor.Split(' ')[0];
                                                        string ActorSurname = Actor.Split(' ')[1];

                                                        cmd.CommandText = "SELECT Id FROM ContentWorkers WHERE Name = '" + ActorName + "' AND Surname = '" + ActorSurname + "' AND WorkerTypeId = " + 2;

                                                        int ActorId = Convert.ToInt32(cmd.ExecuteScalar());

                                                        if (ActorId == 0)
                                                        {
                                                            cmd.CommandText = "INSERT INTO ContentWorkers VALUES ('" + ActorName + "','" + ActorSurname + "', 2);";
                                                            cmd.ExecuteNonQuery();

                                                            cmd.CommandText = "SELECT MAX(Id) FROM ContentWorkers";
                                                            ActorId = Convert.ToInt32(cmd.ExecuteScalar());
                                                        }

                                                        cmd.CommandText = "INSERT INTO ActorsAndContent VALUES (" + ActorId + "," + ContentId + ");";
                                                        cmd.ExecuteNonQuery();
                                                    }

                                                    foreach (int Genre in GenresId)
                                                    {
                                                        cmd.CommandText = "INSERT INTO GenreAndContent VALUES (" + Genre + "," + ContentId + ");";
                                                        cmd.ExecuteNonQuery();
                                                    }

                                                    foreach (int collection in CollectionsId)
                                                    {
                                                        cmd.CommandText = "INSERT INTO CollectionsContent VALUES (" + collection + "," + ContentId + ");";
                                                        cmd.ExecuteNonQuery();
                                                    }

                                                    if (TypeId == 1)
                                                        MessageBox.Show("Фильм был добавлен в базу данных", "Добавление прошло успешно!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                    else
                                                    {
                                                        cmd.CommandText = "UPDATE AllContent SET Season = 1, Series = 1 WHERE Id = " + ContentId;
                                                        MessageBox.Show("Сериал был добавлен в базу данных", "Добавление прошло успешно!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                    }
                                                }
                                                catch (Exception ex)
                                                {
                                                    MessageBox.Show(ex.Message);
                                                }
                                                finally { con.Close(); }

                                            }
                                        }
                                    }
                                    else MessageBox.Show("Выберите постер!", "Отсутсвует постер!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                                else MessageBox.Show("Введите, сколько должен длиться фильм (от 1 до 999) в минутах", "Поле \"Продолжительность\" пустует или заполнено с ошибкой!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            else MessageBox.Show("Введите, в каком году вышел фильм.\nПример: 2018", "Поле \"Год выхода\" пустует или заполнено с ошибкой!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else MessageBox.Show("Заполните актеров.\nПример: Имя Фамилия, Имя Фамилия", "Поле \"Актеры\" пустует или заполнено с ошибкой!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else MessageBox.Show("Заполните режиссёра.\nПример: Имя Фамилия", "Поле \"Режиссёр\" пустует или заполнено с ошибкой!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else MessageBox.Show("Выберите жанры.", "Жанры отсутствуют!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else MessageBox.Show("Введите название фильма", "Поле \"Название\" пустует или заполнено с ошибкой!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void AddContent_Load(object sender, EventArgs e)
        {
            Actions.ListBoxFill(lbType, "ContentTypes", "TypeId", "ContentType");
            Actions.ListBoxFill(lbGenres, "Genres", "Id", "Genre");
            Actions.ListBoxFill(lbCollection, "Collections", "Id", "Name");
            Actions.ListBoxFill(lbSubscription, "SubscriptionTypes", "Id", "Name");
        }

        private void lbType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbType.SelectedIndex == 1)
            {
                txtDuration.Text = "";
                txtDuration.ReadOnly = true;
            }
            else
            {
                txtDuration.ReadOnly = false;
            }
        }

        private void radioPrice_CheckedChanged(object sender, EventArgs e)
        {
            if(radioPrice.Checked)
            {
                txtPrice.ReadOnly = false;
                lbSubscription.Visible = false;
                label13.Visible = false;
                lbSubscription.ClearSelected();
            }
            else
            {
                txtPrice.ReadOnly = true;
                lbSubscription.Visible = true;
                label13.Visible = true;
                txtPrice.Text = "";
            }
        }

        private void btnSetPoster_Click(object sender, EventArgs e)
        {
            OpenFileDialog OpenDialog = new OpenFileDialog();
            OpenDialog.Filter = "Image Files(*.BMP;*.JPG;*.PNG)|*.BMP;*.JPG;*.PNG|All Files (*.*)|*.*";
            if(OpenDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    picPoster.Image = new Bitmap(OpenDialog.FileName);

                    picPoster.Invalidate();
                    txtPoster.Text = OpenDialog.FileName;
                }
                catch
                {
                    MessageBox.Show("Невозможно открыть выбранный файл",
                        "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnSetVideo_Click(object sender, EventArgs e)
        {
            OpenFileDialog OpenDialog = new OpenFileDialog();
            OpenDialog.Filter = "Video(*.mp4)|*.mp4";
            if (OpenDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    txtVideo.Text = OpenDialog.FileName;
                }
                catch
                {
                    MessageBox.Show("Невозможно открыть выбранный файл",
                        "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
