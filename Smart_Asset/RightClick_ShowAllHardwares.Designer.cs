namespace Smart_Asset
{
    partial class RightClick_ShowAllHardwares
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
            refresh_Btn = new Button();
            edit_Btn = new Button();
            remove_Btn = new Button();
            SuspendLayout();
            // 
            // refresh_Btn
            // 
            refresh_Btn.Location = new Point(9, 12);
            refresh_Btn.Name = "refresh_Btn";
            refresh_Btn.Size = new Size(172, 31);
            refresh_Btn.TabIndex = 1;
            refresh_Btn.Text = "Refresh";
            refresh_Btn.UseVisualStyleBackColor = true;
            refresh_Btn.Click += refresh_Btn_Click;
            // 
            // edit_Btn
            // 
            edit_Btn.Location = new Point(9, 49);
            edit_Btn.Name = "edit_Btn";
            edit_Btn.Size = new Size(172, 31);
            edit_Btn.TabIndex = 2;
            edit_Btn.Text = "Edit";
            edit_Btn.UseVisualStyleBackColor = true;
            // 
            // remove_Btn
            // 
            remove_Btn.Location = new Point(9, 86);
            remove_Btn.Name = "remove_Btn";
            remove_Btn.Size = new Size(172, 31);
            remove_Btn.TabIndex = 3;
            remove_Btn.Text = "Archieve";
            remove_Btn.UseVisualStyleBackColor = true;
            // 
            // RightClick_ShowAllHardwares
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(193, 262);
            Controls.Add(remove_Btn);
            Controls.Add(edit_Btn);
            Controls.Add(refresh_Btn);
            FormBorderStyle = FormBorderStyle.None;
            Name = "RightClick_ShowAllHardwares";
            Text = "RightClick";
            ResumeLayout(false);
        }

        #endregion
        public Button refresh_Btn;
        public Button edit_Btn;
        public Button remove_Btn;
    }
}