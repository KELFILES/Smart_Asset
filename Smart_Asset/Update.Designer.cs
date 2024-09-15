namespace Smart_Asset
{
    partial class Update
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
            show2_Btn = new Button();
            serialNo_Cmb = new ComboBox();
            label3 = new Label();
            button1 = new Button();
            dataGridView1 = new DataGridView();
            panel2 = new Panel();
            show_Btn = new Button();
            location_Cmb = new ComboBox();
            label1 = new Label();
            unit_Cmb = new ComboBox();
            label2 = new Label();
            panel1.SuspendLayout();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.AutoScroll = true;
            panel1.BackColor = Color.FromArgb(10, 18, 45);
            panel1.Controls.Add(panel3);
            panel1.Controls.Add(button1);
            panel1.Controls.Add(dataGridView1);
            panel1.Controls.Add(panel2);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Padding = new Padding(0, 55, 0, 0);
            panel1.Size = new Size(1125, 800);
            panel1.TabIndex = 9;
            // 
            // panel3
            // 
            panel3.Anchor = AnchorStyles.Top;
            panel3.BackColor = Color.DimGray;
            panel3.Controls.Add(show2_Btn);
            panel3.Controls.Add(serialNo_Cmb);
            panel3.Controls.Add(label3);
            panel3.Location = new Point(572, 67);
            panel3.Name = "panel3";
            panel3.Size = new Size(541, 102);
            panel3.TabIndex = 10;
            // 
            // show2_Btn
            // 
            show2_Btn.Anchor = AnchorStyles.Top;
            show2_Btn.Location = new Point(254, 53);
            show2_Btn.Name = "show2_Btn";
            show2_Btn.Size = new Size(70, 26);
            show2_Btn.TabIndex = 10;
            show2_Btn.Text = "SHOW";
            show2_Btn.UseVisualStyleBackColor = true;
            show2_Btn.Click += show2_Btn_Click;
            // 
            // serialNo_Cmb
            // 
            serialNo_Cmb.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            serialNo_Cmb.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            serialNo_Cmb.AutoCompleteSource = AutoCompleteSource.ListItems;
            serialNo_Cmb.FormattingEnabled = true;
            serialNo_Cmb.Location = new Point(83, 24);
            serialNo_Cmb.Name = "serialNo_Cmb";
            serialNo_Cmb.Size = new Size(431, 23);
            serialNo_Cmb.TabIndex = 5;
            serialNo_Cmb.DropDown += serialNo_Cmb_MouseEnter;
            serialNo_Cmb.KeyPress += serialNo_Cmb_KeyPress;
            serialNo_Cmb.MouseEnter += serialNo_Cmb_MouseEnter;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label3.AutoSize = true;
            label3.Location = new Point(20, 27);
            label3.Name = "label3";
            label3.Size = new Size(54, 15);
            label3.TabIndex = 4;
            label3.Text = "SerialNo:";
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.Bottom;
            button1.Location = new Point(524, 751);
            button1.Name = "button1";
            button1.Size = new Size(101, 37);
            button1.TabIndex = 9;
            button1.Text = "UPDATE";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToOrderColumns = true;
            dataGridView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.EditMode = DataGridViewEditMode.EditOnEnter;
            dataGridView1.Location = new Point(11, 175);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(1102, 570);
            dataGridView1.TabIndex = 4;
            dataGridView1.MouseClick += dataGridView1_MouseClick;
            // 
            // panel2
            // 
            panel2.Anchor = AnchorStyles.Top;
            panel2.BackColor = Color.DimGray;
            panel2.Controls.Add(show_Btn);
            panel2.Controls.Add(location_Cmb);
            panel2.Controls.Add(label1);
            panel2.Controls.Add(unit_Cmb);
            panel2.Controls.Add(label2);
            panel2.Location = new Point(11, 67);
            panel2.Name = "panel2";
            panel2.Size = new Size(555, 102);
            panel2.TabIndex = 8;
            // 
            // show_Btn
            // 
            show_Btn.Anchor = AnchorStyles.Top;
            show_Btn.Location = new Point(263, 70);
            show_Btn.Name = "show_Btn";
            show_Btn.Size = new Size(70, 26);
            show_Btn.TabIndex = 10;
            show_Btn.Text = "SHOW";
            show_Btn.UseVisualStyleBackColor = true;
            show_Btn.Click += show_Btn_Click;
            // 
            // location_Cmb
            // 
            location_Cmb.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            location_Cmb.DropDownStyle = ComboBoxStyle.DropDownList;
            location_Cmb.FormattingEnabled = true;
            location_Cmb.Location = new Point(84, 12);
            location_Cmb.Name = "location_Cmb";
            location_Cmb.Size = new Size(443, 23);
            location_Cmb.TabIndex = 5;
            location_Cmb.DropDown += location_Cmb_DropDown;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Location = new Point(21, 15);
            label1.Name = "label1";
            label1.Size = new Size(56, 15);
            label1.TabIndex = 4;
            label1.Text = "Location:";
            // 
            // unit_Cmb
            // 
            unit_Cmb.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            unit_Cmb.DropDownStyle = ComboBoxStyle.DropDownList;
            unit_Cmb.FormattingEnabled = true;
            unit_Cmb.Location = new Point(84, 41);
            unit_Cmb.Name = "unit_Cmb";
            unit_Cmb.Size = new Size(443, 23);
            unit_Cmb.TabIndex = 6;
            unit_Cmb.DropDown += unit_Cmb_DropDown;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label2.AutoSize = true;
            label2.Location = new Point(21, 44);
            label2.Name = "label2";
            label2.Size = new Size(32, 15);
            label2.TabIndex = 7;
            label2.Text = "Unit:";
            // 
            // Update
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1125, 800);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Update";
            Text = "Update";
            panel1.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private DataGridView dataGridView1;
        private Panel panel2;
        private ComboBox location_Cmb;
        private Label label1;
        private ComboBox unit_Cmb;
        private Label label2;
        private Button button1;
        private Button show_Btn;
        private Panel panel3;
        private Button show2_Btn;
        private ComboBox serialNo_Cmb;
        private Label label3;
    }
}