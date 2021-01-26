namespace WindowsFormsApp4
{
    partial class Admin
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnAllContent = new System.Windows.Forms.Button();
            this.btnUpdateCollections = new System.Windows.Forms.Button();
            this.btnUpdateGenres = new System.Windows.Forms.Button();
            this.btnAddContent = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DarkGray;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(917, 78);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(196, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(337, 32);
            this.label1.TabIndex = 2;
            this.label1.Text = "Меню администратора";
            // 
            // panel2
            // 
            this.panel2.Location = new System.Drawing.Point(0, 75);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1155, 480);
            this.panel2.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.LightGray;
            this.panel3.Controls.Add(this.btnAllContent);
            this.panel3.Controls.Add(this.btnUpdateCollections);
            this.panel3.Controls.Add(this.btnUpdateGenres);
            this.panel3.Controls.Add(this.btnAddContent);
            this.panel3.Location = new System.Drawing.Point(0, 78);
            this.panel3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1155, 476);
            this.panel3.TabIndex = 1;
            // 
            // btnAllContent
            // 
            this.btnAllContent.Location = new System.Drawing.Point(47, 130);
            this.btnAllContent.Margin = new System.Windows.Forms.Padding(4);
            this.btnAllContent.Name = "btnAllContent";
            this.btnAllContent.Size = new System.Drawing.Size(176, 54);
            this.btnAllContent.TabIndex = 3;
            this.btnAllContent.Text = "Просмотреть/удалить контент";
            this.btnAllContent.UseVisualStyleBackColor = true;
            this.btnAllContent.Click += new System.EventHandler(this.btnAllContent_Click);
            // 
            // btnUpdateCollections
            // 
            this.btnUpdateCollections.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnUpdateCollections.Location = new System.Drawing.Point(451, 42);
            this.btnUpdateCollections.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnUpdateCollections.Name = "btnUpdateCollections";
            this.btnUpdateCollections.Size = new System.Drawing.Size(176, 54);
            this.btnUpdateCollections.TabIndex = 2;
            this.btnUpdateCollections.Text = "Редактировать коллекции";
            this.btnUpdateCollections.UseVisualStyleBackColor = true;
            this.btnUpdateCollections.Click += new System.EventHandler(this.btnUpdateCollections_Click);
            // 
            // btnUpdateGenres
            // 
            this.btnUpdateGenres.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnUpdateGenres.Location = new System.Drawing.Point(245, 42);
            this.btnUpdateGenres.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnUpdateGenres.Name = "btnUpdateGenres";
            this.btnUpdateGenres.Size = new System.Drawing.Size(176, 54);
            this.btnUpdateGenres.TabIndex = 1;
            this.btnUpdateGenres.Text = "Редактировать жанры";
            this.btnUpdateGenres.UseVisualStyleBackColor = true;
            this.btnUpdateGenres.Click += new System.EventHandler(this.btnUpdateGenres_Click);
            // 
            // btnAddContent
            // 
            this.btnAddContent.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnAddContent.Location = new System.Drawing.Point(47, 42);
            this.btnAddContent.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnAddContent.Name = "btnAddContent";
            this.btnAddContent.Size = new System.Drawing.Size(176, 54);
            this.btnAddContent.TabIndex = 0;
            this.btnAddContent.Text = "Добавить фильм/сериал";
            this.btnAddContent.UseVisualStyleBackColor = true;
            this.btnAddContent.Click += new System.EventHandler(this.btnAddContent_Click);
            // 
            // Admin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(673, 370);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Admin";
            this.Text = "Form9";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnAddContent;
        private System.Windows.Forms.Button btnUpdateCollections;
        private System.Windows.Forms.Button btnUpdateGenres;
        private System.Windows.Forms.Button btnAllContent;
    }
}