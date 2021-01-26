using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Data.SqlClient;

namespace WindowsFormsApp4
{
    public partial class Registration : Form
    {
        public Registration()
        {
            InitializeComponent();
        }

        private void picCancel_Click(object sender, EventArgs e)
        {
            Authentication authentication = new Authentication();
            authentication.Show();
            Hide();
        }

        private void btnReg_Click(object sender, EventArgs e)
        {
            if (!Regex.IsMatch(txtEmail.Text, @"^\s*$")) 
            {
                if (Regex.IsMatch(txtEmail.Text, @"^([a-z0-9_-]+\.)*[a-z0-9_-]+@[a-z0-9_-]+(\.[a-z0-9_-]+)*\.[a-z]{2,6}$"))
                {
                    if (!Regex.IsMatch(txtPhone.Text, @"^\s*$")) 
                    {
                        if (Regex.IsMatch(txtPhone.Text, @"^(\+7)\(\d{3}\)-\d{3}-\d{4}"))
                        {
                            if (!Regex.IsMatch(txtPassword.Text, @"^\s*$"))
                            {
                                if (txtPassword.Text.Length < 17)
                                {
                                    if (txtPassword.Text == txtRepPassword.Text)
                                    {
                                        SqlConnection con = DBUtils.GetDBConnection();
                                        try
                                        {
                                            con.Open();
                                            SqlCommand cmd = con.CreateCommand();
                                            cmd.CommandText = "SELECT COUNT(*) FROM Users WHERE Email = '" + txtEmail.Text + "'";
                                            if (Convert.ToInt32(cmd.ExecuteScalar()) == 0)
                                            {
                                                cmd.CommandText = "SELECT COUNT(*) FROM Users WHERE PhoneNumber = '" + txtPhone.Text + "'";
                                                if (Convert.ToInt32(cmd.ExecuteScalar()) == 0)
                                                {
                                                    cmd.CommandText = "INSERT INTO Users VALUES ('" + txtEmail.Text + "', '" + txtPhone.Text + "', '" + txtPassword.Text + "', 2)";
                                                    cmd.ExecuteNonQuery();
                                                    MessageBox.Show("Регистрация прошла успешно!");

                                                    Authentication authentication = new Authentication();
                                                    authentication.Show();
                                                    Hide();
                                                }
                                                else MessageBox.Show("Данный телефон занят!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                            }
                                            else MessageBox.Show("Данный email занят!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                        }
                                        catch (Exception ex)
                                        {
                                            MessageBox.Show("Error: " + ex.Message);
                                        }
                                        con.Close();
                                    }
                                    else MessageBox.Show("Пароли не совпадают");
                                }
                                else MessageBox.Show("Пароль должен быть менее 50 символов");
                            }
                            else MessageBox.Show("Заполните пароль");
                        }
                        else MessageBox.Show("Неверный формат номера телефона!");
                    }
                    else MessageBox.Show("Заполните телефон");
                }
                else MessageBox.Show("Неверный формат Email");
            }
            else MessageBox.Show("Заполните поле Email");
        }
    }
}
