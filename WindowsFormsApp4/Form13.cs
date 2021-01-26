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
    public partial class Form13 : Form
    {
        public Form13()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form14 f = new Form14();
            f.ShowDialog();
        }

        private void Form13_Load(object sender, EventArgs e)
        {
            Actions.ListBoxFill(listBox1, "Collections", "Id", "Name");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form9 f = new Form9();
            f.Show();
            Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(listBox1.SelectedValue);

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

                        cmd.CommandText = "SELECT COUNT(*) FROM AllContent WHERE CollectionId = " + id;

                        bool delete = true; //указывает на то, что коллекция подлежит удалению.

                        if (Convert.ToInt32(cmd.ExecuteScalar()) > 0)
                        {
                            dialog = MessageBox.Show("Данной коллекции принадлежат несколько элементов. При удалении данная коллекция пропадет у этих элементов.\nВосстановить буден невозможно.\nВсе равно удалить данную коллекцию?", "Предупреждение", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                            if (dialog == DialogResult.Yes)
                            {
                                cmd.CommandText = "UPDATE AllContent SET CollectionId = NULL WHERE CollectionId = " + id;
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

                        Actions.ListBoxFill(listBox1, "Collections", "Id", "Name");
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

        private void Form13_Activated(object sender, EventArgs e)
        {
            Actions.ListBoxFill(listBox1, "Collections", "Id", "Name");
        }
    }
}
