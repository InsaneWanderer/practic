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

namespace HousingFund
{
    public partial class Authorization : Form
    {
        public Authorization()
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
                cmd.CommandText = "SELECT * FROM Employees WHERE Login = '" + txtLogin.Text + "'";
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    if(reader.GetString(6) == txtPassword.Text)
                    {
                        switch (reader.GetInt32(7))
                        {
                            case 1:
                                Admin admin = new Admin();
                                admin.Show();
                                break;
                        }
                        Hide();
                    }
                    else MessageBox.Show("Неверный пароль", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else MessageBox.Show("Неверный логин", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
