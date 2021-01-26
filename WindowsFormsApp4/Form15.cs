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
    public partial class Form15 : Form
    {
        public Form15()
        {
            InitializeComponent();
        }

        private void Form15_Load(object sender, EventArgs e)
        {
            Actions.ContentDataGridViewFill(dataGridView1);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form9 f = new Form9();
            f.Show();
            Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DialogResult dialog = MessageBox.Show("Вы дейстивительно хотите удалить данный контент?", "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (dialog == DialogResult.Yes)
                {
                    for (int SelectedRow = 0; SelectedRow < dataGridView1.SelectedRows.Count; SelectedRow++)
                    {
                        int ContentId = Convert.ToInt32(dataGridView1.SelectedRows[SelectedRow].Cells[0].Value);

                        SqlConnection con = DBUtils.GetDBConnection();

                        try
                        {
                            con.Open();

                            SqlCommand cmd = con.CreateCommand();

                            cmd.CommandText = "DELETE GenreAndContent WHERE ContentId = " + ContentId;
                            cmd.ExecuteNonQuery();

                            cmd.CommandText = "DELETE ActorsAndContent WHERE ContentId = " + ContentId;
                            cmd.ExecuteNonQuery();

                            cmd.CommandText = "DELETE DirectorsAndContent WHERE ContentId = " + ContentId;
                            cmd.ExecuteNonQuery();

                            cmd.CommandText = "DELETE AllContent WHERE Id = " + ContentId;
                            cmd.ExecuteNonQuery();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(Convert.ToString(ex));
                        }
                        finally
                        {
                            con.Close();
                            Actions.ContentDataGridViewFill(dataGridView1);
                        }
                    }
                    MessageBox.Show("Контент был удален!");
                }
            }
        }
    }
}
