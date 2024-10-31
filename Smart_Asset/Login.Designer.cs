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
            bgBox = new Panel();
            label1 = new Label();
            submit_Btn = new Button();
            forgotPassword_Lbl = new Label();
            password_Tb = new TextBox();
            username_Tb = new TextBox();
            password_Lbl = new Label();
            username_Lbl = new Label();
            panel1.SuspendLayout();
            bgBox.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(bgBox);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1109, 681);
            panel1.TabIndex = 7;
            // 
            // bgBox
            // 
            bgBox.Controls.Add(label1);
            bgBox.Controls.Add(submit_Btn);
            bgBox.Controls.Add(forgotPassword_Lbl);
            bgBox.Controls.Add(password_Tb);
            bgBox.Controls.Add(username_Tb);
            bgBox.Controls.Add(password_Lbl);
            bgBox.Controls.Add(username_Lbl);
            bgBox.Location = new Point(356, 267);
            bgBox.Name = "bgBox";
            bgBox.Size = new Size(406, 336);
            bgBox.TabIndex = 28;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.None;
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(95, 73);
            label1.Name = "label1";
            label1.Size = new Size(224, 21);
            label1.TabIndex = 33;
            label1.Text = "Enter Username and Password:";
            // 
            // submit_Btn
            // 
            submit_Btn.Anchor = AnchorStyles.None;
            submit_Btn.BackColor = Color.Transparent;
            submit_Btn.Cursor = Cursors.Hand;
            submit_Btn.FlatAppearance.MouseDownBackColor = Color.Red;
            submit_Btn.FlatAppearance.MouseOverBackColor = Color.DeepSkyBlue;
            submit_Btn.FlatStyle = FlatStyle.Flat;
            submit_Btn.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            submit_Btn.ForeColor = Color.White;
            submit_Btn.Location = new Point(160, 206);
            submit_Btn.Name = "submit_Btn";
            submit_Btn.Size = new Size(98, 36);
            submit_Btn.TabIndex = 32;
            submit_Btn.Text = "SUBMIT";
            submit_Btn.UseVisualStyleBackColor = false;
            submit_Btn.Click += submit_Btn_Click_1;
            submit_Btn.KeyDown += Login_KeyDown;
            // 
            // forgotPassword_Lbl
            // 
            forgotPassword_Lbl.Anchor = AnchorStyles.None;
            forgotPassword_Lbl.AutoSize = true;
            forgotPassword_Lbl.BackColor = Color.Transparent;
            forgotPassword_Lbl.Cursor = Cursors.Hand;
            forgotPassword_Lbl.FlatStyle = FlatStyle.Flat;
            forgotPassword_Lbl.Font = new Font("Segoe UI", 9F, FontStyle.Underline);
            forgotPassword_Lbl.ForeColor = Color.White;
            forgotPassword_Lbl.Location = new Point(160, 257);
            forgotPassword_Lbl.Name = "forgotPassword_Lbl";
            forgotPassword_Lbl.Size = new Size(101, 15);
            forgotPassword_Lbl.TabIndex = 31;
            forgotPassword_Lbl.Text = "Change Password";
            // 
            // password_Tb
            // 
            password_Tb.Anchor = AnchorStyles.None;
            password_Tb.Cursor = Cursors.IBeam;
            password_Tb.Location = new Point(115, 164);
            password_Tb.Name = "password_Tb";
            password_Tb.PasswordChar = '*';
            password_Tb.Size = new Size(224, 23);
            password_Tb.TabIndex = 30;
            password_Tb.KeyDown += password_Tb_KeyDown;
            // 
            // username_Tb
            // 
            username_Tb.Anchor = AnchorStyles.None;
            username_Tb.Cursor = Cursors.IBeam;
            username_Tb.Location = new Point(115, 128);
            username_Tb.Name = "username_Tb";
            username_Tb.Size = new Size(224, 23);
            username_Tb.TabIndex = 29;
            username_Tb.KeyDown += username_Tb_KeyDown;
            // 
            // password_Lbl
            // 
            password_Lbl.Anchor = AnchorStyles.None;
            password_Lbl.AutoSize = true;
            password_Lbl.BackColor = Color.Transparent;
            password_Lbl.ForeColor = Color.White;
            password_Lbl.Location = new Point(46, 167);
            password_Lbl.Name = "password_Lbl";
            password_Lbl.Size = new Size(60, 15);
            password_Lbl.TabIndex = 28;
            password_Lbl.Text = "Password:";
            // 
            // username_Lbl
            // 
            username_Lbl.Anchor = AnchorStyles.None;
            username_Lbl.AutoSize = true;
            username_Lbl.BackColor = Color.Transparent;
            username_Lbl.ForeColor = Color.White;
            username_Lbl.Location = new Point(46, 131);
            username_Lbl.Name = "username_Lbl";
            username_Lbl.Size = new Size(63, 15);
            username_Lbl.TabIndex = 27;
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
            Load += Login_Load;
            Shown += Login_Shown;
            KeyDown += Login_KeyDown;
            panel1.ResumeLayout(false);
            bgBox.ResumeLayout(false);
            bgBox.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private DoubleBufferedPanel panel1;
        private Panel bgBox;
        private Button submit_Btn;
        private TextBox password_Tb;
        private TextBox username_Tb;
        private Label password_Lbl;
        private Label username_Lbl;
        private Label label1;
        private Label forgotPassword_Lbl;
    }
}