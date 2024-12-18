﻿namespace Smart_Asset
{
    partial class AddUser
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
            panel2 = new Panel();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            name_Tb = new TextBox();
            username_Tb = new TextBox();
            label7 = new Label();
            button1 = new Button();
            role_Cb = new ComboBox();
            label6 = new Label();
            panel1 = new Panel();
            panel3 = new Panel();
            panel4 = new Panel();
            otherModules_Panel = new Panel();
            button3 = new Button();
            button4 = new Button();
            label9 = new Label();
            dashboard_Cb = new CheckBox();
            artificialIntelligence_Cb = new CheckBox();
            createReport_Cb = new CheckBox();
            backupAndRestoreData_Cb = new CheckBox();
            assetEnabled_Panel = new Panel();
            button2 = new Button();
            button5 = new Button();
            label10 = new Label();
            showImage_Cb = new CheckBox();
            add_Cb = new CheckBox();
            edit_Cb = new CheckBox();
            archive_Cb = new CheckBox();
            replace_Cb = new CheckBox();
            borrow_Cb = new CheckBox();
            transfer_Cb = new CheckBox();
            manageAsset_Panel = new Panel();
            clear_Btn = new Button();
            selectAll_Btn = new Button();
            label11 = new Label();
            assetHistory_Cb = new CheckBox();
            assets_Cb = new CheckBox();
            archived_Cb = new CheckBox();
            replacement_Cb = new CheckBox();
            reserved_Cb = new CheckBox();
            cleaning_Cb = new CheckBox();
            borrowed_Cb = new CheckBox();
            disposed_Cb = new CheckBox();
            lowerLabel_Lbl = new Label();
            topLabel_Lbl = new Label();
            panel2.SuspendLayout();
            panel1.SuspendLayout();
            panel3.SuspendLayout();
            panel4.SuspendLayout();
            otherModules_Panel.SuspendLayout();
            assetEnabled_Panel.SuspendLayout();
            manageAsset_Panel.SuspendLayout();
            SuspendLayout();
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(0, 91, 143);
            panel2.Controls.Add(label3);
            panel2.Controls.Add(label2);
            panel2.Controls.Add(label1);
            panel2.Controls.Add(name_Tb);
            panel2.Controls.Add(username_Tb);
            panel2.Controls.Add(label7);
            panel2.Controls.Add(button1);
            panel2.Controls.Add(role_Cb);
            panel2.Controls.Add(label6);
            panel2.Dock = DockStyle.Left;
            panel2.Location = new Point(10, 10);
            panel2.Name = "panel2";
            panel2.Padding = new Padding(10);
            panel2.Size = new Size(574, 451);
            panel2.TabIndex = 17;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.Yellow;
            label3.Location = new Point(13, 238);
            label3.Name = "label3";
            label3.Size = new Size(540, 16);
            label3.TabIndex = 14;
            label3.Text = "Reminder: The default password will be Username + 123 (Ex.\"Username123\").";
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top;
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft Sans Serif", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.White;
            label2.Location = new Point(80, 122);
            label2.Name = "label2";
            label2.Size = new Size(74, 25);
            label2.TabIndex = 1;
            label2.Text = "Name:";
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top;
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 27.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(181, 19);
            label1.Name = "label1";
            label1.Size = new Size(230, 42);
            label1.TabIndex = 0;
            label1.Text = "ADD USER:";
            // 
            // name_Tb
            // 
            name_Tb.Anchor = AnchorStyles.Top;
            name_Tb.Location = new Point(160, 123);
            name_Tb.Name = "name_Tb";
            name_Tb.Size = new Size(276, 23);
            name_Tb.TabIndex = 2;
            // 
            // username_Tb
            // 
            username_Tb.Anchor = AnchorStyles.Top;
            username_Tb.Location = new Point(160, 152);
            username_Tb.Name = "username_Tb";
            username_Tb.Size = new Size(276, 23);
            username_Tb.TabIndex = 13;
            // 
            // label7
            // 
            label7.Anchor = AnchorStyles.Top;
            label7.AutoSize = true;
            label7.Font = new Font("Microsoft Sans Serif", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label7.ForeColor = Color.White;
            label7.Location = new Point(38, 147);
            label7.Name = "label7";
            label7.Size = new Size(116, 25);
            label7.TabIndex = 12;
            label7.Text = "Username:";
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.Top;
            button1.BackColor = Color.White;
            button1.FlatAppearance.MouseDownBackColor = Color.Red;
            button1.FlatAppearance.MouseOverBackColor = Color.Green;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.ForeColor = Color.FromArgb(2, 119, 189);
            button1.Location = new Point(226, 289);
            button1.Name = "button1";
            button1.Size = new Size(121, 38);
            button1.TabIndex = 11;
            button1.Text = "CONFIRM";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // role_Cb
            // 
            role_Cb.Anchor = AnchorStyles.Top;
            role_Cb.DropDownStyle = ComboBoxStyle.DropDownList;
            role_Cb.FormattingEnabled = true;
            role_Cb.Items.AddRange(new object[] { "Super Admin", "Admin", "Custom User" });
            role_Cb.Location = new Point(160, 181);
            role_Cb.Name = "role_Cb";
            role_Cb.Size = new Size(276, 23);
            role_Cb.TabIndex = 10;
            role_Cb.TextChanged += role_Cb_TextChanged_1;
            // 
            // label6
            // 
            label6.Anchor = AnchorStyles.Top;
            label6.AutoSize = true;
            label6.Font = new Font("Microsoft Sans Serif", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.ForeColor = Color.White;
            label6.Location = new Point(92, 176);
            label6.Name = "label6";
            label6.Size = new Size(62, 25);
            label6.TabIndex = 9;
            label6.Text = "Role:";
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(0, 91, 143);
            panel1.Controls.Add(panel3);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(584, 10);
            panel1.Name = "panel1";
            panel1.Padding = new Padding(7);
            panel1.Size = new Size(612, 451);
            panel1.TabIndex = 18;
            // 
            // panel3
            // 
            panel3.BackColor = Color.FromArgb(0, 91, 143);
            panel3.Controls.Add(panel4);
            panel3.Controls.Add(lowerLabel_Lbl);
            panel3.Controls.Add(topLabel_Lbl);
            panel3.Location = new Point(7, 7);
            panel3.Name = "panel3";
            panel3.Padding = new Padding(7);
            panel3.Size = new Size(599, 437);
            panel3.TabIndex = 10;
            // 
            // panel4
            // 
            panel4.BackColor = SystemColors.GrayText;
            panel4.BorderStyle = BorderStyle.FixedSingle;
            panel4.Controls.Add(otherModules_Panel);
            panel4.Controls.Add(assetEnabled_Panel);
            panel4.Controls.Add(manageAsset_Panel);
            panel4.Location = new Point(7, 107);
            panel4.Name = "panel4";
            panel4.Size = new Size(584, 323);
            panel4.TabIndex = 7;
            // 
            // otherModules_Panel
            // 
            otherModules_Panel.BackColor = Color.FromArgb(2, 119, 189);
            otherModules_Panel.BorderStyle = BorderStyle.FixedSingle;
            otherModules_Panel.Controls.Add(button3);
            otherModules_Panel.Controls.Add(button4);
            otherModules_Panel.Controls.Add(label9);
            otherModules_Panel.Controls.Add(dashboard_Cb);
            otherModules_Panel.Controls.Add(artificialIntelligence_Cb);
            otherModules_Panel.Controls.Add(createReport_Cb);
            otherModules_Panel.Controls.Add(backupAndRestoreData_Cb);
            otherModules_Panel.Dock = DockStyle.Left;
            otherModules_Panel.Location = new Point(378, 0);
            otherModules_Panel.Name = "otherModules_Panel";
            otherModules_Panel.Size = new Size(204, 321);
            otherModules_Panel.TabIndex = 12;
            // 
            // button3
            // 
            button3.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold);
            button3.ForeColor = Color.FromArgb(2, 119, 189);
            button3.Location = new Point(109, 272);
            button3.Name = "button3";
            button3.Size = new Size(75, 23);
            button3.TabIndex = 14;
            button3.Text = "Clear All";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button4
            // 
            button4.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold);
            button4.ForeColor = Color.FromArgb(2, 119, 189);
            button4.Location = new Point(28, 272);
            button4.Name = "button4";
            button4.Size = new Size(75, 23);
            button4.TabIndex = 13;
            button4.Text = "Select All";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold);
            label9.ForeColor = Color.White;
            label9.Location = new Point(44, 25);
            label9.Name = "label9";
            label9.Size = new Size(126, 20);
            label9.TabIndex = 11;
            label9.Text = "Other Modules";
            // 
            // dashboard_Cb
            // 
            dashboard_Cb.AutoSize = true;
            dashboard_Cb.Font = new Font("Microsoft Sans Serif", 8.75F, FontStyle.Bold);
            dashboard_Cb.ForeColor = Color.White;
            dashboard_Cb.Location = new Point(13, 59);
            dashboard_Cb.Name = "dashboard_Cb";
            dashboard_Cb.Size = new Size(96, 19);
            dashboard_Cb.TabIndex = 2;
            dashboard_Cb.Text = "Dashboard";
            dashboard_Cb.UseVisualStyleBackColor = true;
            // 
            // artificialIntelligence_Cb
            // 
            artificialIntelligence_Cb.AutoSize = true;
            artificialIntelligence_Cb.Font = new Font("Microsoft Sans Serif", 8.75F, FontStyle.Bold);
            artificialIntelligence_Cb.ForeColor = Color.White;
            artificialIntelligence_Cb.Location = new Point(13, 84);
            artificialIntelligence_Cb.Name = "artificialIntelligence_Cb";
            artificialIntelligence_Cb.Size = new Size(157, 19);
            artificialIntelligence_Cb.TabIndex = 3;
            artificialIntelligence_Cb.Text = "Artificial Intelligence";
            artificialIntelligence_Cb.UseVisualStyleBackColor = true;
            // 
            // createReport_Cb
            // 
            createReport_Cb.AutoSize = true;
            createReport_Cb.Font = new Font("Microsoft Sans Serif", 8.75F, FontStyle.Bold);
            createReport_Cb.ForeColor = Color.White;
            createReport_Cb.Location = new Point(13, 109);
            createReport_Cb.Name = "createReport_Cb";
            createReport_Cb.Size = new Size(115, 19);
            createReport_Cb.TabIndex = 4;
            createReport_Cb.Text = "Create Report";
            createReport_Cb.UseVisualStyleBackColor = true;
            // 
            // backupAndRestoreData_Cb
            // 
            backupAndRestoreData_Cb.AutoSize = true;
            backupAndRestoreData_Cb.Font = new Font("Microsoft Sans Serif", 8.75F, FontStyle.Bold);
            backupAndRestoreData_Cb.ForeColor = Color.White;
            backupAndRestoreData_Cb.Location = new Point(13, 134);
            backupAndRestoreData_Cb.Name = "backupAndRestoreData_Cb";
            backupAndRestoreData_Cb.Size = new Size(189, 19);
            backupAndRestoreData_Cb.TabIndex = 5;
            backupAndRestoreData_Cb.Text = "Backup And Restore Data";
            backupAndRestoreData_Cb.UseVisualStyleBackColor = true;
            // 
            // assetEnabled_Panel
            // 
            assetEnabled_Panel.BackColor = Color.FromArgb(2, 119, 189);
            assetEnabled_Panel.BorderStyle = BorderStyle.FixedSingle;
            assetEnabled_Panel.Controls.Add(button2);
            assetEnabled_Panel.Controls.Add(button5);
            assetEnabled_Panel.Controls.Add(label10);
            assetEnabled_Panel.Controls.Add(showImage_Cb);
            assetEnabled_Panel.Controls.Add(add_Cb);
            assetEnabled_Panel.Controls.Add(edit_Cb);
            assetEnabled_Panel.Controls.Add(archive_Cb);
            assetEnabled_Panel.Controls.Add(replace_Cb);
            assetEnabled_Panel.Controls.Add(borrow_Cb);
            assetEnabled_Panel.Controls.Add(transfer_Cb);
            assetEnabled_Panel.Dock = DockStyle.Left;
            assetEnabled_Panel.Location = new Point(189, 0);
            assetEnabled_Panel.Name = "assetEnabled_Panel";
            assetEnabled_Panel.Size = new Size(189, 321);
            assetEnabled_Panel.TabIndex = 11;
            // 
            // button2
            // 
            button2.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold);
            button2.ForeColor = Color.FromArgb(2, 119, 189);
            button2.Location = new Point(97, 272);
            button2.Name = "button2";
            button2.Size = new Size(75, 23);
            button2.TabIndex = 14;
            button2.Text = "Clear All";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button5
            // 
            button5.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold);
            button5.ForeColor = Color.FromArgb(2, 119, 189);
            button5.Location = new Point(16, 272);
            button5.Name = "button5";
            button5.Size = new Size(75, 23);
            button5.TabIndex = 13;
            button5.Text = "Select All";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold);
            label10.ForeColor = Color.White;
            label10.Location = new Point(26, 25);
            label10.Name = "label10";
            label10.Size = new Size(146, 20);
            label10.TabIndex = 11;
            label10.Text = "Assets - Enabled";
            // 
            // showImage_Cb
            // 
            showImage_Cb.AutoSize = true;
            showImage_Cb.Font = new Font("Microsoft Sans Serif", 8.75F, FontStyle.Bold);
            showImage_Cb.ForeColor = Color.White;
            showImage_Cb.Location = new Point(41, 207);
            showImage_Cb.Name = "showImage_Cb";
            showImage_Cb.Size = new Size(105, 19);
            showImage_Cb.TabIndex = 9;
            showImage_Cb.Text = "Show Image";
            showImage_Cb.UseVisualStyleBackColor = true;
            // 
            // add_Cb
            // 
            add_Cb.AutoSize = true;
            add_Cb.Font = new Font("Microsoft Sans Serif", 8.75F, FontStyle.Bold);
            add_Cb.ForeColor = Color.White;
            add_Cb.Location = new Point(41, 59);
            add_Cb.Name = "add_Cb";
            add_Cb.Size = new Size(50, 19);
            add_Cb.TabIndex = 2;
            add_Cb.Text = "Add";
            add_Cb.UseVisualStyleBackColor = true;
            // 
            // edit_Cb
            // 
            edit_Cb.AutoSize = true;
            edit_Cb.Font = new Font("Microsoft Sans Serif", 8.75F, FontStyle.Bold);
            edit_Cb.ForeColor = Color.White;
            edit_Cb.Location = new Point(41, 84);
            edit_Cb.Name = "edit_Cb";
            edit_Cb.Size = new Size(51, 19);
            edit_Cb.TabIndex = 3;
            edit_Cb.Text = "Edit";
            edit_Cb.UseVisualStyleBackColor = true;
            // 
            // archive_Cb
            // 
            archive_Cb.AutoSize = true;
            archive_Cb.Font = new Font("Microsoft Sans Serif", 8.75F, FontStyle.Bold);
            archive_Cb.ForeColor = Color.White;
            archive_Cb.Location = new Point(41, 184);
            archive_Cb.Name = "archive_Cb";
            archive_Cb.Size = new Size(72, 19);
            archive_Cb.TabIndex = 7;
            archive_Cb.Text = "Archive";
            archive_Cb.UseVisualStyleBackColor = true;
            // 
            // replace_Cb
            // 
            replace_Cb.AutoSize = true;
            replace_Cb.Font = new Font("Microsoft Sans Serif", 8.75F, FontStyle.Bold);
            replace_Cb.ForeColor = Color.White;
            replace_Cb.Location = new Point(41, 109);
            replace_Cb.Name = "replace_Cb";
            replace_Cb.Size = new Size(79, 19);
            replace_Cb.TabIndex = 4;
            replace_Cb.Text = "Replace";
            replace_Cb.UseVisualStyleBackColor = true;
            // 
            // borrow_Cb
            // 
            borrow_Cb.AutoSize = true;
            borrow_Cb.Font = new Font("Microsoft Sans Serif", 8.75F, FontStyle.Bold);
            borrow_Cb.ForeColor = Color.White;
            borrow_Cb.Location = new Point(41, 159);
            borrow_Cb.Name = "borrow_Cb";
            borrow_Cb.Size = new Size(71, 19);
            borrow_Cb.TabIndex = 6;
            borrow_Cb.Text = "Borrow";
            borrow_Cb.UseVisualStyleBackColor = true;
            // 
            // transfer_Cb
            // 
            transfer_Cb.AutoSize = true;
            transfer_Cb.Font = new Font("Microsoft Sans Serif", 8.75F, FontStyle.Bold);
            transfer_Cb.ForeColor = Color.White;
            transfer_Cb.Location = new Point(41, 134);
            transfer_Cb.Name = "transfer_Cb";
            transfer_Cb.Size = new Size(79, 19);
            transfer_Cb.TabIndex = 5;
            transfer_Cb.Text = "Transfer";
            transfer_Cb.UseVisualStyleBackColor = true;
            // 
            // manageAsset_Panel
            // 
            manageAsset_Panel.BackColor = Color.FromArgb(2, 119, 189);
            manageAsset_Panel.BorderStyle = BorderStyle.FixedSingle;
            manageAsset_Panel.Controls.Add(clear_Btn);
            manageAsset_Panel.Controls.Add(selectAll_Btn);
            manageAsset_Panel.Controls.Add(label11);
            manageAsset_Panel.Controls.Add(assetHistory_Cb);
            manageAsset_Panel.Controls.Add(assets_Cb);
            manageAsset_Panel.Controls.Add(archived_Cb);
            manageAsset_Panel.Controls.Add(replacement_Cb);
            manageAsset_Panel.Controls.Add(reserved_Cb);
            manageAsset_Panel.Controls.Add(cleaning_Cb);
            manageAsset_Panel.Controls.Add(borrowed_Cb);
            manageAsset_Panel.Controls.Add(disposed_Cb);
            manageAsset_Panel.Dock = DockStyle.Left;
            manageAsset_Panel.Font = new Font("Microsoft Sans Serif", 8.75F, FontStyle.Bold);
            manageAsset_Panel.Location = new Point(0, 0);
            manageAsset_Panel.Name = "manageAsset_Panel";
            manageAsset_Panel.Size = new Size(189, 321);
            manageAsset_Panel.TabIndex = 10;
            // 
            // clear_Btn
            // 
            clear_Btn.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold);
            clear_Btn.ForeColor = Color.FromArgb(2, 119, 189);
            clear_Btn.Location = new Point(97, 272);
            clear_Btn.Name = "clear_Btn";
            clear_Btn.Size = new Size(75, 23);
            clear_Btn.TabIndex = 12;
            clear_Btn.Text = "Clear All";
            clear_Btn.UseVisualStyleBackColor = true;
            clear_Btn.Click += clear_Btn_Click;
            // 
            // selectAll_Btn
            // 
            selectAll_Btn.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold);
            selectAll_Btn.ForeColor = Color.FromArgb(2, 119, 189);
            selectAll_Btn.Location = new Point(16, 272);
            selectAll_Btn.Name = "selectAll_Btn";
            selectAll_Btn.Size = new Size(75, 23);
            selectAll_Btn.TabIndex = 11;
            selectAll_Btn.Text = "Select All";
            selectAll_Btn.UseVisualStyleBackColor = true;
            selectAll_Btn.Click += selectAll_Btn_Click;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold);
            label11.ForeColor = Color.White;
            label11.Location = new Point(48, 25);
            label11.Name = "label11";
            label11.Size = new Size(124, 20);
            label11.TabIndex = 10;
            label11.Text = "Manage Asset";
            // 
            // assetHistory_Cb
            // 
            assetHistory_Cb.AutoSize = true;
            assetHistory_Cb.Font = new Font("Microsoft Sans Serif", 8.75F, FontStyle.Bold);
            assetHistory_Cb.ForeColor = Color.White;
            assetHistory_Cb.Location = new Point(41, 232);
            assetHistory_Cb.Name = "assetHistory_Cb";
            assetHistory_Cb.Size = new Size(108, 19);
            assetHistory_Cb.TabIndex = 9;
            assetHistory_Cb.Text = "Asset History";
            assetHistory_Cb.UseVisualStyleBackColor = true;
            // 
            // assets_Cb
            // 
            assets_Cb.AutoSize = true;
            assets_Cb.Font = new Font("Microsoft Sans Serif", 8.75F, FontStyle.Bold);
            assets_Cb.ForeColor = Color.White;
            assets_Cb.Location = new Point(41, 59);
            assets_Cb.Name = "assets_Cb";
            assets_Cb.Size = new Size(67, 19);
            assets_Cb.TabIndex = 2;
            assets_Cb.Text = "Assets";
            assets_Cb.UseVisualStyleBackColor = true;
            assets_Cb.CheckedChanged += assets_Cb_CheckedChanged;
            // 
            // archived_Cb
            // 
            archived_Cb.AutoSize = true;
            archived_Cb.Font = new Font("Microsoft Sans Serif", 8.75F, FontStyle.Bold);
            archived_Cb.ForeColor = Color.White;
            archived_Cb.Location = new Point(41, 207);
            archived_Cb.Name = "archived_Cb";
            archived_Cb.Size = new Size(80, 19);
            archived_Cb.TabIndex = 8;
            archived_Cb.Text = "Archived";
            archived_Cb.UseVisualStyleBackColor = true;
            // 
            // replacement_Cb
            // 
            replacement_Cb.AutoSize = true;
            replacement_Cb.Font = new Font("Microsoft Sans Serif", 8.75F, FontStyle.Bold);
            replacement_Cb.ForeColor = Color.White;
            replacement_Cb.Location = new Point(41, 109);
            replacement_Cb.Name = "replacement_Cb";
            replacement_Cb.Size = new Size(111, 19);
            replacement_Cb.TabIndex = 3;
            replacement_Cb.Text = "Replacement";
            replacement_Cb.UseVisualStyleBackColor = true;
            // 
            // reserved_Cb
            // 
            reserved_Cb.AutoSize = true;
            reserved_Cb.Font = new Font("Microsoft Sans Serif", 8.75F, FontStyle.Bold);
            reserved_Cb.ForeColor = Color.White;
            reserved_Cb.Location = new Point(41, 184);
            reserved_Cb.Name = "reserved_Cb";
            reserved_Cb.Size = new Size(86, 19);
            reserved_Cb.TabIndex = 7;
            reserved_Cb.Text = "Reserved";
            reserved_Cb.UseVisualStyleBackColor = true;
            // 
            // cleaning_Cb
            // 
            cleaning_Cb.AutoSize = true;
            cleaning_Cb.Font = new Font("Microsoft Sans Serif", 8.75F, FontStyle.Bold);
            cleaning_Cb.ForeColor = Color.White;
            cleaning_Cb.Location = new Point(41, 84);
            cleaning_Cb.Name = "cleaning_Cb";
            cleaning_Cb.Size = new Size(83, 19);
            cleaning_Cb.TabIndex = 4;
            cleaning_Cb.Text = "Cleaning";
            cleaning_Cb.UseVisualStyleBackColor = true;
            // 
            // borrowed_Cb
            // 
            borrowed_Cb.AutoSize = true;
            borrowed_Cb.Font = new Font("Microsoft Sans Serif", 8.75F, FontStyle.Bold);
            borrowed_Cb.ForeColor = Color.White;
            borrowed_Cb.Location = new Point(41, 159);
            borrowed_Cb.Name = "borrowed_Cb";
            borrowed_Cb.Size = new Size(87, 19);
            borrowed_Cb.TabIndex = 6;
            borrowed_Cb.Text = "Borrowed";
            borrowed_Cb.UseVisualStyleBackColor = true;
            // 
            // disposed_Cb
            // 
            disposed_Cb.AutoSize = true;
            disposed_Cb.Font = new Font("Microsoft Sans Serif", 8.75F, FontStyle.Bold);
            disposed_Cb.ForeColor = Color.White;
            disposed_Cb.Location = new Point(41, 134);
            disposed_Cb.Name = "disposed_Cb";
            disposed_Cb.Size = new Size(86, 19);
            disposed_Cb.TabIndex = 5;
            disposed_Cb.Text = "Disposed";
            disposed_Cb.UseVisualStyleBackColor = true;
            // 
            // lowerLabel_Lbl
            // 
            lowerLabel_Lbl.AutoSize = true;
            lowerLabel_Lbl.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold);
            lowerLabel_Lbl.ForeColor = Color.FromArgb(255, 242, 0);
            lowerLabel_Lbl.Location = new Point(157, 78);
            lowerLabel_Lbl.Name = "lowerLabel_Lbl";
            lowerLabel_Lbl.Size = new Size(266, 16);
            lowerLabel_Lbl.TabIndex = 6;
            lowerLabel_Lbl.Text = "Reminder: Select the access for roles";
            // 
            // topLabel_Lbl
            // 
            topLabel_Lbl.AutoSize = true;
            topLabel_Lbl.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            topLabel_Lbl.ForeColor = Color.White;
            topLabel_Lbl.Location = new Point(233, 22);
            topLabel_Lbl.Name = "topLabel_Lbl";
            topLabel_Lbl.Size = new Size(137, 32);
            topLabel_Lbl.TabIndex = 5;
            topLabel_Lbl.Text = "TOP LABEL";
            // 
            // AddUser
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(0, 91, 143);
            ClientSize = new Size(1204, 471);
            Controls.Add(panel1);
            Controls.Add(panel2);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "AddUser";
            Padding = new Padding(10);
            Text = "AddUser";
            FormClosed += AddUser_FormClosed;
            Load += AddUser_Load;
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel1.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel4.ResumeLayout(false);
            otherModules_Panel.ResumeLayout(false);
            otherModules_Panel.PerformLayout();
            assetEnabled_Panel.ResumeLayout(false);
            assetEnabled_Panel.PerformLayout();
            manageAsset_Panel.ResumeLayout(false);
            manageAsset_Panel.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel2;
        private Label label2;
        private Label label1;
        private TextBox name_Tb;
        private TextBox username_Tb;
        private Label label7;
        private Button button1;
        private ComboBox role_Cb;
        private Label label6;
        private Panel panel1;
        private Panel panel3;
        private Panel panel4;
        private Panel otherModules_Panel;
        private Button button3;
        private Button button4;
        private Label label9;
        private CheckBox dashboard_Cb;
        private CheckBox artificialIntelligence_Cb;
        private CheckBox createReport_Cb;
        private CheckBox backupAndRestoreData_Cb;
        private Panel assetEnabled_Panel;
        private Button button2;
        private Button button5;
        private Label label10;
        private CheckBox showImage_Cb;
        private CheckBox add_Cb;
        private CheckBox edit_Cb;
        private CheckBox archive_Cb;
        private CheckBox replace_Cb;
        private CheckBox borrow_Cb;
        private CheckBox transfer_Cb;
        private Panel manageAsset_Panel;
        private Button clear_Btn;
        private Button selectAll_Btn;
        private Label label11;
        private CheckBox assetHistory_Cb;
        private CheckBox assets_Cb;
        private CheckBox archived_Cb;
        private CheckBox replacement_Cb;
        private CheckBox reserved_Cb;
        private CheckBox cleaning_Cb;
        private CheckBox borrowed_Cb;
        private CheckBox disposed_Cb;
        private Label lowerLabel_Lbl;
        private Label topLabel_Lbl;
        private Label label3;
    }
}