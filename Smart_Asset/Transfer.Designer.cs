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
            label1 = new Label();
            plus2_Btn = new Button();
            plus1_Btn = new Button();
            locationType_Cmb = new ComboBox();
            unitType_Cmb = new ComboBox();
            location_Rdb = new RadioButton();
            reserved_RadBtn = new RadioButton();
            transfer_Btn = new Button();
            disposal_RadBtn = new RadioButton();
            cleaning_RadBtn = new RadioButton();
            serialNo_Cmb = new ComboBox();
            label7 = new Label();
            label5 = new Label();
            label8 = new Label();
            notes_Tb = new RichTextBox();
            panel1.SuspendLayout();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.AutoScroll = true;
            panel1.BackColor = Color.DarkGray;
            panel1.Controls.Add(panel3);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Padding = new Padding(0, 55, 0, 0);
            panel1.Size = new Size(1161, 612);
            panel1.TabIndex = 0;
            // 
            // panel3
            // 
            panel3.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel3.BackColor = Color.Gray;
            panel3.Controls.Add(label1);
            panel3.Controls.Add(plus2_Btn);
            panel3.Controls.Add(plus1_Btn);
            panel3.Controls.Add(locationType_Cmb);
            panel3.Controls.Add(unitType_Cmb);
            panel3.Controls.Add(location_Rdb);
            panel3.Controls.Add(reserved_RadBtn);
            panel3.Controls.Add(transfer_Btn);
            panel3.Controls.Add(disposal_RadBtn);
            panel3.Controls.Add(cleaning_RadBtn);
            panel3.Controls.Add(serialNo_Cmb);
            panel3.Controls.Add(label7);
            panel3.Controls.Add(label5);
            panel3.Controls.Add(label8);
            panel3.Controls.Add(notes_Tb);
            panel3.Location = new Point(21, 29);
            panel3.Name = "panel3";
            panel3.Size = new Size(1117, 555);
            panel3.TabIndex = 7;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(615, 179);
            label1.Name = "label1";
            label1.Size = new Size(37, 17);
            label1.TabIndex = 39;
            label1.Text = "UNIT";
            // 
            // plus2_Btn
            // 
            plus2_Btn.Enabled = false;
            plus2_Btn.Location = new Point(882, 173);
            plus2_Btn.Name = "plus2_Btn";
            plus2_Btn.Size = new Size(44, 24);
            plus2_Btn.TabIndex = 38;
            plus2_Btn.Text = "+";
            plus2_Btn.UseVisualStyleBackColor = true;
            plus2_Btn.Click += plus2_Btn_Click;
            // 
            // plus1_Btn
            // 
            plus1_Btn.Enabled = false;
            plus1_Btn.Location = new Point(555, 174);
            plus1_Btn.Name = "plus1_Btn";
            plus1_Btn.Size = new Size(44, 24);
            plus1_Btn.TabIndex = 37;
            plus1_Btn.Text = "+";
            plus1_Btn.UseVisualStyleBackColor = true;
            plus1_Btn.Click += plus1_Btn_Click;
            // 
            // locationType_Cmb
            // 
            locationType_Cmb.Anchor = AnchorStyles.Top;
            locationType_Cmb.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            locationType_Cmb.AutoCompleteSource = AutoCompleteSource.ListItems;
            locationType_Cmb.DropDownStyle = ComboBoxStyle.DropDownList;
            locationType_Cmb.Enabled = false;
            locationType_Cmb.FormattingEnabled = true;
            locationType_Cmb.Location = new Point(340, 175);
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
            unitType_Cmb.Location = new Point(667, 173);
            unitType_Cmb.Name = "unitType_Cmb";
            unitType_Cmb.Size = new Size(209, 23);
            unitType_Cmb.TabIndex = 36;
            unitType_Cmb.DropDown += unitType_Cmb_DropDown;
            // 
            // location_Rdb
            // 
            location_Rdb.Anchor = AnchorStyles.Top;
            location_Rdb.AutoSize = true;
            location_Rdb.ForeColor = Color.White;
            location_Rdb.Location = new Point(242, 179);
            location_Rdb.Name = "location_Rdb";
            location_Rdb.Size = new Size(82, 19);
            location_Rdb.TabIndex = 32;
            location_Rdb.TabStop = true;
            location_Rdb.Text = "LOCATION";
            location_Rdb.UseVisualStyleBackColor = true;
            location_Rdb.CheckedChanged += location_Rdb_CheckedChanged;
            // 
            // reserved_RadBtn
            // 
            reserved_RadBtn.Anchor = AnchorStyles.Top;
            reserved_RadBtn.AutoSize = true;
            reserved_RadBtn.ForeColor = Color.White;
            reserved_RadBtn.Location = new Point(648, 143);
            reserved_RadBtn.Name = "reserved_RadBtn";
            reserved_RadBtn.Size = new Size(78, 19);
            reserved_RadBtn.TabIndex = 31;
            reserved_RadBtn.TabStop = true;
            reserved_RadBtn.Text = "RESERVED";
            reserved_RadBtn.UseVisualStyleBackColor = true;
            reserved_RadBtn.CheckedChanged += reserved_RadBtn_CheckedChanged;
            // 
            // transfer_Btn
            // 
            transfer_Btn.Anchor = AnchorStyles.Top;
            transfer_Btn.Location = new Point(519, 484);
            transfer_Btn.Name = "transfer_Btn";
            transfer_Btn.Size = new Size(100, 26);
            transfer_Btn.TabIndex = 29;
            transfer_Btn.Text = "TRANSFER";
            transfer_Btn.UseVisualStyleBackColor = true;
            transfer_Btn.Click += transfer_Btn_Click;
            // 
            // disposal_RadBtn
            // 
            disposal_RadBtn.Anchor = AnchorStyles.Top;
            disposal_RadBtn.AutoSize = true;
            disposal_RadBtn.ForeColor = Color.White;
            disposal_RadBtn.Location = new Point(453, 143);
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
            cleaning_RadBtn.ForeColor = Color.White;
            cleaning_RadBtn.Location = new Point(548, 143);
            cleaning_RadBtn.Name = "cleaning_RadBtn";
            cleaning_RadBtn.Size = new Size(82, 19);
            cleaning_RadBtn.TabIndex = 26;
            cleaning_RadBtn.TabStop = true;
            cleaning_RadBtn.Text = "CLEANING";
            cleaning_RadBtn.UseVisualStyleBackColor = true;
            cleaning_RadBtn.CheckedChanged += cleaning_RadBtn_CheckedChanged;
            // 
            // serialNo_Cmb
            // 
            serialNo_Cmb.Anchor = AnchorStyles.Top;
            serialNo_Cmb.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            serialNo_Cmb.AutoCompleteSource = AutoCompleteSource.ListItems;
            serialNo_Cmb.FormattingEnabled = true;
            serialNo_Cmb.Location = new Point(225, 104);
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
            label7.Location = new Point(224, 214);
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
            label5.ForeColor = Color.White;
            label5.Location = new Point(465, 60);
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
            label8.ForeColor = Color.White;
            label8.Location = new Point(104, 102);
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
            notes_Tb.Location = new Point(224, 237);
            notes_Tb.Name = "notes_Tb";
            notes_Tb.Size = new Size(716, 232);
            notes_Tb.TabIndex = 11;
            notes_Tb.Text = "";
            // 
            // Transfer
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1161, 612);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "Transfer";
            Text = "Transfer";
            panel1.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private TextBox textBox3;
        private Label label3;
        private CheckBox checkBox3;
        private Panel panel3;
        private CheckBox checkBox5;
        private Label label7;
        private RichTextBox notes_Tb;
        private Label label5;
        private Label label8;
        private RadioButton cleaning_RadBtn;
        private RadioButton disposal_RadBtn;
        private Button transfer_Btn;
        private RadioButton reserved_RadBtn;
        private ComboBox locationType_Cmb;
        private ComboBox unitType_Cmb;
        public ComboBox serialNo_Cmb;
        public RadioButton location_Rdb;
        private Button plus1_Btn;
        private Label label1;
        private Button plus2_Btn;
    }
}