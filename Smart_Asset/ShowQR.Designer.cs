namespace Smart_Asset
{
    partial class ShowQR
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
            panel1 = new Panel();
            panel3 = new Panel();
            serial2_Cb = new ComboBox();
            button3 = new Button();
            qr_pictureBox = new PictureBox();
            label12 = new Label();
            panel1.SuspendLayout();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)qr_pictureBox).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(254, 242, 0);
            panel1.Controls.Add(panel3);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Padding = new Padding(10);
            panel1.Size = new Size(380, 408);
            panel1.TabIndex = 0;
            // 
            // panel3
            // 
            panel3.AutoScroll = true;
            panel3.BackColor = Color.Gray;
            panel3.Controls.Add(serial2_Cb);
            panel3.Controls.Add(button3);
            panel3.Controls.Add(qr_pictureBox);
            panel3.Controls.Add(label12);
            panel3.Dock = DockStyle.Fill;
            panel3.Location = new Point(10, 10);
            panel3.Name = "panel3";
            panel3.Size = new Size(360, 388);
            panel3.TabIndex = 55;
            // 
            // serial2_Cb
            // 
            serial2_Cb.Anchor = AnchorStyles.None;
            serial2_Cb.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            serial2_Cb.AutoCompleteSource = AutoCompleteSource.ListItems;
            serial2_Cb.FormattingEnabled = true;
            serial2_Cb.Location = new Point(33, 47);
            serial2_Cb.Name = "serial2_Cb";
            serial2_Cb.Size = new Size(303, 23);
            serial2_Cb.TabIndex = 27;
            serial2_Cb.Enter += serial2_Cb_Enter;
            serial2_Cb.KeyPress += serial2_Cb_KeyPress;
            serial2_Cb.MouseEnter += serial2_Cb_MouseEnter;
            // 
            // button3
            // 
            button3.Anchor = AnchorStyles.None;
            button3.Location = new Point(140, 343);
            button3.Name = "button3";
            button3.Size = new Size(82, 23);
            button3.TabIndex = 26;
            button3.Text = "SAVE";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // qr_pictureBox
            // 
            qr_pictureBox.Anchor = AnchorStyles.None;
            qr_pictureBox.BackColor = Color.White;
            qr_pictureBox.Location = new Point(55, 87);
            qr_pictureBox.Name = "qr_pictureBox";
            qr_pictureBox.Size = new Size(250, 250);
            qr_pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            qr_pictureBox.TabIndex = 24;
            qr_pictureBox.TabStop = false;
            // 
            // label12
            // 
            label12.Anchor = AnchorStyles.None;
            label12.AutoSize = true;
            label12.Font = new Font("Microsoft Sans Serif", 12.75F);
            label12.ForeColor = Color.White;
            label12.Location = new Point(140, 24);
            label12.Name = "label12";
            label12.Size = new Size(87, 20);
            label12.TabIndex = 23;
            label12.Text = "Serial No.:";
            // 
            // ShowQR
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(380, 408);
            Controls.Add(panel1);
            Name = "ShowQR";
            Text = "ShowQR";
            Load += GenerateQR_Load;
            panel1.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)qr_pictureBox).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Panel panel3;
        private Label label12;
        private Button button3;
        private PictureBox qr_pictureBox;
        public ComboBox serial2_Cb;
    }
}