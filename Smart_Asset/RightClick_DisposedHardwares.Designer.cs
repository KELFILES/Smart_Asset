namespace Smart_Asset
{
    partial class RightClick_DisposedHardwares
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
            markAs_Btn = new Button();
            refresh_Btn = new Button();
            SuspendLayout();
            // 
            // markAs_Btn
            // 
            markAs_Btn.Location = new Point(12, 49);
            markAs_Btn.Name = "markAs_Btn";
            markAs_Btn.Size = new Size(172, 31);
            markAs_Btn.TabIndex = 0;
            markAs_Btn.Text = "Mark as";
            markAs_Btn.UseVisualStyleBackColor = true;
            markAs_Btn.Click += markAsRepaired_Btn_Click;
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
            // RightClick_DisposedHardwares
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(193, 262);
            Controls.Add(refresh_Btn);
            Controls.Add(markAs_Btn);
            FormBorderStyle = FormBorderStyle.None;
            Name = "RightClick_DisposedHardwares";
            Text = "RightClick";
            Load += RightClick_DisposedHardwares_Load;
            ResumeLayout(false);
        }

        #endregion

        private Button markAs_Btn;
        public Button refresh_Btn;
    }
}