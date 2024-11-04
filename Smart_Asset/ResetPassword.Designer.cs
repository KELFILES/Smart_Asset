namespace Smart_Asset
{
    partial class ResetPassword
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
            panel2 = new Panel();
            label3 = new Label();
            panel3 = new Panel();
            panel5 = new Panel();
            resetPassword_Btn = new Button();
            panel4 = new Panel();
            panel7 = new Panel();
            userIDVal_Lbl = new Label();
            label2 = new Label();
            reEnterPassword_Tb = new TextBox();
            nameVal_Lbl = new Label();
            password_Tb = new TextBox();
            label6 = new Label();
            label4 = new Label();
            label7 = new Label();
            panel1 = new Panel();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            panel5.SuspendLayout();
            panel4.SuspendLayout();
            panel7.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel2
            // 
            panel2.Controls.Add(label3);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(7, 7);
            panel2.Name = "panel2";
            panel2.Size = new Size(671, 65);
            panel2.TabIndex = 13;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.White;
            label3.Location = new Point(198, 13);
            label3.Name = "label3";
            label3.Size = new Size(223, 32);
            label3.TabIndex = 5;
            label3.Text = "RESET PASSWORD";
            // 
            // panel3
            // 
            panel3.BackColor = Color.DimGray;
            panel3.Controls.Add(panel5);
            panel3.Controls.Add(panel4);
            panel3.Controls.Add(panel2);
            panel3.Dock = DockStyle.Fill;
            panel3.Location = new Point(7, 7);
            panel3.Name = "panel3";
            panel3.Padding = new Padding(7);
            panel3.Size = new Size(685, 438);
            panel3.TabIndex = 10;
            // 
            // panel5
            // 
            panel5.Controls.Add(resetPassword_Btn);
            panel5.Dock = DockStyle.Bottom;
            panel5.Location = new Point(7, 361);
            panel5.Name = "panel5";
            panel5.Size = new Size(671, 70);
            panel5.TabIndex = 19;
            // 
            // resetPassword_Btn
            // 
            resetPassword_Btn.Anchor = AnchorStyles.Top;
            resetPassword_Btn.Location = new Point(280, 21);
            resetPassword_Btn.Name = "resetPassword_Btn";
            resetPassword_Btn.Size = new Size(92, 31);
            resetPassword_Btn.TabIndex = 10;
            resetPassword_Btn.Text = "RESET";
            resetPassword_Btn.UseVisualStyleBackColor = true;
            resetPassword_Btn.Click += resetPassword_Btn_Click;
            // 
            // panel4
            // 
            panel4.BackColor = SystemColors.GrayText;
            panel4.BorderStyle = BorderStyle.FixedSingle;
            panel4.Controls.Add(panel7);
            panel4.Dock = DockStyle.Fill;
            panel4.Location = new Point(7, 72);
            panel4.Name = "panel4";
            panel4.Size = new Size(671, 359);
            panel4.TabIndex = 15;
            // 
            // panel7
            // 
            panel7.Controls.Add(userIDVal_Lbl);
            panel7.Controls.Add(label2);
            panel7.Controls.Add(reEnterPassword_Tb);
            panel7.Controls.Add(nameVal_Lbl);
            panel7.Controls.Add(password_Tb);
            panel7.Controls.Add(label6);
            panel7.Controls.Add(label4);
            panel7.Controls.Add(label7);
            panel7.Dock = DockStyle.Fill;
            panel7.Location = new Point(0, 0);
            panel7.Name = "panel7";
            panel7.Size = new Size(669, 357);
            panel7.TabIndex = 15;
            // 
            // userIDVal_Lbl
            // 
            userIDVal_Lbl.AutoSize = true;
            userIDVal_Lbl.Font = new Font("Segoe UI", 14.25F);
            userIDVal_Lbl.ForeColor = Color.White;
            userIDVal_Lbl.Location = new Point(172, 51);
            userIDVal_Lbl.Name = "userIDVal_Lbl";
            userIDVal_Lbl.Size = new Size(94, 25);
            userIDVal_Lbl.TabIndex = 6;
            userIDVal_Lbl.Text = "UserIDVal";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.White;
            label2.Location = new Point(84, 51);
            label2.Name = "label2";
            label2.Size = new Size(82, 25);
            label2.TabIndex = 5;
            label2.Text = "User ID:";
            // 
            // reEnterPassword_Tb
            // 
            reEnterPassword_Tb.Location = new Point(279, 188);
            reEnterPassword_Tb.Name = "reEnterPassword_Tb";
            reEnterPassword_Tb.PasswordChar = '*';
            reEnterPassword_Tb.Size = new Size(295, 23);
            reEnterPassword_Tb.TabIndex = 15;
            // 
            // nameVal_Lbl
            // 
            nameVal_Lbl.AutoSize = true;
            nameVal_Lbl.Font = new Font("Segoe UI", 14.25F);
            nameVal_Lbl.ForeColor = Color.White;
            nameVal_Lbl.Location = new Point(172, 76);
            nameVal_Lbl.Name = "nameVal_Lbl";
            nameVal_Lbl.Size = new Size(88, 25);
            nameVal_Lbl.TabIndex = 12;
            nameVal_Lbl.Text = "NameVal";
            // 
            // password_Tb
            // 
            password_Tb.Location = new Point(279, 151);
            password_Tb.Name = "password_Tb";
            password_Tb.PasswordChar = '*';
            password_Tb.Size = new Size(295, 23);
            password_Tb.TabIndex = 14;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.ForeColor = Color.White;
            label6.Location = new Point(84, 76);
            label6.Name = "label6";
            label6.Size = new Size(69, 25);
            label6.TabIndex = 11;
            label6.Text = "Name:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.White;
            label4.Location = new Point(82, 151);
            label4.Name = "label4";
            label4.Size = new Size(102, 25);
            label4.TabIndex = 12;
            label4.Text = "Password:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.ForeColor = Color.White;
            label7.Location = new Point(82, 188);
            label7.Name = "label7";
            label7.Size = new Size(184, 25);
            label7.TabIndex = 13;
            label7.Text = "Re-Enter Password:";
            // 
            // panel1
            // 
            panel1.BackColor = Color.Gray;
            panel1.Controls.Add(panel3);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Padding = new Padding(7);
            panel1.Size = new Size(699, 452);
            panel1.TabIndex = 1;
            // 
            // ResetPassword
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(699, 452);
            Controls.Add(panel1);
            Name = "ResetPassword";
            Text = "ResetPassword";
            Load += ResetPassword_Load;
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel3.ResumeLayout(false);
            panel5.ResumeLayout(false);
            panel4.ResumeLayout(false);
            panel7.ResumeLayout(false);
            panel7.PerformLayout();
            panel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel2;
        private Label label3;
        private Panel panel3;
        private Panel panel5;
        private Button resetPassword_Btn;
        private Panel panel4;
        private Panel panel1;
        public Label userIDVal_Lbl;
        private Label label2;
        public Label nameVal_Lbl;
        private Label label6;
        private Panel panel7;
        private TextBox reEnterPassword_Tb;
        private TextBox password_Tb;
        private Label label4;
        private Label label7;
    }
}