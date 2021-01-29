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

namespace Timetable
{
    public partial class UserForm : Form
    {
        UserData user;

        public UserForm()
        {
            InitializeComponent();
        }

        public UserForm(UserData user)
        {
            InitializeComponent();
            this.user = user;
        }

        private void btnEnter_Click(object sender, EventArgs e)
        {
            string surname = txtSurname.Text;
            string name = txtName.Text;
            string patronymic = txtPatronymic.Text;
            string login = txtLogin.Text;
            int typeId = Convert.ToInt32(lbType.SelectedValue);

            if (Regex.IsMatch(surname, @"^[А-Я][а-я]*$"))
            {
                if (Regex.IsMatch(name, @"^[А-Я][а-я]*$"))
                {
                    if (Regex.IsMatch(patronymic, @"^[А-Я][а-я]*$") || patronymic == "")
                    {
                        patronymic = patronymic == "" ? "NULL" : "'" + patronymic + "'";
                        if (Regex.IsMatch(login, @"^[A-Za-z0-9]+$"))
                        {
                            string id = user.Get("id");
                            bool check = true; //Служит для проверки того, что значения не повторяются
                            SqlConnection conn = DBUtils.GetDBConnection();
                            try
                            {
                                conn.Open();
                                SqlCommand cmd = conn.CreateCommand();
                                //проверка на повторение ФИО
                                cmd.CommandText = "SELECT COUNT(*) FROM Users " +
                                    "WHERE Surname = '" + surname + "' AND Name = '" + name + "' AND Patronymic = " + patronymic;
                                if (id == "0")
                                {
                                    if (CheckMatch(cmd))
                                    {
                                        check = false;
                                        MessageBox.Show("Пользователь с таким ФИО уже существует!");
                                    }
                                }
                                else if (surname != user.Get("surname") || name != user.Get("name") || patronymic != user.Get("patronymic"))
                                {
                                    if (CheckMatch(cmd))
                                    {
                                        check = false;
                                        MessageBox.Show("Пользователь с таким ФИО уже существует!");
                                    }
                                }
                                //Проверка на повторение логина
                                cmd.CommandText = "SELECT COUNT(*) FROM Users " +
                                    "WHERE Login = '" + login + "'";
                                if (id == "0")
                                {
                                    if (CheckMatch(cmd))
                                    {
                                        check = false;
                                        MessageBox.Show("Пользователь с таким логином уже существует!");
                                    }
                                }
                                else if (login != user.Get("login"))
                                {
                                    if (CheckMatch(cmd))
                                    {
                                        check = false;
                                        MessageBox.Show("Пользователь с таким логином уже существует!");
                                    }
                                }

                                if (check)
                                {
                                    if (id == "0")
                                    {
                                        cmd.CommandText = "INSERT INTO Users (Surname, Name, Patronymic, TypeId, Login) " +
                                            "Values ('" + surname + "','" + name + "'," + patronymic + "," + typeId + ",'" + login + "');";
                                        cmd.ExecuteNonQuery();
                                        MessageBox.Show("Добавление прошло успешно!");
                                    }
                                    else
                                    {
                                        DialogResult result = MessageBox.Show("Вы действительно хотите изменить данного пользователя?", "Внимание!",
                                            MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                        if (result == DialogResult.Yes)
                                        {
                                            cmd.CommandText = "UPDATE Users " +
                                                "SET Surname = '" + surname + "'" +
                                                ", Name = '" + name + "'" +
                                                ", Patronymic = " + patronymic +
                                                ", Login = '" + login + "'" +
                                                " WHERE Id = " + id;
                                            cmd.ExecuteNonQuery();
                                            MessageBox.Show("Изменение прошло успешно!");
                                        }
                                    }
                                }
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.ToString());
                            }
                            finally
                            {
                                if (conn.State == ConnectionState.Open)
                                    conn.Close();
                            }
                        }
                        else MessageBox.Show("Неверный формат для логина!\nМогут быть только буквы английского алфавита или цифры!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else MessageBox.Show("Неверный формат для отчества!\nПример: Иванович\nПоле может быть пустым!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else MessageBox.Show("Неверный формат для имени!\nПример: Иван", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else MessageBox.Show("Неверный формат для фамилии!\nПример: Иванов", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void UserForm_Load(object sender, EventArgs e)
        {
            if(user.Get("id") != "0")
            {
                txtSurname.Text = user.Get("surname");
                txtName.Text = user.Get("name");
                txtPatronymic.Text = user.Get("patronymic");
                txtType.Text = user.Get("type");
                txtLogin.Text = user.Get("login");

                btnEnter.Text = "Сохранить изменения";
                btnDropPassword.Visible = true;
                lbType.Visible = false;
                txtType.Visible = true;
            }
            else
            {
                FillUserTypes();
                btnEnter.Text = "Добавить";
                btnDropPassword.Visible = false;
                lbType.Visible = true;
                txtType.Visible = false;
            }
        }

        private void FillUserTypes()
        {
            SqlConnection conn = DBUtils.GetDBConnection();
            try
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT * FROM UserTypes";
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adapter.Fill(ds);
                lbType.DataSource = ds.Tables[0];
                lbType.DisplayMember = "Type";
                lbType.ValueMember = "Id";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            FormActions.GoTo(new AllUsers());
        }

        private void btnDropPassword_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Вы действительно хотите сбросить пароль?", "Внимание", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(result == DialogResult.Yes)
            {
                SqlConnection conn = DBUtils.GetDBConnection();
                try
                {
                    conn.Open();
                    SqlCommand cmd = conn.CreateCommand();
                    cmd.CommandText = "UPDATE Users " +
                        "SET Password = 'password' " +
                        "WHERE Id = " + user.Get("id");
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Пароль был сброшен!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                finally
                {
                    if (conn.State == ConnectionState.Open)
                        conn.Close();
                }
            }
        }

        //Проверяет на существование похожей записи
        private bool CheckMatch(SqlCommand cmd)
        {
            return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
        }
    }
}
