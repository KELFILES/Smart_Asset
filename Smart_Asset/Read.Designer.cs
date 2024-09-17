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
            edit_Btn = new Button();
            label3 = new Label();
            button2 = new Button();
            panel7 = new Panel();
            borrowedHardwares_Btn = new Button();
            cleaningHardwares_Btn = new Button();
            disposedHardwares_Btn = new Button();
            repairingHardwares_Btn = new Button();
            panel5 = new Panel();
            recycleBin_Btn = new Button();
            showAllHardwares_Btn = new Button();
            reservedHardwares_Btn = new Button();
            panel4 = new Panel();
            show1_Btn = new Button();
            serialNo_Cmb = new ComboBox();
            label4 = new Label();
            panel6 = new Panel();
            location_Cmb = new ComboBox();
            label1 = new Label();
            show2_Btn = new Button();
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
            panel3.BackColor = Color.DimGray;
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
            dataGridView1.Dock = DockStyle.Fill;
            dataGridView1.Location = new Point(8, 235);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.Size = new Size(1904, 733);
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
            panel2.BackColor = Color.DimGray;
            panel2.Controls.Add(edit_Btn);
            panel2.Controls.Add(label3);
            panel2.Controls.Add(button2);
            panel2.Controls.Add(panel7);
            panel2.Controls.Add(panel5);
            panel2.Controls.Add(panel4);
            panel2.Controls.Add(panel6);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(8, 55);
            panel2.Name = "panel2";
            panel2.Size = new Size(1904, 180);
            panel2.TabIndex = 8;
            // 
            // edit_Btn
            // 
            edit_Btn.Anchor = AnchorStyles.Top;
            edit_Btn.BackColor = Color.LightGray;
            edit_Btn.FlatStyle = FlatStyle.Flat;
            edit_Btn.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            edit_Btn.Location = new Point(362, 142);
            edit_Btn.Name = "edit_Btn";
            edit_Btn.Size = new Size(28, 27);
            edit_Btn.TabIndex = 33;
            edit_Btn.Text = "E";
            edit_Btn.UseVisualStyleBackColor = false;
            edit_Btn.Click += edit_Btn_Click;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Top;
            label3.AutoSize = true;
            label3.BackColor = Color.Gray;
            label3.FlatStyle = FlatStyle.Flat;
            label3.Font = new Font("Trebuchet MS", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.White;
            label3.Location = new Point(870, 139);
            label3.Name = "label3";
            label3.Size = new Size(159, 35);
            label3.TabIndex = 32;
            label3.Text = "ASSET LISTS";
            // 
            // button2
            // 
            button2.Anchor = AnchorStyles.Top;
            button2.BackColor = Color.LightGray;
            button2.FlatStyle = FlatStyle.Flat;
            button2.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button2.Location = new Point(328, 142);
            button2.Name = "button2";
            button2.Size = new Size(28, 27);
            button2.TabIndex = 31;
            button2.Text = "+";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // panel7
            // 
            panel7.Anchor = AnchorStyles.Top;
            panel7.BackColor = Color.Gray;
            panel7.Controls.Add(borrowedHardwares_Btn);
            panel7.Controls.Add(cleaningHardwares_Btn);
            panel7.Controls.Add(disposedHardwares_Btn);
            panel7.Controls.Add(repairingHardwares_Btn);
            panel7.Location = new Point(1311, 13);
            panel7.Name = "panel7";
            panel7.Size = new Size(265, 120);
            panel7.TabIndex = 23;
            // 
            // borrowedHardwares_Btn
            // 
            borrowedHardwares_Btn.Anchor = AnchorStyles.Top;
            borrowedHardwares_Btn.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            borrowedHardwares_Btn.Location = new Point(134, 63);
            borrowedHardwares_Btn.Name = "borrowedHardwares_Btn";
            borrowedHardwares_Btn.Size = new Size(121, 48);
            borrowedHardwares_Btn.TabIndex = 12;
            borrowedHardwares_Btn.Text = "BORROWED HARDWARES";
            borrowedHardwares_Btn.UseVisualStyleBackColor = true;
            borrowedHardwares_Btn.Click += borrowedHardwares_Btn_Click;
            // 
            // cleaningHardwares_Btn
            // 
            cleaningHardwares_Btn.Anchor = AnchorStyles.Top;
            cleaningHardwares_Btn.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cleaningHardwares_Btn.Location = new Point(134, 9);
            cleaningHardwares_Btn.Name = "cleaningHardwares_Btn";
            cleaningHardwares_Btn.Size = new Size(121, 48);
            cleaningHardwares_Btn.TabIndex = 11;
            cleaningHardwares_Btn.Text = "CLEANING HARDWARES";
            cleaningHardwares_Btn.UseVisualStyleBackColor = true;
            cleaningHardwares_Btn.Click += cleaningHardwares_Btn_Click;
            // 
            // disposedHardwares_Btn
            // 
            disposedHardwares_Btn.Anchor = AnchorStyles.Top;
            disposedHardwares_Btn.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            disposedHardwares_Btn.Location = new Point(7, 63);
            disposedHardwares_Btn.Name = "disposedHardwares_Btn";
            disposedHardwares_Btn.Size = new Size(121, 48);
            disposedHardwares_Btn.TabIndex = 11;
            disposedHardwares_Btn.Text = "DISPOSED HARDWARES";
            disposedHardwares_Btn.UseVisualStyleBackColor = true;
            disposedHardwares_Btn.Click += disposedHardwares_Btn_Click;
            // 
            // repairingHardwares_Btn
            // 
            repairingHardwares_Btn.Anchor = AnchorStyles.Top;
            repairingHardwares_Btn.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            repairingHardwares_Btn.Location = new Point(7, 9);
            repairingHardwares_Btn.Name = "repairingHardwares_Btn";
            repairingHardwares_Btn.Size = new Size(121, 48);
            repairingHardwares_Btn.TabIndex = 10;
            repairingHardwares_Btn.Text = "REPAIRING HARDWARES";
            repairingHardwares_Btn.UseVisualStyleBackColor = true;
            repairingHardwares_Btn.Click += repairingHardwares_Btn_Click;
            // 
            // panel5
            // 
            panel5.Anchor = AnchorStyles.Top;
            panel5.BackColor = Color.Gray;
            panel5.Controls.Add(recycleBin_Btn);
            panel5.Controls.Add(showAllHardwares_Btn);
            panel5.Controls.Add(reservedHardwares_Btn);
            panel5.Location = new Point(328, 13);
            panel5.Name = "panel5";
            panel5.Size = new Size(265, 120);
            panel5.TabIndex = 22;
            // 
            // recycleBin_Btn
            // 
            recycleBin_Btn.Anchor = AnchorStyles.Top;
            recycleBin_Btn.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            recycleBin_Btn.Location = new Point(7, 63);
            recycleBin_Btn.Name = "recycleBin_Btn";
            recycleBin_Btn.Size = new Size(121, 48);
            recycleBin_Btn.TabIndex = 13;
            recycleBin_Btn.Text = "RECYCLE BIN";
            recycleBin_Btn.UseVisualStyleBackColor = true;
            recycleBin_Btn.Click += recycleBin_Btn_Click;
            // 
            // showAllHardwares_Btn
            // 
            showAllHardwares_Btn.Anchor = AnchorStyles.Top;
            showAllHardwares_Btn.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            showAllHardwares_Btn.Location = new Point(7, 9);
            showAllHardwares_Btn.Name = "showAllHardwares_Btn";
            showAllHardwares_Btn.Size = new Size(121, 48);
            showAllHardwares_Btn.TabIndex = 12;
            showAllHardwares_Btn.Text = "SHOW ALL HARDWARES";
            showAllHardwares_Btn.UseVisualStyleBackColor = true;
            showAllHardwares_Btn.Click += showAllHardwares_Btn_Click;
            // 
            // reservedHardwares_Btn
            // 
            reservedHardwares_Btn.Anchor = AnchorStyles.Top;
            reservedHardwares_Btn.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            reservedHardwares_Btn.Location = new Point(134, 9);
            reservedHardwares_Btn.Name = "reservedHardwares_Btn";
            reservedHardwares_Btn.Size = new Size(121, 48);
            reservedHardwares_Btn.TabIndex = 10;
            reservedHardwares_Btn.Text = "RESERVED HARDWARES";
            reservedHardwares_Btn.UseVisualStyleBackColor = true;
            reservedHardwares_Btn.Click += reservedHardwares_Btn_Click_1;
            // 
            // panel4
            // 
            panel4.Anchor = AnchorStyles.Top;
            panel4.BackColor = Color.Gray;
            panel4.Controls.Add(show1_Btn);
            panel4.Controls.Add(serialNo_Cmb);
            panel4.Controls.Add(label4);
            panel4.Location = new Point(599, 13);
            panel4.Name = "panel4";
            panel4.Size = new Size(350, 120);
            panel4.TabIndex = 29;
            // 
            // show1_Btn
            // 
            show1_Btn.Anchor = AnchorStyles.Top;
            show1_Btn.Location = new Point(157, 63);
            show1_Btn.Name = "show1_Btn";
            show1_Btn.Size = new Size(74, 23);
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
            panel6.Controls.Add(show2_Btn);
            panel6.Controls.Add(unit_Cmb);
            panel6.Controls.Add(label2);
            panel6.Location = new Point(955, 13);
            panel6.Name = "panel6";
            panel6.Size = new Size(350, 120);
            panel6.TabIndex = 30;
            // 
            // location_Cmb
            // 
            location_Cmb.Anchor = AnchorStyles.Top;
            location_Cmb.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
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
            // show2_Btn
            // 
            show2_Btn.Anchor = AnchorStyles.Top;
            show2_Btn.Location = new Point(174, 82);
            show2_Btn.Name = "show2_Btn";
            show2_Btn.Size = new Size(68, 23);
            show2_Btn.TabIndex = 28;
            show2_Btn.Text = "SHOW";
            show2_Btn.UseVisualStyleBackColor = true;
            show2_Btn.Click += Show2_Click_1;
            // 
            // unit_Cmb
            // 
            unit_Cmb.Anchor = AnchorStyles.Top;
            unit_Cmb.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
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
            panel2.PerformLayout();
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
        private Button show1_Btn;
        private Panel panel2;
        private Label label4;
        private ComboBox serialNo_Cmb;
        private Panel panel5;
        private Button reservedHardwares_Btn;
        private ComboBox location_Cmb;
        private Label label1;
        private Label label2;
        private Button show2_Btn;
        private ComboBox unit_Cmb;
        private Panel panel4;
        private Panel panel6;
        private Panel panel7;
        private Button disposedHardwares_Btn;
        private Button cleaningHardwares_Btn;
        private Button showAllHardwares_Btn;
        private Button borrowedHardwares_Btn;
        private Button recycleBin_Btn;
        private Button button2;
        private Label label3;
        private Button edit_Btn;
        public Button repairingHardwares_Btn;
        public DataGridView dataGridView1;
    }
}