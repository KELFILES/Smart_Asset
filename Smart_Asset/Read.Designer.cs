namespace Smart_Asset
{
    partial class Read
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
            panel3 = new Panel();
            exportTo_Cb = new ComboBox();
            export_Btn = new Button();
            exportTo_Lbl = new Label();
            dataGridView1 = new DataGridView();
            panel1 = new Panel();
            panel2 = new Panel();
            location_Cmb = new ComboBox();
            label1 = new Label();
            panel5 = new Panel();
            reservedHardwares_Btn = new Button();
            label2 = new Label();
            button1 = new Button();
            unit_Cmb = new ComboBox();
            panel4 = new Panel();
            show1_Btn = new Button();
            serialNo_Cmb = new ComboBox();
            label4 = new Label();
            panel6 = new Panel();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel5.SuspendLayout();
            panel4.SuspendLayout();
            SuspendLayout();
            // 
            // panel3
            // 
            panel3.BackColor = Color.DimGray;
            panel3.Controls.Add(exportTo_Cb);
            panel3.Controls.Add(export_Btn);
            panel3.Controls.Add(exportTo_Lbl);
            panel3.Dock = DockStyle.Bottom;
            panel3.Location = new Point(8, 688);
            panel3.Name = "panel3";
            panel3.Size = new Size(1173, 104);
            panel3.TabIndex = 9;
            // 
            // exportTo_Cb
            // 
            exportTo_Cb.Anchor = AnchorStyles.Top;
            exportTo_Cb.FormattingEnabled = true;
            exportTo_Cb.Location = new Point(546, 30);
            exportTo_Cb.Name = "exportTo_Cb";
            exportTo_Cb.Size = new Size(133, 23);
            exportTo_Cb.TabIndex = 8;
            exportTo_Cb.Tag = "";
            // 
            // export_Btn
            // 
            export_Btn.Anchor = AnchorStyles.Top;
            export_Btn.Location = new Point(577, 59);
            export_Btn.Name = "export_Btn";
            export_Btn.Size = new Size(75, 23);
            export_Btn.TabIndex = 7;
            export_Btn.Text = "EXPORT";
            export_Btn.UseVisualStyleBackColor = true;
            export_Btn.Click += export_Btn_Click;
            // 
            // exportTo_Lbl
            // 
            exportTo_Lbl.Anchor = AnchorStyles.Top;
            exportTo_Lbl.AutoSize = true;
            exportTo_Lbl.Location = new Point(481, 33);
            exportTo_Lbl.Name = "exportTo_Lbl";
            exportTo_Lbl.Size = new Size(59, 15);
            exportTo_Lbl.TabIndex = 5;
            exportTo_Lbl.Text = "Export To:";
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToOrderColumns = true;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView1.Dock = DockStyle.Fill;
            dataGridView1.Location = new Point(8, 124);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.Size = new Size(1173, 564);
            dataGridView1.TabIndex = 4;
            // 
            // panel1
            // 
            panel1.AutoScroll = true;
            panel1.Controls.Add(dataGridView1);
            panel1.Controls.Add(panel2);
            panel1.Controls.Add(panel3);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Padding = new Padding(8);
            panel1.Size = new Size(1189, 800);
            panel1.TabIndex = 8;
            // 
            // panel2
            // 
            panel2.BackColor = Color.DimGray;
            panel2.Controls.Add(location_Cmb);
            panel2.Controls.Add(label1);
            panel2.Controls.Add(panel5);
            panel2.Controls.Add(label2);
            panel2.Controls.Add(button1);
            panel2.Controls.Add(unit_Cmb);
            panel2.Controls.Add(panel4);
            panel2.Controls.Add(panel6);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(8, 8);
            panel2.Name = "panel2";
            panel2.Size = new Size(1173, 116);
            panel2.TabIndex = 8;
            // 
            // location_Cmb
            // 
            location_Cmb.Anchor = AnchorStyles.Top;
            location_Cmb.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            location_Cmb.AutoCompleteSource = AutoCompleteSource.ListItems;
            location_Cmb.DropDownStyle = ComboBoxStyle.DropDownList;
            location_Cmb.FormattingEnabled = true;
            location_Cmb.Location = new Point(604, 17);
            location_Cmb.Name = "location_Cmb";
            location_Cmb.Size = new Size(293, 23);
            location_Cmb.TabIndex = 25;
            location_Cmb.DropDown += location_Cmb_DropDown_1;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top;
            label1.AutoSize = true;
            label1.BackColor = Color.Gray;
            label1.Location = new Point(542, 20);
            label1.Name = "label1";
            label1.Size = new Size(56, 15);
            label1.TabIndex = 24;
            label1.Text = "Location:";
            // 
            // panel5
            // 
            panel5.Anchor = AnchorStyles.Top;
            panel5.BackColor = Color.Gray;
            panel5.Controls.Add(reservedHardwares_Btn);
            panel5.Location = new Point(942, 8);
            panel5.Name = "panel5";
            panel5.Size = new Size(136, 100);
            panel5.TabIndex = 22;
            // 
            // reservedHardwares_Btn
            // 
            reservedHardwares_Btn.Anchor = AnchorStyles.Top;
            reservedHardwares_Btn.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            reservedHardwares_Btn.Location = new Point(6, 8);
            reservedHardwares_Btn.Name = "reservedHardwares_Btn";
            reservedHardwares_Btn.Size = new Size(121, 48);
            reservedHardwares_Btn.TabIndex = 10;
            reservedHardwares_Btn.Text = "RESERVED HARDWARES";
            reservedHardwares_Btn.UseVisualStyleBackColor = true;
            reservedHardwares_Btn.Click += reservedHardwares_Btn_Click_1;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top;
            label2.AutoSize = true;
            label2.BackColor = Color.Gray;
            label2.Location = new Point(542, 49);
            label2.Name = "label2";
            label2.Size = new Size(32, 15);
            label2.TabIndex = 27;
            label2.Text = "Unit:";
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.Top;
            button1.Location = new Point(708, 75);
            button1.Name = "button1";
            button1.Size = new Size(74, 23);
            button1.TabIndex = 28;
            button1.Text = "SHOW";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click_1;
            // 
            // unit_Cmb
            // 
            unit_Cmb.Anchor = AnchorStyles.Top;
            unit_Cmb.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            unit_Cmb.AutoCompleteSource = AutoCompleteSource.ListItems;
            unit_Cmb.DropDownStyle = ComboBoxStyle.DropDownList;
            unit_Cmb.FormattingEnabled = true;
            unit_Cmb.Location = new Point(604, 46);
            unit_Cmb.Name = "unit_Cmb";
            unit_Cmb.Size = new Size(293, 23);
            unit_Cmb.TabIndex = 26;
            unit_Cmb.DropDown += unit_Cmb_DropDown_1;
            // 
            // panel4
            // 
            panel4.Anchor = AnchorStyles.Top;
            panel4.BackColor = Color.Gray;
            panel4.Controls.Add(show1_Btn);
            panel4.Controls.Add(serialNo_Cmb);
            panel4.Controls.Add(label4);
            panel4.Location = new Point(93, 8);
            panel4.Name = "panel4";
            panel4.Size = new Size(421, 100);
            panel4.TabIndex = 29;
            // 
            // show1_Btn
            // 
            show1_Btn.Anchor = AnchorStyles.Top;
            show1_Btn.Location = new Point(196, 62);
            show1_Btn.Name = "show1_Btn";
            show1_Btn.Size = new Size(81, 23);
            show1_Btn.TabIndex = 19;
            show1_Btn.Text = "SHOW";
            show1_Btn.UseVisualStyleBackColor = true;
            show1_Btn.Click += show1_Btn_Click;
            // 
            // serialNo_Cmb
            // 
            serialNo_Cmb.Anchor = AnchorStyles.Top;
            serialNo_Cmb.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            serialNo_Cmb.AutoCompleteSource = AutoCompleteSource.ListItems;
            serialNo_Cmb.FormattingEnabled = true;
            serialNo_Cmb.Location = new Point(95, 33);
            serialNo_Cmb.Name = "serialNo_Cmb";
            serialNo_Cmb.Size = new Size(300, 23);
            serialNo_Cmb.TabIndex = 23;
            serialNo_Cmb.KeyPress += serialNo_Cmb_KeyPress;
            serialNo_Cmb.MouseEnter += serialNo_Cmb_MouseEnter;
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Top;
            label4.AutoSize = true;
            label4.Location = new Point(33, 36);
            label4.Name = "label4";
            label4.Size = new Size(60, 15);
            label4.TabIndex = 24;
            label4.Text = "Serial No.:";
            // 
            // panel6
            // 
            panel6.Anchor = AnchorStyles.Top;
            panel6.BackColor = Color.Gray;
            panel6.Location = new Point(520, 8);
            panel6.Name = "panel6";
            panel6.Size = new Size(416, 100);
            panel6.TabIndex = 30;
            // 
            // Read
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            ClientSize = new Size(1189, 800);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Read";
            Text = "Read";
            Load += Read_Load;
            Resize += Read_Resize;
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel5.ResumeLayout(false);
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel3;
        private ComboBox exportTo_Cb;
        private Button export_Btn;
        private Label exportTo_Lbl;
        private DataGridView dataGridView1;
        private Panel panel1;
        private Button show1_Btn;
        private Panel panel2;
        private Label label4;
        private ComboBox serialNo_Cmb;
        private Panel panel5;
        private Button reservedHardwares_Btn;
        private ComboBox location_Cmb;
        private Label label1;
        private Label label2;
        private Button button1;
        private ComboBox unit_Cmb;
        private Panel panel4;
        private Panel panel6;
    }
}