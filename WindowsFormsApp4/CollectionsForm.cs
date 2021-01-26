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
    public partial class CollectionsForm : Form
    {
        public CollectionsForm()
        {
            InitializeComponent();
        }

        private void Form6_Load(object sender, EventArgs e)
        {
            Controls.Add(Header.Get());
            Controls.Add(Header.GetGenresPanel());
            Controls[Controls.Count - 2].BringToFront();
            Controls[Controls.Count - 1].BringToFront();

            SqlConnection conn = DBUtils.GetDBConnection();
            try
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT * FROM Collections";
                SqlDataReader reader = cmd.ExecuteReader();

                int x = 0, y = 35;
                while (reader.Read())
                {
                    string collectionName = reader.GetString(1);
                    int collectiontId = reader.GetInt32(0);
                    Label lb = new Label();

                    lb.AutoSize = false;
                    lb.Location = new System.Drawing.Point(x, y + 125);
                    lb.Name = "lb" + collectiontId;
                    lb.Size = new System.Drawing.Size(190, 30);
                    lb.TabIndex = 0;
                    lb.Text = collectionName;
                    lb.TextAlign = System.Drawing.ContentAlignment.TopCenter;
                    lb.Click += new EventHandler(lbFilm_Clicked);

                    x += 210;
                    if (x > 630)
                    {
                        x = 0;
                        y += 200;
                    }
                    panel3.Controls.Add(lb);
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                conn.Close();
            }
        }

        private void lbFilm_Clicked(object sender, EventArgs e)
        {
            Label triggeredCollection = (Label)sender;
            CollectionData.id = Convert.ToInt16(triggeredCollection.Name.Remove(0, 2));
            CollectionContent collectionContent = new CollectionContent();
            Hide();
            collectionContent.Show();
        }
    }
}

