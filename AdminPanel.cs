using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Timetable
{
    public partial class AdminPanel : Form
    {
        public AdminPanel()
        {
            InitializeComponent();
        }

        private void btnUsers_Click(object sender, EventArgs e)
        {
            FormActions.GoTo(new AllUsers());
        }

        private void btnToTeachers_Click(object sender, EventArgs e)
        {
            FormActions.GoTo(new AllTeachers());
        }

        private void btnToStudents_Click(object sender, EventArgs e)
        {
            FormActions.GoTo(new AllStudents());
        }

        private void btnToSubjects_Click(object sender, EventArgs e)
        {

        }
    }
}
