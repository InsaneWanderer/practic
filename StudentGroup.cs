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

namespace Timetable
{
    public partial class StudentGroup : Form
    {
        int studentId;
        public StudentGroup()
        {
            InitializeComponent();
        }

        public StudentGroup(int studentId)
        {
            InitializeComponent();
            this.studentId = studentId;
        }

        private void StudentGroup_Load(object sender, EventArgs e)
        {
            SqlConnection conn = DBUtils.GetDBConnection();
            try
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT * FROM Groups";
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adapter.Fill(ds);
                lbGroups.DataSource = ds.Tables[0];
                lbGroups.ValueMember = "Id";
                lbGroups.DisplayMember = "Name";
                cmd.CommandText = "SELECT GroupId FROM Students " +
                    "WHERE StudentId = " + studentId;
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    lbGroups.SetSelected(FormActions.GetIndexOf(lbGroups, reader.GetValue(0)), true);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            FormActions.GoTo(new AllStudents());
        }

        private void btnEnter_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Вы уверены в этом?", "Внимание", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res == DialogResult.Yes)
            {
                SqlConnection conn = DBUtils.GetDBConnection();
                try
                {
                    conn.Open();
                    SqlCommand cmd = conn.CreateCommand();
                    cmd.CommandText = "DELETE Students WHERE StudentId = " + studentId;
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = "INSERT INTO Students " +
                        "VALUES (" + studentId + ", " + lbGroups.SelectedValue.ToString() + ");";
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Изменение прошло успешно!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                finally
                {
                    if (conn.State == ConnectionState.Open)
                        conn.Close();
                }
            }
        }
    }
}
