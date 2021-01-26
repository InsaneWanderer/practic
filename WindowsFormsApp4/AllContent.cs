using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp4
{
    public partial class AllContent : Form
    {
        public AllContent()
        {
            InitializeComponent();
        }

        private void AllContent_Load(object sender, EventArgs e)
        {
            Actions.ContentDataGridViewFill(dgvContent);
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Admin admin = new Admin();
            admin.Show();
            Hide();
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (dgvContent.SelectedRows.Count > 0)
            {
                DialogResult dialog = MessageBox.Show("Вы дейстивительно хотите удалить данный контент?", "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (dialog == DialogResult.Yes)
                {
                    for (int SelectedRow = 0; SelectedRow < dgvContent.SelectedRows.Count; SelectedRow++)
                    {
                        int ContentId = Convert.ToInt32(dgvContent.SelectedRows[SelectedRow].Cells[0].Value);

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

                            cmd.CommandText = "DELETE CollectionsContent WHERE ContentId = " + ContentId;
                            cmd.ExecuteNonQuery();

                            cmd.CommandText = "SELECT PosterName, Video FROM AllContent WHERE Id = " + ContentId;
                            SqlDataReader reader = cmd.ExecuteReader();
                            reader.Read();
                            File.Delete(Directory.GetParent(@"..").FullName + "\\Resources\\" + reader.GetString(0));
                            File.Delete(Directory.GetParent(@"..").FullName + "\\Resources\\" + reader.GetString(1));
                            reader.Close();

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
                            Actions.ContentDataGridViewFill(dgvContent);
                        }
                    }
                    MessageBox.Show("Контент был удален!");
                }
            }
        }
    }
}
