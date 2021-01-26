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
    public partial class Collections : Form
    {
        public Collections()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddCollection add = new AddCollection();
            add.ShowDialog();
        }

        private void Form13_Load(object sender, EventArgs e)
        {
            Actions.ListBoxFill(lbCollections, "Collections", "Id", "Name");
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Admin admin = new Admin();
            admin.Show();
            Hide();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(lbCollections.SelectedValue);

            if (id > 0)
            {
                DialogResult dialog = MessageBox.Show("Вы действительно хотите удалить данную коллекцию?", "Подтвердите", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialog == DialogResult.Yes)
                {
                    SqlConnection con = DBUtils.GetDBConnection();

                    try
                    {
                        con.Open();

                        SqlCommand cmd = con.CreateCommand();

                        cmd.CommandText = "SELECT COUNT(*) FROM CollectionsContent WHERE CollectionId = " + id;

                        bool delete = true; //указывает на то, что коллекция подлежит удалению.

                        if (Convert.ToInt32(cmd.ExecuteScalar()) > 0)
                        {
                            dialog = MessageBox.Show("Данной коллекции принадлежат некоторые фильмы. \nВосстановить буден невозможно.\nВсе равно удалить данную коллекцию?", "Предупреждение", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                            if (dialog == DialogResult.Yes)
                            {
                                cmd.CommandText = "DELETE CollectionsContent WHERE CollectionId = " + id;
                                cmd.ExecuteNonQuery();
                            }
                            else delete = false;
                        }

                        if (delete)
                        {
                            cmd.CommandText = "DELETE Collections WHERE Id = " + id;
                            cmd.ExecuteNonQuery();

                            MessageBox.Show("Коллекция была удалена!");
                        }

                        Actions.ListBoxFill(lbCollections, "Collections", "Id", "Name");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(Convert.ToString(ex));
                    }
                    finally { con.Close(); }
                }
            }
            else MessageBox.Show("Выберите коллекцию для удаления");
        }

        private void Collections_Activated(object sender, EventArgs e)
        {
            Actions.ListBoxFill(lbCollections, "Collections", "Id", "Name");
        }
    }
}
