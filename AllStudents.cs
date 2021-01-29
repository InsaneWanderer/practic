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
    public partial class AllStudents : Form
    {
        public AllStudents()
        {
            InitializeComponent();
        }

        private void AllStudents_Load(object sender, EventArgs e)
        {
            SqlConnection conn = DBUtils.GetDBConnection();
            try
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT u.Id, u.Name 'Имя', u.Surname 'Фамилия', u.Patronymic 'Отчество', g.Name 'Группа' FROM Users u " +
                    "JOIN Students s ON s.StudentId = u.Id " +
                    "JOIN Groups g ON g.Id = s.GroupId";
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adapter.Fill(ds);
                dgvDefiniteStudents.DataSource = ds.Tables[0];

                cmd.CommandText = "SELECT Id, Name 'Имя', Surname 'Фамилия', Patronymic 'Отчество' FROM Users " +
                    "WHERE TypeId = 2 AND Id NOT IN(SELECT StudentId FROM Students)";
                adapter = new SqlDataAdapter(cmd);
                ds = new DataSet();
                adapter.Fill(ds);
                dgvUndefiniteStudents.DataSource = ds.Tables[0];
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

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            FormActions.GoTo(new StudentGroup(Convert.ToInt32(dgvDefiniteStudents.SelectedRows[0].Cells[0].Value)));
        }

        private void btnAddGroup_Click(object sender, EventArgs e)
        {
            FormActions.GoTo(new StudentGroup(Convert.ToInt32(dgvUndefiniteStudents.SelectedRows[0].Cells[0].Value)));
        }
    }
}
