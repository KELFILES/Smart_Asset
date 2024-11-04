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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Startup));
            panel1 = new Panel();
            pictureBox1 = new PictureBox();
            start_Btn = new Button();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(pictureBox1);
            panel1.Controls.Add(start_Btn);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1109, 681);
            panel1.TabIndex = 0;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.Transparent;
            pictureBox1.BackgroundImageLayout = ImageLayout.None;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(332, 67);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(453, 308);
            pictureBox1.SizeMode = PictureBoxSizeMode.CenterImage;
            pictureBox1.TabIndex = 5;
            pictureBox1.TabStop = false;
            // 
            // start_Btn
            // 
            start_Btn.Anchor = AnchorStyles.None;
            start_Btn.BackColor = Color.Transparent;
            start_Btn.Cursor = Cursors.Hand;
            start_Btn.FlatAppearance.MouseDownBackColor = Color.OrangeRed;
            start_Btn.FlatAppearance.MouseOverBackColor = Color.DeepSkyBlue;
            start_Btn.FlatStyle = FlatStyle.Flat;
            start_Btn.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            start_Btn.ForeColor = Color.White;
            start_Btn.Location = new Point(488, 511);
            start_Btn.Name = "start_Btn";
            start_Btn.Size = new Size(135, 46);
            start_Btn.TabIndex = 3;
            start_Btn.Text = "START";
            start_Btn.UseVisualStyleBackColor = false;
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
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Button start_Btn;
        private PictureBox pictureBox1;
    }
}
