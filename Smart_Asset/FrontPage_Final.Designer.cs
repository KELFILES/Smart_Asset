namespace Smart_Asset
{
    partial class FrontPage_Final
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
            sideMenu_Panel = new Panel();
            logout_Panel = new Panel();
            logout_Btn = new Button();
            panel5 = new Panel();
            createReport_Btn = new Button();
            ManageUsers_Btn = new Button();
            artificialIntelligence_Btn = new Button();
            fileMaintenance_SubMenuPanel = new Panel();
            backupData_Btn = new Button();
            AssetCategories_Btn = new Button();
            AssetHistory_Btn = new Button();
            asset_Btn = new Button();
            ManageAsset_Btn = new Button();
            dashboard_Btn = new Button();
            logo_Panel = new Panel();
            pictureBox1 = new PictureBox();
            panel3 = new Panel();
            header_Lbl = new Label();
            headerPicture_Pb = new PictureBox();
            qmark_Btn = new Button();
            mainPanel = new Panel();
            sideMenu_Panel.SuspendLayout();
            logout_Panel.SuspendLayout();
            panel5.SuspendLayout();
            fileMaintenance_SubMenuPanel.SuspendLayout();
            logo_Panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)headerPicture_Pb).BeginInit();
            SuspendLayout();
            // 
            // sideMenu_Panel
            // 
            sideMenu_Panel.AutoScroll = true;
            sideMenu_Panel.BackColor = Color.FromArgb(11, 8, 20);
            sideMenu_Panel.BorderStyle = BorderStyle.Fixed3D;
            sideMenu_Panel.Controls.Add(logout_Panel);
            sideMenu_Panel.Controls.Add(panel5);
            sideMenu_Panel.Controls.Add(logo_Panel);
            sideMenu_Panel.Dock = DockStyle.Left;
            sideMenu_Panel.Location = new Point(2, 2);
            sideMenu_Panel.Name = "sideMenu_Panel";
            sideMenu_Panel.Size = new Size(250, 1037);
            sideMenu_Panel.TabIndex = 0;
            // 
            // logout_Panel
            // 
            logout_Panel.Controls.Add(logout_Btn);
            logout_Panel.Dock = DockStyle.Bottom;
            logout_Panel.Location = new Point(0, 971);
            logout_Panel.Name = "logout_Panel";
            logout_Panel.Padding = new Padding(0, 20, 90, 20);
            logout_Panel.Size = new Size(246, 62);
            logout_Panel.TabIndex = 50;
            // 
            // logout_Btn
            // 
            logout_Btn.AutoSize = true;
            logout_Btn.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            logout_Btn.Dock = DockStyle.Right;
            logout_Btn.FlatAppearance.BorderColor = Color.White;
            logout_Btn.FlatAppearance.MouseDownBackColor = Color.Red;
            logout_Btn.FlatAppearance.MouseOverBackColor = Color.DimGray;
            logout_Btn.FlatStyle = FlatStyle.Flat;
            logout_Btn.Font = new Font("Segoe UI", 8F);
            logout_Btn.ForeColor = Color.Gainsboro;
            logout_Btn.Location = new Point(100, 20);
            logout_Btn.Name = "logout_Btn";
            logout_Btn.Size = new Size(56, 22);
            logout_Btn.TabIndex = 32;
            logout_Btn.Text = "Logout";
            logout_Btn.UseVisualStyleBackColor = true;
            logout_Btn.Click += logout_Btn_Click_1;
            // 
            // panel5
            // 
            panel5.BackColor = Color.FromArgb(11, 8, 20);
            panel5.Controls.Add(createReport_Btn);
            panel5.Controls.Add(ManageUsers_Btn);
            panel5.Controls.Add(artificialIntelligence_Btn);
            panel5.Controls.Add(fileMaintenance_SubMenuPanel);
            panel5.Controls.Add(ManageAsset_Btn);
            panel5.Controls.Add(dashboard_Btn);
            panel5.Dock = DockStyle.Fill;
            panel5.Location = new Point(0, 100);
            panel5.Name = "panel5";
            panel5.Size = new Size(246, 933);
            panel5.TabIndex = 49;
            // 
            // createReport_Btn
            // 
            createReport_Btn.Dock = DockStyle.Top;
            createReport_Btn.FlatAppearance.BorderSize = 0;
            createReport_Btn.FlatAppearance.MouseDownBackColor = Color.Red;
            createReport_Btn.FlatStyle = FlatStyle.Flat;
            createReport_Btn.ForeColor = Color.Gainsboro;
            createReport_Btn.ImageAlign = ContentAlignment.MiddleRight;
            createReport_Btn.Location = new Point(0, 353);
            createReport_Btn.Name = "createReport_Btn";
            createReport_Btn.Padding = new Padding(10, 0, 0, 0);
            createReport_Btn.Size = new Size(246, 45);
            createReport_Btn.TabIndex = 38;
            createReport_Btn.Text = "Create Report";
            createReport_Btn.TextAlign = ContentAlignment.MiddleLeft;
            createReport_Btn.UseVisualStyleBackColor = true;
            createReport_Btn.Click += createReport_Btn_Click_1;
            createReport_Btn.MouseEnter += createReport_Btn_MouseEnter;
            createReport_Btn.MouseLeave += createReport_Btn_MouseLeave;
            // 
            // ManageUsers_Btn
            // 
            ManageUsers_Btn.Dock = DockStyle.Top;
            ManageUsers_Btn.FlatAppearance.BorderSize = 0;
            ManageUsers_Btn.FlatAppearance.MouseDownBackColor = Color.Red;
            ManageUsers_Btn.FlatStyle = FlatStyle.Flat;
            ManageUsers_Btn.ForeColor = Color.Gainsboro;
            ManageUsers_Btn.ImageAlign = ContentAlignment.MiddleRight;
            ManageUsers_Btn.Location = new Point(0, 308);
            ManageUsers_Btn.Name = "ManageUsers_Btn";
            ManageUsers_Btn.Padding = new Padding(10, 0, 0, 0);
            ManageUsers_Btn.Size = new Size(246, 45);
            ManageUsers_Btn.TabIndex = 37;
            ManageUsers_Btn.Text = "Manage Users";
            ManageUsers_Btn.TextAlign = ContentAlignment.MiddleLeft;
            ManageUsers_Btn.UseVisualStyleBackColor = true;
            ManageUsers_Btn.Click += ManageUsers_Btn_Click_1;
            ManageUsers_Btn.MouseEnter += ManageUsers_Btn_MouseEnter;
            ManageUsers_Btn.MouseLeave += ManageUsers_Btn_MouseLeave;
            // 
            // artificialIntelligence_Btn
            // 
            artificialIntelligence_Btn.Dock = DockStyle.Top;
            artificialIntelligence_Btn.FlatAppearance.BorderSize = 0;
            artificialIntelligence_Btn.FlatAppearance.MouseDownBackColor = Color.Red;
            artificialIntelligence_Btn.FlatStyle = FlatStyle.Flat;
            artificialIntelligence_Btn.ForeColor = Color.Gainsboro;
            artificialIntelligence_Btn.ImageAlign = ContentAlignment.MiddleRight;
            artificialIntelligence_Btn.Location = new Point(0, 263);
            artificialIntelligence_Btn.Name = "artificialIntelligence_Btn";
            artificialIntelligence_Btn.Padding = new Padding(10, 0, 0, 0);
            artificialIntelligence_Btn.Size = new Size(246, 45);
            artificialIntelligence_Btn.TabIndex = 36;
            artificialIntelligence_Btn.Text = "Artificial Intelligence";
            artificialIntelligence_Btn.TextAlign = ContentAlignment.MiddleLeft;
            artificialIntelligence_Btn.UseVisualStyleBackColor = true;
            artificialIntelligence_Btn.Click += artificialIntelligence_Btn_Click_1;
            artificialIntelligence_Btn.MouseEnter += artificialIntelligence_Btn_MouseEnter;
            artificialIntelligence_Btn.MouseLeave += artificialIntelligence_Btn_MouseLeave;
            // 
            // fileMaintenance_SubMenuPanel
            // 
            fileMaintenance_SubMenuPanel.BackColor = Color.FromArgb(35, 32, 39);
            fileMaintenance_SubMenuPanel.Controls.Add(backupData_Btn);
            fileMaintenance_SubMenuPanel.Controls.Add(AssetCategories_Btn);
            fileMaintenance_SubMenuPanel.Controls.Add(AssetHistory_Btn);
            fileMaintenance_SubMenuPanel.Controls.Add(asset_Btn);
            fileMaintenance_SubMenuPanel.Dock = DockStyle.Top;
            fileMaintenance_SubMenuPanel.Location = new Point(0, 90);
            fileMaintenance_SubMenuPanel.Name = "fileMaintenance_SubMenuPanel";
            fileMaintenance_SubMenuPanel.Size = new Size(246, 173);
            fileMaintenance_SubMenuPanel.TabIndex = 23;
            // 
            // backupData_Btn
            // 
            backupData_Btn.Dock = DockStyle.Top;
            backupData_Btn.FlatAppearance.BorderSize = 0;
            backupData_Btn.FlatAppearance.MouseDownBackColor = Color.Red;
            backupData_Btn.FlatStyle = FlatStyle.Flat;
            backupData_Btn.ForeColor = Color.Gainsboro;
            backupData_Btn.ImageAlign = ContentAlignment.MiddleRight;
            backupData_Btn.Location = new Point(0, 120);
            backupData_Btn.Name = "backupData_Btn";
            backupData_Btn.Padding = new Padding(35, 0, 0, 0);
            backupData_Btn.Size = new Size(246, 40);
            backupData_Btn.TabIndex = 7;
            backupData_Btn.Text = "Backup Data";
            backupData_Btn.TextAlign = ContentAlignment.MiddleLeft;
            backupData_Btn.UseVisualStyleBackColor = true;
            backupData_Btn.Click += backupData_Btn_Click;
            backupData_Btn.MouseEnter += backupData_Btn_MouseEnter;
            backupData_Btn.MouseLeave += backupData_Btn_MouseLeave;
            // 
            // AssetCategories_Btn
            // 
            AssetCategories_Btn.Dock = DockStyle.Top;
            AssetCategories_Btn.FlatAppearance.BorderSize = 0;
            AssetCategories_Btn.FlatAppearance.MouseDownBackColor = Color.Red;
            AssetCategories_Btn.FlatStyle = FlatStyle.Flat;
            AssetCategories_Btn.ForeColor = Color.Gainsboro;
            AssetCategories_Btn.ImageAlign = ContentAlignment.MiddleRight;
            AssetCategories_Btn.Location = new Point(0, 80);
            AssetCategories_Btn.Name = "AssetCategories_Btn";
            AssetCategories_Btn.Padding = new Padding(35, 0, 0, 0);
            AssetCategories_Btn.Size = new Size(246, 40);
            AssetCategories_Btn.TabIndex = 6;
            AssetCategories_Btn.Text = "Asset Categories";
            AssetCategories_Btn.TextAlign = ContentAlignment.MiddleLeft;
            AssetCategories_Btn.UseVisualStyleBackColor = true;
            AssetCategories_Btn.Click += AssetCategories_Btn_Click;
            AssetCategories_Btn.MouseEnter += AssetCategories_Btn_MouseEnter;
            AssetCategories_Btn.MouseLeave += AssetCategories_Btn_MouseLeave;
            // 
            // AssetHistory_Btn
            // 
            AssetHistory_Btn.Dock = DockStyle.Top;
            AssetHistory_Btn.FlatAppearance.BorderSize = 0;
            AssetHistory_Btn.FlatAppearance.MouseDownBackColor = Color.Red;
            AssetHistory_Btn.FlatStyle = FlatStyle.Flat;
            AssetHistory_Btn.ForeColor = Color.Gainsboro;
            AssetHistory_Btn.ImageAlign = ContentAlignment.MiddleRight;
            AssetHistory_Btn.Location = new Point(0, 40);
            AssetHistory_Btn.Name = "AssetHistory_Btn";
            AssetHistory_Btn.Padding = new Padding(35, 0, 0, 0);
            AssetHistory_Btn.Size = new Size(246, 40);
            AssetHistory_Btn.TabIndex = 5;
            AssetHistory_Btn.Text = "Asset History";
            AssetHistory_Btn.TextAlign = ContentAlignment.MiddleLeft;
            AssetHistory_Btn.UseVisualStyleBackColor = true;
            AssetHistory_Btn.Click += AssetHistory_Button_Click;
            AssetHistory_Btn.MouseEnter += AssetHistory_Btn_MouseEnter;
            AssetHistory_Btn.MouseLeave += AssetHistory_Btn_MouseLeave;
            // 
            // asset_Btn
            // 
            asset_Btn.Dock = DockStyle.Top;
            asset_Btn.FlatAppearance.BorderSize = 0;
            asset_Btn.FlatAppearance.MouseDownBackColor = Color.Red;
            asset_Btn.FlatStyle = FlatStyle.Flat;
            asset_Btn.ForeColor = Color.Gainsboro;
            asset_Btn.ImageAlign = ContentAlignment.MiddleRight;
            asset_Btn.Location = new Point(0, 0);
            asset_Btn.Name = "asset_Btn";
            asset_Btn.Padding = new Padding(35, 0, 0, 0);
            asset_Btn.Size = new Size(246, 40);
            asset_Btn.TabIndex = 4;
            asset_Btn.Text = "Asset";
            asset_Btn.TextAlign = ContentAlignment.MiddleLeft;
            asset_Btn.UseVisualStyleBackColor = true;
            asset_Btn.Click += asset_Btn_Click;
            asset_Btn.MouseEnter += asset_Btn_MouseEnter;
            asset_Btn.MouseLeave += asset_Btn_MouseLeave;
            // 
            // ManageAsset_Btn
            // 
            ManageAsset_Btn.Dock = DockStyle.Top;
            ManageAsset_Btn.FlatAppearance.BorderSize = 0;
            ManageAsset_Btn.FlatAppearance.MouseDownBackColor = Color.Red;
            ManageAsset_Btn.FlatStyle = FlatStyle.Flat;
            ManageAsset_Btn.ForeColor = Color.Gainsboro;
            ManageAsset_Btn.ImageAlign = ContentAlignment.MiddleRight;
            ManageAsset_Btn.Location = new Point(0, 45);
            ManageAsset_Btn.Name = "ManageAsset_Btn";
            ManageAsset_Btn.Padding = new Padding(10, 0, 0, 0);
            ManageAsset_Btn.Size = new Size(246, 45);
            ManageAsset_Btn.TabIndex = 13;
            ManageAsset_Btn.Text = "Manage Asset";
            ManageAsset_Btn.TextAlign = ContentAlignment.MiddleLeft;
            ManageAsset_Btn.UseVisualStyleBackColor = true;
            ManageAsset_Btn.Click += ManageAsset_Btn_Click;
            ManageAsset_Btn.MouseEnter += fileMaintenance_Btn_MouseEnter;
            ManageAsset_Btn.MouseLeave += fileMaintenance_Btn_MouseLeave;
            // 
            // dashboard_Btn
            // 
            dashboard_Btn.Dock = DockStyle.Top;
            dashboard_Btn.FlatAppearance.BorderSize = 0;
            dashboard_Btn.FlatAppearance.MouseDownBackColor = Color.Red;
            dashboard_Btn.FlatStyle = FlatStyle.Flat;
            dashboard_Btn.ForeColor = Color.Gainsboro;
            dashboard_Btn.ImageAlign = ContentAlignment.MiddleRight;
            dashboard_Btn.Location = new Point(0, 0);
            dashboard_Btn.Name = "dashboard_Btn";
            dashboard_Btn.Padding = new Padding(10, 0, 0, 0);
            dashboard_Btn.Size = new Size(246, 45);
            dashboard_Btn.TabIndex = 12;
            dashboard_Btn.Text = "Dashboard";
            dashboard_Btn.TextAlign = ContentAlignment.MiddleLeft;
            dashboard_Btn.UseVisualStyleBackColor = true;
            dashboard_Btn.Click += dashboard_Btn_Click;
            dashboard_Btn.MouseEnter += dashboard_Btn_MouseEnter;
            dashboard_Btn.MouseLeave += dashboard_Btn_MouseLeave;
            // 
            // logo_Panel
            // 
            logo_Panel.Controls.Add(pictureBox1);
            logo_Panel.Dock = DockStyle.Top;
            logo_Panel.Location = new Point(0, 0);
            logo_Panel.Name = "logo_Panel";
            logo_Panel.Size = new Size(246, 100);
            logo_Panel.TabIndex = 47;
            // 
            // pictureBox1
            // 
            pictureBox1.BorderStyle = BorderStyle.FixedSingle;
            pictureBox1.Image = Properties.Resources.frontPage_Logo1;
            pictureBox1.ImageLocation = "";
            pictureBox1.InitialImage = null;
            pictureBox1.Location = new Point(36, 7);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(160, 87);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // panel3
            // 
            panel3.BackColor = Color.FromArgb(11, 7, 17);
            panel3.BorderStyle = BorderStyle.Fixed3D;
            panel3.Controls.Add(header_Lbl);
            panel3.Controls.Add(headerPicture_Pb);
            panel3.Controls.Add(qmark_Btn);
            panel3.Dock = DockStyle.Top;
            panel3.Location = new Point(252, 2);
            panel3.Name = "panel3";
            panel3.Padding = new Padding(0, 10, 0, 0);
            panel3.Size = new Size(1650, 55);
            panel3.TabIndex = 1;
            // 
            // header_Lbl
            // 
            header_Lbl.AutoSize = true;
            header_Lbl.Dock = DockStyle.Left;
            header_Lbl.Font = new Font("Segoe Script", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            header_Lbl.ForeColor = SystemColors.ButtonFace;
            header_Lbl.ImageAlign = ContentAlignment.MiddleLeft;
            header_Lbl.Location = new Point(115, 10);
            header_Lbl.Name = "header_Lbl";
            header_Lbl.Padding = new Padding(10, 0, 0, 0);
            header_Lbl.Size = new Size(127, 34);
            header_Lbl.TabIndex = 7;
            header_Lbl.Text = "HEADER";
            header_Lbl.TextAlign = ContentAlignment.MiddleRight;
            // 
            // headerPicture_Pb
            // 
            headerPicture_Pb.Dock = DockStyle.Left;
            headerPicture_Pb.Location = new Point(0, 10);
            headerPicture_Pb.Name = "headerPicture_Pb";
            headerPicture_Pb.Padding = new Padding(80, 0, 0, 0);
            headerPicture_Pb.Size = new Size(115, 41);
            headerPicture_Pb.TabIndex = 5;
            headerPicture_Pb.TabStop = false;
            // 
            // qmark_Btn
            // 
            qmark_Btn.FlatStyle = FlatStyle.Flat;
            qmark_Btn.Font = new Font("Segoe UI", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            qmark_Btn.ForeColor = SystemColors.ButtonFace;
            qmark_Btn.Image = Properties.Resources.questionMark_Icon;
            qmark_Btn.Location = new Point(1615, 13);
            qmark_Btn.Name = "qmark_Btn";
            qmark_Btn.Size = new Size(21, 21);
            qmark_Btn.TabIndex = 4;
            qmark_Btn.UseVisualStyleBackColor = true;
            qmark_Btn.Click += button3_Click;
            // 
            // mainPanel
            // 
            mainPanel.BackColor = Color.FromArgb(30, 30, 45);
            mainPanel.Dock = DockStyle.Fill;
            mainPanel.Location = new Point(252, 57);
            mainPanel.Name = "mainPanel";
            mainPanel.Size = new Size(1650, 982);
            mainPanel.TabIndex = 4;
            // 
            // FrontPage_Final
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1904, 1041);
            Controls.Add(mainPanel);
            Controls.Add(panel3);
            Controls.Add(sideMenu_Panel);
            Font = new Font("Segoe UI", 10F);
            Name = "FrontPage_Final";
            Padding = new Padding(2);
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FrontPage";
            Load += FrontPage_Final_Load;
            sideMenu_Panel.ResumeLayout(false);
            logout_Panel.ResumeLayout(false);
            logout_Panel.PerformLayout();
            panel5.ResumeLayout(false);
            fileMaintenance_SubMenuPanel.ResumeLayout(false);
            logo_Panel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)headerPicture_Pb).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private Panel sideMenu_Panel;
        private Panel panel3;
        private Panel logo_Panel;
        private Panel panel5;
        private Panel fileMaintenance_SubMenuPanel;
        private Button ManageAsset_Btn;
        private Button dashboard_Btn;
        private Button artificialIntelligence_Btn;
        private Button qmark_Btn;
        private Button asset_Btn;
        private Panel mainPanel;
        private PictureBox pictureBox1;
        private Panel logout_Panel;
        private Button logout_Btn;
        private Button createReport_Btn;
        private Button ManageUsers_Btn;
        private Button AssetHistory_Btn;
        private Button backupData_Btn;
        private Button AssetCategories_Btn;
        private PictureBox headerPicture_Pb;
        public Label header_Lbl;
    }
}