namespace Smart_Asset
{
    partial class Dispose_Window
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
            dispose_Btn = new Button();
            serialNo_Cmb = new ComboBox();
            label7 = new Label();
            label5 = new Label();
            label8 = new Label();
            notes_Tb = new RichTextBox();
            panel1.SuspendLayout();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.AutoScroll = true;
            panel1.BackColor = Color.FromArgb(0, 91, 143);
            panel1.Controls.Add(panel3);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Padding = new Padding(0, 55, 0, 0);
            panel1.Size = new Size(1200, 764);
            panel1.TabIndex = 0;
            // 
            // panel3
            // 
            panel3.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel3.BackColor = Color.FromArgb(2, 119, 189);
            panel3.Controls.Add(dispose_Btn);
            panel3.Controls.Add(serialNo_Cmb);
            panel3.Controls.Add(label7);
            panel3.Controls.Add(label5);
            panel3.Controls.Add(label8);
            panel3.Controls.Add(notes_Tb);
            panel3.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold);
            panel3.ForeColor = Color.White;
            panel3.Location = new Point(12, 67);
            panel3.Name = "panel3";
            panel3.Size = new Size(1176, 685);
            panel3.TabIndex = 7;
            // 
            // dispose_Btn
            // 
            dispose_Btn.Anchor = AnchorStyles.Top;
            dispose_Btn.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold);
            dispose_Btn.ForeColor = Color.FromArgb(2, 119, 189);
            dispose_Btn.Location = new Point(547, 483);
            dispose_Btn.Name = "dispose_Btn";
            dispose_Btn.Size = new Size(100, 26);
            dispose_Btn.TabIndex = 29;
            dispose_Btn.Text = "CONFIRM";
            dispose_Btn.UseVisualStyleBackColor = true;
            dispose_Btn.Click += transfer_Btn_Click;
            // 
            // serialNo_Cmb
            // 
            serialNo_Cmb.Anchor = AnchorStyles.Top;
            serialNo_Cmb.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            serialNo_Cmb.AutoCompleteSource = AutoCompleteSource.ListItems;
            serialNo_Cmb.FormattingEnabled = true;
            serialNo_Cmb.Location = new Point(257, 173);
            serialNo_Cmb.Name = "serialNo_Cmb";
            serialNo_Cmb.Size = new Size(715, 24);
            serialNo_Cmb.TabIndex = 24;
            serialNo_Cmb.KeyPress += serialNo_Cmb_KeyPress;
            serialNo_Cmb.MouseEnter += serialNo_Cmb_MouseEnter;
            // 
            // label7
            // 
            label7.Anchor = AnchorStyles.Top;
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.ForeColor = Color.FromArgb(255, 242, 0);
            label7.Location = new Point(256, 213);
            label7.Name = "label7";
            label7.Size = new Size(218, 20);
            label7.TabIndex = 12;
            label7.Text = "Reminder: Notes are Optional";
            // 
            // label5
            // 
            label5.Anchor = AnchorStyles.Top;
            label5.AutoSize = true;
            label5.Font = new Font("Microsoft Sans Serif", 27.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.White;
            label5.Location = new Point(408, 52);
            label5.Name = "label5";
            label5.Size = new Size(427, 42);
            label5.TabIndex = 7;
            label5.Text = "DISPOSE HARDWARE";
            // 
            // label8
            // 
            label8.Anchor = AnchorStyles.Top;
            label8.AutoSize = true;
            label8.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label8.ForeColor = Color.White;
            label8.Location = new Point(159, 175);
            label8.Name = "label8";
            label8.Size = new Size(92, 20);
            label8.TabIndex = 0;
            label8.Text = "Serial No.:";
            // 
            // notes_Tb
            // 
            notes_Tb.Anchor = AnchorStyles.Top;
            notes_Tb.BackColor = Color.White;
            notes_Tb.BorderStyle = BorderStyle.None;
            notes_Tb.Location = new Point(256, 236);
            notes_Tb.Name = "notes_Tb";
            notes_Tb.Size = new Size(716, 232);
            notes_Tb.TabIndex = 11;
            notes_Tb.Text = "";
            // 
            // Dispose_Window
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1200, 764);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Dispose_Window";
            Text = "Delete";
            panel1.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private TextBox textBox3;
        private Label label3;
        private CheckBox checkBox3;
        private Panel panel3;
        private CheckBox checkBox5;
        private Label label7;
        private RichTextBox notes_Tb;
        private Label label5;
        private Label label8;
        private Button dispose_Btn;
        public ComboBox serialNo_Cmb;
    }
}