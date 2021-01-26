namespace WindowsFormsApp4
{
    partial class Genres
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
            this.lbGenres = new System.Windows.Forms.ListBox();
            this.btnAddGenre = new System.Windows.Forms.Button();
            this.btnDeleteGenre = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbGenres
            // 
            this.lbGenres.FormattingEnabled = true;
            this.lbGenres.HorizontalScrollbar = true;
            this.lbGenres.ItemHeight = 16;
            this.lbGenres.Location = new System.Drawing.Point(176, 15);
            this.lbGenres.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lbGenres.Name = "lbGenres";
            this.lbGenres.Size = new System.Drawing.Size(220, 212);
            this.lbGenres.TabIndex = 23;
            // 
            // btnAddGenre
            // 
            this.btnAddGenre.Location = new System.Drawing.Point(89, 302);
            this.btnAddGenre.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnAddGenre.Name = "btnAddGenre";
            this.btnAddGenre.Size = new System.Drawing.Size(121, 46);
            this.btnAddGenre.TabIndex = 24;
            this.btnAddGenre.Text = "Добавить жанр";
            this.btnAddGenre.UseVisualStyleBackColor = true;
            this.btnAddGenre.Click += new System.EventHandler(this.btnAddGenre_Click);
            // 
            // btnDeleteGenre
            // 
            this.btnDeleteGenre.Location = new System.Drawing.Point(361, 302);
            this.btnDeleteGenre.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnDeleteGenre.Name = "btnDeleteGenre";
            this.btnDeleteGenre.Size = new System.Drawing.Size(121, 46);
            this.btnDeleteGenre.TabIndex = 25;
            this.btnDeleteGenre.Text = "Удалить жанр";
            this.btnDeleteGenre.UseVisualStyleBackColor = true;
            this.btnDeleteGenre.Click += new System.EventHandler(this.btnDeleteGenre_Click);
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(16, 378);
            this.btnBack.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(121, 46);
            this.btnBack.TabIndex = 24;
            this.btnBack.Text = "Назад";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // Genres
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(576, 438);
            this.Controls.Add(this.btnDeleteGenre);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnAddGenre);
            this.Controls.Add(this.lbGenres);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Genres";
            this.Text = "Form11";
            this.Activated += new System.EventHandler(this.Genres_Activated);
            this.Load += new System.EventHandler(this.Genres_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lbGenres;
        private System.Windows.Forms.Button btnAddGenre;
        private System.Windows.Forms.Button btnDeleteGenre;
        private System.Windows.Forms.Button btnBack;
    }
}