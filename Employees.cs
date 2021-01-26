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

namespace HousingFund
{
    public partial class Employees : Form
    {
        public Employees()
        {
            InitializeComponent();
        }

        private void Employees_Load(object sender, EventArgs e)
        {
            FillEmployees();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvEmployees.SelectedRows[0].Cells[7].Value.ToString() != "1")
            {
                var result = MessageBox.Show("Вы действительно хотите удалить данного работника?\nВосстановить будет невозможно.", "Внимание!", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    int id = Convert.ToInt32(dgvEmployees.SelectedRows[0].Cells[0].Value);
                    SqlConnection conn = DBUtils.GetDBConnection();
                    try
                    {
                        conn.Open();
                        SqlCommand cmd = conn.CreateCommand();
                        cmd.CommandText = "DELETE Employees WHERE Id = " + id;
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Удаление прошло успешно!");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    finally
                    {
                        conn.Close();
                    }
                    FillEmployees();
                }
            }
            else MessageBox.Show("Вы не можете удалить админа");
        }

        private void FillEmployees()
        {
            SqlConnection conn = DBUtils.GetDBConnection();
            try
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT * FROM Employees";
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adapter.Fill(ds);
                dgvEmployees.DataSource = ds.Tables[0];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            EmployeeForm employee = new EmployeeForm();
            employee.ShowDialog();
            FillEmployees();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            EmployeeData.id = Convert.ToInt32(dgvEmployees.SelectedRows[0].Cells[0].Value);
            UpdateEmployee update = new UpdateEmployee();
            update.ShowDialog();
            FillEmployees();
        }
    }
}
