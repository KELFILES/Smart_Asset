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
            button1 = new Button();
            add_Btn = new Button();
            item_Tb = new TextBox();
            item_Lbl = new Label();
            dataGridView1 = new DataGridView();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(button1);
            panel1.Controls.Add(add_Btn);
            panel1.Controls.Add(item_Tb);
            panel1.Controls.Add(item_Lbl);
            panel1.Controls.Add(dataGridView1);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(631, 479);
            panel1.TabIndex = 0;
            // 
            // button1
            // 
            button1.Font = new Font("Segoe UI", 13F);
            button1.Location = new Point(402, 408);
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
            add_Btn.Location = new Point(130, 408);
            add_Btn.Name = "add_Btn";
            add_Btn.Size = new Size(98, 41);
            add_Btn.TabIndex = 3;
            add_Btn.Text = "ADD";
            add_Btn.UseVisualStyleBackColor = true;
            add_Btn.Click += add_Btn_Click;
            // 
            // item_Tb
            // 
            item_Tb.Anchor = AnchorStyles.Top;
            item_Tb.Font = new Font("Segoe UI", 13F);
            item_Tb.Location = new Point(130, 358);
            item_Tb.Multiline = true;
            item_Tb.Name = "item_Tb";
            item_Tb.Size = new Size(370, 25);
            item_Tb.TabIndex = 2;
            // 
            // item_Lbl
            // 
            item_Lbl.Anchor = AnchorStyles.Top;
            item_Lbl.AutoSize = true;
            item_Lbl.Font = new Font("Segoe UI", 13F);
            item_Lbl.Location = new Point(72, 358);
            item_Lbl.Name = "item_Lbl";
            item_Lbl.Size = new Size(52, 25);
            item_Lbl.TabIndex = 1;
            item_Lbl.Text = "Item:";
            // 
            // dataGridView1
            // 
            dataGridView1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView1.BackgroundColor = Color.Black;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.GridColor = SystemColors.WindowText;
            dataGridView1.Location = new Point(29, 28);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(572, 295);
            dataGridView1.TabIndex = 0;
            // 
            // Deployment_Location_List
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(631, 479);
            Controls.Add(panel1);
            Name = "Deployment_Location_List";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Location";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Button button1;
        private Button add_Btn;
        private TextBox item_Tb;
        private Label item_Lbl;
        private DataGridView dataGridView1;
    }
}