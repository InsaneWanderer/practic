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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
            Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            if(!Regex.IsMatch(textBox1.Text, @"^\s*$"))
            {
                if(!Regex.IsMatch(textBox2.Text, @"^\s*$"))
                {
                    SqlConnection con = DBUtils.GetDBConnection();
                    try
                    {
                        con.Open();
                        SqlCommand cmd = con.CreateCommand();
                        cmd.CommandText = "SELECT UserId FROM Users WHERE Email = '" + textBox1.Text + "'";
                        int id = Convert.ToInt32(cmd.ExecuteScalar());
                        if (id > 0)
                        {
                            cmd.CommandText = "SELECT Password FROM Users WHERE UserId = " + id;
                            string pass = Convert.ToString(cmd.ExecuteScalar());
                            if (textBox2.Text == pass)
                            {
                                cmd.CommandText = "SELECT * FROM UserSubscriptions WHERE UserId = " + id;
                                SqlDataReader reader = cmd.ExecuteReader();

                                if (reader.HasRows)
                                {
                                    reader.Read();
                                    if (DateTime.Now > Convert.ToDateTime(reader["EndDate"]))
                                    {
                                        cmd.CommandText = "DELETE UserSubscriptions WHERE UserId = " + id;
                                        cmd.ExecuteNonQuery();
                                        MessageBox.Show("Ваша подписка просрочена!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    }                                    
                                }

                                if (Convert.ToInt32(reader["SubscriptionId"]) == 1)
                                {
                                    Form9 form9 = new Form9();
                                    form9.Show();
                                }
                                else
                                {
                                    Form3 form3 = new Form3();
                                    form3.Show();
                                }
                                Hide();
                                
                            }
                            else MessageBox.Show("Неверный пароль!");
                        }
                        else MessageBox.Show("Такого аккаунта не существует");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                    finally { con.Close(); }                    
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBox1.Text = "";
          
            textBox2.Text = "";
            textBox2.PasswordChar = '*';
        }
    }
}
