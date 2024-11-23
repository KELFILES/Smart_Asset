namespace Smart_Asset
{
    partial class RightClick_Replacement
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
            RetriveToReserved_Btn = new Button();
            refresh_Btn = new Button();
            dispose_Btn = new Button();
            hideTableColumn_Btn = new Button();
            SuspendLayout();
            // 
            // RetriveToReserved_Btn
            // 
            RetriveToReserved_Btn.Location = new Point(12, 49);
            RetriveToReserved_Btn.Name = "RetriveToReserved_Btn";
            RetriveToReserved_Btn.Size = new Size(172, 31);
            RetriveToReserved_Btn.TabIndex = 0;
            RetriveToReserved_Btn.Text = "Retrive to Reserved";
            RetriveToReserved_Btn.UseVisualStyleBackColor = true;
            RetriveToReserved_Btn.Click += markAsRepaired_Btn_Click;
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
            // dispose_Btn
            // 
            dispose_Btn.Location = new Point(9, 86);
            dispose_Btn.Name = "dispose_Btn";
            dispose_Btn.Size = new Size(172, 31);
            dispose_Btn.TabIndex = 2;
            dispose_Btn.Text = "Dispose";
            dispose_Btn.UseVisualStyleBackColor = true;
            dispose_Btn.Click += dispose_Btn_Click;
            // 
            // hideTableColumn_Btn
            // 
            hideTableColumn_Btn.Location = new Point(9, 123);
            hideTableColumn_Btn.Name = "hideTableColumn_Btn";
            hideTableColumn_Btn.Size = new Size(172, 31);
            hideTableColumn_Btn.TabIndex = 3;
            hideTableColumn_Btn.Text = "Hide Table Column";
            hideTableColumn_Btn.UseVisualStyleBackColor = true;
            hideTableColumn_Btn.Click += hideTableColumn_Btn_Click;
            // 
            // RightClick_Replacement
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(193, 262);
            Controls.Add(hideTableColumn_Btn);
            Controls.Add(dispose_Btn);
            Controls.Add(refresh_Btn);
            Controls.Add(RetriveToReserved_Btn);
            FormBorderStyle = FormBorderStyle.None;
            Name = "RightClick_Replacement";
            Text = "RightClick";
            Load += RightClick_RepairingHardwares_Load;
            ResumeLayout(false);
        }

        #endregion

        private Button RetriveToReserved_Btn;
        public Button refresh_Btn;
        private Button dispose_Btn;
        private Button hideTableColumn_Btn;
    }
}