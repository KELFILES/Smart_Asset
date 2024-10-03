namespace Smart_Asset
{
    partial class Deployment
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
            dataGridView1 = new DataGridView();
            panel2 = new Panel();
            serialNo_Cmb = new TextBox();
            label4 = new Label();
            label3 = new Label();
            type_Cmb = new ComboBox();
            enter_Btn = new Button();
            unit_Cmb = new ComboBox();
            location_Cmb = new ComboBox();
            addUnit_Btn = new Button();
            addLocation_Btn = new Button();
            label2 = new Label();
            label1 = new Label();
            panel1.SuspendLayout();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(10, 18, 45);
            panel1.Controls.Add(panel3);
            panel1.Controls.Add(panel2);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Padding = new Padding(0, 55, 0, 0);
            panel1.Size = new Size(1109, 761);
            panel1.TabIndex = 0;
            // 
            // panel3
            // 
            panel3.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel3.BackColor = SystemColors.WindowFrame;
            panel3.BorderStyle = BorderStyle.FixedSingle;
            panel3.Controls.Add(dataGridView1);
            panel3.Location = new Point(12, 273);
            panel3.Name = "panel3";
            panel3.Padding = new Padding(10);
            panel3.Size = new Size(1085, 476);
            panel3.TabIndex = 1;
            // 
            // dataGridView1
            // 
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView1.BackgroundColor = Color.Black;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Dock = DockStyle.Fill;
            dataGridView1.Location = new Point(10, 10);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(1063, 454);
            dataGridView1.TabIndex = 0;
            // 
            // panel2
            // 
            panel2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel2.BackColor = Color.DimGray;
            panel2.Controls.Add(serialNo_Cmb);
            panel2.Controls.Add(label4);
            panel2.Controls.Add(label3);
            panel2.Controls.Add(type_Cmb);
            panel2.Controls.Add(enter_Btn);
            panel2.Controls.Add(unit_Cmb);
            panel2.Controls.Add(location_Cmb);
            panel2.Controls.Add(addUnit_Btn);
            panel2.Controls.Add(addLocation_Btn);
            panel2.Controls.Add(label2);
            panel2.Controls.Add(label1);
            panel2.Location = new Point(12, 67);
            panel2.Name = "panel2";
            panel2.Size = new Size(1085, 200);
            panel2.TabIndex = 0;
            // 
            // serialNo_Cmb
            // 
            serialNo_Cmb.Anchor = AnchorStyles.Top;
            serialNo_Cmb.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            serialNo_Cmb.CharacterCasing = CharacterCasing.Upper;
            serialNo_Cmb.Location = new Point(608, 111);
            serialNo_Cmb.Name = "serialNo_Cmb";
            serialNo_Cmb.Size = new Size(271, 23);
            serialNo_Cmb.TabIndex = 48;
            serialNo_Cmb.MouseClick += textBox1_MouseClick;
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Top;
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F);
            label4.ForeColor = Color.White;
            label4.Location = new Point(526, 113);
            label4.Name = "label4";
            label4.Size = new Size(76, 21);
            label4.TabIndex = 47;
            label4.Text = "SerialNo.:";
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Top;
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F);
            label3.ForeColor = Color.White;
            label3.Location = new Point(194, 113);
            label3.Name = "label3";
            label3.Size = new Size(45, 21);
            label3.TabIndex = 46;
            label3.Text = "Type:";
            // 
            // type_Cmb
            // 
            type_Cmb.Anchor = AnchorStyles.Top;
            type_Cmb.AutoCompleteSource = AutoCompleteSource.CustomSource;
            type_Cmb.DropDownStyle = ComboBoxStyle.DropDownList;
            type_Cmb.FormattingEnabled = true;
            type_Cmb.Location = new Point(245, 111);
            type_Cmb.Name = "type_Cmb";
            type_Cmb.Size = new Size(271, 23);
            type_Cmb.TabIndex = 44;
            type_Cmb.DropDown += type_Cmb_DropDown;
            // 
            // enter_Btn
            // 
            enter_Btn.Anchor = AnchorStyles.Top;
            enter_Btn.Location = new Point(508, 162);
            enter_Btn.Name = "enter_Btn";
            enter_Btn.Size = new Size(94, 23);
            enter_Btn.TabIndex = 43;
            enter_Btn.Text = "ENTER";
            enter_Btn.UseVisualStyleBackColor = true;
            enter_Btn.Click += enter_Btn_Click;
            // 
            // unit_Cmb
            // 
            unit_Cmb.Anchor = AnchorStyles.Top;
            unit_Cmb.AutoCompleteSource = AutoCompleteSource.CustomSource;
            unit_Cmb.DropDownStyle = ComboBoxStyle.DropDownList;
            unit_Cmb.FormattingEnabled = true;
            unit_Cmb.Location = new Point(245, 57);
            unit_Cmb.Name = "unit_Cmb";
            unit_Cmb.Size = new Size(595, 23);
            unit_Cmb.TabIndex = 42;
            unit_Cmb.DropDown += unit_DropDown;
            // 
            // location_Cmb
            // 
            location_Cmb.Anchor = AnchorStyles.Top;
            location_Cmb.AutoCompleteSource = AutoCompleteSource.CustomSource;
            location_Cmb.DropDownStyle = ComboBoxStyle.DropDownList;
            location_Cmb.FormattingEnabled = true;
            location_Cmb.Location = new Point(245, 27);
            location_Cmb.Name = "location_Cmb";
            location_Cmb.Size = new Size(595, 23);
            location_Cmb.TabIndex = 41;
            location_Cmb.DropDown += location_DropDown;
            // 
            // addUnit_Btn
            // 
            addUnit_Btn.Anchor = AnchorStyles.Top;
            addUnit_Btn.Font = new Font("Segoe UI", 12F);
            addUnit_Btn.Location = new Point(846, 55);
            addUnit_Btn.Name = "addUnit_Btn";
            addUnit_Btn.Size = new Size(33, 28);
            addUnit_Btn.TabIndex = 40;
            addUnit_Btn.Text = "+";
            addUnit_Btn.UseVisualStyleBackColor = true;
            addUnit_Btn.Click += addUnit_Btn_Click;
            // 
            // addLocation_Btn
            // 
            addLocation_Btn.Anchor = AnchorStyles.Top;
            addLocation_Btn.Font = new Font("Segoe UI", 12F);
            addLocation_Btn.Location = new Point(846, 25);
            addLocation_Btn.Name = "addLocation_Btn";
            addLocation_Btn.Size = new Size(33, 28);
            addLocation_Btn.TabIndex = 39;
            addLocation_Btn.Text = "+";
            addLocation_Btn.UseVisualStyleBackColor = true;
            addLocation_Btn.Click += addLocation_Btn_Click;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top;
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F);
            label2.ForeColor = Color.White;
            label2.Location = new Point(167, 59);
            label2.Name = "label2";
            label2.Size = new Size(42, 21);
            label2.TabIndex = 1;
            label2.Text = "Unit:";
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top;
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F);
            label1.ForeColor = Color.White;
            label1.Location = new Point(167, 29);
            label1.Name = "label1";
            label1.Size = new Size(72, 21);
            label1.TabIndex = 0;
            label1.Text = "Location:";
            // 
            // Deployment
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1109, 761);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Deployment";
            Text = "Deployment";
            panel1.ResumeLayout(false);
            panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Panel panel2;
        private Label label1;
        private Label label2;
        private Button addUnit_Btn;
        private Button addLocation_Btn;
        private Button enter_Btn;
        private Panel panel3;
        private Label label4;
        private Label label3;
        private ComboBox unit_Cmb;
        private ComboBox location_Cmb;
        private ComboBox type_Cmb;
        private TextBox serialNo_Cmb;
        private DataGridView dataGridView1;
    }
}