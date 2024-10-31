namespace Smart_Asset
{
    partial class Update_Users
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
            panel1 = new Panel();
            panel3 = new Panel();
            show2_Btn = new Button();
            userID_Cmb = new ComboBox();
            label3 = new Label();
            button1 = new Button();
            dataGridView1 = new DataGridView();
            panel1.SuspendLayout();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.AutoScroll = true;
            panel1.BackColor = Color.FromArgb(10, 18, 45);
            panel1.Controls.Add(panel3);
            panel1.Controls.Add(button1);
            panel1.Controls.Add(dataGridView1);
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
            panel3.Controls.Add(userID_Cmb);
            panel3.Controls.Add(label3);
            panel3.Location = new Point(279, 67);
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
            // userID_Cmb
            // 
            userID_Cmb.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            userID_Cmb.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            userID_Cmb.AutoCompleteSource = AutoCompleteSource.ListItems;
            userID_Cmb.FormattingEnabled = true;
            userID_Cmb.Location = new Point(83, 24);
            userID_Cmb.Name = "userID_Cmb";
            userID_Cmb.Size = new Size(431, 23);
            userID_Cmb.TabIndex = 5;
            userID_Cmb.DropDown += serialNo_Cmb_MouseEnter;
            userID_Cmb.KeyPress += serialNo_Cmb_KeyPress;
            userID_Cmb.MouseEnter += serialNo_Cmb_MouseEnter;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label3.AutoSize = true;
            label3.Location = new Point(20, 27);
            label3.Name = "label3";
            label3.Size = new Size(44, 15);
            label3.TabIndex = 4;
            label3.Text = "UserID:";
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
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView1.BackgroundColor = Color.Black;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.Black;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = Color.White;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.False;
            dataGridView1.DefaultCellStyle = dataGridViewCellStyle1;
            dataGridView1.EditMode = DataGridViewEditMode.EditOnEnter;
            dataGridView1.Location = new Point(11, 175);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(1102, 570);
            dataGridView1.TabIndex = 4;
            dataGridView1.MouseClick += dataGridView1_MouseClick;
            // 
            // Update_Users
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1125, 800);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Update_Users";
            Text = "Update";
            panel1.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private DataGridView dataGridView1;
        private Button button1;
        private Panel panel3;
        private Label label3;
        public ComboBox userID_Cmb;
        public Button show2_Btn;
    }
}