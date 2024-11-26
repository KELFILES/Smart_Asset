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
            panel1 = new Panel();
            panel3 = new Panel();
            label3 = new Label();
            label4 = new Label();
            pictureBox1 = new PictureBox();
            panel2 = new Panel();
            panel4 = new Panel();
            bgBox = new Panel();
            label2 = new Label();
            label1 = new Label();
            submit_Btn = new Button();
            forgotPassword_Lbl = new Label();
            password_Tb = new TextBox();
            username_Tb = new TextBox();
            password_Lbl = new Label();
            username_Lbl = new Label();
            panel1.SuspendLayout();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel2.SuspendLayout();
            panel4.SuspendLayout();
            bgBox.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(panel3);
            panel1.Controls.Add(panel2);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1904, 1041);
            panel1.TabIndex = 29;
            // 
            // panel3
            // 
            panel3.BackColor = Color.FromArgb(2, 119, 189);
            panel3.Controls.Add(label3);
            panel3.Controls.Add(label4);
            panel3.Controls.Add(pictureBox1);
            panel3.Dock = DockStyle.Fill;
            panel3.Location = new Point(0, 0);
            panel3.Name = "panel3";
            panel3.Size = new Size(822, 1041);
            panel3.TabIndex = 30;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Top;
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Arial Rounded MT Bold", 36F);
            label3.ForeColor = Color.White;
            label3.Location = new Point(208, 700);
            label3.Name = "label3";
            label3.Size = new Size(586, 55);
            label3.TabIndex = 36;
            label3.Text = "MANAGEMENT SYSTEM";
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Top;
            label4.AutoSize = true;
            label4.BackColor = Color.Transparent;
            label4.Font = new Font("Arial Rounded MT Bold", 36F);
            label4.ForeColor = Color.White;
            label4.Location = new Point(325, 638);
            label4.Name = "label4";
            label4.Size = new Size(369, 55);
            label4.TabIndex = 35;
            label4.Text = "SMART ASSET";
            // 
            // pictureBox1
            // 
            pictureBox1.Anchor = AnchorStyles.Top;
            pictureBox1.Image = Properties.Resources.frontPage_Logo2;
            pictureBox1.Location = new Point(310, 242);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(409, 352);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(2, 119, 189);
            panel2.Controls.Add(panel4);
            panel2.Dock = DockStyle.Right;
            panel2.Location = new Point(822, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(1082, 1041);
            panel2.TabIndex = 29;
            // 
            // panel4
            // 
            panel4.Anchor = AnchorStyles.Top;
            panel4.BackColor = Color.FromArgb(255, 242, 0);
            panel4.Controls.Add(bgBox);
            panel4.Location = new Point(252, 223);
            panel4.Name = "panel4";
            panel4.Padding = new Padding(10);
            panel4.Size = new Size(615, 629);
            panel4.TabIndex = 29;
            // 
            // bgBox
            // 
            bgBox.BackColor = Color.White;
            bgBox.Controls.Add(label2);
            bgBox.Controls.Add(label1);
            bgBox.Controls.Add(submit_Btn);
            bgBox.Controls.Add(forgotPassword_Lbl);
            bgBox.Controls.Add(password_Tb);
            bgBox.Controls.Add(username_Tb);
            bgBox.Controls.Add(password_Lbl);
            bgBox.Controls.Add(username_Lbl);
            bgBox.Dock = DockStyle.Fill;
            bgBox.Location = new Point(10, 10);
            bgBox.Name = "bgBox";
            bgBox.Size = new Size(595, 609);
            bgBox.TabIndex = 28;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.None;
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Arial Rounded MT Bold", 36F);
            label2.ForeColor = Color.FromArgb(2, 119, 189);
            label2.Location = new Point(78, 136);
            label2.Name = "label2";
            label2.Size = new Size(255, 55);
            label2.TabIndex = 34;
            label2.Text = "Welcome,";
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.None;
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Arial Rounded MT Bold", 36F);
            label1.ForeColor = Color.FromArgb(2, 119, 189);
            label1.Location = new Point(78, 70);
            label1.Name = "label1";
            label1.Size = new Size(89, 55);
            label1.TabIndex = 33;
            label1.Text = "Hi!";
            // 
            // submit_Btn
            // 
            submit_Btn.Anchor = AnchorStyles.None;
            submit_Btn.BackColor = Color.FromArgb(2, 119, 189);
            submit_Btn.Cursor = Cursors.Hand;
            submit_Btn.FlatAppearance.MouseDownBackColor = Color.Red;
            submit_Btn.FlatAppearance.MouseOverBackColor = Color.DeepSkyBlue;
            submit_Btn.FlatStyle = FlatStyle.Flat;
            submit_Btn.Font = new Font("Microsoft Sans Serif", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            submit_Btn.ForeColor = Color.White;
            submit_Btn.Location = new Point(193, 420);
            submit_Btn.Name = "submit_Btn";
            submit_Btn.Size = new Size(215, 45);
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
            forgotPassword_Lbl.Font = new Font("Segoe UI", 14.25F, FontStyle.Underline, GraphicsUnit.Point, 0);
            forgotPassword_Lbl.ForeColor = Color.Black;
            forgotPassword_Lbl.Location = new Point(366, 369);
            forgotPassword_Lbl.Name = "forgotPassword_Lbl";
            forgotPassword_Lbl.Size = new Size(161, 25);
            forgotPassword_Lbl.TabIndex = 31;
            forgotPassword_Lbl.Text = "Change Password";
            forgotPassword_Lbl.Click += forgotPassword_Lbl_Click;
            // 
            // password_Tb
            // 
            password_Tb.Anchor = AnchorStyles.None;
            password_Tb.BorderStyle = BorderStyle.FixedSingle;
            password_Tb.Cursor = Cursors.IBeam;
            password_Tb.Font = new Font("Segoe UI", 18F);
            password_Tb.ForeColor = Color.Black;
            password_Tb.Location = new Point(216, 311);
            password_Tb.Multiline = true;
            password_Tb.Name = "password_Tb";
            password_Tb.PasswordChar = '*';
            password_Tb.Size = new Size(311, 40);
            password_Tb.TabIndex = 30;
            password_Tb.KeyDown += password_Tb_KeyDown;
            // 
            // username_Tb
            // 
            username_Tb.Anchor = AnchorStyles.None;
            username_Tb.BorderStyle = BorderStyle.FixedSingle;
            username_Tb.Cursor = Cursors.IBeam;
            username_Tb.Font = new Font("Segoe UI", 18F);
            username_Tb.ForeColor = Color.Black;
            username_Tb.Location = new Point(216, 250);
            username_Tb.Multiline = true;
            username_Tb.Name = "username_Tb";
            username_Tb.Size = new Size(311, 40);
            username_Tb.TabIndex = 29;
            username_Tb.KeyDown += username_Tb_KeyDown;
            // 
            // password_Lbl
            // 
            password_Lbl.Anchor = AnchorStyles.None;
            password_Lbl.AutoSize = true;
            password_Lbl.BackColor = Color.Transparent;
            password_Lbl.Font = new Font("Microsoft Sans Serif", 24F, FontStyle.Bold);
            password_Lbl.ForeColor = Color.Black;
            password_Lbl.Location = new Point(38, 314);
            password_Lbl.Name = "password_Lbl";
            password_Lbl.Size = new Size(176, 37);
            password_Lbl.TabIndex = 28;
            password_Lbl.Text = "Password:";
            // 
            // username_Lbl
            // 
            username_Lbl.Anchor = AnchorStyles.None;
            username_Lbl.AutoSize = true;
            username_Lbl.BackColor = Color.Transparent;
            username_Lbl.Font = new Font("Microsoft Sans Serif", 24F, FontStyle.Bold);
            username_Lbl.ForeColor = Color.Black;
            username_Lbl.Location = new Point(28, 253);
            username_Lbl.Name = "username_Lbl";
            username_Lbl.Size = new Size(182, 37);
            username_Lbl.TabIndex = 27;
            username_Lbl.Text = "Username:";
            // 
            // Login
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1904, 1041);
            Controls.Add(panel1);
            Name = "Login";
            Text = "Login";
            WindowState = FormWindowState.Maximized;
            FormClosed += Login_FormClosed;
            Load += Login_Load;
            Shown += Login_Shown;
            KeyDown += Login_KeyDown;
            panel1.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel2.ResumeLayout(false);
            panel4.ResumeLayout(false);
            bgBox.ResumeLayout(false);
            bgBox.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Panel panel3;
        private Panel panel2;
        private Panel panel4;
        private Panel bgBox;
        private Button submit_Btn;
        private Label forgotPassword_Lbl;
        private TextBox password_Tb;
        private TextBox username_Tb;
        private Label password_Lbl;
        private Label username_Lbl;
        private Label label2;
        private Label label1;
        private Label label3;
        private Label label4;
        private PictureBox pictureBox1;
    }
}