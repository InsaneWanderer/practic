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
    public partial class EmployeeForm : Form
    {
        public EmployeeForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
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
                                    cmd.CommandText = "INSERT INTO Employees " +
                                        "VALUES ('" + surname + "','" + name + "'," + patronymic + ",'" + date + "','" + login + "','" + password + "', 2);";
                                    cmd.ExecuteNonQuery();
                                    MessageBox.Show("Добавление прошло успешно!");
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

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
