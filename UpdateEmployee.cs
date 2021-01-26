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

namespace HousingFund
{
    public partial class UpdateEmployee : Form
    {
        public UpdateEmployee()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string surname = txtSurname.Text;
            string name = txtName.Text;
            string patronymic = txtPatronymic.Text == "" ? "NULL" : "'" + txtPatronymic.Text + "'";
            string login = txtLogin.Text;
            string password = txtPassword.Text;
            string date = dtpHired.Value.ToString("dd.MM.yyyy");

            if (Regex.IsMatch(surname, @"^\w+$"))
            {
                if (Regex.IsMatch(name, @"^\w+$"))
                {
                    if (Regex.IsMatch(txtPatronymic.Text, @"^\w+$"))
                    {
                        if (Regex.IsMatch(login, @"^[a-zA-Z]+$"))
                        {
                            if (Regex.IsMatch(password, @"^([a-zA-Z]*[0-9]*)+$"))
                            {
                                SqlConnection conn = DBUtils.GetDBConnection();
                                try
                                {
                                    conn.Open();
                                    SqlCommand cmd = conn.CreateCommand();
                                    cmd.CommandText = "UPDATE Employees " +
                                        "SET Surname = '" + surname + "'" +
                                        ", Name = '" + name + "'" +
                                        ", Patronymic = " + patronymic + "" +
                                        ", Hired = '" + date + "'" +
                                        ", Login = '" + login + "'" +
                                        ", Password = '" + password + "'" +
                                        " WHERE Id = " + EmployeeData.id;
                                    cmd.ExecuteNonQuery();
                                    MessageBox.Show("Изменение прошло успешно!");
                                    Close();
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show(ex.Message);
                                }
                                finally
                                {
                                    conn.Close();
                                }
                            }
                            else MessageBox.Show("Неверный формат пароля", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else MessageBox.Show("Неверный формат логина", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else MessageBox.Show("Неверный формат отчества", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else MessageBox.Show("Неверный формат имени", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else MessageBox.Show("Неверный формат фамилии", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void UpdateEmployee_Load(object sender, EventArgs e)
        {
            SqlConnection conn = DBUtils.GetDBConnection();
            try
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT * FROM Employees WHERE Id = " + EmployeeData.id;
                SqlDataReader reader = cmd.ExecuteReader();
                reader.Read();
                txtSurname.Text = reader.GetString(1);
                txtName.Text = reader.GetString(2);
                txtPatronymic.Text = reader.GetString(3);
                dtpHired.Value = reader.GetDateTime(4);
                txtLogin.Text = reader.GetString(5);
                txtPassword.Text = reader.GetString(6);
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }
    }
}
