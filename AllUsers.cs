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
    public partial class AllUsers : Form
    {
        UserData user;

        public AllUsers()
        {
            InitializeComponent();
        }

        private void AllUsers_Load(object sender, EventArgs e)
        {
            FillUsers();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            CallUserForm();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dgvUsers.SelectedRows.Count == 1)
            {
                GetData();
                CallUserForm(user);
            }
            else MessageBox.Show("Выберите пользователя!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (dgvUsers.SelectedRows.Count == 1)
            {
                int id = Convert.ToInt32(dgvUsers.SelectedRows[0].Cells[0].Value);

                if (id != WorkUser.id)
                {
                    DialogResult result = MessageBox.Show("Вы действительно хотите удалить данного пользователя?", "Внимание!",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        SqlConnection conn = DBUtils.GetDBConnection();
                        try
                        {
                            conn.Open();
                            SqlCommand cmd = conn.CreateCommand();
                            cmd.CommandText = "DELETE Teachers WHERE TeacherId = " + id;
                            cmd.ExecuteNonQuery();
                            cmd.CommandText = "DELETE Students WHERE StudentId = " + id;
                            cmd.ExecuteNonQuery();
                            cmd.CommandText = "DELETE Users WHERE Id = " + id;
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Удаление прошло успешно!");
                            FillUsers();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.ToString());
                        }
                        finally
                        {
                            if (conn.State == ConnectionState.Open)
                            {
                                conn.Close();
                            }
                        }
                    }
                }
                else MessageBox.Show("Вы не можете удалить самого себя!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else MessageBox.Show("Выберите пользователя!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        //Заполняет dataGridView данными из базы данных
        private void FillUsers()
        {
            SqlConnection conn = DBUtils.GetDBConnection();
            try
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT u.Id, u.Name, u.Surname, u.Patronymic, ut.Type, u.Login FROM Users u " +
                    "JOIN UserTypes ut ON ut.Id = u.TypeId";
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adapter.Fill(ds);
                dgvUsers.DataSource = ds.Tables[0];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if(conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }

        //Сохраняет данные пользователя в классе User
        private void GetData()
        {
            user = new UserData(dgvUsers.SelectedRows[0].Cells[0].Value.ToString(), dgvUsers.SelectedRows[0].Cells[2].Value.ToString(),
                 dgvUsers.SelectedRows[0].Cells[1].Value.ToString(), dgvUsers.SelectedRows[0].Cells[3].Value.ToString(),
                 dgvUsers.SelectedRows[0].Cells[4].Value.ToString(), dgvUsers.SelectedRows[0].Cells[5].Value.ToString());
        }

        //Вызывает UserForm в виде диалогового окна
        private void CallUserForm(UserData user = null)
        {
            UserForm userForm;
            if (user != null)
                userForm = new UserForm(user);
            else
                userForm = new UserForm();
            FormActions.GoTo(userForm);
            FillUsers();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            FormActions.GoTo(new AdminPanel());
        }
    }    
}
