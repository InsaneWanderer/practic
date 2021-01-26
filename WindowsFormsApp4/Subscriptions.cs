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

namespace WindowsFormsApp4
{
    public partial class Subscriptions : Form
    {
        public Subscriptions()
        {
            InitializeComponent();
        }

        private void Form7_Load(object sender, EventArgs e)
        {
            Controls.Add(Header.Get());
            Controls.Add(Header.GetGenresPanel());
            Controls[Controls.Count - 2].BringToFront();
            Controls[Controls.Count - 1].BringToFront();
        }

        private void button_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            int id = UserData.id;
            SqlConnection con = DBUtils.GetDBConnection();
            try
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandText = "SELECT COUNT(*) FROM UserSubscriptions WHERE UserId = " + id;
                if (Convert.ToInt32(cmd.ExecuteScalar()) == 0)
                {
                    switch (button.Name)
                    {
                        case "button1":
                            cmd.CommandText = id + ", 1";
                            break;
                        case "button2":
                            cmd.CommandText = id + ", 2";
                            break;
                        default:
                            cmd.CommandText = id + ", 3";
                            break;
                    }
                    cmd.CommandText = "INSERT INTO UserSubscriptions " +
                        "VALUES (" + cmd.CommandText + ", '" + DateTime.Today + "', '" + DateTime.Today.AddMonths(1) + "');";
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Подписка успешно активированна!", "Операция прошла успешно!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else MessageBox.Show("У вас уже оформлена подписка!", "Операция отменена", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                con.Close();
            }
            
        }
    }
}

