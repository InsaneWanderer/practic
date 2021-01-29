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
    public partial class AllTeachers : Form
    {
        public AllTeachers()
        {
            InitializeComponent();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            FormActions.GoTo(new AdminPanel());
        }

        private void AllTeachers_Load(object sender, EventArgs e)
        {
            SqlConnection conn = DBUtils.GetDBConnection();
            try
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT u.Id, u.Name 'Имя', u.Surname 'Фамилия', u.Patronymic 'Отчество', s.Subjects 'Преподаваемые предметы' FROM Users u " +
                    "JOIN(SELECT t.TeacherId, STRING_AGG(Name, ', ') Subjects FROM Subjects s " +
                    "JOIN Teachers t ON t.SubjectId = s.Id " +
                    "GROUP BY TeacherId) s ON u.Id = s.TeacherId";
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adapter.Fill(ds);
                dgvDefiniteTeachers.DataSource = ds.Tables[0];

                cmd.CommandText = "SELECT Id, Name 'Имя', Surname 'Фамилия', Patronymic 'Отчество' FROM Users " +
                    "WHERE TypeId = 3 AND Id NOT IN(SELECT TeacherId FROM Teachers)";
                adapter = new SqlDataAdapter(cmd);
                ds = new DataSet();
                adapter.Fill(ds);
                dgvUndefiniteTeachers.DataSource = ds.Tables[0];
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
            FormActions.GoTo(new TeacherSubject(Convert.ToInt32(dgvDefiniteTeachers.SelectedRows[0].Cells[0].Value)));
        }

        private void btnAddSubjects_Click(object sender, EventArgs e)
        {
            FormActions.GoTo(new TeacherSubject(Convert.ToInt32(dgvUndefiniteTeachers.SelectedRows[0].Cells[0].Value)));
        }
    }
}
