namespace Timetable
{
    partial class AllStudents
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
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnAddGroup = new System.Windows.Forms.Button();
            this.lblUndefiniteStudents = new System.Windows.Forms.Label();
            this.lblDefiniteStudents = new System.Windows.Forms.Label();
            this.btnBack = new System.Windows.Forms.Button();
            this.dgvUndefiniteStudents = new System.Windows.Forms.DataGridView();
            this.dgvDefiniteStudents = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUndefiniteStudents)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDefiniteStudents)).BeginInit();
            this.SuspendLayout();
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(12, 256);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(104, 55);
            this.btnUpdate.TabIndex = 10;
            this.btnUpdate.Text = "Изменить группу";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnAddGroup
            // 
            this.btnAddGroup.Location = new System.Drawing.Point(733, 256);
            this.btnAddGroup.Name = "btnAddGroup";
            this.btnAddGroup.Size = new System.Drawing.Size(104, 55);
            this.btnAddGroup.TabIndex = 11;
            this.btnAddGroup.Text = "Определить студента";
            this.btnAddGroup.UseVisualStyleBackColor = true;
            this.btnAddGroup.Click += new System.EventHandler(this.btnAddGroup_Click);
            // 
            // lblUndefiniteStudents
            // 
            this.lblUndefiniteStudents.AutoSize = true;
            this.lblUndefiniteStudents.Location = new System.Drawing.Point(424, 11);
            this.lblUndefiniteStudents.Name = "lblUndefiniteStudents";
            this.lblUndefiniteStudents.Size = new System.Drawing.Size(145, 13);
            this.lblUndefiniteStudents.TabIndex = 8;
            this.lblUndefiniteStudents.Text = "Неопределенные студенты";
            // 
            // lblDefiniteStudents
            // 
            this.lblDefiniteStudents.AutoSize = true;
            this.lblDefiniteStudents.Location = new System.Drawing.Point(13, 11);
            this.lblDefiniteStudents.Name = "lblDefiniteStudents";
            this.lblDefiniteStudents.Size = new System.Drawing.Size(133, 13);
            this.lblDefiniteStudents.TabIndex = 9;
            this.lblDefiniteStudents.Text = "Определенные студенты";
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(12, 390);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(92, 50);
            this.btnBack.TabIndex = 7;
            this.btnBack.Text = "Назад";
            this.btnBack.UseVisualStyleBackColor = true;
            // 
            // dgvUndefiniteStudents
            // 
            this.dgvUndefiniteStudents.AllowUserToAddRows = false;
            this.dgvUndefiniteStudents.AllowUserToDeleteRows = false;
            this.dgvUndefiniteStudents.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUndefiniteStudents.Location = new System.Drawing.Point(427, 30);
            this.dgvUndefiniteStudents.MultiSelect = false;
            this.dgvUndefiniteStudents.Name = "dgvUndefiniteStudents";
            this.dgvUndefiniteStudents.ReadOnly = true;
            this.dgvUndefiniteStudents.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvUndefiniteStudents.Size = new System.Drawing.Size(409, 220);
            this.dgvUndefiniteStudents.TabIndex = 5;
            // 
            // dgvDefiniteStudents
            // 
            this.dgvDefiniteStudents.AllowUserToAddRows = false;
            this.dgvDefiniteStudents.AllowUserToDeleteRows = false;
            this.dgvDefiniteStudents.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDefiniteStudents.Location = new System.Drawing.Point(12, 30);
            this.dgvDefiniteStudents.MultiSelect = false;
            this.dgvDefiniteStudents.Name = "dgvDefiniteStudents";
            this.dgvDefiniteStudents.ReadOnly = true;
            this.dgvDefiniteStudents.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDefiniteStudents.Size = new System.Drawing.Size(409, 220);
            this.dgvDefiniteStudents.TabIndex = 6;
            // 
            // AllStudents
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(849, 450);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnAddGroup);
            this.Controls.Add(this.lblUndefiniteStudents);
            this.Controls.Add(this.lblDefiniteStudents);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.dgvUndefiniteStudents);
            this.Controls.Add(this.dgvDefiniteStudents);
            this.Name = "AllStudents";
            this.Text = "AllStudents";
            this.Load += new System.EventHandler(this.AllStudents_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUndefiniteStudents)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDefiniteStudents)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnAddGroup;
        private System.Windows.Forms.Label lblUndefiniteStudents;
        private System.Windows.Forms.Label lblDefiniteStudents;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.DataGridView dgvUndefiniteStudents;
        private System.Windows.Forms.DataGridView dgvDefiniteStudents;
    }
}