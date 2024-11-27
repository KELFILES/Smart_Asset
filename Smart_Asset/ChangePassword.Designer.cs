namespace Smart_Asset
{
    partial class ChangePassword
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
            fileSystemWatcher1 = new FileSystemWatcher();
            panel1 = new Panel();
            change_Btn = new Button();
            repeatPassword_Tb = new TextBox();
            label3 = new Label();
            newPassword_Tb = new TextBox();
            label2 = new Label();
            currentPassword_Tb = new TextBox();
            label1 = new Label();
            username_Tb = new TextBox();
            Model_Lbl = new Label();
            topLabel_Lbl = new Label();
            ((System.ComponentModel.ISupportInitialize)fileSystemWatcher1).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // fileSystemWatcher1
            // 
            fileSystemWatcher1.EnableRaisingEvents = true;
            fileSystemWatcher1.SynchronizingObject = this;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(2, 119, 189);
            panel1.Controls.Add(change_Btn);
            panel1.Controls.Add(repeatPassword_Tb);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(newPassword_Tb);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(currentPassword_Tb);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(username_Tb);
            panel1.Controls.Add(Model_Lbl);
            panel1.Controls.Add(topLabel_Lbl);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(7, 7);
            panel1.Name = "panel1";
            panel1.Size = new Size(786, 436);
            panel1.TabIndex = 0;
            // 
            // change_Btn
            // 
            change_Btn.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Bold);
            change_Btn.ForeColor = Color.FromArgb(2, 119, 189);
            change_Btn.Location = new Point(368, 328);
            change_Btn.Name = "change_Btn";
            change_Btn.Size = new Size(134, 33);
            change_Btn.TabIndex = 70;
            change_Btn.Text = "CONFIRM";
            change_Btn.UseVisualStyleBackColor = true;
            change_Btn.Click += change_Btn_Click;
            // 
            // repeatPassword_Tb
            // 
            repeatPassword_Tb.Anchor = AnchorStyles.Top;
            repeatPassword_Tb.Font = new Font("Microsoft Sans Serif", 12.75F);
            repeatPassword_Tb.Location = new Point(262, 273);
            repeatPassword_Tb.Name = "repeatPassword_Tb";
            repeatPassword_Tb.PasswordChar = '*';
            repeatPassword_Tb.Size = new Size(388, 27);
            repeatPassword_Tb.TabIndex = 69;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Top;
            label3.AutoSize = true;
            label3.Font = new Font("Microsoft Sans Serif", 12.75F, FontStyle.Bold);
            label3.ForeColor = Color.White;
            label3.Location = new Point(94, 276);
            label3.Name = "label3";
            label3.Size = new Size(162, 20);
            label3.TabIndex = 68;
            label3.Text = "Repeat Password:";
            // 
            // newPassword_Tb
            // 
            newPassword_Tb.Anchor = AnchorStyles.Top;
            newPassword_Tb.Font = new Font("Microsoft Sans Serif", 12.75F);
            newPassword_Tb.Location = new Point(262, 229);
            newPassword_Tb.Name = "newPassword_Tb";
            newPassword_Tb.PasswordChar = '*';
            newPassword_Tb.Size = new Size(388, 27);
            newPassword_Tb.TabIndex = 67;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top;
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft Sans Serif", 12.75F, FontStyle.Bold);
            label2.ForeColor = Color.White;
            label2.Location = new Point(117, 232);
            label2.Name = "label2";
            label2.Size = new Size(139, 20);
            label2.TabIndex = 66;
            label2.Text = "New Password:";
            // 
            // currentPassword_Tb
            // 
            currentPassword_Tb.Anchor = AnchorStyles.Top;
            currentPassword_Tb.Font = new Font("Microsoft Sans Serif", 12.75F);
            currentPassword_Tb.Location = new Point(262, 186);
            currentPassword_Tb.Name = "currentPassword_Tb";
            currentPassword_Tb.PasswordChar = '*';
            currentPassword_Tb.Size = new Size(388, 27);
            currentPassword_Tb.TabIndex = 65;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top;
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 12.75F, FontStyle.Bold);
            label1.ForeColor = Color.White;
            label1.Location = new Point(91, 189);
            label1.Name = "label1";
            label1.Size = new Size(166, 20);
            label1.TabIndex = 64;
            label1.Text = "Current Password:";
            // 
            // username_Tb
            // 
            username_Tb.Anchor = AnchorStyles.Top;
            username_Tb.Font = new Font("Microsoft Sans Serif", 12.75F);
            username_Tb.Location = new Point(262, 143);
            username_Tb.Name = "username_Tb";
            username_Tb.Size = new Size(388, 27);
            username_Tb.TabIndex = 63;
            // 
            // Model_Lbl
            // 
            Model_Lbl.Anchor = AnchorStyles.Top;
            Model_Lbl.AutoSize = true;
            Model_Lbl.Font = new Font("Microsoft Sans Serif", 12.75F, FontStyle.Bold);
            Model_Lbl.ForeColor = Color.White;
            Model_Lbl.Location = new Point(156, 146);
            Model_Lbl.Name = "Model_Lbl";
            Model_Lbl.Size = new Size(100, 20);
            Model_Lbl.TabIndex = 62;
            Model_Lbl.Text = "Username:";
            // 
            // topLabel_Lbl
            // 
            topLabel_Lbl.AutoSize = true;
            topLabel_Lbl.Font = new Font("Segoe UI", 21.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            topLabel_Lbl.ForeColor = Color.White;
            topLabel_Lbl.Location = new Point(280, 59);
            topLabel_Lbl.Name = "topLabel_Lbl";
            topLabel_Lbl.Size = new Size(303, 40);
            topLabel_Lbl.TabIndex = 7;
            topLabel_Lbl.Text = "CHANGE PASSWORD";
            // 
            // ChangePassword
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(0, 91, 143);
            ClientSize = new Size(800, 450);
            Controls.Add(panel1);
            Name = "ChangePassword";
            Padding = new Padding(7);
            Text = "ChangePassword";
            ((System.ComponentModel.ISupportInitialize)fileSystemWatcher1).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private FileSystemWatcher fileSystemWatcher1;
        private Panel panel1;
        private Label topLabel_Lbl;
        private TextBox newPassword_Tb;
        private Label label2;
        private TextBox currentPassword_Tb;
        private Label label1;
        private TextBox username_Tb;
        private Label Model_Lbl;
        private Button change_Btn;
        private TextBox repeatPassword_Tb;
        private Label label3;
    }
}