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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            panel3 = new Panel();
            exportTo_Cb = new ComboBox();
            export_Btn = new Button();
            exportTo_Lbl = new Label();
            dataGridView1 = new DataGridView();
            panel1 = new Panel();
            panel2 = new Panel();
            panel7 = new Panel();
            borrowedHardwares_Btn = new Button();
            cleaningHardwares_Btn = new Button();
            disposedHardwares_Btn = new Button();
            repairingHardwares_Btn = new Button();
            panel5 = new Panel();
            archive_Btn = new Button();
            showAllHardwares_Btn = new Button();
            reservedHardwares_Btn = new Button();
            panel4 = new Panel();
            search1_Btn = new Button();
            serialNo_Cmb = new ComboBox();
            label4 = new Label();
            panel6 = new Panel();
            location_Cmb = new ComboBox();
            label1 = new Label();
            search2_Btn = new Button();
            unit_Cmb = new ComboBox();
            label2 = new Label();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel7.SuspendLayout();
            panel5.SuspendLayout();
            panel4.SuspendLayout();
            panel6.SuspendLayout();
            SuspendLayout();
            // 
            // panel3
            // 
            panel3.AutoScroll = true;
            panel3.BackColor = SystemColors.WindowFrame;
            panel3.Controls.Add(exportTo_Cb);
            panel3.Controls.Add(export_Btn);
            panel3.Controls.Add(exportTo_Lbl);
            panel3.Dock = DockStyle.Bottom;
            panel3.Location = new Point(8, 968);
            panel3.Name = "panel3";
            panel3.Size = new Size(1904, 104);
            panel3.TabIndex = 9;
            // 
            // exportTo_Cb
            // 
            exportTo_Cb.Anchor = AnchorStyles.Top;
            exportTo_Cb.FormattingEnabled = true;
            exportTo_Cb.Location = new Point(885, 42);
            exportTo_Cb.Name = "exportTo_Cb";
            exportTo_Cb.Size = new Size(133, 23);
            exportTo_Cb.TabIndex = 8;
            exportTo_Cb.Tag = "";
            // 
            // export_Btn
            // 
            export_Btn.Anchor = AnchorStyles.Top;
            export_Btn.Location = new Point(906, 71);
            export_Btn.Name = "export_Btn";
            export_Btn.Size = new Size(88, 23);
            export_Btn.TabIndex = 7;
            export_Btn.Text = "EXPORT";
            export_Btn.UseVisualStyleBackColor = true;
            export_Btn.Click += export_Btn_Click;
            // 
            // exportTo_Lbl
            // 
            exportTo_Lbl.Anchor = AnchorStyles.Top;
            exportTo_Lbl.AutoSize = true;
            exportTo_Lbl.Location = new Point(922, 24);
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
            dataGridView1.BackgroundColor = Color.Black;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dataGridView1.ColumnHeadersHeight = 35;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.Black;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 11F);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dataGridView1.DefaultCellStyle = dataGridViewCellStyle2;
            dataGridView1.Dock = DockStyle.Fill;
            dataGridView1.GridColor = Color.White;
            dataGridView1.Location = new Point(8, 197);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowTemplate.Height = 50;
            dataGridView1.Size = new Size(1904, 771);
            dataGridView1.TabIndex = 4;
            dataGridView1.SelectionChanged += dataGridView1_SelectionChanged;
            dataGridView1.MouseDown += dataGridView1_MouseDown;
            // 
            // panel1
            // 
            panel1.AutoScroll = true;
            panel1.BackColor = Color.FromArgb(10, 18, 45);
            panel1.Controls.Add(dataGridView1);
            panel1.Controls.Add(panel2);
            panel1.Controls.Add(panel3);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Padding = new Padding(8, 55, 8, 8);
            panel1.Size = new Size(1920, 1080);
            panel1.TabIndex = 8;
            // 
            // panel2
            // 
            panel2.AutoScroll = true;
            panel2.BackColor = SystemColors.WindowFrame;
            panel2.Controls.Add(panel7);
            panel2.Controls.Add(panel5);
            panel2.Controls.Add(panel4);
            panel2.Controls.Add(panel6);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(8, 55);
            panel2.Name = "panel2";
            panel2.Size = new Size(1904, 142);
            panel2.TabIndex = 8;
            // 
            // panel7
            // 
            panel7.Anchor = AnchorStyles.Top;
            panel7.BackColor = SystemColors.WindowFrame;
            panel7.Controls.Add(borrowedHardwares_Btn);
            panel7.Controls.Add(cleaningHardwares_Btn);
            panel7.Controls.Add(disposedHardwares_Btn);
            panel7.Controls.Add(repairingHardwares_Btn);
            panel7.Location = new Point(1890, 13);
            panel7.Name = "panel7";
            panel7.Size = new Size(10, 10);
            panel7.TabIndex = 23;
            // 
            // borrowedHardwares_Btn
            // 
            borrowedHardwares_Btn.Anchor = AnchorStyles.Top;
            borrowedHardwares_Btn.BackColor = Color.LightGray;
            borrowedHardwares_Btn.FlatAppearance.BorderColor = Color.White;
            borrowedHardwares_Btn.FlatAppearance.MouseDownBackColor = Color.Red;
            borrowedHardwares_Btn.FlatAppearance.MouseOverBackColor = Color.Turquoise;
            borrowedHardwares_Btn.FlatStyle = FlatStyle.Flat;
            borrowedHardwares_Btn.Font = new Font("Times New Roman", 9.75F);
            borrowedHardwares_Btn.Location = new Point(7, 63);
            borrowedHardwares_Btn.Name = "borrowedHardwares_Btn";
            borrowedHardwares_Btn.Size = new Size(121, 48);
            borrowedHardwares_Btn.TabIndex = 12;
            borrowedHardwares_Btn.Text = "BORROWED HARDWARES";
            borrowedHardwares_Btn.UseVisualStyleBackColor = false;
            borrowedHardwares_Btn.Click += borrowedHardwares_Btn_Click;
            // 
            // cleaningHardwares_Btn
            // 
            cleaningHardwares_Btn.Anchor = AnchorStyles.Top;
            cleaningHardwares_Btn.BackColor = Color.LightGray;
            cleaningHardwares_Btn.FlatAppearance.BorderColor = Color.White;
            cleaningHardwares_Btn.FlatAppearance.MouseDownBackColor = Color.Red;
            cleaningHardwares_Btn.FlatAppearance.MouseOverBackColor = Color.Turquoise;
            cleaningHardwares_Btn.FlatStyle = FlatStyle.Flat;
            cleaningHardwares_Btn.Font = new Font("Times New Roman", 9.75F);
            cleaningHardwares_Btn.Location = new Point(7, 9);
            cleaningHardwares_Btn.Name = "cleaningHardwares_Btn";
            cleaningHardwares_Btn.Size = new Size(121, 48);
            cleaningHardwares_Btn.TabIndex = 11;
            cleaningHardwares_Btn.Text = "CLEANING HARDWARES";
            cleaningHardwares_Btn.UseVisualStyleBackColor = false;
            cleaningHardwares_Btn.Click += cleaningHardwares_Btn_Click;
            // 
            // disposedHardwares_Btn
            // 
            disposedHardwares_Btn.Anchor = AnchorStyles.Top;
            disposedHardwares_Btn.BackColor = Color.LightGray;
            disposedHardwares_Btn.FlatAppearance.BorderColor = Color.White;
            disposedHardwares_Btn.FlatAppearance.MouseDownBackColor = Color.Red;
            disposedHardwares_Btn.FlatAppearance.MouseOverBackColor = Color.Turquoise;
            disposedHardwares_Btn.FlatStyle = FlatStyle.Flat;
            disposedHardwares_Btn.Font = new Font("Times New Roman", 9.75F);
            disposedHardwares_Btn.Location = new Point(-120, 63);
            disposedHardwares_Btn.Name = "disposedHardwares_Btn";
            disposedHardwares_Btn.Size = new Size(121, 48);
            disposedHardwares_Btn.TabIndex = 11;
            disposedHardwares_Btn.Text = "DISPOSED HARDWARES";
            disposedHardwares_Btn.UseVisualStyleBackColor = false;
            disposedHardwares_Btn.Click += disposedHardwares_Btn_Click;
            // 
            // repairingHardwares_Btn
            // 
            repairingHardwares_Btn.Anchor = AnchorStyles.Top;
            repairingHardwares_Btn.BackColor = Color.LightGray;
            repairingHardwares_Btn.FlatAppearance.BorderColor = Color.White;
            repairingHardwares_Btn.FlatAppearance.MouseDownBackColor = Color.Red;
            repairingHardwares_Btn.FlatAppearance.MouseOverBackColor = Color.Turquoise;
            repairingHardwares_Btn.FlatStyle = FlatStyle.Flat;
            repairingHardwares_Btn.Font = new Font("Times New Roman", 9.75F);
            repairingHardwares_Btn.Location = new Point(-120, 9);
            repairingHardwares_Btn.Name = "repairingHardwares_Btn";
            repairingHardwares_Btn.Size = new Size(121, 48);
            repairingHardwares_Btn.TabIndex = 10;
            repairingHardwares_Btn.Text = "REPAIRING HARDWARES";
            repairingHardwares_Btn.UseVisualStyleBackColor = false;
            repairingHardwares_Btn.Click += repairingHardwares_Btn_Click;
            // 
            // panel5
            // 
            panel5.Anchor = AnchorStyles.Top;
            panel5.BackColor = SystemColors.WindowFrame;
            panel5.Controls.Add(archive_Btn);
            panel5.Controls.Add(showAllHardwares_Btn);
            panel5.Controls.Add(reservedHardwares_Btn);
            panel5.Location = new Point(13, 13);
            panel5.Name = "panel5";
            panel5.Size = new Size(10, 10);
            panel5.TabIndex = 22;
            // 
            // archive_Btn
            // 
            archive_Btn.Anchor = AnchorStyles.Top;
            archive_Btn.BackColor = Color.LightGray;
            archive_Btn.FlatAppearance.BorderColor = Color.White;
            archive_Btn.FlatAppearance.MouseDownBackColor = Color.Red;
            archive_Btn.FlatAppearance.MouseOverBackColor = Color.Turquoise;
            archive_Btn.FlatStyle = FlatStyle.Flat;
            archive_Btn.Font = new Font("Times New Roman", 9.75F);
            archive_Btn.Location = new Point(-120, 63);
            archive_Btn.Name = "archive_Btn";
            archive_Btn.Size = new Size(121, 48);
            archive_Btn.TabIndex = 13;
            archive_Btn.Text = "ARCHIVED";
            archive_Btn.UseVisualStyleBackColor = false;
            archive_Btn.Click += recycleBin_Btn_Click;
            // 
            // showAllHardwares_Btn
            // 
            showAllHardwares_Btn.Anchor = AnchorStyles.Top;
            showAllHardwares_Btn.BackColor = Color.LightGray;
            showAllHardwares_Btn.FlatAppearance.BorderColor = Color.White;
            showAllHardwares_Btn.FlatAppearance.MouseDownBackColor = Color.Red;
            showAllHardwares_Btn.FlatAppearance.MouseOverBackColor = Color.Turquoise;
            showAllHardwares_Btn.FlatStyle = FlatStyle.Flat;
            showAllHardwares_Btn.Font = new Font("Times New Roman", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            showAllHardwares_Btn.Location = new Point(-120, 9);
            showAllHardwares_Btn.Name = "showAllHardwares_Btn";
            showAllHardwares_Btn.Size = new Size(121, 48);
            showAllHardwares_Btn.TabIndex = 12;
            showAllHardwares_Btn.Text = "SHOW ALL HARDWARES";
            showAllHardwares_Btn.UseVisualStyleBackColor = false;
            showAllHardwares_Btn.Click += showAllHardwares_Btn_Click;
            // 
            // reservedHardwares_Btn
            // 
            reservedHardwares_Btn.Anchor = AnchorStyles.Top;
            reservedHardwares_Btn.BackColor = Color.LightGray;
            reservedHardwares_Btn.FlatAppearance.BorderColor = Color.White;
            reservedHardwares_Btn.FlatAppearance.MouseDownBackColor = Color.Red;
            reservedHardwares_Btn.FlatAppearance.MouseOverBackColor = Color.Turquoise;
            reservedHardwares_Btn.FlatStyle = FlatStyle.Flat;
            reservedHardwares_Btn.Font = new Font("Times New Roman", 9.75F);
            reservedHardwares_Btn.Location = new Point(7, 9);
            reservedHardwares_Btn.Name = "reservedHardwares_Btn";
            reservedHardwares_Btn.Size = new Size(121, 48);
            reservedHardwares_Btn.TabIndex = 10;
            reservedHardwares_Btn.Text = "RESERVED HARDWARES";
            reservedHardwares_Btn.UseVisualStyleBackColor = false;
            reservedHardwares_Btn.Click += reservedHardwares_Btn_Click_1;
            // 
            // panel4
            // 
            panel4.Anchor = AnchorStyles.Top;
            panel4.BackColor = Color.Gray;
            panel4.Controls.Add(search1_Btn);
            panel4.Controls.Add(serialNo_Cmb);
            panel4.Controls.Add(label4);
            panel4.Location = new Point(608, 13);
            panel4.Name = "panel4";
            panel4.Size = new Size(350, 120);
            panel4.TabIndex = 29;
            // 
            // search1_Btn
            // 
            search1_Btn.Anchor = AnchorStyles.Top;
            search1_Btn.Location = new Point(149, 63);
            search1_Btn.Name = "search1_Btn";
            search1_Btn.Size = new Size(88, 28);
            search1_Btn.TabIndex = 19;
            search1_Btn.Text = "SEARCH";
            search1_Btn.UseVisualStyleBackColor = true;
            search1_Btn.Click += show1_Btn_Click;
            // 
            // serialNo_Cmb
            // 
            serialNo_Cmb.Anchor = AnchorStyles.Top;
            serialNo_Cmb.AutoCompleteMode = AutoCompleteMode.Append;
            serialNo_Cmb.AutoCompleteSource = AutoCompleteSource.ListItems;
            serialNo_Cmb.FormattingEnabled = true;
            serialNo_Cmb.Location = new Point(76, 34);
            serialNo_Cmb.Name = "serialNo_Cmb";
            serialNo_Cmb.Size = new Size(261, 23);
            serialNo_Cmb.TabIndex = 23;
            serialNo_Cmb.KeyPress += serialNo_Cmb_KeyPress;
            serialNo_Cmb.MouseEnter += serialNo_Cmb_MouseEnter;
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Top;
            label4.AutoSize = true;
            label4.Location = new Point(14, 37);
            label4.Name = "label4";
            label4.Size = new Size(60, 15);
            label4.TabIndex = 24;
            label4.Text = "Serial No.:";
            // 
            // panel6
            // 
            panel6.Anchor = AnchorStyles.Top;
            panel6.BackColor = Color.Gray;
            panel6.Controls.Add(location_Cmb);
            panel6.Controls.Add(label1);
            panel6.Controls.Add(search2_Btn);
            panel6.Controls.Add(unit_Cmb);
            panel6.Controls.Add(label2);
            panel6.Location = new Point(964, 13);
            panel6.Name = "panel6";
            panel6.Size = new Size(350, 120);
            panel6.TabIndex = 30;
            // 
            // location_Cmb
            // 
            location_Cmb.Anchor = AnchorStyles.Top;
            location_Cmb.AutoCompleteMode = AutoCompleteMode.Append;
            location_Cmb.AutoCompleteSource = AutoCompleteSource.ListItems;
            location_Cmb.DropDownStyle = ComboBoxStyle.DropDownList;
            location_Cmb.FormattingEnabled = true;
            location_Cmb.Location = new Point(80, 24);
            location_Cmb.Name = "location_Cmb";
            location_Cmb.Size = new Size(255, 23);
            location_Cmb.TabIndex = 25;
            location_Cmb.DropDown += location_Cmb_DropDown_1;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top;
            label1.AutoSize = true;
            label1.BackColor = Color.Gray;
            label1.Location = new Point(18, 27);
            label1.Name = "label1";
            label1.Size = new Size(56, 15);
            label1.TabIndex = 24;
            label1.Text = "Location:";
            // 
            // search2_Btn
            // 
            search2_Btn.Anchor = AnchorStyles.Top;
            search2_Btn.Location = new Point(163, 82);
            search2_Btn.Name = "search2_Btn";
            search2_Btn.Size = new Size(84, 29);
            search2_Btn.TabIndex = 28;
            search2_Btn.Text = "SEARCH";
            search2_Btn.UseVisualStyleBackColor = true;
            search2_Btn.Click += Show2_Click_1;
            // 
            // unit_Cmb
            // 
            unit_Cmb.Anchor = AnchorStyles.Top;
            unit_Cmb.AutoCompleteMode = AutoCompleteMode.Append;
            unit_Cmb.AutoCompleteSource = AutoCompleteSource.ListItems;
            unit_Cmb.DropDownStyle = ComboBoxStyle.DropDownList;
            unit_Cmb.FormattingEnabled = true;
            unit_Cmb.Location = new Point(80, 53);
            unit_Cmb.Name = "unit_Cmb";
            unit_Cmb.Size = new Size(255, 23);
            unit_Cmb.TabIndex = 26;
            unit_Cmb.DropDown += unit_Cmb_DropDown_1;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top;
            label2.AutoSize = true;
            label2.BackColor = Color.Gray;
            label2.Location = new Point(18, 56);
            label2.Name = "label2";
            label2.Size = new Size(32, 15);
            label2.TabIndex = 27;
            label2.Text = "Unit:";
            // 
            // Read
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            ClientSize = new Size(1920, 1080);
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
            panel7.ResumeLayout(false);
            panel5.ResumeLayout(false);
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            panel6.ResumeLayout(false);
            panel6.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel3;
        private ComboBox exportTo_Cb;
        private Button export_Btn;
        private Label exportTo_Lbl;
        private Panel panel1;
        private Button search1_Btn;
        private Label label4;
        private ComboBox serialNo_Cmb;
        private ComboBox location_Cmb;
        private Label label1;
        private Label label2;
        private Button search2_Btn;
        private ComboBox unit_Cmb;
        public Button repairingHardwares_Btn;
        public DataGridView dataGridView1;
        public Button reservedHardwares_Btn;
        public Button disposedHardwares_Btn;
        public Button cleaningHardwares_Btn;
        public Button showAllHardwares_Btn;
        public Button borrowedHardwares_Btn;
        public Button archive_Btn;
        public Panel panel5;
        public Panel panel7;
        public Panel panel4;
        public Panel panel6;
        public Panel panel2;
    }
}