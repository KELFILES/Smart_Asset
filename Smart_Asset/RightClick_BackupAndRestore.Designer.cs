namespace Smart_Asset
{
    partial class RightClick_BackupAndRestore
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
            Backup_Btn = new Button();
            button1 = new Button();
            SuspendLayout();
            // 
            // Backup_Btn
            // 
            Backup_Btn.Location = new Point(12, 12);
            Backup_Btn.Name = "Backup_Btn";
            Backup_Btn.Size = new Size(172, 31);
            Backup_Btn.TabIndex = 1;
            Backup_Btn.Text = "Backup Data";
            Backup_Btn.UseVisualStyleBackColor = true;
            Backup_Btn.Click += localBackup_Btn_Click;
            // 
            // button1
            // 
            button1.Location = new Point(9, 49);
            button1.Name = "button1";
            button1.Size = new Size(172, 31);
            button1.TabIndex = 2;
            button1.Text = "INVISIBLE";
            button1.UseVisualStyleBackColor = true;
            button1.Visible = false;
            button1.Click += button1_Click;
            // 
            // RightClick_BackupAndRestore
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(193, 262);
            Controls.Add(button1);
            Controls.Add(Backup_Btn);
            FormBorderStyle = FormBorderStyle.None;
            Name = "RightClick_BackupAndRestore";
            Text = "RightClick";
            ResumeLayout(false);
        }

        #endregion
        public Button Backup_Btn;
        public Button button1;
    }
}