namespace Smart_Asset
{
    partial class ShowImage
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
            panel3 = new Panel();
            pictureBox1 = new PictureBox();
            panel4 = new Panel();
            save_Btn = new Button();
            upload_Btn = new Button();
            panel1 = new Panel();
            panel2 = new Panel();
            serialNoValue_Lb = new Label();
            label1 = new Label();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel4.SuspendLayout();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // panel3
            // 
            panel3.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel3.AutoScroll = true;
            panel3.BackColor = Color.Gray;
            panel3.Controls.Add(pictureBox1);
            panel3.Location = new Point(20, 92);
            panel3.Name = "panel3";
            panel3.Padding = new Padding(20);
            panel3.Size = new Size(1160, 545);
            panel3.TabIndex = 11;
            // 
            // pictureBox1
            // 
            pictureBox1.Dock = DockStyle.Fill;
            pictureBox1.Location = new Point(20, 20);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(1120, 505);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 5;
            pictureBox1.TabStop = false;
            // 
            // panel4
            // 
            panel4.BackColor = Color.DimGray;
            panel4.Controls.Add(save_Btn);
            panel4.Controls.Add(upload_Btn);
            panel4.Dock = DockStyle.Bottom;
            panel4.Location = new Point(20, 637);
            panel4.Name = "panel4";
            panel4.Size = new Size(1160, 107);
            panel4.TabIndex = 12;
            // 
            // save_Btn
            // 
            save_Btn.Anchor = AnchorStyles.Top;
            save_Btn.FlatStyle = FlatStyle.Flat;
            save_Btn.Font = new Font("Verdana", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            save_Btn.ForeColor = Color.White;
            save_Btn.Location = new Point(600, 35);
            save_Btn.Name = "save_Btn";
            save_Btn.Size = new Size(132, 41);
            save_Btn.TabIndex = 7;
            save_Btn.Text = "Save";
            save_Btn.UseVisualStyleBackColor = true;
            save_Btn.Click += save_Btn_Click;
            // 
            // upload_Btn
            // 
            upload_Btn.Anchor = AnchorStyles.Top;
            upload_Btn.FlatStyle = FlatStyle.Flat;
            upload_Btn.Font = new Font("Verdana", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            upload_Btn.ForeColor = Color.White;
            upload_Btn.Location = new Point(462, 35);
            upload_Btn.Name = "upload_Btn";
            upload_Btn.Size = new Size(132, 41);
            upload_Btn.TabIndex = 6;
            upload_Btn.Text = "Upload";
            upload_Btn.UseVisualStyleBackColor = true;
            upload_Btn.Click += upload_Btn_Click;
            // 
            // panel1
            // 
            panel1.BackColor = Color.Black;
            panel1.Controls.Add(panel4);
            panel1.Controls.Add(panel2);
            panel1.Controls.Add(panel3);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Padding = new Padding(20);
            panel1.Size = new Size(1200, 764);
            panel1.TabIndex = 0;
            // 
            // panel2
            // 
            panel2.BackColor = Color.DimGray;
            panel2.Controls.Add(serialNoValue_Lb);
            panel2.Controls.Add(label1);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(20, 20);
            panel2.Name = "panel2";
            panel2.Size = new Size(1160, 72);
            panel2.TabIndex = 10;
            // 
            // serialNoValue_Lb
            // 
            serialNoValue_Lb.Anchor = AnchorStyles.Top;
            serialNoValue_Lb.AutoSize = true;
            serialNoValue_Lb.Font = new Font("Segoe UI", 14.25F);
            serialNoValue_Lb.ForeColor = Color.White;
            serialNoValue_Lb.Location = new Point(584, 24);
            serialNoValue_Lb.Name = "serialNoValue_Lb";
            serialNoValue_Lb.Size = new Size(92, 25);
            serialNoValue_Lb.TabIndex = 10;
            serialNoValue_Lb.Text = "00000000";
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top;
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14.25F);
            label1.ForeColor = Color.White;
            label1.Location = new Point(485, 24);
            label1.Name = "label1";
            label1.Size = new Size(93, 25);
            label1.TabIndex = 9;
            label1.Text = "Serial No:";
            // 
            // ShowImage
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1200, 764);
            Controls.Add(panel1);
            Name = "ShowImage";
            Text = "ShowImage";
            Load += ShowImage_Load;
            panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel4.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel3;
        private PictureBox pictureBox1;
        private Panel panel4;
        private Button save_Btn;
        private Button upload_Btn;
        private Panel panel1;
        private Panel panel2;
        private Label label1;
        public Label serialNoValue_Lb;
    }
}