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
            username_Lbl = new Label();
            password_Lbl = new Label();
            username_Tb = new TextBox();
            password_Tb = new TextBox();
            forgotPassword_Lbl = new Label();
            submit_Btn = new Button();
            manageUsers_Lbl = new Label();
            label1 = new Label();
            SuspendLayout();
            // 
            // username_Lbl
            // 
            username_Lbl.Anchor = AnchorStyles.None;
            username_Lbl.AutoSize = true;
            username_Lbl.Location = new Point(459, 482);
            username_Lbl.Name = "username_Lbl";
            username_Lbl.Size = new Size(63, 15);
            username_Lbl.TabIndex = 0;
            username_Lbl.Text = "Username:";
            // 
            // password_Lbl
            // 
            password_Lbl.Anchor = AnchorStyles.None;
            password_Lbl.AutoSize = true;
            password_Lbl.Location = new Point(459, 510);
            password_Lbl.Name = "password_Lbl";
            password_Lbl.Size = new Size(60, 15);
            password_Lbl.TabIndex = 1;
            password_Lbl.Text = "Password:";
            // 
            // username_Tb
            // 
            username_Tb.Anchor = AnchorStyles.None;
            username_Tb.Cursor = Cursors.IBeam;
            username_Tb.Location = new Point(528, 474);
            username_Tb.Name = "username_Tb";
            username_Tb.Size = new Size(100, 23);
            username_Tb.TabIndex = 2;
            // 
            // password_Tb
            // 
            password_Tb.Anchor = AnchorStyles.None;
            password_Tb.Cursor = Cursors.IBeam;
            password_Tb.Location = new Point(528, 510);
            password_Tb.Name = "password_Tb";
            password_Tb.Size = new Size(100, 23);
            password_Tb.TabIndex = 3;
            // 
            // forgotPassword_Lbl
            // 
            forgotPassword_Lbl.Anchor = AnchorStyles.None;
            forgotPassword_Lbl.AutoSize = true;
            forgotPassword_Lbl.Cursor = Cursors.Hand;
            forgotPassword_Lbl.Font = new Font("Segoe UI", 9F, FontStyle.Underline);
            forgotPassword_Lbl.Location = new Point(495, 597);
            forgotPassword_Lbl.Name = "forgotPassword_Lbl";
            forgotPassword_Lbl.Size = new Size(101, 15);
            forgotPassword_Lbl.TabIndex = 4;
            forgotPassword_Lbl.Text = "Change Password";
            // 
            // submit_Btn
            // 
            submit_Btn.Anchor = AnchorStyles.None;
            submit_Btn.Cursor = Cursors.Hand;
            submit_Btn.Location = new Point(511, 549);
            submit_Btn.Name = "submit_Btn";
            submit_Btn.Size = new Size(75, 23);
            submit_Btn.TabIndex = 5;
            submit_Btn.Text = "SUBMIT";
            submit_Btn.UseVisualStyleBackColor = true;
            submit_Btn.Click += submit_Btn_Click;
            // 
            // manageUsers_Lbl
            // 
            manageUsers_Lbl.Anchor = AnchorStyles.None;
            manageUsers_Lbl.AutoSize = true;
            manageUsers_Lbl.Cursor = Cursors.Hand;
            manageUsers_Lbl.Font = new Font("Segoe UI", 9F, FontStyle.Underline);
            manageUsers_Lbl.Location = new Point(505, 624);
            manageUsers_Lbl.Name = "manageUsers_Lbl";
            manageUsers_Lbl.Size = new Size(81, 15);
            manageUsers_Lbl.TabIndex = 6;
            manageUsers_Lbl.Text = "Manage Users";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(495, 225);
            label1.Name = "label1";
            label1.Size = new Size(122, 15);
            label1.TabIndex = 7;
            label1.Text = "Add background here";
            // 
            // Login
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1109, 681);
            Controls.Add(label1);
            Controls.Add(manageUsers_Lbl);
            Controls.Add(submit_Btn);
            Controls.Add(forgotPassword_Lbl);
            Controls.Add(password_Tb);
            Controls.Add(username_Tb);
            Controls.Add(password_Lbl);
            Controls.Add(username_Lbl);
            Name = "Login";
            Text = "Login";
            WindowState = FormWindowState.Maximized;
            FormClosed += Login_FormClosed;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label username_Lbl;
        private Label password_Lbl;
        private TextBox username_Tb;
        private TextBox password_Tb;
        private Label forgotPassword_Lbl;
        private Button submit_Btn;
        private Label manageUsers_Lbl;
        private Label label1;
    }
}