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
    public partial class Form11 : Form
    {
        public Form11()
        {
            InitializeComponent();
        }

        private void Form11_Load(object sender, EventArgs e)
        {
            Actions.ListBoxFill(listBox1, "Genres", "Id", "Genre");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form12 f = new Form12();
            f.ShowDialog();
        }

        private void Form11_Activated(object sender, EventArgs e)
        {
            Actions.ListBoxFill(listBox1, "Genres", "Id", "Genre");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(listBox1.SelectedValue);

            if (id > 0)
            {
                DialogResult dialog = MessageBox.Show("Вы действительно хотите удалить данный жанр?", "Подтвердите", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialog == DialogResult.Yes)
                {
                    SqlConnection con = DBUtils.GetDBConnection();

                    try
                    {
                        con.Open();

                        SqlCommand cmd = con.CreateCommand();

                        cmd.CommandText = "SELECT COUNT(*) FROM GenreAndContent WHERE GenreId = " + id;

                        bool delete = true; //указывает на то, что жанр подлежит удалению.

                        if (Convert.ToInt32(cmd.ExecuteScalar()) > 0)
                        {
                            dialog = MessageBox.Show("Данный жанр указан в качестве жанра у некоторых элементов. При удалении данный жанр пропадет у этих элементов.\nВосстановить буден невозможно.\nВсе равно удалить данный жанр?", "Предупреждение", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                            if (dialog == DialogResult.Yes)
                            {
                                cmd.CommandText = "DELETE GenreAndContent WHERE GenreId = " + id;
                                cmd.ExecuteNonQuery();
                            }
                            else delete = false;
                        }

                        if (delete)
                        {
                            cmd.CommandText = "DELETE Genres WHERE Id = " + id;
                            cmd.ExecuteNonQuery();

                            MessageBox.Show("Жанр был удален!");
                        }

                        Actions.ListBoxFill(listBox1, "Genres", "Id", "Genre");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(Convert.ToString(ex));
                    }
                    finally { con.Close(); }                    
                }
            }
            else MessageBox.Show("Выберите жанр для удаления");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form9 f = new Form9();
            f.Show();
            Hide();
        }
    }
}
