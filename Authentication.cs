using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Timetable
{
    public partial class Authentication : Form
    {
        public Authentication()
        {
            InitializeComponent();
        }

        private void btnEnter_Click(object sender, EventArgs e)
        {
            SqlConnection conn = DBUtils.GetDBConnection();

            try
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT * FROM Users WHERE Login = '" + txtLogin.Text + "'";
                SqlDataReader reader = cmd.ExecuteReader();
                if(reader.Read())
                {
                    if(reader.GetString(6) == txtPassword.Text)
                    {
                        WorkUser.id = reader.GetInt32(0);
                        switch (reader.GetInt32(4))
                        {
                            case 1:
                                AdminPanel admin = new AdminPanel();
                                admin.Show();
                                break;
                        }
                        Hide();
                    }
                    else
                    {
                        MessageBox.Show("Неверный пароль!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    txtLogin.Text = "";
                    MessageBox.Show("Неверный логин!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                reader.Close();
                txtPassword.Text = "";
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
}
