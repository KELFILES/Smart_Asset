namespace Smart_Asset
{
    partial class Borrow
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
            returnDate_Dtp = new DateTimePicker();
            label2 = new Label();
            name_Tb = new TextBox();
            label1 = new Label();
            borrow_Btn = new Button();
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
            panel3.Controls.Add(returnDate_Dtp);
            panel3.Controls.Add(label2);
            panel3.Controls.Add(name_Tb);
            panel3.Controls.Add(label1);
            panel3.Controls.Add(borrow_Btn);
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
            // returnDate_Dtp
            // 
            returnDate_Dtp.Location = new Point(264, 215);
            returnDate_Dtp.Name = "returnDate_Dtp";
            returnDate_Dtp.Size = new Size(200, 22);
            returnDate_Dtp.TabIndex = 33;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top;
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold);
            label2.ForeColor = Color.White;
            label2.Location = new Point(145, 215);
            label2.Name = "label2";
            label2.Size = new Size(113, 20);
            label2.TabIndex = 32;
            label2.Text = "Return Date:";
            // 
            // name_Tb
            // 
            name_Tb.Location = new Point(264, 180);
            name_Tb.Name = "name_Tb";
            name_Tb.Size = new Size(715, 22);
            name_Tb.TabIndex = 31;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top;
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold);
            label1.ForeColor = Color.White;
            label1.Location = new Point(198, 180);
            label1.Name = "label1";
            label1.Size = new Size(60, 20);
            label1.TabIndex = 30;
            label1.Text = "Name:";
            // 
            // borrow_Btn
            // 
            borrow_Btn.Anchor = AnchorStyles.Top;
            borrow_Btn.BackColor = Color.White;
            borrow_Btn.ForeColor = Color.FromArgb(2, 119, 189);
            borrow_Btn.Location = new Point(554, 521);
            borrow_Btn.Name = "borrow_Btn";
            borrow_Btn.Size = new Size(100, 26);
            borrow_Btn.TabIndex = 29;
            borrow_Btn.Text = "CONFIRM";
            borrow_Btn.UseVisualStyleBackColor = false;
            borrow_Btn.Click += transfer_Btn_Click;
            // 
            // serialNo_Cmb
            // 
            serialNo_Cmb.Anchor = AnchorStyles.Top;
            serialNo_Cmb.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            serialNo_Cmb.AutoCompleteSource = AutoCompleteSource.ListItems;
            serialNo_Cmb.FormattingEnabled = true;
            serialNo_Cmb.Location = new Point(264, 143);
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
            label7.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold);
            label7.ForeColor = Color.FromArgb(255, 242, 0);
            label7.Location = new Point(263, 251);
            label7.Name = "label7";
            label7.Size = new Size(209, 16);
            label7.TabIndex = 12;
            label7.Text = "Reminder: notes are Optional";
            // 
            // label5
            // 
            label5.Anchor = AnchorStyles.Top;
            label5.AutoSize = true;
            label5.Font = new Font("Microsoft Sans Serif", 27.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.White;
            label5.Location = new Point(408, 37);
            label5.Name = "label5";
            label5.Size = new Size(433, 42);
            label5.TabIndex = 7;
            label5.Text = "BORROW HARDWARE";
            // 
            // label8
            // 
            label8.Anchor = AnchorStyles.Top;
            label8.AutoSize = true;
            label8.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold);
            label8.ForeColor = Color.White;
            label8.Location = new Point(166, 147);
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
            notes_Tb.Location = new Point(263, 274);
            notes_Tb.Name = "notes_Tb";
            notes_Tb.Size = new Size(716, 232);
            notes_Tb.TabIndex = 11;
            notes_Tb.Text = "";
            // 
            // Borrow
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1200, 764);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "Borrow";
            Text = "Borrow";
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
        private Button borrow_Btn;
        public ComboBox serialNo_Cmb;
        private TextBox name_Tb;
        private Label label1;
        private DateTimePicker returnDate_Dtp;
        private Label label2;
    }
}