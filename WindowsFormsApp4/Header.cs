using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp4
{    
    class Header
    {        
        private static System.Drawing.Color lblNewColor;
        private static System.Drawing.Color lblCollectionsColor;
        private static System.Drawing.Color lblSubscriptionsColor;
        private static Panel panelMain;
        private static Panel panelMenu;
        private static Panel panelGenres;
        private static PictureBox picLogo;
        private static PictureBox picSearch;
        private static PictureBox picSettings;
        private static Label lblContent;
        private static Label lblMy;
        private static Label lblNew;
        private static Label lblCatalog;
        private static Label lblCollections;
        private static Label lblSubscriptions;
        private static TextBox txtSearch;
        public static Panel Get()
        {
            panelMain = new Panel();
            panelMenu = new Panel();
            picLogo = new PictureBox();
            picSearch = new PictureBox();
            picSettings = new PictureBox();
            lblContent = new Label();
            lblMy = new Label();
            lblNew = new Label();
            lblCatalog = new Label();
            lblCollections = new Label();
            lblSubscriptions = new Label();
            txtSearch = new TextBox();
            panelMenu.SuspendLayout();
            panelMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(picLogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(picSearch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(picSettings)).BeginInit();
            //
            // panelMain
            //
            panelMain.BackColor = System.Drawing.Color.White;
            panelMain.Controls.Add(panelMenu);
            panelMain.Controls.Add(picLogo);
            panelMain.Controls.Add(picSearch);
            panelMain.Controls.Add(picSettings);
            panelMain.Controls.Add(lblContent);
            panelMain.Controls.Add(lblMy);
            panelMain.Controls.Add(txtSearch);
            panelMain.Location = new System.Drawing.Point(0, 0);
            panelMain.Margin = new Padding(0, 0, 0, 0);
            panelMain.Name = "panelMain";
            panelMain.Size = new System.Drawing.Size(1066, 135);
            panelMain.TabIndex = 0;
            panelMain.Visible = true;
            panelMain.TabStop = true;
            //
            // picLogo
            //
            picLogo.Image = HeaderImages.logo_Image;
            picLogo.Location = new System.Drawing.Point(0, -30);
            picLogo.Margin = new Padding(2);
            picLogo.Name = "picLogo";
            picLogo.Size = new System.Drawing.Size(154, 140);
            picLogo.SizeMode = PictureBoxSizeMode.StretchImage;
            picLogo.TabIndex = 0;
            picLogo.TabStop = true;
            //
            // lblContent
            //
            lblContent.AutoSize = true;
            lblContent.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            lblContent.Location = new System.Drawing.Point(161, 27);
            lblContent.Margin = new Padding(2, 0, 2, 0);
            lblContent.Name = "lblContent";
            lblContent.Size = new System.Drawing.Size(138, 19);
            lblContent.TabIndex = 1;
            lblContent.Text = "Кино и сериалы";
            lblContent.Click += new EventHandler(lblContent_Clicked);
            //
            // lblMy
            //
            lblMy.AutoSize = true;
            lblMy.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            lblMy.Location = new System.Drawing.Point(313, 27);
            lblMy.Margin = new Padding(2, 0, 2, 0);
            lblMy.Name = "lblMy";
            lblMy.Size = new System.Drawing.Size(41, 19);
            lblMy.TabIndex = 2;
            lblMy.Text = "Моё";
            lblMy.Click += new EventHandler(lblMy_Clicked);
            //
            // txtSearch
            //
            txtSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            txtSearch.Location = new System.Drawing.Point(696, 20);
            txtSearch.Margin = new Padding(2);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new System.Drawing.Size(266, 26);
            txtSearch.TabIndex = 3;
            //
            // picSearch
            //
            picSearch.Image = HeaderImages.search_Image;
            picSearch.Location = new System.Drawing.Point(936, 20);
            picSearch.Margin = new Padding(2);
            picSearch.Name = "picSearch";
            picSearch.Size = new System.Drawing.Size(26, 26);
            picSearch.SizeMode = PictureBoxSizeMode.StretchImage;
            picSearch.TabIndex = 4;
            //
            // picSettings
            //
            picSettings.Image = HeaderImages.settings_Image;
            picSettings.Location = new System.Drawing.Point(993, 15);
            picSettings.Margin = new Padding(2);
            picSettings.Name = "pictureBox3";
            picSettings.Size = new System.Drawing.Size(37, 37);
            picSettings.SizeMode = PictureBoxSizeMode.StretchImage;
            picSettings.TabIndex = 5;
            //
            // panelMenu
            //
            panelMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(103)))), ((int)(((byte)(183)))));
            panelMenu.Controls.Add(lblSubscriptions);
            panelMenu.Controls.Add(lblCollections);
            panelMenu.Controls.Add(lblCatalog);
            panelMenu.Controls.Add(lblNew);
            panelMenu.Location = new System.Drawing.Point(0, 84);
            panelMenu.Margin = new Padding(2);
            panelMenu.Name = "panelMenu";
            panelMenu.Size = new System.Drawing.Size(1064, 34);
            panelMenu.TabIndex = 0;
            panelMenu.TabStop = true;
            //
            // lblNew
            //
            lblNew.AutoSize = true;
            lblNew.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            lblNew.ForeColor = lblNewColor.IsEmpty ? System.Drawing.Color.White : lblNewColor;
            lblNew.Location = new System.Drawing.Point(161, 8);
            lblNew.Margin = new Padding(2, 0, 2, 0);
            lblNew.Name = "lblNew";
            lblNew.Size = new System.Drawing.Size(79, 19);
            lblNew.TabIndex = 6;
            lblNew.Text = "Новинки";
            lblNew.Click += new EventHandler(MenuLabel_Clicked);
            lblNew.MouseEnter += new EventHandler(MenuLabel_MouseEnter);
            lblNew.MouseLeave += new EventHandler(MenuLabel_MouseLeave);
            //
            // lblCatalog
            //
            lblCatalog.AutoSize = true;
            lblCatalog.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            lblCatalog.Location = new System.Drawing.Point(253, 8);
            lblCatalog.Name = "lblCatalog";
            lblCatalog.Size = new System.Drawing.Size(72, 19);
            lblCatalog.TabIndex = 7;
            lblCatalog.Text = "Каталог";
            lblCatalog.Click += new EventHandler(MenuLabel_Clicked);
            lblCatalog.MouseEnter += new EventHandler(MenuLabel_MouseEnter);
            lblCatalog.MouseLeave += new EventHandler(MenuLabel_MouseLeave);
            // 
            // lblCollections
            // 
            lblCollections.AutoSize = true;
            lblCollections.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            lblCollections.ForeColor = lblCollectionsColor.IsEmpty ? System.Drawing.Color.Black : lblCollectionsColor;
            lblCollections.Location = new System.Drawing.Point(338, 8);
            lblCollections.Name = "lblCollections";
            lblCollections.Size = new System.Drawing.Size(89, 19);
            lblCollections.TabIndex = 8;
            lblCollections.Text = "Подборки";
            lblCollections.Click += new EventHandler(MenuLabel_Clicked);
            lblCollections.MouseEnter += new EventHandler(MenuLabel_MouseEnter);
            lblCollections.MouseLeave += new EventHandler(MenuLabel_MouseLeave);
            // 
            // lblSubscriptions
            // 
            lblSubscriptions.AutoSize = true;
            lblSubscriptions.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            lblSubscriptions.ForeColor = lblSubscriptionsColor.IsEmpty ? System.Drawing.Color.Black : lblSubscriptionsColor;
            lblSubscriptions.Location = new System.Drawing.Point(435, 8);
            lblSubscriptions.Name = "lblSubscriptions";
            lblSubscriptions.Size = new System.Drawing.Size(88, 19);
            lblSubscriptions.TabIndex = 9;
            lblSubscriptions.Text = "Подписки";
            lblSubscriptions.Click += new EventHandler(MenuLabel_Clicked);
            lblSubscriptions.MouseEnter += new EventHandler(MenuLabel_MouseEnter);
            lblSubscriptions.MouseLeave += new EventHandler(MenuLabel_MouseLeave);            

            return panelMain;
        }

        public static Panel GetGenresPanel()
        {
            panelGenres = new Panel();
            panelGenres.SuspendLayout();
            //
            // panelGenres
            //
            panelGenres.AutoSize = true;
            panelGenres.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(103)))), ((int)(((byte)(183)))));
            panelGenres.Location = new System.Drawing.Point(0, 114);
            panelGenres.Margin = new Padding(2);
            panelGenres.MaximumSize = new System.Drawing.Size(1066, 0);
            panelGenres.MinimumSize = new System.Drawing.Size(1066, 0);
            panelGenres.Name = "panelGenres";
            panelGenres.Size = new System.Drawing.Size(1066, 0);
            panelGenres.TabIndex = 0;
            panelGenres.TabStop = true;
            panelGenres.Visible = false;
            //
            // Genres
            //
            SqlConnection con = DBUtils.GetDBConnection();
            try
            {
                con.Open();
                string sql = "SELECT * FROM Genres";
                SqlCommand cmd = new SqlCommand(sql, con);
                SqlDataReader reader = cmd.ExecuteReader();

                int x = 130, y = 15;

                while (reader.Read())
                {
                    string genre = reader.GetString(1);
                    int genreId = reader.GetInt32(0);

                    Label lb = new Label();
                    panelGenres.Controls.Add(lb);
                    lb.AutoSize = false;
                    lb.Location = new System.Drawing.Point(x, y);
                    lb.Name = "lb" + genreId;
                    lb.Size = new System.Drawing.Size(150, 30);
                    lb.TabIndex = 0;
                    lb.Text = genre;
                    lb.TextAlign = System.Drawing.ContentAlignment.TopCenter;
                    lb.Click += new EventHandler(lbGenre_Clicked);
                    lb.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
                    lb.ForeColor = System.Drawing.Color.White;
                    x += 150;
                    if (x > 790)
                    {
                        x = 130;
                        y += 50;
                    }
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                con.Close();
            }

            return panelGenres;
        }

        public static void MenuLabel_Clicked(object sender, EventArgs e)
        {
            Label label = (Label)sender;
            var activeForm = Form.ActiveForm;
            switch (label.Text)
            {
                case "Новинки":
                    if (activeForm.GetType() != Type.GetType("WindowsFormsApp4.Start"))
                    {
                        lblNewColor = System.Drawing.Color.White;
                        lblCollectionsColor = System.Drawing.Color.Black;
                        lblSubscriptionsColor = System.Drawing.Color.Black;

                        Start start = new Start();
                        start.Show();
                        activeForm.Hide();
                    }
                    break;
                case "Подборки":
                    if (activeForm.GetType() != Type.GetType("WindowsFormsApp4.CollectionsForm"))
                    {
                        lblNewColor = System.Drawing.Color.Black;
                        lblCollectionsColor = System.Drawing.Color.White;
                        lblSubscriptionsColor = System.Drawing.Color.Black;

                        CollectionsForm collections = new CollectionsForm();
                        collections.Show();
                        activeForm.Hide();
                    }
                    break;
                case "Подписки":
                    if (activeForm.GetType() != Type.GetType("WindowsFormsApp4.Subscriptions"))
                    {
                        lblNewColor = System.Drawing.Color.Black;
                        lblCollectionsColor = System.Drawing.Color.Black;
                        lblSubscriptionsColor = System.Drawing.Color.White;

                        Subscriptions subscriptions = new Subscriptions();
                        subscriptions.Show();
                        activeForm.Hide();
                    }
                    break;
                case "Каталог":
                    panelGenres.Visible = !panelGenres.Visible;
                    break;
                default:
                    lblNewColor = System.Drawing.Color.Black;
                    lblCollectionsColor = System.Drawing.Color.Black;
                    lblSubscriptionsColor = System.Drawing.Color.Black;
                    break;
            } 
        }

        public static void MenuLabel_MouseLeave(object sender, EventArgs e)
        {
            Label label = (Label)sender;
            var activeForm = Form.ActiveForm;
            switch (label.Text)
            {
                case "Новинки":
                    if (activeForm.GetType() != Type.GetType("WindowsFormsApp4.Start"))
                    {
                        label.ForeColor = System.Drawing.Color.Black;
                    }
                    break;
                case "Подборки":
                    if (activeForm.GetType() != Type.GetType("WindowsFormsApp4.CollectionsForm"))
                    {
                        label.ForeColor = System.Drawing.Color.Black;
                    }
                    break;
                case "Подписки":
                    if (activeForm.GetType() != Type.GetType("WindowsFormsApp4.Subscriptions"))
                    {
                        label.ForeColor = System.Drawing.Color.Black;
                    }
                    break;
                default:
                    label.ForeColor = System.Drawing.Color.Black;
                    break;
            }
        }

        public static void MenuLabel_MouseEnter(object sender, EventArgs e)
        {
            Label label = (Label)sender;
            var activeForm = Form.ActiveForm;
            switch (label.Text)
            {
                case "Новинки":
                    if (activeForm.GetType() != Type.GetType("WindowsFormsApp4.Start"))
                    {
                        label.ForeColor = System.Drawing.Color.White;
                    }
                    break;
                case "Подборки":
                    if (activeForm.GetType() != Type.GetType("WindowsFormsApp4.CollectionsForm"))
                    {
                        label.ForeColor = System.Drawing.Color.White;
                    }
                    break;
                case "Подписки":
                    if (activeForm.GetType() != Type.GetType("WindowsFormsApp4.Subscriptions"))
                    {
                        label.ForeColor = System.Drawing.Color.White;
                    }
                    break;
                default:
                    label.ForeColor = System.Drawing.Color.White;
                    break;
            }
        }

        private static void lbGenre_Clicked(object sender, EventArgs e)
        {
            Label triggeredGenre = (Label)sender;
            GenreData.id = Convert.ToInt16(triggeredGenre.Name.Remove(0, 2));
            GenreContent genreContent = new GenreContent();
            Form.ActiveForm.Hide();
            genreContent.Show();
        }

        private static void lblContent_Clicked(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private static void lblMy_Clicked(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
