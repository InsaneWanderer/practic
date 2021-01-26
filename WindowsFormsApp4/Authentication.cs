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
    public partial class Authentication : Form
    {
        public Authentication()
        {
            InitializeComponent();
        }

        private void linkRegistration_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Registration registration = new Registration();
            registration.Show();
            Hide();
        }

        private void Enter_Click(object sender, EventArgs e)
        {            
            if(!Regex.IsMatch(txtLogin.Text, @"^\s*$"))
            {
                if(!Regex.IsMatch(txtPassword.Text, @"^\s*$"))
                {
                    SqlConnection con = DBUtils.GetDBConnection();
                    try
                    {
                        con.Open();
                        SqlCommand cmd = con.CreateCommand();
                        cmd.CommandText = "SELECT UserId FROM Users WHERE Email = '" + txtLogin.Text + "'";
                        int id = Convert.ToInt32(cmd.ExecuteScalar());
                        if (id > 0)
                        {
                            cmd.CommandText = "SELECT Password FROM Users WHERE UserId = " + id;
                            string pass = Convert.ToString(cmd.ExecuteScalar());
                            if (txtPassword.Text == pass)
                            {
                                cmd.CommandText = "SELECT TypeId FROM Users WHERE UserId = " + id;
                                UserData.id = id;
                                int type = Convert.ToInt32(cmd.ExecuteScalar());

                                if(type == 1)
                                {
                                    Admin form = new Admin();
                                    form.Show();
                                }
                                else
                                {
                                    Start form = new Start();
                                    form.Show();
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
                    finally 
                    { 
                        if(con.State == ConnectionState.Open)
                            con.Close(); 
                    }                    
                }
            }
        }

        private void Authentication_Load(object sender, EventArgs e)
        {
            txtLogin.Text = "";
          
            txtPassword.Text = "";
            txtPassword.PasswordChar = '*';
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            
        }
    }
}
