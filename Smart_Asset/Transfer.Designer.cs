namespace Smart_Asset
{
    partial class Transfer
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
            panel1 = new Panel();
            panel3 = new Panel();
            locationType_Cmb = new ComboBox();
            unitType_Cmb = new ComboBox();
            location_Rdb = new RadioButton();
            reservedHardwares_RadBtn = new RadioButton();
            remove_RadBtn = new RadioButton();
            transfer_Btn = new Button();
            borrow_RadBtn = new RadioButton();
            disposal_RadBtn = new RadioButton();
            cleaning_RadBtn = new RadioButton();
            repairing_RadBtn = new RadioButton();
            serialNo_Cmb = new ComboBox();
            label7 = new Label();
            label5 = new Label();
            label8 = new Label();
            notes_Tb = new RichTextBox();
            panel2 = new Panel();
            locationType2_Cmb = new ComboBox();
            unitType2_Cmb = new ComboBox();
            location2_Rdb = new RadioButton();
            reservedHardwares2_RadBtn = new RadioButton();
            label4 = new Label();
            transfer2_Btn = new Button();
            remove2_RadBtn = new RadioButton();
            borrow2_RadBtn = new RadioButton();
            location_Cmb = new ComboBox();
            disposal2_RadBtn = new RadioButton();
            unit_Cmb = new ComboBox();
            cleaning2_RadBtn = new RadioButton();
            repairing2_RadBtn = new RadioButton();
            label6 = new Label();
            label2 = new Label();
            label1 = new Label();
            notes2_Tb = new RichTextBox();
            panel1.SuspendLayout();
            panel3.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.AutoScroll = true;
            panel1.BackColor = Color.FromArgb(10, 18, 45);
            panel1.Controls.Add(panel3);
            panel1.Controls.Add(panel2);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Padding = new Padding(0, 55, 0, 0);
            panel1.Size = new Size(1920, 1080);
            panel1.TabIndex = 0;
            // 
            // panel3
            // 
            panel3.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel3.BackColor = Color.DarkGray;
            panel3.Controls.Add(locationType_Cmb);
            panel3.Controls.Add(unitType_Cmb);
            panel3.Controls.Add(location_Rdb);
            panel3.Controls.Add(reservedHardwares_RadBtn);
            panel3.Controls.Add(remove_RadBtn);
            panel3.Controls.Add(transfer_Btn);
            panel3.Controls.Add(borrow_RadBtn);
            panel3.Controls.Add(disposal_RadBtn);
            panel3.Controls.Add(cleaning_RadBtn);
            panel3.Controls.Add(repairing_RadBtn);
            panel3.Controls.Add(serialNo_Cmb);
            panel3.Controls.Add(label7);
            panel3.Controls.Add(label5);
            panel3.Controls.Add(label8);
            panel3.Controls.Add(notes_Tb);
            panel3.Location = new Point(12, 67);
            panel3.Name = "panel3";
            panel3.Size = new Size(1896, 494);
            panel3.TabIndex = 7;
            // 
            // locationType_Cmb
            // 
            locationType_Cmb.Anchor = AnchorStyles.Top;
            locationType_Cmb.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            locationType_Cmb.AutoCompleteSource = AutoCompleteSource.ListItems;
            locationType_Cmb.DropDownStyle = ComboBoxStyle.DropDownList;
            locationType_Cmb.Enabled = false;
            locationType_Cmb.FormattingEnabled = true;
            locationType_Cmb.Location = new Point(802, 391);
            locationType_Cmb.Name = "locationType_Cmb";
            locationType_Cmb.Size = new Size(209, 23);
            locationType_Cmb.TabIndex = 35;
            locationType_Cmb.DropDown += locationType_Cmb_DropDown;
            // 
            // unitType_Cmb
            // 
            unitType_Cmb.Anchor = AnchorStyles.Top;
            unitType_Cmb.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            unitType_Cmb.AutoCompleteSource = AutoCompleteSource.ListItems;
            unitType_Cmb.DropDownStyle = ComboBoxStyle.DropDownList;
            unitType_Cmb.Enabled = false;
            unitType_Cmb.FormattingEnabled = true;
            unitType_Cmb.Location = new Point(1029, 391);
            unitType_Cmb.Name = "unitType_Cmb";
            unitType_Cmb.Size = new Size(209, 23);
            unitType_Cmb.TabIndex = 36;
            unitType_Cmb.DropDown += unitType_Cmb_DropDown;
            // 
            // location_Rdb
            // 
            location_Rdb.Anchor = AnchorStyles.Top;
            location_Rdb.AutoSize = true;
            location_Rdb.Location = new Point(704, 395);
            location_Rdb.Name = "location_Rdb";
            location_Rdb.Size = new Size(82, 19);
            location_Rdb.TabIndex = 32;
            location_Rdb.TabStop = true;
            location_Rdb.Text = "LOCATION";
            location_Rdb.UseVisualStyleBackColor = true;
            location_Rdb.CheckedChanged += location_Rdb_CheckedChanged;
            // 
            // reservedHardwares_RadBtn
            // 
            reservedHardwares_RadBtn.Anchor = AnchorStyles.Top;
            reservedHardwares_RadBtn.AutoSize = true;
            reservedHardwares_RadBtn.Location = new Point(1052, 363);
            reservedHardwares_RadBtn.Name = "reservedHardwares_RadBtn";
            reservedHardwares_RadBtn.Size = new Size(151, 19);
            reservedHardwares_RadBtn.TabIndex = 31;
            reservedHardwares_RadBtn.TabStop = true;
            reservedHardwares_RadBtn.Text = "RESERVED HARDWARES";
            reservedHardwares_RadBtn.UseVisualStyleBackColor = true;
            // 
            // remove_RadBtn
            // 
            remove_RadBtn.Anchor = AnchorStyles.Top;
            remove_RadBtn.AutoSize = true;
            remove_RadBtn.Location = new Point(1225, 363);
            remove_RadBtn.Name = "remove_RadBtn";
            remove_RadBtn.Size = new Size(71, 19);
            remove_RadBtn.TabIndex = 30;
            remove_RadBtn.TabStop = true;
            remove_RadBtn.Text = "REMOVE";
            remove_RadBtn.UseVisualStyleBackColor = true;
            // 
            // transfer_Btn
            // 
            transfer_Btn.Anchor = AnchorStyles.Top;
            transfer_Btn.Location = new Point(933, 428);
            transfer_Btn.Name = "transfer_Btn";
            transfer_Btn.Size = new Size(100, 26);
            transfer_Btn.TabIndex = 29;
            transfer_Btn.Text = "TRANSFER";
            transfer_Btn.UseVisualStyleBackColor = true;
            transfer_Btn.Click += transfer_Btn_Click;
            // 
            // borrow_RadBtn
            // 
            borrow_RadBtn.Anchor = AnchorStyles.Top;
            borrow_RadBtn.AutoSize = true;
            borrow_RadBtn.Location = new Point(956, 363);
            borrow_RadBtn.Name = "borrow_RadBtn";
            borrow_RadBtn.Size = new Size(75, 19);
            borrow_RadBtn.TabIndex = 28;
            borrow_RadBtn.TabStop = true;
            borrow_RadBtn.Text = "BORROW";
            borrow_RadBtn.UseVisualStyleBackColor = true;
            // 
            // disposal_RadBtn
            // 
            disposal_RadBtn.Anchor = AnchorStyles.Top;
            disposal_RadBtn.AutoSize = true;
            disposal_RadBtn.Location = new Point(859, 363);
            disposal_RadBtn.Name = "disposal_RadBtn";
            disposal_RadBtn.Size = new Size(78, 19);
            disposal_RadBtn.TabIndex = 27;
            disposal_RadBtn.TabStop = true;
            disposal_RadBtn.Text = "DISPOSAL";
            disposal_RadBtn.UseVisualStyleBackColor = true;
            // 
            // cleaning_RadBtn
            // 
            cleaning_RadBtn.Anchor = AnchorStyles.Top;
            cleaning_RadBtn.AutoSize = true;
            cleaning_RadBtn.Location = new Point(761, 363);
            cleaning_RadBtn.Name = "cleaning_RadBtn";
            cleaning_RadBtn.Size = new Size(82, 19);
            cleaning_RadBtn.TabIndex = 26;
            cleaning_RadBtn.TabStop = true;
            cleaning_RadBtn.Text = "CLEANING";
            cleaning_RadBtn.UseVisualStyleBackColor = true;
            // 
            // repairing_RadBtn
            // 
            repairing_RadBtn.Anchor = AnchorStyles.Top;
            repairing_RadBtn.AutoSize = true;
            repairing_RadBtn.Location = new Point(662, 363);
            repairing_RadBtn.Name = "repairing_RadBtn";
            repairing_RadBtn.Size = new Size(82, 19);
            repairing_RadBtn.TabIndex = 25;
            repairing_RadBtn.TabStop = true;
            repairing_RadBtn.Text = "REPAIRING";
            repairing_RadBtn.UseVisualStyleBackColor = true;
            // 
            // serialNo_Cmb
            // 
            serialNo_Cmb.Anchor = AnchorStyles.Top;
            serialNo_Cmb.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            serialNo_Cmb.AutoCompleteSource = AutoCompleteSource.ListItems;
            serialNo_Cmb.FormattingEnabled = true;
            serialNo_Cmb.Location = new Point(619, 66);
            serialNo_Cmb.Name = "serialNo_Cmb";
            serialNo_Cmb.Size = new Size(715, 23);
            serialNo_Cmb.TabIndex = 24;
            serialNo_Cmb.KeyPress += serialNo_Cmb_KeyPress;
            serialNo_Cmb.MouseEnter += serialNo_Cmb_MouseEnter;
            // 
            // label7
            // 
            label7.Anchor = AnchorStyles.Top;
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 11F);
            label7.ForeColor = Color.Red;
            label7.Location = new Point(619, 102);
            label7.Name = "label7";
            label7.Size = new Size(125, 20);
            label7.TabIndex = 12;
            label7.Text = "Notes: \"Optional\"";
            // 
            // label5
            // 
            label5.Anchor = AnchorStyles.Top;
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 14F);
            label5.Location = new Point(859, 22);
            label5.Name = "label5";
            label5.Size = new Size(216, 25);
            label5.TabIndex = 7;
            label5.Text = "Transfer using Serial No:";
            // 
            // label8
            // 
            label8.Anchor = AnchorStyles.Top;
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 14F);
            label8.Location = new Point(498, 64);
            label8.Name = "label8";
            label8.Size = new Size(97, 25);
            label8.TabIndex = 0;
            label8.Text = "Serial No.:";
            // 
            // notes_Tb
            // 
            notes_Tb.Anchor = AnchorStyles.Top;
            notes_Tb.BackColor = Color.Silver;
            notes_Tb.BorderStyle = BorderStyle.None;
            notes_Tb.Location = new Point(619, 125);
            notes_Tb.Name = "notes_Tb";
            notes_Tb.Size = new Size(716, 232);
            notes_Tb.TabIndex = 11;
            notes_Tb.Text = "";
            // 
            // panel2
            // 
            panel2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel2.BackColor = Color.DimGray;
            panel2.Controls.Add(locationType2_Cmb);
            panel2.Controls.Add(unitType2_Cmb);
            panel2.Controls.Add(location2_Rdb);
            panel2.Controls.Add(reservedHardwares2_RadBtn);
            panel2.Controls.Add(label4);
            panel2.Controls.Add(transfer2_Btn);
            panel2.Controls.Add(remove2_RadBtn);
            panel2.Controls.Add(borrow2_RadBtn);
            panel2.Controls.Add(location_Cmb);
            panel2.Controls.Add(disposal2_RadBtn);
            panel2.Controls.Add(unit_Cmb);
            panel2.Controls.Add(cleaning2_RadBtn);
            panel2.Controls.Add(repairing2_RadBtn);
            panel2.Controls.Add(label6);
            panel2.Controls.Add(label2);
            panel2.Controls.Add(label1);
            panel2.Controls.Add(notes2_Tb);
            panel2.Location = new Point(12, 567);
            panel2.Name = "panel2";
            panel2.Padding = new Padding(0, 20, 0, 0);
            panel2.Size = new Size(1896, 485);
            panel2.TabIndex = 0;
            // 
            // locationType2_Cmb
            // 
            locationType2_Cmb.Anchor = AnchorStyles.Top;
            locationType2_Cmb.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            locationType2_Cmb.AutoCompleteSource = AutoCompleteSource.ListItems;
            locationType2_Cmb.DropDownStyle = ComboBoxStyle.DropDownList;
            locationType2_Cmb.Enabled = false;
            locationType2_Cmb.FormattingEnabled = true;
            locationType2_Cmb.Location = new Point(802, 406);
            locationType2_Cmb.Name = "locationType2_Cmb";
            locationType2_Cmb.Size = new Size(209, 23);
            locationType2_Cmb.TabIndex = 38;
            locationType2_Cmb.DropDown += locationType2_Cmb_DropDown;
            // 
            // unitType2_Cmb
            // 
            unitType2_Cmb.Anchor = AnchorStyles.Top;
            unitType2_Cmb.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            unitType2_Cmb.AutoCompleteSource = AutoCompleteSource.ListItems;
            unitType2_Cmb.DropDownStyle = ComboBoxStyle.DropDownList;
            unitType2_Cmb.Enabled = false;
            unitType2_Cmb.FormattingEnabled = true;
            unitType2_Cmb.Location = new Point(1029, 406);
            unitType2_Cmb.Name = "unitType2_Cmb";
            unitType2_Cmb.Size = new Size(209, 23);
            unitType2_Cmb.TabIndex = 39;
            unitType2_Cmb.DropDown += unitType2_Cmb_DropDown;
            // 
            // location2_Rdb
            // 
            location2_Rdb.Anchor = AnchorStyles.Top;
            location2_Rdb.AutoSize = true;
            location2_Rdb.ForeColor = Color.White;
            location2_Rdb.Location = new Point(704, 410);
            location2_Rdb.Name = "location2_Rdb";
            location2_Rdb.Size = new Size(82, 19);
            location2_Rdb.TabIndex = 37;
            location2_Rdb.TabStop = true;
            location2_Rdb.Text = "LOCATION";
            location2_Rdb.UseVisualStyleBackColor = true;
            location2_Rdb.CheckedChanged += location2_Rdb_CheckedChanged;
            // 
            // reservedHardwares2_RadBtn
            // 
            reservedHardwares2_RadBtn.Anchor = AnchorStyles.Top;
            reservedHardwares2_RadBtn.AutoSize = true;
            reservedHardwares2_RadBtn.ForeColor = Color.White;
            reservedHardwares2_RadBtn.Location = new Point(1053, 376);
            reservedHardwares2_RadBtn.Name = "reservedHardwares2_RadBtn";
            reservedHardwares2_RadBtn.Size = new Size(151, 19);
            reservedHardwares2_RadBtn.TabIndex = 36;
            reservedHardwares2_RadBtn.TabStop = true;
            reservedHardwares2_RadBtn.Text = "RESERVED HARDWARES";
            reservedHardwares2_RadBtn.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Top;
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 14F);
            label4.ForeColor = Color.White;
            label4.Location = new Point(859, 47);
            label4.Name = "label4";
            label4.Size = new Size(211, 25);
            label4.TabIndex = 35;
            label4.Text = "Transfer using Location:";
            // 
            // transfer2_Btn
            // 
            transfer2_Btn.Anchor = AnchorStyles.Top;
            transfer2_Btn.Location = new Point(933, 446);
            transfer2_Btn.Name = "transfer2_Btn";
            transfer2_Btn.Size = new Size(100, 26);
            transfer2_Btn.TabIndex = 34;
            transfer2_Btn.Text = "TRANSFER";
            transfer2_Btn.UseVisualStyleBackColor = true;
            transfer2_Btn.Click += transfer2_Btn_Click_1;
            // 
            // remove2_RadBtn
            // 
            remove2_RadBtn.Anchor = AnchorStyles.Top;
            remove2_RadBtn.AutoSize = true;
            remove2_RadBtn.ForeColor = Color.White;
            remove2_RadBtn.Location = new Point(1226, 376);
            remove2_RadBtn.Name = "remove2_RadBtn";
            remove2_RadBtn.Size = new Size(71, 19);
            remove2_RadBtn.TabIndex = 33;
            remove2_RadBtn.TabStop = true;
            remove2_RadBtn.Text = "REMOVE";
            remove2_RadBtn.UseVisualStyleBackColor = true;
            // 
            // borrow2_RadBtn
            // 
            borrow2_RadBtn.Anchor = AnchorStyles.Top;
            borrow2_RadBtn.AutoSize = true;
            borrow2_RadBtn.ForeColor = Color.White;
            borrow2_RadBtn.Location = new Point(958, 376);
            borrow2_RadBtn.Name = "borrow2_RadBtn";
            borrow2_RadBtn.Size = new Size(75, 19);
            borrow2_RadBtn.TabIndex = 32;
            borrow2_RadBtn.TabStop = true;
            borrow2_RadBtn.Text = "BORROW";
            borrow2_RadBtn.UseVisualStyleBackColor = true;
            // 
            // location_Cmb
            // 
            location_Cmb.Anchor = AnchorStyles.Top;
            location_Cmb.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            location_Cmb.AutoCompleteSource = AutoCompleteSource.ListItems;
            location_Cmb.DropDownStyle = ComboBoxStyle.DropDownList;
            location_Cmb.FormattingEnabled = true;
            location_Cmb.Location = new Point(620, 84);
            location_Cmb.Name = "location_Cmb";
            location_Cmb.Size = new Size(715, 23);
            location_Cmb.TabIndex = 18;
            location_Cmb.DropDown += location_Cmb_DropDown;
            // 
            // disposal2_RadBtn
            // 
            disposal2_RadBtn.Anchor = AnchorStyles.Top;
            disposal2_RadBtn.AutoSize = true;
            disposal2_RadBtn.ForeColor = Color.White;
            disposal2_RadBtn.Location = new Point(861, 376);
            disposal2_RadBtn.Name = "disposal2_RadBtn";
            disposal2_RadBtn.Size = new Size(78, 19);
            disposal2_RadBtn.TabIndex = 31;
            disposal2_RadBtn.TabStop = true;
            disposal2_RadBtn.Text = "DISPOSAL";
            disposal2_RadBtn.UseVisualStyleBackColor = true;
            // 
            // unit_Cmb
            // 
            unit_Cmb.Anchor = AnchorStyles.Top;
            unit_Cmb.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            unit_Cmb.AutoCompleteSource = AutoCompleteSource.ListItems;
            unit_Cmb.DropDownStyle = ComboBoxStyle.DropDownList;
            unit_Cmb.FormattingEnabled = true;
            unit_Cmb.Location = new Point(620, 113);
            unit_Cmb.Name = "unit_Cmb";
            unit_Cmb.Size = new Size(715, 23);
            unit_Cmb.TabIndex = 19;
            unit_Cmb.DropDown += unit_Cmb_DropDown;
            // 
            // cleaning2_RadBtn
            // 
            cleaning2_RadBtn.Anchor = AnchorStyles.Top;
            cleaning2_RadBtn.AutoSize = true;
            cleaning2_RadBtn.ForeColor = Color.White;
            cleaning2_RadBtn.Location = new Point(763, 376);
            cleaning2_RadBtn.Name = "cleaning2_RadBtn";
            cleaning2_RadBtn.Size = new Size(82, 19);
            cleaning2_RadBtn.TabIndex = 30;
            cleaning2_RadBtn.TabStop = true;
            cleaning2_RadBtn.Text = "CLEANING";
            cleaning2_RadBtn.UseVisualStyleBackColor = true;
            // 
            // repairing2_RadBtn
            // 
            repairing2_RadBtn.Anchor = AnchorStyles.Top;
            repairing2_RadBtn.AutoSize = true;
            repairing2_RadBtn.ForeColor = Color.White;
            repairing2_RadBtn.Location = new Point(664, 376);
            repairing2_RadBtn.Name = "repairing2_RadBtn";
            repairing2_RadBtn.Size = new Size(82, 19);
            repairing2_RadBtn.TabIndex = 29;
            repairing2_RadBtn.TabStop = true;
            repairing2_RadBtn.Text = "REPAIRING";
            repairing2_RadBtn.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            label6.Anchor = AnchorStyles.Top;
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 11F);
            label6.ForeColor = Color.Red;
            label6.Location = new Point(619, 148);
            label6.Name = "label6";
            label6.Size = new Size(125, 20);
            label6.TabIndex = 8;
            label6.Text = "Notes: \"Optional\"";
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top;
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 14F);
            label2.ForeColor = Color.White;
            label2.Location = new Point(499, 111);
            label2.Name = "label2";
            label2.Size = new Size(51, 25);
            label2.TabIndex = 1;
            label2.Text = "Unit:";
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top;
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14F);
            label1.ForeColor = Color.White;
            label1.Location = new Point(499, 82);
            label1.Name = "label1";
            label1.Size = new Size(88, 25);
            label1.TabIndex = 0;
            label1.Text = "Location:";
            // 
            // notes2_Tb
            // 
            notes2_Tb.Anchor = AnchorStyles.Top;
            notes2_Tb.BackColor = Color.Silver;
            notes2_Tb.BorderStyle = BorderStyle.None;
            notes2_Tb.Location = new Point(619, 171);
            notes2_Tb.Name = "notes2_Tb";
            notes2_Tb.Size = new Size(716, 199);
            notes2_Tb.TabIndex = 7;
            notes2_Tb.Text = "";
            // 
            // Transfer
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1920, 1080);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Transfer";
            Text = "Delete";
            panel1.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Panel panel2;
        private TextBox textBox3;
        private Label label3;
        private Label label2;
        private Label label1;
        private RichTextBox notes2_Tb;
        private Label label6;
        private CheckBox checkBox3;
        private ComboBox location_Cmb;
        private ComboBox unit_Cmb;
        private Panel panel3;
        private CheckBox checkBox5;
        private Label label7;
        private RichTextBox notes_Tb;
        private Label label5;
        private Label label8;
        private ComboBox serialNo_Cmb;
        private RadioButton cleaning_RadBtn;
        private RadioButton repairing_RadBtn;
        private RadioButton borrow_RadBtn;
        private RadioButton disposal_RadBtn;
        private RadioButton borrow2_RadBtn;
        private RadioButton disposal2_RadBtn;
        private RadioButton cleaning2_RadBtn;
        private RadioButton repairing2_RadBtn;
        private Button transfer_Btn;
        private RadioButton remove_RadBtn;
        private RadioButton remove2_RadBtn;
        private Button transfer2_Btn;
        private Label label4;
        private RadioButton reservedHardwares_RadBtn;
        private RadioButton reservedHardwares2_RadBtn;
        private RadioButton location_Rdb;
        private ComboBox locationType_Cmb;
        private ComboBox unitType_Cmb;
        private ComboBox locationType2_Cmb;
        private ComboBox unitType2_Cmb;
        private RadioButton location2_Rdb;
    }
}