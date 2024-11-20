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
            panel1 = new Panel();
            changePassword_Lbl = new Label();
            userID_Lbl = new Label();
            label2 = new Label();
            name_Lbl = new Label();
            label1 = new Label();
            backupAndRestoreData_Btn = new Button();
            createReport_Btn = new Button();
            ManageUsers_Btn = new Button();
            aIChat_Btn = new Button();
            fileMaintenance_SubMenuPanel = new Panel();
            assetHistory_Btn = new Button();
            archived_Btn = new Button();
            reserved_Btn = new Button();
            borrowed_Btn = new Button();
            disposed_Btn = new Button();
            replaced_Btn = new Button();
            cleaning_Btn = new Button();
            assets_Btn = new Button();
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
            panel1.SuspendLayout();
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
            logout_Panel.Location = new Point(0, 967);
            logout_Panel.Name = "logout_Panel";
            logout_Panel.Padding = new Padding(0, 20, 90, 20);
            logout_Panel.Size = new Size(246, 66);
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
            logout_Btn.Size = new Size(56, 26);
            logout_Btn.TabIndex = 32;
            logout_Btn.Text = "Logout";
            logout_Btn.UseVisualStyleBackColor = true;
            logout_Btn.Click += logout_Btn_Click_1;
            // 
            // panel5
            // 
            panel5.AutoScroll = true;
            panel5.BackColor = Color.FromArgb(11, 8, 20);
            panel5.Controls.Add(panel1);
            panel5.Controls.Add(backupAndRestoreData_Btn);
            panel5.Controls.Add(createReport_Btn);
            panel5.Controls.Add(ManageUsers_Btn);
            panel5.Controls.Add(aIChat_Btn);
            panel5.Controls.Add(fileMaintenance_SubMenuPanel);
            panel5.Controls.Add(ManageAsset_Btn);
            panel5.Controls.Add(dashboard_Btn);
            panel5.Dock = DockStyle.Fill;
            panel5.Location = new Point(0, 128);
            panel5.Name = "panel5";
            panel5.Size = new Size(246, 905);
            panel5.TabIndex = 49;
            // 
            // panel1
            // 
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(changePassword_Lbl);
            panel1.Controls.Add(userID_Lbl);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(name_Lbl);
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Bottom;
            panel1.Location = new Point(0, 704);
            panel1.Name = "panel1";
            panel1.Size = new Size(246, 201);
            panel1.TabIndex = 40;
            // 
            // changePassword_Lbl
            // 
            changePassword_Lbl.Anchor = AnchorStyles.Top;
            changePassword_Lbl.AutoSize = true;
            changePassword_Lbl.Cursor = Cursors.Hand;
            changePassword_Lbl.Font = new Font("Segoe UI", 9.75F, FontStyle.Underline, GraphicsUnit.Point, 0);
            changePassword_Lbl.ForeColor = Color.White;
            changePassword_Lbl.Location = new Point(66, 109);
            changePassword_Lbl.Name = "changePassword_Lbl";
            changePassword_Lbl.Size = new Size(112, 17);
            changePassword_Lbl.TabIndex = 4;
            changePassword_Lbl.Text = "Change Password";
            changePassword_Lbl.Click += changePassword_Lbl_Click;
            // 
            // userID_Lbl
            // 
            userID_Lbl.Anchor = AnchorStyles.Top;
            userID_Lbl.AutoSize = true;
            userID_Lbl.ForeColor = Color.White;
            userID_Lbl.Location = new Point(18, 78);
            userID_Lbl.Name = "userID_Lbl";
            userID_Lbl.Size = new Size(51, 19);
            userID_Lbl.TabIndex = 3;
            userID_Lbl.Text = "UserID";
            userID_Lbl.TabIndexChanged += userID_Lbl_TabIndexChanged;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top;
            label2.AutoSize = true;
            label2.ForeColor = Color.White;
            label2.Location = new Point(18, 59);
            label2.Name = "label2";
            label2.Size = new Size(58, 19);
            label2.TabIndex = 2;
            label2.Text = "User ID:";
            // 
            // name_Lbl
            // 
            name_Lbl.Anchor = AnchorStyles.Top;
            name_Lbl.AutoSize = true;
            name_Lbl.ForeColor = Color.White;
            name_Lbl.Location = new Point(18, 30);
            name_Lbl.Name = "name_Lbl";
            name_Lbl.Size = new Size(45, 19);
            name_Lbl.TabIndex = 1;
            name_Lbl.Text = "Name";
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top;
            label1.AutoSize = true;
            label1.ForeColor = Color.White;
            label1.Location = new Point(17, 11);
            label1.Name = "label1";
            label1.Size = new Size(40, 19);
            label1.TabIndex = 0;
            label1.Text = "User:";
            // 
            // backupAndRestoreData_Btn
            // 
            backupAndRestoreData_Btn.Dock = DockStyle.Top;
            backupAndRestoreData_Btn.FlatAppearance.BorderSize = 0;
            backupAndRestoreData_Btn.FlatAppearance.MouseDownBackColor = Color.Red;
            backupAndRestoreData_Btn.FlatStyle = FlatStyle.Flat;
            backupAndRestoreData_Btn.ForeColor = Color.Gainsboro;
            backupAndRestoreData_Btn.ImageAlign = ContentAlignment.MiddleRight;
            backupAndRestoreData_Btn.Location = new Point(0, 547);
            backupAndRestoreData_Btn.Name = "backupAndRestoreData_Btn";
            backupAndRestoreData_Btn.Padding = new Padding(10, 0, 0, 0);
            backupAndRestoreData_Btn.Size = new Size(246, 45);
            backupAndRestoreData_Btn.TabIndex = 39;
            backupAndRestoreData_Btn.Text = "Backup and Restore Data";
            backupAndRestoreData_Btn.TextAlign = ContentAlignment.MiddleLeft;
            backupAndRestoreData_Btn.UseVisualStyleBackColor = true;
            backupAndRestoreData_Btn.Click += backupData_Btn_Click;
            backupAndRestoreData_Btn.MouseEnter += backupData_Btn_MouseEnter;
            backupAndRestoreData_Btn.MouseLeave += backupData_Btn_MouseLeave;
            // 
            // createReport_Btn
            // 
            createReport_Btn.Dock = DockStyle.Top;
            createReport_Btn.FlatAppearance.BorderSize = 0;
            createReport_Btn.FlatAppearance.MouseDownBackColor = Color.Red;
            createReport_Btn.FlatStyle = FlatStyle.Flat;
            createReport_Btn.ForeColor = Color.Gainsboro;
            createReport_Btn.ImageAlign = ContentAlignment.MiddleRight;
            createReport_Btn.Location = new Point(0, 502);
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
            ManageUsers_Btn.Location = new Point(0, 457);
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
            // aIChat_Btn
            // 
            aIChat_Btn.Dock = DockStyle.Top;
            aIChat_Btn.FlatAppearance.BorderSize = 0;
            aIChat_Btn.FlatAppearance.MouseDownBackColor = Color.Red;
            aIChat_Btn.FlatStyle = FlatStyle.Flat;
            aIChat_Btn.ForeColor = Color.Gainsboro;
            aIChat_Btn.ImageAlign = ContentAlignment.MiddleRight;
            aIChat_Btn.Location = new Point(0, 412);
            aIChat_Btn.Name = "aIChat_Btn";
            aIChat_Btn.Padding = new Padding(10, 0, 0, 0);
            aIChat_Btn.Size = new Size(246, 45);
            aIChat_Btn.TabIndex = 36;
            aIChat_Btn.Text = "AI Chat";
            aIChat_Btn.TextAlign = ContentAlignment.MiddleLeft;
            aIChat_Btn.UseVisualStyleBackColor = true;
            aIChat_Btn.Click += artificialIntelligence_Btn_Click_1;
            aIChat_Btn.MouseEnter += artificialIntelligence_Btn_MouseEnter;
            aIChat_Btn.MouseLeave += artificialIntelligence_Btn_MouseLeave;
            // 
            // fileMaintenance_SubMenuPanel
            // 
            fileMaintenance_SubMenuPanel.BackColor = Color.FromArgb(35, 32, 39);
            fileMaintenance_SubMenuPanel.Controls.Add(assetHistory_Btn);
            fileMaintenance_SubMenuPanel.Controls.Add(archived_Btn);
            fileMaintenance_SubMenuPanel.Controls.Add(reserved_Btn);
            fileMaintenance_SubMenuPanel.Controls.Add(borrowed_Btn);
            fileMaintenance_SubMenuPanel.Controls.Add(disposed_Btn);
            fileMaintenance_SubMenuPanel.Controls.Add(replaced_Btn);
            fileMaintenance_SubMenuPanel.Controls.Add(cleaning_Btn);
            fileMaintenance_SubMenuPanel.Controls.Add(assets_Btn);
            fileMaintenance_SubMenuPanel.Dock = DockStyle.Top;
            fileMaintenance_SubMenuPanel.Location = new Point(0, 90);
            fileMaintenance_SubMenuPanel.Name = "fileMaintenance_SubMenuPanel";
            fileMaintenance_SubMenuPanel.Size = new Size(246, 322);
            fileMaintenance_SubMenuPanel.TabIndex = 23;
            // 
            // assetHistory_Btn
            // 
            assetHistory_Btn.Dock = DockStyle.Top;
            assetHistory_Btn.FlatAppearance.BorderSize = 0;
            assetHistory_Btn.FlatAppearance.MouseDownBackColor = Color.Red;
            assetHistory_Btn.FlatStyle = FlatStyle.Flat;
            assetHistory_Btn.ForeColor = Color.Gainsboro;
            assetHistory_Btn.ImageAlign = ContentAlignment.MiddleRight;
            assetHistory_Btn.Location = new Point(0, 280);
            assetHistory_Btn.Name = "assetHistory_Btn";
            assetHistory_Btn.Padding = new Padding(35, 0, 0, 0);
            assetHistory_Btn.Size = new Size(246, 40);
            assetHistory_Btn.TabIndex = 29;
            assetHistory_Btn.Text = "Asset History";
            assetHistory_Btn.TextAlign = ContentAlignment.MiddleLeft;
            assetHistory_Btn.UseVisualStyleBackColor = true;
            assetHistory_Btn.Click += AssetHistory_Button_Click;
            assetHistory_Btn.MouseEnter += AssetHistory_Btn_MouseEnter;
            assetHistory_Btn.MouseLeave += AssetHistory_Btn_MouseLeave;
            // 
            // archived_Btn
            // 
            archived_Btn.Dock = DockStyle.Top;
            archived_Btn.FlatAppearance.BorderSize = 0;
            archived_Btn.FlatAppearance.MouseDownBackColor = Color.Red;
            archived_Btn.FlatStyle = FlatStyle.Flat;
            archived_Btn.ForeColor = Color.Gainsboro;
            archived_Btn.ImageAlign = ContentAlignment.MiddleRight;
            archived_Btn.Location = new Point(0, 240);
            archived_Btn.Name = "archived_Btn";
            archived_Btn.Padding = new Padding(35, 0, 0, 0);
            archived_Btn.Size = new Size(246, 40);
            archived_Btn.TabIndex = 28;
            archived_Btn.Text = "Archived";
            archived_Btn.TextAlign = ContentAlignment.MiddleLeft;
            archived_Btn.UseVisualStyleBackColor = true;
            archived_Btn.Click += archived_Btn_Click;
            archived_Btn.MouseEnter += archived_Btn_MouseEnter;
            archived_Btn.MouseLeave += archived_Btn_MouseLeave;
            // 
            // reserved_Btn
            // 
            reserved_Btn.Dock = DockStyle.Top;
            reserved_Btn.FlatAppearance.BorderSize = 0;
            reserved_Btn.FlatAppearance.MouseDownBackColor = Color.Red;
            reserved_Btn.FlatStyle = FlatStyle.Flat;
            reserved_Btn.ForeColor = Color.Gainsboro;
            reserved_Btn.ImageAlign = ContentAlignment.MiddleRight;
            reserved_Btn.Location = new Point(0, 200);
            reserved_Btn.Name = "reserved_Btn";
            reserved_Btn.Padding = new Padding(35, 0, 0, 0);
            reserved_Btn.Size = new Size(246, 40);
            reserved_Btn.TabIndex = 27;
            reserved_Btn.Text = "Reserved";
            reserved_Btn.TextAlign = ContentAlignment.MiddleLeft;
            reserved_Btn.UseVisualStyleBackColor = true;
            reserved_Btn.Click += reserved_Btn_Click;
            reserved_Btn.MouseEnter += reserved_Btn_MouseEnter;
            reserved_Btn.MouseLeave += reserved_Btn_MouseLeave;
            // 
            // borrowed_Btn
            // 
            borrowed_Btn.Dock = DockStyle.Top;
            borrowed_Btn.FlatAppearance.BorderSize = 0;
            borrowed_Btn.FlatAppearance.MouseDownBackColor = Color.Red;
            borrowed_Btn.FlatStyle = FlatStyle.Flat;
            borrowed_Btn.ForeColor = Color.Gainsboro;
            borrowed_Btn.ImageAlign = ContentAlignment.MiddleRight;
            borrowed_Btn.Location = new Point(0, 160);
            borrowed_Btn.Name = "borrowed_Btn";
            borrowed_Btn.Padding = new Padding(35, 0, 0, 0);
            borrowed_Btn.Size = new Size(246, 40);
            borrowed_Btn.TabIndex = 26;
            borrowed_Btn.Text = "Borrowed";
            borrowed_Btn.TextAlign = ContentAlignment.MiddleLeft;
            borrowed_Btn.UseVisualStyleBackColor = true;
            borrowed_Btn.Click += borrowed_Btn_Click;
            borrowed_Btn.MouseEnter += borrowed_Btn_MouseEnter;
            borrowed_Btn.MouseLeave += borrowed_Btn_MouseLeave;
            // 
            // disposed_Btn
            // 
            disposed_Btn.Dock = DockStyle.Top;
            disposed_Btn.FlatAppearance.BorderSize = 0;
            disposed_Btn.FlatAppearance.MouseDownBackColor = Color.Red;
            disposed_Btn.FlatStyle = FlatStyle.Flat;
            disposed_Btn.ForeColor = Color.Gainsboro;
            disposed_Btn.ImageAlign = ContentAlignment.MiddleRight;
            disposed_Btn.Location = new Point(0, 120);
            disposed_Btn.Name = "disposed_Btn";
            disposed_Btn.Padding = new Padding(35, 0, 0, 0);
            disposed_Btn.Size = new Size(246, 40);
            disposed_Btn.TabIndex = 25;
            disposed_Btn.Text = "Disposed";
            disposed_Btn.TextAlign = ContentAlignment.MiddleLeft;
            disposed_Btn.UseVisualStyleBackColor = true;
            disposed_Btn.Click += disposed_Btn_Click_1;
            disposed_Btn.MouseEnter += disposed_Btn_MouseEnter;
            disposed_Btn.MouseLeave += disposed_Btn_MouseLeave;
            // 
            // replaced_Btn
            // 
            replaced_Btn.Dock = DockStyle.Top;
            replaced_Btn.FlatAppearance.BorderSize = 0;
            replaced_Btn.FlatAppearance.MouseDownBackColor = Color.Red;
            replaced_Btn.FlatStyle = FlatStyle.Flat;
            replaced_Btn.ForeColor = Color.Gainsboro;
            replaced_Btn.ImageAlign = ContentAlignment.MiddleRight;
            replaced_Btn.Location = new Point(0, 80);
            replaced_Btn.Name = "replaced_Btn";
            replaced_Btn.Padding = new Padding(35, 0, 0, 0);
            replaced_Btn.Size = new Size(246, 40);
            replaced_Btn.TabIndex = 24;
            replaced_Btn.Text = "Replaced";
            replaced_Btn.TextAlign = ContentAlignment.MiddleLeft;
            replaced_Btn.UseVisualStyleBackColor = true;
            replaced_Btn.Click += repairing_Btn_Click;
            replaced_Btn.MouseEnter += repairingHardwares_Btn_MouseEnter;
            replaced_Btn.MouseLeave += repairingHardwares_Btn_MouseLeave;
            // 
            // cleaning_Btn
            // 
            cleaning_Btn.Dock = DockStyle.Top;
            cleaning_Btn.FlatAppearance.BorderSize = 0;
            cleaning_Btn.FlatAppearance.MouseDownBackColor = Color.Red;
            cleaning_Btn.FlatStyle = FlatStyle.Flat;
            cleaning_Btn.ForeColor = Color.Gainsboro;
            cleaning_Btn.ImageAlign = ContentAlignment.MiddleRight;
            cleaning_Btn.Location = new Point(0, 40);
            cleaning_Btn.Name = "cleaning_Btn";
            cleaning_Btn.Padding = new Padding(35, 0, 0, 0);
            cleaning_Btn.Size = new Size(246, 40);
            cleaning_Btn.TabIndex = 23;
            cleaning_Btn.Text = "Cleaning";
            cleaning_Btn.TextAlign = ContentAlignment.MiddleLeft;
            cleaning_Btn.UseVisualStyleBackColor = true;
            cleaning_Btn.Click += cleaning_Btn_Click_1;
            cleaning_Btn.MouseEnter += cleaning_Btn_MouseEnter;
            cleaning_Btn.MouseLeave += cleaning_Btn_MouseLeave;
            // 
            // assets_Btn
            // 
            assets_Btn.Dock = DockStyle.Top;
            assets_Btn.FlatAppearance.BorderSize = 0;
            assets_Btn.FlatAppearance.MouseDownBackColor = Color.Red;
            assets_Btn.FlatStyle = FlatStyle.Flat;
            assets_Btn.ForeColor = Color.Gainsboro;
            assets_Btn.ImageAlign = ContentAlignment.MiddleRight;
            assets_Btn.Location = new Point(0, 0);
            assets_Btn.Name = "assets_Btn";
            assets_Btn.Padding = new Padding(35, 0, 0, 0);
            assets_Btn.Size = new Size(246, 40);
            assets_Btn.TabIndex = 4;
            assets_Btn.Text = "Assets";
            assets_Btn.TextAlign = ContentAlignment.MiddleLeft;
            assets_Btn.UseVisualStyleBackColor = true;
            assets_Btn.Click += asset_Btn_Click;
            assets_Btn.MouseEnter += asset_Btn_MouseEnter;
            assets_Btn.MouseLeave += asset_Btn_MouseLeave;
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
            logo_Panel.Size = new Size(246, 128);
            logo_Panel.TabIndex = 47;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.frontPage_Logo1;
            pictureBox1.ImageLocation = "";
            pictureBox1.InitialImage = null;
            pictureBox1.Location = new Point(24, 16);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(194, 95);
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
            header_Lbl.TextChanged += header_Lbl_TextChanged;
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
            FormClosed += FrontPage_Final_FormClosed;
            Load += FrontPage_Final_Load;
            sideMenu_Panel.ResumeLayout(false);
            logout_Panel.ResumeLayout(false);
            logout_Panel.PerformLayout();
            panel5.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
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
        private Button dashboard_Btn;
        private Button aIChat_Btn;
        private Button qmark_Btn;
        private Panel mainPanel;
        private PictureBox pictureBox1;
        private Panel logout_Panel;
        private Button logout_Btn;
        private PictureBox headerPicture_Pb;
        public Label header_Lbl;
        private Button backupAndRestoreData_Btn;
        private Button createReport_Btn;
        private Panel panel1;
        private Label label2;
        private Label label1;
        public Label userID_Lbl;
        public Label name_Lbl;
        public Button ManageUsers_Btn;
        public Label changePassword_Lbl;
        private Button assetHistory_Btn;
        private Button archived_Btn;
        private Button reserved_Btn;
        private Button borrowed_Btn;
        private Button disposed_Btn;
        private Button replaced_Btn;
        private Button cleaning_Btn;
        public Button assets_Btn;
        public Button ManageAsset_Btn;
    }
}