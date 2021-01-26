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

namespace WindowsFormsApp4
{
    public partial class Form12 : Form
    {
        public Form12()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(Regex.IsMatch(textBox1.Text, @"^\w+$"))
            {
                SqlConnection con = DBUtils.GetDBConnection();

                try
                {
                    con.Open();

                    SqlCommand cmd = con.CreateCommand();

                    cmd.CommandText = "SELECT COUNT(*) FROM Genres WHERE Genre = '" + textBox1.Text + "'";

                    if (Convert.ToInt32(cmd.ExecuteScalar()) == 0)
                    {
                        cmd.CommandText = "INSERT INTO Genres VALUES ('" + textBox1.Text + "');";
                        cmd.ExecuteNonQuery();

                        MessageBox.Show("Жанр был успешно добавлен!");
                    }
                    else MessageBox.Show("Жанр с таким именем уже существует!");
                }                
                catch (Exception ex)
                {
                    MessageBox.Show(Convert.ToString(ex));
                }
                finally { con.Close(); }
            }
            else MessageBox.Show("Неверный формат ввода!");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
