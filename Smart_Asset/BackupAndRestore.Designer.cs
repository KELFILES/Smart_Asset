namespace Smart_Asset
{
    partial class backupAndRestore
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
            panel5 = new Panel();
            systemBackup_Btn = new Button();
            panel2 = new Panel();
            systemRestore_Btn = new Button();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(0, 91, 143);
            panel1.Controls.Add(panel5);
            panel1.Controls.Add(panel2);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Padding = new Padding(15);
            panel1.Size = new Size(1904, 1041);
            panel1.TabIndex = 0;
            // 
            // panel5
            // 
            panel5.BackColor = Color.FromArgb(2, 119, 189);
            panel5.Dock = DockStyle.Fill;
            panel5.Location = new Point(15, 115);
            panel5.Name = "panel5";
            panel5.Padding = new Padding(10);
            panel5.Size = new Size(1874, 911);
            panel5.TabIndex = 1;
            // 
            // systemBackup_Btn
            // 
            systemBackup_Btn.Anchor = AnchorStyles.Right;
            systemBackup_Btn.BackColor = Color.White;
            systemBackup_Btn.FlatStyle = FlatStyle.Flat;
            systemBackup_Btn.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold);
            systemBackup_Btn.ForeColor = Color.FromArgb(2, 119, 189);
            systemBackup_Btn.Location = new Point(477, 28);
            systemBackup_Btn.Name = "systemBackup_Btn";
            systemBackup_Btn.Size = new Size(171, 43);
            systemBackup_Btn.TabIndex = 15;
            systemBackup_Btn.Text = "System Backup";
            systemBackup_Btn.UseVisualStyleBackColor = false;
            systemBackup_Btn.Click += systemBackup_Btn_Click;
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(2, 119, 189);
            panel2.Controls.Add(systemBackup_Btn);
            panel2.Controls.Add(systemRestore_Btn);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(15, 15);
            panel2.Name = "panel2";
            panel2.Size = new Size(1874, 100);
            panel2.TabIndex = 0;
            // 
            // systemRestore_Btn
            // 
            systemRestore_Btn.Anchor = AnchorStyles.Right;
            systemRestore_Btn.BackColor = Color.White;
            systemRestore_Btn.FlatStyle = FlatStyle.Flat;
            systemRestore_Btn.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            systemRestore_Btn.ForeColor = Color.FromArgb(2, 119, 189);
            systemRestore_Btn.Location = new Point(1239, 28);
            systemRestore_Btn.Name = "systemRestore_Btn";
            systemRestore_Btn.Size = new Size(171, 43);
            systemRestore_Btn.TabIndex = 14;
            systemRestore_Btn.Text = "System Restore";
            systemRestore_Btn.UseVisualStyleBackColor = false;
            systemRestore_Btn.Click += systemRestore_Btn_Click;
            // 
            // backupAndRestore
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1904, 1041);
            Controls.Add(panel1);
            Name = "backupAndRestore";
            Text = "BackupAndRestore";
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Panel panel5;
        private Panel panel2;
        private Button systemRestore_Btn;
        private Button systemBackup_Btn;
    }
}