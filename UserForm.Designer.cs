namespace Timetable
{
    partial class UserForm
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
            this.lblSurname = new System.Windows.Forms.Label();
            this.txtSurname = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblPatronymic = new System.Windows.Forms.Label();
            this.txtPatronymic = new System.Windows.Forms.TextBox();
            this.lbType = new System.Windows.Forms.ListBox();
            this.lblType = new System.Windows.Forms.Label();
            this.btnEnter = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.btnDropPassword = new System.Windows.Forms.Button();
            this.lblLogin = new System.Windows.Forms.Label();
            this.txtLogin = new System.Windows.Forms.TextBox();
            this.txtType = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lblSurname
            // 
            this.lblSurname.AutoSize = true;
            this.lblSurname.Location = new System.Drawing.Point(287, 142);
            this.lblSurname.Name = "lblSurname";
            this.lblSurname.Size = new System.Drawing.Size(59, 13);
            this.lblSurname.TabIndex = 0;
            this.lblSurname.Text = "Фамилия:";
            // 
            // txtSurname
            // 
            this.txtSurname.Location = new System.Drawing.Point(352, 139);
            this.txtSurname.Name = "txtSurname";
            this.txtSurname.Size = new System.Drawing.Size(120, 20);
            this.txtSurname.TabIndex = 1;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(314, 168);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(32, 13);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "Имя:";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(352, 165);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(120, 20);
            this.txtName.TabIndex = 1;
            // 
            // lblPatronymic
            // 
            this.lblPatronymic.AutoSize = true;
            this.lblPatronymic.Location = new System.Drawing.Point(289, 194);
            this.lblPatronymic.Name = "lblPatronymic";
            this.lblPatronymic.Size = new System.Drawing.Size(57, 13);
            this.lblPatronymic.TabIndex = 0;
            this.lblPatronymic.Text = "Отчество:";
            // 
            // txtPatronymic
            // 
            this.txtPatronymic.Location = new System.Drawing.Point(352, 191);
            this.txtPatronymic.Name = "txtPatronymic";
            this.txtPatronymic.Size = new System.Drawing.Size(120, 20);
            this.txtPatronymic.TabIndex = 1;
            // 
            // lbType
            // 
            this.lbType.FormattingEnabled = true;
            this.lbType.Location = new System.Drawing.Point(352, 217);
            this.lbType.Name = "lbType";
            this.lbType.Size = new System.Drawing.Size(120, 43);
            this.lbType.TabIndex = 2;
            // 
            // lblType
            // 
            this.lblType.AutoSize = true;
            this.lblType.Location = new System.Drawing.Point(243, 217);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(103, 13);
            this.lblType.TabIndex = 3;
            this.lblType.Text = "Тип пользователя:";
            // 
            // btnEnter
            // 
            this.btnEnter.Location = new System.Drawing.Point(352, 305);
            this.btnEnter.Name = "btnEnter";
            this.btnEnter.Size = new System.Drawing.Size(120, 44);
            this.btnEnter.TabIndex = 4;
            this.btnEnter.Text = "Действие";
            this.btnEnter.UseVisualStyleBackColor = true;
            this.btnEnter.Click += new System.EventHandler(this.btnEnter_Click);
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(226, 305);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(120, 44);
            this.btnBack.TabIndex = 5;
            this.btnBack.Text = "Назад";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // btnDropPassword
            // 
            this.btnDropPassword.Location = new System.Drawing.Point(478, 305);
            this.btnDropPassword.Name = "btnDropPassword";
            this.btnDropPassword.Size = new System.Drawing.Size(120, 44);
            this.btnDropPassword.TabIndex = 6;
            this.btnDropPassword.Text = "Сбросить пароль";
            this.btnDropPassword.UseVisualStyleBackColor = true;
            this.btnDropPassword.Visible = false;
            this.btnDropPassword.Click += new System.EventHandler(this.btnDropPassword_Click);
            // 
            // lblLogin
            // 
            this.lblLogin.AutoSize = true;
            this.lblLogin.Location = new System.Drawing.Point(305, 269);
            this.lblLogin.Name = "lblLogin";
            this.lblLogin.Size = new System.Drawing.Size(41, 13);
            this.lblLogin.TabIndex = 0;
            this.lblLogin.Text = "Логин:";
            // 
            // txtLogin
            // 
            this.txtLogin.Location = new System.Drawing.Point(352, 266);
            this.txtLogin.Name = "txtLogin";
            this.txtLogin.Size = new System.Drawing.Size(120, 20);
            this.txtLogin.TabIndex = 1;
            // 
            // txtType
            // 
            this.txtType.Location = new System.Drawing.Point(352, 217);
            this.txtType.Name = "txtType";
            this.txtType.ReadOnly = true;
            this.txtType.Size = new System.Drawing.Size(120, 20);
            this.txtType.TabIndex = 7;
            // 
            // UserForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.txtType);
            this.Controls.Add(this.btnDropPassword);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnEnter);
            this.Controls.Add(this.lblType);
            this.Controls.Add(this.lbType);
            this.Controls.Add(this.txtPatronymic);
            this.Controls.Add(this.lblPatronymic);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.txtLogin);
            this.Controls.Add(this.lblLogin);
            this.Controls.Add(this.txtSurname);
            this.Controls.Add(this.lblSurname);
            this.Name = "UserForm";
            this.Text = "UserForm";
            this.Load += new System.EventHandler(this.UserForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblSurname;
        private System.Windows.Forms.TextBox txtSurname;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblPatronymic;
        private System.Windows.Forms.TextBox txtPatronymic;
        private System.Windows.Forms.ListBox lbType;
        private System.Windows.Forms.Label lblType;
        private System.Windows.Forms.Button btnEnter;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btnDropPassword;
        private System.Windows.Forms.Label lblLogin;
        private System.Windows.Forms.TextBox txtLogin;
        private System.Windows.Forms.TextBox txtType;
    }
}