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
    public partial class TeacherSubject : Form
    {
        int id, rows = 1, y = 3;
        DataSet subjects;
        Button btnAdd = new Button();
        Button btnBack = new Button();
        Button btnUpdate = new Button();

        public TeacherSubject()
        {
            InitializeComponent();
        }

        public TeacherSubject(int id)
        {
            InitializeComponent();
            this.id = id;
        }

        private void TeacherSubject_Load(object sender, EventArgs e)
        {
            SqlConnection conn = DBUtils.GetDBConnection();
            try
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT SubjectId FROM Teachers " +
                    "WHERE TeacherId = " + id;
                SqlDataReader reader = cmd.ExecuteReader();
                if(reader.Read())
                {
                    do
                    {
                        LoadElements(y, rows++);
                        ((ListBox)panelSubjects.Controls[panelSubjects.Controls.Count - 2]).
                            SetSelected(FormActions.GetIndexOf((ListBox)panelSubjects.Controls[panelSubjects.Controls.Count - 2], reader.GetValue(0)), true);                        
                        y += 40;
                    } while (reader.Read());
                }
                else
                {
                    LoadElements(y, rows++);
                    y += 40;
                }
                Controls.Add(btnAdd);
                Controls[Controls.Count - 1].BringToFront();
                btnAdd.Location = new Point(90, 50 + panelSubjects.Size.Height + 7);
                btnAdd.Name = "btnAdd";
                btnAdd.Size = new Size(80, 25);
                btnAdd.TabIndex = 100;
                btnAdd.Text = "Добавить";
                btnAdd.UseVisualStyleBackColor = true;
                btnAdd.Click += new EventHandler(AddClicked);

                Controls.Add(btnBack);
                Controls[Controls.Count - 1].BringToFront();
                btnBack.Location = new Point(190, 50 + panelSubjects.Size.Height + 7);
                btnBack.Name = "btnBack";
                btnBack.Size = new Size(80, 25);
                btnBack.TabIndex = 100;
                btnBack.Text = "Назад";
                btnBack.UseVisualStyleBackColor = true;
                btnBack.Click += new EventHandler(BackClicked);

                Controls.Add(btnUpdate);
                Controls[Controls.Count - 1].BringToFront();
                btnUpdate.Location = new Point(280, 50 + panelSubjects.Size.Height + 7);
                btnUpdate.Name = "btnUpdate";
                btnUpdate.Size = new Size(90, 40);
                btnUpdate.TabIndex = 100;
                btnUpdate.Text = "Подтвердить\nизменения";
                btnUpdate.UseVisualStyleBackColor = true;
                btnUpdate.Click += new EventHandler(EnterClicked);
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
        //Прогружает элементы
        private void LoadElements(int y, int number)
        {
            Label lbl = new Label();
            ListBox lb = new ListBox();
            Button btn = new Button();
            panelSubjects.Controls.Add(lbl);
            panelSubjects.Controls.Add(lb);
            panelSubjects.Controls.Add(btn);

            lbl.AutoSize = true;
            lbl.Location = new Point(3, y);
            lbl.Name = "lblSubject" + number;
            lbl.Size = new Size(64, 13);
            lbl.TabIndex = (number-1) * 3;
            lbl.TabStop = true;
            lbl.Text = "Предмет " + number + ":";

            lb.FormattingEnabled = true;
            lb.Location = new Point(70, y - 1);
            lb.Name = "lbSubject" + number;
            lb.Size = new Size(145, 30);
            lb.TabIndex = (number - 1) * 3 + 1;
            SetSubjects(lb);

            btn.Location = new Point(237, y - 2);
            btn.Name = "btnDel" + number;
            btn.Size = new Size(63, 19);
            btn.TabIndex = (number - 1) * 3 + 2;
            btn.Text = "Удалить";
            btn.UseVisualStyleBackColor = true;
            btn.Click += new EventHandler(DeleteClicked);

            Size = new Size(Size.Width, Size.Height + 40);
        }
        //Подтверждение изменений
        private void EnterClicked(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Вы уверены в этом?", "Внимание", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(res == DialogResult.Yes)
            {
                string[] subjectsId = new string[0];

                //Запись всех выбранных предметов в массив
                for (int row = 1; row <= panelSubjects.Controls.Count / 3; row++)
                {
                    if (panelSubjects.Controls.ContainsKey("lblSubject" + row))
                    {
                        Array.Resize(ref subjectsId, subjectsId.Length + 1);
                        subjectsId[subjectsId.Length - 1] = ((ListBox)panelSubjects.Controls["lbSubject" + row]).SelectedValue.ToString();
                    }
                }
                //Очистка от повторяющихся значений
                for (int i = subjectsId.Length - 1; i > 0; i--)
                {
                    for (int j = i - 1; j >= 0; j--)
                        if(subjectsId[i] == subjectsId[j])
                        {
                            subjectsId[i] = "";
                            break;
                        }
                }

                SqlConnection conn = DBUtils.GetDBConnection();
                try
                {
                    conn.Open();
                    SqlCommand cmd = conn.CreateCommand();
                    cmd.CommandText = "DELETE Teachers WHERE TeacherId = " + id;
                    cmd.ExecuteNonQuery();
                    foreach (string subjectId in subjectsId)
                    {
                        if (subjectId != "")
                        {
                            cmd.CommandText = "INSERT INTO Teachers " +
                                "VALUES (" + id + ", " + subjectId + ");";
                            cmd.ExecuteNonQuery();
                        }
                    }
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
        //Возврат на предыдущую форму
        private void BackClicked(object sender, EventArgs e)
        {
            FormActions.GoTo(new AllTeachers());
        }
        //Добавление дополнительного предмета
        private void AddClicked(object sender, EventArgs e)
        {
            LoadElements(y, rows++);
            y += 40;
            btnAdd.Location = new Point(90, 50 + panelSubjects.Size.Height + 7);
            btnBack.Location = new Point(190, 50 + panelSubjects.Size.Height + 7);
            btnUpdate.Location = new Point(280, 50 + panelSubjects.Size.Height + 7);

        }
        //Удаление предмета
        private void DeleteClicked(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            string row = btn.Name.Remove(0, 6);
            panelSubjects.Controls.Remove(panelSubjects.Controls["lblSubject" + row]);
            panelSubjects.Controls.Remove(panelSubjects.Controls["lbSubject" + row]);
            panelSubjects.Controls.Remove(panelSubjects.Controls["btnDel" + row]);
        }
        //Загружает все предметы из базы данных в DataSet subjects
        private void LoadSubjects()
        {
            SqlConnection conn = DBUtils.GetDBConnection();
            try
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "SELECT * FROM Subjects";
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                subjects = new DataSet();
                adapter.Fill(subjects);
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
        //Загружает все предметы из DataSet subjects в ListBox
        private void SetSubjects(ListBox lb)
        {
            LoadSubjects();
            lb.DataSource = subjects.Tables[0];
            lb.ValueMember = "Id";
            lb.DisplayMember = "Name";
        }        
    }
}
