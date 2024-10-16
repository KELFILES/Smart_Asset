namespace Smart_Asset
{
    partial class Replacement
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
            button1 = new Button();
            label3 = new Label();
            serialNoTo_Cmb = new ComboBox();
            label2 = new Label();
            label1 = new Label();
            serialNoFrom_Cmb = new ComboBox();
            label8 = new Label();
            label5 = new Label();
            label7 = new Label();
            notes_Tb = new RichTextBox();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.DarkGray;
            panel1.Controls.Add(panel2);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1161, 612);
            panel1.TabIndex = 0;
            // 
            // panel2
            // 
            panel2.BackColor = Color.Gray;
            panel2.Controls.Add(label7);
            panel2.Controls.Add(notes_Tb);
            panel2.Controls.Add(button1);
            panel2.Controls.Add(label3);
            panel2.Controls.Add(serialNoTo_Cmb);
            panel2.Controls.Add(label2);
            panel2.Controls.Add(label1);
            panel2.Controls.Add(serialNoFrom_Cmb);
            panel2.Controls.Add(label8);
            panel2.Controls.Add(label5);
            panel2.Location = new Point(21, 29);
            panel2.Name = "panel2";
            panel2.Size = new Size(1117, 555);
            panel2.TabIndex = 0;
            // 
            // button1
            // 
            button1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button1.Location = new Point(515, 507);
            button1.Name = "button1";
            button1.Size = new Size(109, 34);
            button1.TabIndex = 31;
            button1.Text = "Replace";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Top;
            label3.AutoSize = true;
            label3.BackColor = Color.DimGray;
            label3.Font = new Font("Segoe UI", 24F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.White;
            label3.Location = new Point(453, 20);
            label3.Name = "label3";
            label3.Size = new Size(238, 45);
            label3.TabIndex = 30;
            label3.Text = "REPLACEMENT:";
            // 
            // serialNoTo_Cmb
            // 
            serialNoTo_Cmb.Anchor = AnchorStyles.Top;
            serialNoTo_Cmb.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            serialNoTo_Cmb.AutoCompleteSource = AutoCompleteSource.ListItems;
            serialNoTo_Cmb.FormattingEnabled = true;
            serialNoTo_Cmb.Location = new Point(216, 202);
            serialNoTo_Cmb.Name = "serialNoTo_Cmb";
            serialNoTo_Cmb.Size = new Size(715, 23);
            serialNoTo_Cmb.TabIndex = 29;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top;
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 14F);
            label2.ForeColor = Color.White;
            label2.Location = new Point(95, 200);
            label2.Name = "label2";
            label2.Size = new Size(97, 25);
            label2.TabIndex = 28;
            label2.Text = "Serial No.:";
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top;
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14F);
            label1.ForeColor = Color.White;
            label1.Location = new Point(515, 165);
            label1.Name = "label1";
            label1.Size = new Size(105, 25);
            label1.TabIndex = 27;
            label1.Text = "Replace To:";
            // 
            // serialNoFrom_Cmb
            // 
            serialNoFrom_Cmb.Anchor = AnchorStyles.Top;
            serialNoFrom_Cmb.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            serialNoFrom_Cmb.AutoCompleteSource = AutoCompleteSource.ListItems;
            serialNoFrom_Cmb.FormattingEnabled = true;
            serialNoFrom_Cmb.Location = new Point(216, 127);
            serialNoFrom_Cmb.Name = "serialNoFrom_Cmb";
            serialNoFrom_Cmb.Size = new Size(715, 23);
            serialNoFrom_Cmb.TabIndex = 26;
            // 
            // label8
            // 
            label8.Anchor = AnchorStyles.Top;
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 14F);
            label8.ForeColor = Color.White;
            label8.Location = new Point(95, 125);
            label8.Name = "label8";
            label8.Size = new Size(97, 25);
            label8.TabIndex = 25;
            label8.Text = "Serial No.:";
            // 
            // label5
            // 
            label5.Anchor = AnchorStyles.Top;
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 14F);
            label5.ForeColor = Color.White;
            label5.Location = new Point(506, 88);
            label5.Name = "label5";
            label5.Size = new Size(129, 25);
            label5.TabIndex = 8;
            label5.Text = "Replace From:";
            // 
            // label7
            // 
            label7.Anchor = AnchorStyles.Top;
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 11F);
            label7.ForeColor = Color.Red;
            label7.Location = new Point(215, 241);
            label7.Name = "label7";
            label7.Size = new Size(125, 20);
            label7.TabIndex = 33;
            label7.Text = "Notes: \"Optional\"";
            // 
            // notes_Tb
            // 
            notes_Tb.Anchor = AnchorStyles.Top;
            notes_Tb.BackColor = Color.Silver;
            notes_Tb.BorderStyle = BorderStyle.None;
            notes_Tb.Location = new Point(215, 264);
            notes_Tb.Name = "notes_Tb";
            notes_Tb.Size = new Size(716, 232);
            notes_Tb.TabIndex = 32;
            notes_Tb.Text = "";
            // 
            // Replacement
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1161, 612);
            Controls.Add(panel1);
            Name = "Replacement";
            Text = "Replacement";
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Panel panel2;
        private Label label5;
        public ComboBox serialNoFrom_Cmb;
        private Label label8;
        public ComboBox serialNoTo_Cmb;
        private Label label2;
        private Label label1;
        private Button button1;
        private Label label3;
        private Label label7;
        private RichTextBox notes_Tb;
    }
}