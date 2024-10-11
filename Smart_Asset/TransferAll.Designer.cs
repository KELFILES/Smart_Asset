namespace Smart_Asset
{
    partial class TransferAll
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
            panel2 = new Panel();
            locationType2_Cmb = new ComboBox();
            unitType2_Cmb = new ComboBox();
            location2_Rdb = new RadioButton();
            reservedHardwares2_RadBtn = new RadioButton();
            label4 = new Label();
            transfer2_Btn = new Button();
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
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.AutoScroll = true;
            panel1.BackColor = Color.DarkGray;
            panel1.Controls.Add(panel2);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Padding = new Padding(0, 55, 0, 0);
            panel1.Size = new Size(1161, 612);
            panel1.TabIndex = 0;
            // 
            // panel2
            // 
            panel2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel2.BackColor = Color.DimGray;
            panel2.Controls.Add(locationType2_Cmb);
            panel2.Controls.Add(unitType2_Cmb);
            panel2.Controls.Add(location2_Rdb);
            panel2.Controls.Add(reservedHardwares2_RadBtn);
            panel2.Controls.Add(label4);
            panel2.Controls.Add(transfer2_Btn);
            panel2.Controls.Add(location_Cmb);
            panel2.Controls.Add(disposal2_RadBtn);
            panel2.Controls.Add(unit_Cmb);
            panel2.Controls.Add(cleaning2_RadBtn);
            panel2.Controls.Add(repairing2_RadBtn);
            panel2.Controls.Add(label6);
            panel2.Controls.Add(label2);
            panel2.Controls.Add(label1);
            panel2.Controls.Add(notes2_Tb);
            panel2.Location = new Point(21, 29);
            panel2.Name = "panel2";
            panel2.Padding = new Padding(0, 20, 0, 0);
            panel2.Size = new Size(1117, 555);
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
            locationType2_Cmb.Location = new Point(414, 208);
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
            unitType2_Cmb.Location = new Point(641, 208);
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
            location2_Rdb.Location = new Point(316, 212);
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
            reservedHardwares2_RadBtn.Location = new Point(698, 183);
            reservedHardwares2_RadBtn.Name = "reservedHardwares2_RadBtn";
            reservedHardwares2_RadBtn.Size = new Size(78, 19);
            reservedHardwares2_RadBtn.TabIndex = 36;
            reservedHardwares2_RadBtn.TabStop = true;
            reservedHardwares2_RadBtn.Text = "RESERVED";
            reservedHardwares2_RadBtn.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Top;
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 14F);
            label4.ForeColor = Color.White;
            label4.Location = new Point(521, 63);
            label4.Name = "label4";
            label4.Size = new Size(110, 25);
            label4.TabIndex = 35;
            label4.Text = "Transfer All:";
            // 
            // transfer2_Btn
            // 
            transfer2_Btn.Anchor = AnchorStyles.Top;
            transfer2_Btn.Location = new Point(531, 483);
            transfer2_Btn.Name = "transfer2_Btn";
            transfer2_Btn.Size = new Size(100, 26);
            transfer2_Btn.TabIndex = 34;
            transfer2_Btn.Text = "TRANSFER";
            transfer2_Btn.UseVisualStyleBackColor = true;
            transfer2_Btn.Click += transfer2_Btn_Click_1;
            // 
            // location_Cmb
            // 
            location_Cmb.Anchor = AnchorStyles.Top;
            location_Cmb.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            location_Cmb.AutoCompleteSource = AutoCompleteSource.ListItems;
            location_Cmb.DropDownStyle = ComboBoxStyle.DropDownList;
            location_Cmb.FormattingEnabled = true;
            location_Cmb.Location = new Point(228, 104);
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
            disposal2_RadBtn.Location = new Point(515, 183);
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
            unit_Cmb.Items.AddRange(new object[] { "N/A" });
            unit_Cmb.Location = new Point(228, 133);
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
            cleaning2_RadBtn.Location = new Point(610, 183);
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
            repairing2_RadBtn.Location = new Point(414, 183);
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
            label6.Location = new Point(228, 245);
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
            label2.Location = new Point(107, 131);
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
            label1.Location = new Point(107, 102);
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
            notes2_Tb.Location = new Point(228, 268);
            notes2_Tb.Name = "notes2_Tb";
            notes2_Tb.Size = new Size(716, 199);
            notes2_Tb.TabIndex = 7;
            notes2_Tb.Text = "";
            // 
            // TransferAll
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1161, 612);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "TransferAll";
            Text = "Transfer";
            panel1.ResumeLayout(false);
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
        private CheckBox checkBox5;
        private RadioButton disposal2_RadBtn;
        private RadioButton cleaning2_RadBtn;
        private RadioButton repairing2_RadBtn;
        private Button transfer2_Btn;
        private Label label4;
        private RadioButton reservedHardwares2_RadBtn;
        private ComboBox locationType2_Cmb;
        private ComboBox unitType2_Cmb;
        private RadioButton location2_Rdb;
    }
}