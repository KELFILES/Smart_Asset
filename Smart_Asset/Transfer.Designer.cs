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
            delete_RadBtn = new RadioButton();
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
            label4 = new Label();
            transfer2_Btn = new Button();
            delete2_RadBtn = new RadioButton();
            borrow2_RadBtn = new RadioButton();
            location_Cmb = new ComboBox();
            disposal2_RadBtn = new RadioButton();
            unit_Cmb = new ComboBox();
            cleaning2_RadBtn = new RadioButton();
            checkBox2 = new CheckBox();
            repairing2_RadBtn = new RadioButton();
            checkBox1 = new CheckBox();
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
            panel1.Size = new Size(1125, 800);
            panel1.TabIndex = 0;
            // 
            // panel3
            // 
            panel3.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel3.BackColor = Color.DarkGray;
            panel3.Controls.Add(delete_RadBtn);
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
            panel3.Size = new Size(1101, 418);
            panel3.TabIndex = 7;
            // 
            // delete_RadBtn
            // 
            delete_RadBtn.AutoSize = true;
            delete_RadBtn.Location = new Point(641, 357);
            delete_RadBtn.Name = "delete_RadBtn";
            delete_RadBtn.Size = new Size(63, 19);
            delete_RadBtn.TabIndex = 30;
            delete_RadBtn.TabStop = true;
            delete_RadBtn.Text = "DELETE";
            delete_RadBtn.UseVisualStyleBackColor = true;
            // 
            // transfer_Btn
            // 
            transfer_Btn.Anchor = AnchorStyles.Bottom;
            transfer_Btn.Location = new Point(521, 382);
            transfer_Btn.Name = "transfer_Btn";
            transfer_Btn.Size = new Size(100, 26);
            transfer_Btn.TabIndex = 29;
            transfer_Btn.Text = "TRANSFER";
            transfer_Btn.UseVisualStyleBackColor = true;
            transfer_Btn.Click += transfer_Btn_Click;
            // 
            // borrow_RadBtn
            // 
            borrow_RadBtn.AutoSize = true;
            borrow_RadBtn.Location = new Point(546, 357);
            borrow_RadBtn.Name = "borrow_RadBtn";
            borrow_RadBtn.Size = new Size(75, 19);
            borrow_RadBtn.TabIndex = 28;
            borrow_RadBtn.TabStop = true;
            borrow_RadBtn.Text = "BORROW";
            borrow_RadBtn.UseVisualStyleBackColor = true;
            // 
            // disposal_RadBtn
            // 
            disposal_RadBtn.AutoSize = true;
            disposal_RadBtn.Location = new Point(449, 357);
            disposal_RadBtn.Name = "disposal_RadBtn";
            disposal_RadBtn.Size = new Size(78, 19);
            disposal_RadBtn.TabIndex = 27;
            disposal_RadBtn.TabStop = true;
            disposal_RadBtn.Text = "DISPOSAL";
            disposal_RadBtn.UseVisualStyleBackColor = true;
            // 
            // cleaning_RadBtn
            // 
            cleaning_RadBtn.AutoSize = true;
            cleaning_RadBtn.Location = new Point(351, 357);
            cleaning_RadBtn.Name = "cleaning_RadBtn";
            cleaning_RadBtn.Size = new Size(82, 19);
            cleaning_RadBtn.TabIndex = 26;
            cleaning_RadBtn.TabStop = true;
            cleaning_RadBtn.Text = "CLEANING";
            cleaning_RadBtn.UseVisualStyleBackColor = true;
            // 
            // repairing_RadBtn
            // 
            repairing_RadBtn.AutoSize = true;
            repairing_RadBtn.Location = new Point(252, 357);
            repairing_RadBtn.Name = "repairing_RadBtn";
            repairing_RadBtn.Size = new Size(82, 19);
            repairing_RadBtn.TabIndex = 25;
            repairing_RadBtn.TabStop = true;
            repairing_RadBtn.Text = "REPAIRING";
            repairing_RadBtn.UseVisualStyleBackColor = true;
            // 
            // serialNo_Cmb
            // 
            serialNo_Cmb.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            serialNo_Cmb.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            serialNo_Cmb.AutoCompleteSource = AutoCompleteSource.ListItems;
            serialNo_Cmb.FormattingEnabled = true;
            serialNo_Cmb.Location = new Point(253, 62);
            serialNo_Cmb.Name = "serialNo_Cmb";
            serialNo_Cmb.Size = new Size(625, 23);
            serialNo_Cmb.TabIndex = 24;
            serialNo_Cmb.KeyPress += serialNo_Cmb_KeyPress;
            serialNo_Cmb.MouseEnter += serialNo_Cmb_MouseEnter;
            // 
            // label7
            // 
            label7.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 11F);
            label7.ForeColor = Color.Red;
            label7.Location = new Point(253, 98);
            label7.Name = "label7";
            label7.Size = new Size(125, 20);
            label7.TabIndex = 12;
            label7.Text = "Notes: \"Optional\"";
            // 
            // label5
            // 
            label5.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 14F);
            label5.Location = new Point(461, 18);
            label5.Name = "label5";
            label5.Size = new Size(216, 25);
            label5.TabIndex = 7;
            label5.Text = "Transfer using Serial No:";
            // 
            // label8
            // 
            label8.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 14F);
            label8.Location = new Point(132, 60);
            label8.Name = "label8";
            label8.Size = new Size(97, 25);
            label8.TabIndex = 0;
            label8.Text = "Serial No.:";
            // 
            // notes_Tb
            // 
            notes_Tb.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            notes_Tb.BackColor = Color.Silver;
            notes_Tb.BorderStyle = BorderStyle.None;
            notes_Tb.Location = new Point(253, 121);
            notes_Tb.Name = "notes_Tb";
            notes_Tb.Size = new Size(626, 230);
            notes_Tb.TabIndex = 11;
            notes_Tb.Text = "";
            // 
            // panel2
            // 
            panel2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel2.BackColor = Color.DimGray;
            panel2.Controls.Add(label4);
            panel2.Controls.Add(transfer2_Btn);
            panel2.Controls.Add(delete2_RadBtn);
            panel2.Controls.Add(borrow2_RadBtn);
            panel2.Controls.Add(location_Cmb);
            panel2.Controls.Add(disposal2_RadBtn);
            panel2.Controls.Add(unit_Cmb);
            panel2.Controls.Add(cleaning2_RadBtn);
            panel2.Controls.Add(checkBox2);
            panel2.Controls.Add(repairing2_RadBtn);
            panel2.Controls.Add(checkBox1);
            panel2.Controls.Add(label6);
            panel2.Controls.Add(label2);
            panel2.Controls.Add(label1);
            panel2.Controls.Add(notes2_Tb);
            panel2.Location = new Point(12, 491);
            panel2.Name = "panel2";
            panel2.Size = new Size(1101, 297);
            panel2.TabIndex = 0;
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 14F);
            label4.ForeColor = Color.White;
            label4.Location = new Point(461, 24);
            label4.Name = "label4";
            label4.Size = new Size(211, 25);
            label4.TabIndex = 35;
            label4.Text = "Transfer using Location:";
            // 
            // transfer2_Btn
            // 
            transfer2_Btn.Anchor = AnchorStyles.Bottom;
            transfer2_Btn.Location = new Point(521, 252);
            transfer2_Btn.Name = "transfer2_Btn";
            transfer2_Btn.Size = new Size(100, 26);
            transfer2_Btn.TabIndex = 34;
            transfer2_Btn.Text = "TRANSFER";
            transfer2_Btn.UseVisualStyleBackColor = true;
            transfer2_Btn.Click += transfer2_Btn_Click_1;
            // 
            // delete2_RadBtn
            // 
            delete2_RadBtn.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            delete2_RadBtn.AutoSize = true;
            delete2_RadBtn.ForeColor = Color.White;
            delete2_RadBtn.Location = new Point(641, 207);
            delete2_RadBtn.Name = "delete2_RadBtn";
            delete2_RadBtn.Size = new Size(63, 19);
            delete2_RadBtn.TabIndex = 33;
            delete2_RadBtn.TabStop = true;
            delete2_RadBtn.Text = "DELETE";
            delete2_RadBtn.UseVisualStyleBackColor = true;
            // 
            // borrow2_RadBtn
            // 
            borrow2_RadBtn.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            borrow2_RadBtn.AutoSize = true;
            borrow2_RadBtn.ForeColor = Color.White;
            borrow2_RadBtn.Location = new Point(546, 207);
            borrow2_RadBtn.Name = "borrow2_RadBtn";
            borrow2_RadBtn.Size = new Size(75, 19);
            borrow2_RadBtn.TabIndex = 32;
            borrow2_RadBtn.TabStop = true;
            borrow2_RadBtn.Text = "BORROW";
            borrow2_RadBtn.UseVisualStyleBackColor = true;
            // 
            // location_Cmb
            // 
            location_Cmb.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            location_Cmb.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            location_Cmb.AutoCompleteSource = AutoCompleteSource.ListItems;
            location_Cmb.DropDownStyle = ComboBoxStyle.DropDownList;
            location_Cmb.FormattingEnabled = true;
            location_Cmb.Location = new Point(253, 63);
            location_Cmb.Name = "location_Cmb";
            location_Cmb.Size = new Size(605, 23);
            location_Cmb.TabIndex = 18;
            location_Cmb.DropDown += location_Cmb_DropDown;
            // 
            // disposal2_RadBtn
            // 
            disposal2_RadBtn.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            disposal2_RadBtn.AutoSize = true;
            disposal2_RadBtn.ForeColor = Color.White;
            disposal2_RadBtn.Location = new Point(449, 207);
            disposal2_RadBtn.Name = "disposal2_RadBtn";
            disposal2_RadBtn.Size = new Size(78, 19);
            disposal2_RadBtn.TabIndex = 31;
            disposal2_RadBtn.TabStop = true;
            disposal2_RadBtn.Text = "DISPOSAL";
            disposal2_RadBtn.UseVisualStyleBackColor = true;
            // 
            // unit_Cmb
            // 
            unit_Cmb.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            unit_Cmb.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            unit_Cmb.AutoCompleteSource = AutoCompleteSource.ListItems;
            unit_Cmb.DropDownStyle = ComboBoxStyle.DropDownList;
            unit_Cmb.FormattingEnabled = true;
            unit_Cmb.Location = new Point(253, 92);
            unit_Cmb.Name = "unit_Cmb";
            unit_Cmb.Size = new Size(605, 23);
            unit_Cmb.TabIndex = 19;
            unit_Cmb.DropDown += unit_Cmb_DropDown;
            // 
            // cleaning2_RadBtn
            // 
            cleaning2_RadBtn.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            cleaning2_RadBtn.AutoSize = true;
            cleaning2_RadBtn.ForeColor = Color.White;
            cleaning2_RadBtn.Location = new Point(351, 207);
            cleaning2_RadBtn.Name = "cleaning2_RadBtn";
            cleaning2_RadBtn.Size = new Size(82, 19);
            cleaning2_RadBtn.TabIndex = 30;
            cleaning2_RadBtn.TabStop = true;
            cleaning2_RadBtn.Text = "CLEANING";
            cleaning2_RadBtn.UseVisualStyleBackColor = true;
            // 
            // checkBox2
            // 
            checkBox2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            checkBox2.AutoSize = true;
            checkBox2.Location = new Point(863, 99);
            checkBox2.Name = "checkBox2";
            checkBox2.Size = new Size(15, 14);
            checkBox2.TabIndex = 11;
            checkBox2.UseVisualStyleBackColor = true;
            // 
            // repairing2_RadBtn
            // 
            repairing2_RadBtn.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            repairing2_RadBtn.AutoSize = true;
            repairing2_RadBtn.ForeColor = Color.White;
            repairing2_RadBtn.Location = new Point(252, 207);
            repairing2_RadBtn.Name = "repairing2_RadBtn";
            repairing2_RadBtn.Size = new Size(82, 19);
            repairing2_RadBtn.TabIndex = 29;
            repairing2_RadBtn.TabStop = true;
            repairing2_RadBtn.Text = "REPAIRING";
            repairing2_RadBtn.UseVisualStyleBackColor = true;
            // 
            // checkBox1
            // 
            checkBox1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(863, 70);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(15, 14);
            checkBox1.TabIndex = 10;
            checkBox1.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            label6.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 11F);
            label6.ForeColor = Color.Red;
            label6.Location = new Point(252, 127);
            label6.Name = "label6";
            label6.Size = new Size(125, 20);
            label6.TabIndex = 8;
            label6.Text = "Notes: \"Optional\"";
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 14F);
            label2.Location = new Point(132, 90);
            label2.Name = "label2";
            label2.Size = new Size(51, 25);
            label2.TabIndex = 1;
            label2.Text = "Unit:";
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14F);
            label1.Location = new Point(132, 61);
            label1.Name = "label1";
            label1.Size = new Size(88, 25);
            label1.TabIndex = 0;
            label1.Text = "Location:";
            // 
            // notes2_Tb
            // 
            notes2_Tb.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            notes2_Tb.BackColor = Color.Silver;
            notes2_Tb.BorderStyle = BorderStyle.None;
            notes2_Tb.Location = new Point(252, 148);
            notes2_Tb.Name = "notes2_Tb";
            notes2_Tb.Size = new Size(626, 53);
            notes2_Tb.TabIndex = 7;
            notes2_Tb.Text = "";
            // 
            // Transfer
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1125, 800);
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
        private CheckBox checkBox1;
        private CheckBox checkBox3;
        private CheckBox checkBox2;
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
        private RadioButton delete_RadBtn;
        private RadioButton delete2_RadBtn;
        private Button transfer2_Btn;
        private Label label4;
    }
}