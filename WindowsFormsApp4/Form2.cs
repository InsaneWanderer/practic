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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!Regex.IsMatch(textBox1.Text, @"^\s*$")) 
            {
                if (Regex.IsMatch(textBox1.Text, @"^([a-z0-9_-]+\.)*[a-z0-9_-]+@[a-z0-9_-]+(\.[a-z0-9_-]+)*\.[a-z]{2,6}$"))
                {
                    if (!Regex.IsMatch(textBox2.Text, @"^\s*$")) 
                    {
                        if (Regex.IsMatch(textBox2.Text, @"^(\+7)\(\d{3}\)-\d{3}-\d{4}"))
                        {
                            if (!Regex.IsMatch(textBox3.Text, @"^\s*$"))
                            {
                                if (textBox3.Text == textBox4.Text)
                                {
                                    SqlConnection con = DBUtils.GetDBConnection();
                                    try
                                    {
                                        con.Open();
                                        SqlCommand cmd = con.CreateCommand();
                                        cmd.CommandText = "SELECT COUNT(*) FROM Users WHERE Email = '" + textBox1.Text + "'";
                                        if(Convert.ToInt32(cmd.ExecuteScalar()) == 0)
                                        {
                                            cmd.CommandText = "SELECT COUNT(*) FROM Users WHERE PhoneNumber = '" + textBox2.Text + "'";
                                            if (Convert.ToInt32(cmd.ExecuteScalar()) == 0)
                                            {
                                                cmd.CommandText = "INSERT INTO Users VALUES ('" + textBox1.Text + "', '" + textBox2.Text + "', '" + textBox3.Text + "')";
                                                cmd.ExecuteNonQuery();
                                                MessageBox.Show("Регистрация прошла успешно!");

                                            }
                                            else MessageBox.Show("Данный телефон уже используется!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                        }
                                        else MessageBox.Show("Данный email уже используется!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    }
                                    catch (Exception ex)
                                    {
                                        MessageBox.Show("Error: " + ex.Message);
                                    }
                                    con.Close();
                                }
                                else MessageBox.Show("Пароли не совпадают");
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
