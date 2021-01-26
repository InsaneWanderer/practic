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
    public partial class Form14 : Form
    {
        public Form14()
        {
            InitializeComponent();
        }

        private void Form14_Load(object sender, EventArgs e)
        {
            Actions.ContentDataGridViewFill(dataGridView1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string CollectionName = textBox1.Text;

            if(!Regex.IsMatch(CollectionName, @"^\s*$"))
            {
                if(dataGridView1.SelectedRows.Count > 0)
                {
                    SqlConnection con = DBUtils.GetDBConnection();

                    try
                    {
                        con.Open();

                        SqlCommand cmd = con.CreateCommand();

                        cmd.CommandText = "SELECT COUNT(*) FROM Collections WHERE Name = '" + CollectionName + "'";
                        if (Convert.ToInt32(cmd.ExecuteScalar()) == 0)
                        {
                            cmd.CommandText = "INSERT INTO Collections VALUES ('" + CollectionName + "');";
                            cmd.ExecuteNonQuery();
                            for (int Row = 0; Row < dataGridView1.SelectedRows.Count; Row++)
                            {
                                int ContentId = Convert.ToInt32(dataGridView1.SelectedRows[Row].Cells[0].Value);
                                string Name = Convert.ToString(dataGridView1.SelectedRows[Row].Cells[1].Value);
                                int CollectionId = Convert.ToString(dataGridView1.SelectedRows[Row].Cells[9].Value) == "Отсутствует" ? 0 : Convert.ToInt32(dataGridView1.SelectedRows[Row].Cells[9].Value);
                                
                                cmd.CommandText = "SELECT MAX(Id) FROM Collections";
                                int NewCollectionId = Convert.ToInt32(cmd.ExecuteScalar());

                                bool ChangeCollection = true;

                                if (CollectionId > 0)
                                {
                                    DialogResult res = MessageBox.Show(Name + " уже состоит в коллекции. Изменить?", "Фильм уже имеет коллекцию", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                    if (res == DialogResult.No)
                                        ChangeCollection = false;
                                }

                                if (ChangeCollection)
                                {
                                    cmd.CommandText = "UPDATE AllContent SET CollectionId = " + NewCollectionId + " WHERE Id = " + ContentId;
                                    cmd.ExecuteNonQuery();

                                    MessageBox.Show(Name + " был добавлен в коллекцию");
                                }                                             
                       
                            }
                        }
                        else MessageBox.Show(Name + "Коллекция с таким именем уже существует!");
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
            }
            else MessageBox.Show("Недопустимое имя для коллекции!");
        }        
    }
}
