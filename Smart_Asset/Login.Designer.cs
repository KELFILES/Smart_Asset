namespace Smart_Asset
{
    partial class Login
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
            panel1 = new DoubleBufferedPanel();
            manageUsers_Lbl = new Label();
            submit_Btn = new Button();
            forgotPassword_Lbl = new Label();
            password_Tb = new TextBox();
            username_Tb = new TextBox();
            password_Lbl = new Label();
            username_Lbl = new Label();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(manageUsers_Lbl);
            panel1.Controls.Add(submit_Btn);
            panel1.Controls.Add(forgotPassword_Lbl);
            panel1.Controls.Add(password_Tb);
            panel1.Controls.Add(username_Tb);
            panel1.Controls.Add(password_Lbl);
            panel1.Controls.Add(username_Lbl);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1109, 681);
            panel1.TabIndex = 7;
            // 
            // manageUsers_Lbl
            // 
            manageUsers_Lbl.Anchor = AnchorStyles.None;
            manageUsers_Lbl.AutoSize = true;
            manageUsers_Lbl.Cursor = Cursors.Hand;
            manageUsers_Lbl.Font = new Font("Segoe UI", 9F, FontStyle.Underline);
            manageUsers_Lbl.Location = new Point(491, 602);
            manageUsers_Lbl.Name = "manageUsers_Lbl";
            manageUsers_Lbl.Size = new Size(81, 15);
            manageUsers_Lbl.TabIndex = 13;
            manageUsers_Lbl.Text = "Manage Users";
            // 
            // submit_Btn
            // 
            submit_Btn.Anchor = AnchorStyles.None;
            submit_Btn.Cursor = Cursors.Hand;
            submit_Btn.Location = new Point(497, 527);
            submit_Btn.Name = "submit_Btn";
            submit_Btn.Size = new Size(75, 23);
            submit_Btn.TabIndex = 12;
            submit_Btn.Text = "SUBMIT";
            submit_Btn.UseVisualStyleBackColor = true;
            submit_Btn.Click += submit_Btn_Click_1;
            // 
            // forgotPassword_Lbl
            // 
            forgotPassword_Lbl.Anchor = AnchorStyles.None;
            forgotPassword_Lbl.AutoSize = true;
            forgotPassword_Lbl.Cursor = Cursors.Hand;
            forgotPassword_Lbl.Font = new Font("Segoe UI", 9F, FontStyle.Underline);
            forgotPassword_Lbl.Location = new Point(481, 575);
            forgotPassword_Lbl.Name = "forgotPassword_Lbl";
            forgotPassword_Lbl.Size = new Size(101, 15);
            forgotPassword_Lbl.TabIndex = 11;
            forgotPassword_Lbl.Text = "Change Password";
            // 
            // password_Tb
            // 
            password_Tb.Anchor = AnchorStyles.None;
            password_Tb.Cursor = Cursors.IBeam;
            password_Tb.Location = new Point(514, 488);
            password_Tb.Name = "password_Tb";
            password_Tb.Size = new Size(100, 23);
            password_Tb.TabIndex = 10;
            // 
            // username_Tb
            // 
            username_Tb.Anchor = AnchorStyles.None;
            username_Tb.Cursor = Cursors.IBeam;
            username_Tb.Location = new Point(514, 452);
            username_Tb.Name = "username_Tb";
            username_Tb.Size = new Size(100, 23);
            username_Tb.TabIndex = 9;
            // 
            // password_Lbl
            // 
            password_Lbl.Anchor = AnchorStyles.None;
            password_Lbl.AutoSize = true;
            password_Lbl.Location = new Point(445, 496);
            password_Lbl.Name = "password_Lbl";
            password_Lbl.Size = new Size(60, 15);
            password_Lbl.TabIndex = 8;
            password_Lbl.Text = "Password:";
            // 
            // username_Lbl
            // 
            username_Lbl.Anchor = AnchorStyles.None;
            username_Lbl.AutoSize = true;
            username_Lbl.Location = new Point(445, 460);
            username_Lbl.Name = "username_Lbl";
            username_Lbl.Size = new Size(63, 15);
            username_Lbl.TabIndex = 7;
            username_Lbl.Text = "Username:";
            // 
            // Login
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1109, 681);
            Controls.Add(panel1);
            Name = "Login";
            Text = "Login";
            WindowState = FormWindowState.Maximized;
            FormClosed += Login_FormClosed;
            Shown += Login_Shown;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private DoubleBufferedPanel panel1;
        private Label manageUsers_Lbl;
        private Button submit_Btn;
        private Label forgotPassword_Lbl;
        private TextBox password_Tb;
        private TextBox username_Tb;
        private Label password_Lbl;
        private Label username_Lbl;
    }
}