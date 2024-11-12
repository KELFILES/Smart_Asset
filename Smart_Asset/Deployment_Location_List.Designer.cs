namespace Smart_Asset
{
    partial class Deployment_Location_List
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
            search_Tb = new TextBox();
            label1 = new Label();
            button2 = new Button();
            button3 = new Button();
            item_Tb = new TextBox();
            label2 = new Label();
            dataGridView1 = new DataGridView();
            button1 = new Button();
            add_Btn = new Button();
            item_Lbl = new Label();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(panel2);
            panel1.Controls.Add(button1);
            panel1.Controls.Add(add_Btn);
            panel1.Controls.Add(item_Lbl);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(631, 528);
            panel1.TabIndex = 0;
            // 
            // panel2
            // 
            panel2.Controls.Add(search_Tb);
            panel2.Controls.Add(label1);
            panel2.Controls.Add(button2);
            panel2.Controls.Add(button3);
            panel2.Controls.Add(item_Tb);
            panel2.Controls.Add(label2);
            panel2.Controls.Add(dataGridView1);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(631, 528);
            panel2.TabIndex = 5;
            // 
            // search_Tb
            // 
            search_Tb.Anchor = AnchorStyles.Top;
            search_Tb.CharacterCasing = CharacterCasing.Upper;
            search_Tb.Font = new Font("Segoe UI", 13F);
            search_Tb.Location = new Point(154, 31);
            search_Tb.Multiline = true;
            search_Tb.Name = "search_Tb";
            search_Tb.Size = new Size(370, 25);
            search_Tb.TabIndex = 6;
            search_Tb.Click += search_Tb_Click;
            search_Tb.TextChanged += search_Tb_TextChanged;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top;
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 13F);
            label1.Location = new Point(80, 31);
            label1.Name = "label1";
            label1.Size = new Size(68, 25);
            label1.TabIndex = 5;
            label1.Text = "Search:";
            // 
            // button2
            // 
            button2.Font = new Font("Segoe UI", 13F);
            button2.Location = new Point(402, 458);
            button2.Name = "button2";
            button2.Size = new Size(98, 41);
            button2.TabIndex = 4;
            button2.Text = "REMOVE";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Font = new Font("Segoe UI", 13F);
            button3.Location = new Point(130, 458);
            button3.Name = "button3";
            button3.Size = new Size(98, 41);
            button3.TabIndex = 3;
            button3.Text = "ADD";
            button3.UseVisualStyleBackColor = true;
            button3.Click += add_Btn_Click;
            // 
            // item_Tb
            // 
            item_Tb.Anchor = AnchorStyles.Top;
            item_Tb.CharacterCasing = CharacterCasing.Upper;
            item_Tb.Font = new Font("Segoe UI", 13F);
            item_Tb.Location = new Point(154, 402);
            item_Tb.Multiline = true;
            item_Tb.Name = "item_Tb";
            item_Tb.Size = new Size(370, 25);
            item_Tb.TabIndex = 2;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top;
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 13F);
            label2.Location = new Point(96, 402);
            label2.Name = "label2";
            label2.Size = new Size(52, 25);
            label2.TabIndex = 1;
            label2.Text = "Item:";
            // 
            // dataGridView1
            // 
            dataGridView1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView1.BackgroundColor = Color.Black;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.EditMode = DataGridViewEditMode.EditProgrammatically;
            dataGridView1.Location = new Point(26, 78);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(583, 295);
            dataGridView1.TabIndex = 0;
            dataGridView1.DataBindingComplete += dataGridView2_DataBindingComplete;
            // 
            // button1
            // 
            button1.Font = new Font("Segoe UI", 13F);
            button1.Location = new Point(399, 452);
            button1.Name = "button1";
            button1.Size = new Size(98, 41);
            button1.TabIndex = 4;
            button1.Text = "REMOVE";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // add_Btn
            // 
            add_Btn.Font = new Font("Segoe UI", 13F);
            add_Btn.Location = new Point(127, 452);
            add_Btn.Name = "add_Btn";
            add_Btn.Size = new Size(98, 41);
            add_Btn.TabIndex = 3;
            add_Btn.Text = "ADD";
            add_Btn.UseVisualStyleBackColor = true;
            add_Btn.Click += add_Btn_Click;
            // 
            // item_Lbl
            // 
            item_Lbl.Anchor = AnchorStyles.Top;
            item_Lbl.AutoSize = true;
            item_Lbl.Font = new Font("Segoe UI", 13F);
            item_Lbl.Location = new Point(69, 402);
            item_Lbl.Name = "item_Lbl";
            item_Lbl.Size = new Size(52, 25);
            item_Lbl.TabIndex = 1;
            item_Lbl.Text = "Item:";
            // 
            // Deployment_Location_List
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(631, 528);
            Controls.Add(panel1);
            Name = "Deployment_Location_List";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Location";
            Load += Deployment_Location_List_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Button button1;
        private Button add_Btn;
        private Label item_Lbl;
        private DataGridView dataGridView11;
        private Panel panel2;
        private TextBox search_Tb;
        private Label label1;
        private Button button2;
        private Button button3;
        private TextBox item_Tb;
        private Label label2;
        private DataGridView dataGridView1;
    }
}