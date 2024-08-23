namespace Smart_Asset
{
    partial class Startup
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            start_Btn = new Button();
            label1 = new Label();
            label2 = new Label();
            SuspendLayout();
            // 
            // start_Btn
            // 
            start_Btn.Anchor = AnchorStyles.None;
            start_Btn.Cursor = Cursors.Hand;
            start_Btn.Location = new Point(477, 564);
            start_Btn.Name = "start_Btn";
            start_Btn.Size = new Size(135, 46);
            start_Btn.TabIndex = 0;
            start_Btn.Text = "START";
            start_Btn.UseVisualStyleBackColor = true;
            start_Btn.Click += start_Btn_Click;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.None;
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 24F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(205, 169);
            label1.Name = "label1";
            label1.Size = new Size(730, 45);
            label1.TabIndex = 1;
            label1.Text = "SMART ASSET MANAGEMENT - STI MUNOZ EDSA";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(430, 348);
            label2.Name = "label2";
            label2.Size = new Size(220, 15);
            label2.TabIndex = 2;
            label2.Text = "ADD BACKGROUND PHOTO OF STI HERE";
            // 
            // Startup
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1109, 681);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(start_Btn);
            Name = "Startup";
            StartPosition = FormStartPosition.CenterScreen;
            TopMost = true;
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button start_Btn;
        private Label label1;
        private Label label2;
    }
}
