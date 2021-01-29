namespace Timetable
{
    partial class AdminPanel
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnUsers = new System.Windows.Forms.Button();
            this.btnToTeachers = new System.Windows.Forms.Button();
            this.btnToStudents = new System.Windows.Forms.Button();
            this.btnToSubjects = new System.Windows.Forms.Button();
            this.btnToGroups = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnUsers
            // 
            this.btnUsers.Location = new System.Drawing.Point(228, 153);
            this.btnUsers.Name = "btnUsers";
            this.btnUsers.Size = new System.Drawing.Size(92, 50);
            this.btnUsers.TabIndex = 0;
            this.btnUsers.Text = "Пользователи";
            this.btnUsers.UseVisualStyleBackColor = true;
            this.btnUsers.Click += new System.EventHandler(this.btnUsers_Click);
            // 
            // btnToTeachers
            // 
            this.btnToTeachers.Location = new System.Drawing.Point(339, 153);
            this.btnToTeachers.Name = "btnToTeachers";
            this.btnToTeachers.Size = new System.Drawing.Size(92, 50);
            this.btnToTeachers.TabIndex = 2;
            this.btnToTeachers.Text = "Учителя";
            this.btnToTeachers.UseVisualStyleBackColor = true;
            this.btnToTeachers.Click += new System.EventHandler(this.btnToTeachers_Click);
            // 
            // btnToStudents
            // 
            this.btnToStudents.Location = new System.Drawing.Point(446, 153);
            this.btnToStudents.Name = "btnToStudents";
            this.btnToStudents.Size = new System.Drawing.Size(92, 50);
            this.btnToStudents.TabIndex = 3;
            this.btnToStudents.Text = "Студенты";
            this.btnToStudents.UseVisualStyleBackColor = true;
            this.btnToStudents.Click += new System.EventHandler(this.btnToStudents_Click);
            // 
            // btnToSubjects
            // 
            this.btnToSubjects.Location = new System.Drawing.Point(283, 209);
            this.btnToSubjects.Name = "btnToSubjects";
            this.btnToSubjects.Size = new System.Drawing.Size(92, 50);
            this.btnToSubjects.TabIndex = 4;
            this.btnToSubjects.Text = "Предметы";
            this.btnToSubjects.UseVisualStyleBackColor = true;
            this.btnToSubjects.Click += new System.EventHandler(this.btnToSubjects_Click);
            // 
            // btnToGroups
            // 
            this.btnToGroups.Location = new System.Drawing.Point(397, 209);
            this.btnToGroups.Name = "btnToGroups";
            this.btnToGroups.Size = new System.Drawing.Size(92, 50);
            this.btnToGroups.TabIndex = 4;
            this.btnToGroups.Text = "Группы";
            this.btnToGroups.UseVisualStyleBackColor = true;
            // 
            // AdminPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnToGroups);
            this.Controls.Add(this.btnToSubjects);
            this.Controls.Add(this.btnToStudents);
            this.Controls.Add(this.btnToTeachers);
            this.Controls.Add(this.btnUsers);
            this.Name = "AdminPanel";
            this.Text = "AdminPanel";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnUsers;
        private System.Windows.Forms.Button btnToTeachers;
        private System.Windows.Forms.Button btnToStudents;
        private System.Windows.Forms.Button btnToSubjects;
        private System.Windows.Forms.Button btnToGroups;
    }
}