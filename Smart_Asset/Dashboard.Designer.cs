namespace Smart_Asset
{
    partial class Dashboard
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
            panel6 = new Panel();
            panel1 = new Panel();
            panel7 = new Panel();
            panel5 = new Panel();
            panel8 = new Panel();
            panel4 = new Panel();
            panel1.SuspendLayout();
            panel8.SuspendLayout();
            SuspendLayout();
            // 
            // panel6
            // 
            panel6.BackColor = Color.FromArgb(10, 19, 45);
            panel6.Dock = DockStyle.Right;
            panel6.Location = new Point(779, 7);
            panel6.Name = "panel6";
            panel6.Size = new Size(694, 453);
            panel6.TabIndex = 4;
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel1.BackColor = Color.FromArgb(184, 59, 255);
            panel1.Controls.Add(panel7);
            panel1.Controls.Add(panel5);
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Padding = new Padding(7);
            panel1.Size = new Size(1480, 444);
            panel1.TabIndex = 6;
            // 
            // panel7
            // 
            panel7.BackColor = Color.FromArgb(10, 19, 45);
            panel7.Dock = DockStyle.Fill;
            panel7.Location = new Point(7, 7);
            panel7.Name = "panel7";
            panel7.Size = new Size(772, 430);
            panel7.TabIndex = 12;
            // 
            // panel5
            // 
            panel5.BackColor = Color.FromArgb(10, 19, 45);
            panel5.Dock = DockStyle.Right;
            panel5.Location = new Point(779, 7);
            panel5.Name = "panel5";
            panel5.Size = new Size(694, 430);
            panel5.TabIndex = 3;
            // 
            // panel8
            // 
            panel8.BackColor = Color.FromArgb(255, 183, 0);
            panel8.Controls.Add(panel4);
            panel8.Controls.Add(panel6);
            panel8.Dock = DockStyle.Bottom;
            panel8.Location = new Point(0, 450);
            panel8.Name = "panel8";
            panel8.Padding = new Padding(7);
            panel8.Size = new Size(1480, 467);
            panel8.TabIndex = 7;
            // 
            // panel4
            // 
            panel4.BackColor = Color.FromArgb(10, 19, 45);
            panel4.Dock = DockStyle.Fill;
            panel4.Location = new Point(7, 7);
            panel4.Name = "panel4";
            panel4.Size = new Size(772, 453);
            panel4.TabIndex = 2;
            // 
            // Dashboard
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(10, 19, 45);
            ClientSize = new Size(1480, 917);
            Controls.Add(panel8);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Dashboard";
            Text = "Dashboard";
            Load += Dashboard_Load;
            Shown += Dashboard_Shown;
            panel1.ResumeLayout(false);
            panel8.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private Panel panel6;
        private Panel panel1;
        private Panel panel8;
        private Panel panel7;
        private Panel panel5;
        private Panel panel4;
    }
}