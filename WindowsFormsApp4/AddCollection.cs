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
    public partial class AddCollection : Form
    {
        public AddCollection()
        {
            InitializeComponent();
        }

        private void AddCollection_Load(object sender, EventArgs e)
        {
            Actions.ContentDataGridViewFill(dgvContent);
        }

        private void btnDone_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string CollectionName = txtName.Text;

            if(!Regex.IsMatch(CollectionName, @"^\s*$"))
            {
                if(dgvContent.SelectedRows.Count > 0)
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
                            for (int Row = 0; Row < dgvContent.SelectedRows.Count; Row++)
                            {
                                int ContentId = Convert.ToInt32(dgvContent.SelectedRows[Row].Cells[0].Value);
                                string Name = Convert.ToString(dgvContent.SelectedRows[Row].Cells[1].Value);                                
                                
                                cmd.CommandText = "SELECT MAX(Id) FROM Collections";
                                int NewCollectionId = Convert.ToInt32(cmd.ExecuteScalar());
                                
                                cmd.CommandText = "INSERT INTO CollectionsContent VALUES (" + NewCollectionId + ", " + ContentId + ");";
                                cmd.ExecuteNonQuery();

                                MessageBox.Show(Name + " был добавлен в коллекцию");                                                                       
                       
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
                        Actions.ContentDataGridViewFill(dgvContent);
                    }
                }
            }
            else MessageBox.Show("Недопустимое имя для коллекции!");
        }        
    }
}
