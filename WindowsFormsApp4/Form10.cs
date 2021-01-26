using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp4
{
    public partial class Form10 : Form
    {
        public Form10()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form9 form9 = new Form9();
            form9.Show();
            Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string Name = textBox2.Text;
            int TypeId = Convert.ToInt32(listBox2.SelectedValue);

            int GenresCount = 0;
            int[] GenresId = new int[0];

            //Запись всех выбранных жанров в массив.
            while (Convert.ToInt32(listBox1.SelectedIndex) != -1)
            {
                Array.Resize(ref GenresId, GenresCount + 1);
                GenresId[GenresCount++] = Convert.ToInt32(listBox1.SelectedValue);
                listBox1.SetSelected(Convert.ToInt32(listBox1.SelectedIndex), false);
            }

            string Director = textBox4.Text;
            string Actors = textBox5.Text + ", ";
            string Year = textBox1.Text;
            string Duration = TypeId == 1?"NULL": "20";

            if (!textBox6.ReadOnly)
            {
                Duration = textBox6.Text;
            }

            string CollectionId = listBox3.SelectedIndex == -1 ? "NULL" : Convert.ToString(listBox3.SelectedValue);
            string PosterDirect = textBox3.Text == "" ? "NULL" : textBox3.Text;

            string Price = "NULL";
            if (!textBox7.ReadOnly)
            {
                Price = textBox7.Text;
            }

            int SubscriptionId = 2;
            if (listBox4.Visible)
            {
                SubscriptionId = Convert.ToInt32(listBox4.SelectedValue);
            }

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
                                if ((!textBox6.ReadOnly && Regex.IsMatch(Duration, @"^\d{1,3}$")) || textBox6.ReadOnly)
                                {
                                    bool check = true; // переменная проверки того, цена или подписка выбраны.

                                    if (!textBox7.ReadOnly)
                                    {
                                        if (Price == "NULL")
                                        {
                                            MessageBox.Show("U dick");
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
                                            
                                            cmd.CommandText = "INSERT INTO AllContent VALUES ('" + Name + "'," + TypeId + "," + SubscriptionId + "," + Price + "," + CollectionId + ",'" + Year + "',NULL,'" + PosterDirect + "', NULL, NULL, " + Duration + ");";
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

                                            cmd.CommandText = "INSERT INTO DirectorsAndContent VALUES (" + DirectorId + "," + ContentId + ");";
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

                                            if(TypeId == 1)
                                                MessageBox.Show("Фильм был добавлен в базу данных", "Добавление прошло успешно!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                            else
                                            {
                                                cmd.CommandText = "UPDATE AllContent SET Season = 1, Series = 1 WHERE Id = " + ContentId;
                                                MessageBox.Show("Сериал был добавлен в базу данных", "Добавление прошло успешно!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                            }
                                        }
                                        catch (Exception ex)
                                        {
                                            MessageBox.Show(Convert.ToString(ex));
                                        }
                                        finally { con.Close(); }
                                    }
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

        private void Form10_Load(object sender, EventArgs e)
        {
            Actions.ListBoxFill(listBox2, "ContentTypes", "TypeId", "ContentType");
            Actions.ListBoxFill(listBox1, "Genres", "Id", "Genre");
            Actions.ListBoxFill(listBox3, "Collections", "Id", "Name");
            Actions.ListBoxFill(listBox4, "SubscriptionTypes", "TypeId", "SubscriptionType");
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox2.SelectedIndex == 1)
            {
                textBox6.Text = "";
                textBox6.ReadOnly = true;
            }
            else
            {
                textBox6.ReadOnly = false;
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if(radioButton2.Checked)
            {
                textBox7.ReadOnly = false;
                listBox4.Visible = false;
                label13.Visible = false;
                listBox4.ClearSelected();
            }
            else
            {
                textBox7.ReadOnly = true;
                listBox4.Visible = true;
                label13.Visible = true;
                textBox7.Text = "";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog OpenDialog = new OpenFileDialog();
            OpenDialog.Filter = "Image Files(*.BMP;*.JPG;*.PNG)|*.BMP;*.JPG;*.PNG|All Files (*.*)|*.*";
            if(OpenDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    pictureBox1.Image = new Bitmap(OpenDialog.FileName);

                    pictureBox1.Invalidate();
                    textBox3.Text = OpenDialog.FileName;
                }
                catch
                {
                    DialogResult rezult = MessageBox.Show("Невозможно открыть выбранный файл",
                        "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
