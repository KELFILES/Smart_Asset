namespace Smart_Asset
{
    partial class RightClick_RepairingHardwares
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
            markAsRepaired_Btn = new Button();
            refresh_Btn = new Button();
            SuspendLayout();
            // 
            // markAsRepaired_Btn
            // 
            markAsRepaired_Btn.Location = new Point(12, 49);
            markAsRepaired_Btn.Name = "markAsRepaired_Btn";
            markAsRepaired_Btn.Size = new Size(172, 31);
            markAsRepaired_Btn.TabIndex = 0;
            markAsRepaired_Btn.Text = "Mark as Repaired";
            markAsRepaired_Btn.UseVisualStyleBackColor = true;
            markAsRepaired_Btn.Click += markAsRepaired_Btn_Click;
            // 
            // refresh_Btn
            // 
            refresh_Btn.Location = new Point(12, 12);
            refresh_Btn.Name = "refresh_Btn";
            refresh_Btn.Size = new Size(172, 31);
            refresh_Btn.TabIndex = 1;
            refresh_Btn.Text = "Refresh";
            refresh_Btn.UseVisualStyleBackColor = true;
            refresh_Btn.Click += refresh_Btn_Click;
            // 
            // RightClick_RepairingHardwares
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(193, 262);
            Controls.Add(refresh_Btn);
            Controls.Add(markAsRepaired_Btn);
            FormBorderStyle = FormBorderStyle.None;
            Name = "RightClick_RepairingHardwares";
            Text = "RightClick";
            ResumeLayout(false);
        }

        #endregion

        private Button markAsRepaired_Btn;
        public Button refresh_Btn;
    }
}