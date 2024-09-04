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
            panel1 = new Panel();
            title_Lbl = new Label();
            start_Btn = new Button();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(title_Lbl);
            panel1.Controls.Add(start_Btn);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1109, 681);
            panel1.TabIndex = 0;
            // 
            // title_Lbl
            // 
            title_Lbl.Anchor = AnchorStyles.None;
            title_Lbl.AutoSize = true;
            title_Lbl.Font = new Font("Segoe UI", 24F, FontStyle.Regular, GraphicsUnit.Point, 0);
            title_Lbl.Location = new Point(189, 120);
            title_Lbl.Name = "title_Lbl";
            title_Lbl.Size = new Size(730, 45);
            title_Lbl.TabIndex = 4;
            title_Lbl.Text = "SMART ASSET MANAGEMENT - STI MUNOZ EDSA";
            // 
            // start_Btn
            // 
            start_Btn.Anchor = AnchorStyles.None;
            start_Btn.Cursor = Cursors.Hand;
            start_Btn.Location = new Point(461, 515);
            start_Btn.Name = "start_Btn";
            start_Btn.Size = new Size(135, 46);
            start_Btn.TabIndex = 3;
            start_Btn.Text = "START";
            start_Btn.UseVisualStyleBackColor = true;
            start_Btn.Click += start_Btn_Click_1;
            // 
            // Startup
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1109, 681);
            Controls.Add(panel1);
            Name = "Startup";
            StartPosition = FormStartPosition.CenterScreen;
            TopMost = true;
            Load += Form1_Load;
            Shown += Startup_Shown;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label title_Lbl;
        private Button start_Btn;
    }
}
