namespace Timetable
{
    partial class AllTeachers
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
            this.dgvDefiniteTeachers = new System.Windows.Forms.DataGridView();
            this.btnBack = new System.Windows.Forms.Button();
            this.lblDefiniteTeachers = new System.Windows.Forms.Label();
            this.dgvUndefiniteTeachers = new System.Windows.Forms.DataGridView();
            this.lblUndefiniteTeachers = new System.Windows.Forms.Label();
            this.btnAddSubjects = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDefiniteTeachers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUndefiniteTeachers)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvDefiniteTeachers
            // 
            this.dgvDefiniteTeachers.AllowUserToAddRows = false;
            this.dgvDefiniteTeachers.AllowUserToDeleteRows = false;
            this.dgvDefiniteTeachers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDefiniteTeachers.Location = new System.Drawing.Point(12, 28);
            this.dgvDefiniteTeachers.MultiSelect = false;
            this.dgvDefiniteTeachers.Name = "dgvDefiniteTeachers";
            this.dgvDefiniteTeachers.ReadOnly = true;
            this.dgvDefiniteTeachers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDefiniteTeachers.Size = new System.Drawing.Size(409, 220);
            this.dgvDefiniteTeachers.TabIndex = 0;
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(12, 388);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(92, 50);
            this.btnBack.TabIndex = 2;
            this.btnBack.Text = "Назад";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // lblDefiniteTeachers
            // 
            this.lblDefiniteTeachers.AutoSize = true;
            this.lblDefiniteTeachers.Location = new System.Drawing.Point(13, 9);
            this.lblDefiniteTeachers.Name = "lblDefiniteTeachers";
            this.lblDefiniteTeachers.Size = new System.Drawing.Size(163, 13);
            this.lblDefiniteTeachers.TabIndex = 3;
            this.lblDefiniteTeachers.Text = "Определенные преподаватели";
            // 
            // dgvUndefiniteTeachers
            // 
            this.dgvUndefiniteTeachers.AllowUserToAddRows = false;
            this.dgvUndefiniteTeachers.AllowUserToDeleteRows = false;
            this.dgvUndefiniteTeachers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUndefiniteTeachers.Location = new System.Drawing.Point(427, 28);
            this.dgvUndefiniteTeachers.MultiSelect = false;
            this.dgvUndefiniteTeachers.Name = "dgvUndefiniteTeachers";
            this.dgvUndefiniteTeachers.ReadOnly = true;
            this.dgvUndefiniteTeachers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvUndefiniteTeachers.Size = new System.Drawing.Size(409, 220);
            this.dgvUndefiniteTeachers.TabIndex = 0;
            // 
            // lblUndefiniteTeachers
            // 
            this.lblUndefiniteTeachers.AutoSize = true;
            this.lblUndefiniteTeachers.Location = new System.Drawing.Point(424, 9);
            this.lblUndefiniteTeachers.Name = "lblUndefiniteTeachers";
            this.lblUndefiniteTeachers.Size = new System.Drawing.Size(175, 13);
            this.lblUndefiniteTeachers.TabIndex = 3;
            this.lblUndefiniteTeachers.Text = "Неопределенные преподаватели";
            // 
            // btnAddSubjects
            // 
            this.btnAddSubjects.Location = new System.Drawing.Point(733, 254);
            this.btnAddSubjects.Name = "btnAddSubjects";
            this.btnAddSubjects.Size = new System.Drawing.Size(104, 55);
            this.btnAddSubjects.TabIndex = 4;
            this.btnAddSubjects.Text = "Определить преподавателя";
            this.btnAddSubjects.UseVisualStyleBackColor = true;
            this.btnAddSubjects.Click += new System.EventHandler(this.btnAddSubjects_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(12, 254);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(104, 55);
            this.btnUpdate.TabIndex = 4;
            this.btnUpdate.Text = "Изменить предмет";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // AllTeachers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(849, 450);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnAddSubjects);
            this.Controls.Add(this.lblUndefiniteTeachers);
            this.Controls.Add(this.lblDefiniteTeachers);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.dgvUndefiniteTeachers);
            this.Controls.Add(this.dgvDefiniteTeachers);
            this.Name = "AllTeachers";
            this.Text = "AllTeachers";
            this.Load += new System.EventHandler(this.AllTeachers_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDefiniteTeachers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUndefiniteTeachers)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvDefiniteTeachers;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Label lblDefiniteTeachers;
        private System.Windows.Forms.DataGridView dgvUndefiniteTeachers;
        private System.Windows.Forms.Label lblUndefiniteTeachers;
        private System.Windows.Forms.Button btnAddSubjects;
        private System.Windows.Forms.Button btnUpdate;
    }
}