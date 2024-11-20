namespace Smart_Asset
{
    partial class GenerateQR
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
            label4 = new Label();
            label3 = new Label();
            location_Cmb = new ComboBox();
            unit_Cmb = new ComboBox();
            button1 = new Button();
            button2 = new Button();
            label2 = new Label();
            qr2_pictureBox = new PictureBox();
            serial2_Cb = new ComboBox();
            button3 = new Button();
            generate_Btn = new Button();
            label10 = new Label();
            qr_pictureBox = new PictureBox();
            label12 = new Label();
            panel2 = new Panel();
            label1 = new Label();
            panel1.SuspendLayout();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)qr2_pictureBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)qr_pictureBox).BeginInit();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(254, 242, 0);
            panel1.Controls.Add(panel3);
            panel1.Controls.Add(panel2);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Padding = new Padding(10);
            panel1.Size = new Size(1200, 871);
            panel1.TabIndex = 0;
            // 
            // panel3
            // 
            panel3.AutoScroll = true;
            panel3.BackColor = Color.Gray;
            panel3.Controls.Add(label4);
            panel3.Controls.Add(label3);
            panel3.Controls.Add(location_Cmb);
            panel3.Controls.Add(unit_Cmb);
            panel3.Controls.Add(button1);
            panel3.Controls.Add(button2);
            panel3.Controls.Add(label2);
            panel3.Controls.Add(qr2_pictureBox);
            panel3.Controls.Add(serial2_Cb);
            panel3.Controls.Add(button3);
            panel3.Controls.Add(generate_Btn);
            panel3.Controls.Add(label10);
            panel3.Controls.Add(qr_pictureBox);
            panel3.Controls.Add(label12);
            panel3.Dock = DockStyle.Fill;
            panel3.Location = new Point(10, 130);
            panel3.Name = "panel3";
            panel3.Size = new Size(1180, 731);
            panel3.TabIndex = 55;
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.None;
            label4.AutoSize = true;
            label4.Font = new Font("Microsoft Sans Serif", 12.75F);
            label4.ForeColor = Color.White;
            label4.Location = new Point(229, 555);
            label4.Name = "label4";
            label4.Size = new Size(44, 20);
            label4.TabIndex = 37;
            label4.Text = "Unit:";
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.None;
            label3.AutoSize = true;
            label3.Font = new Font("Microsoft Sans Serif", 12.75F);
            label3.ForeColor = Color.White;
            label3.Location = new Point(229, 522);
            label3.Name = "label3";
            label3.Size = new Size(78, 20);
            label3.TabIndex = 36;
            label3.Text = "Location:";
            // 
            // location_Cmb
            // 
            location_Cmb.Anchor = AnchorStyles.Top;
            location_Cmb.AutoCompleteMode = AutoCompleteMode.Append;
            location_Cmb.AutoCompleteSource = AutoCompleteSource.ListItems;
            location_Cmb.DropDownHeight = 200;
            location_Cmb.DropDownStyle = ComboBoxStyle.DropDownList;
            location_Cmb.FormattingEnabled = true;
            location_Cmb.IntegralHeight = false;
            location_Cmb.Location = new Point(322, 519);
            location_Cmb.Name = "location_Cmb";
            location_Cmb.Size = new Size(303, 23);
            location_Cmb.TabIndex = 34;
            location_Cmb.DropDown += location_Cmb_DropDown;
            // 
            // unit_Cmb
            // 
            unit_Cmb.Anchor = AnchorStyles.Top;
            unit_Cmb.AutoCompleteMode = AutoCompleteMode.Append;
            unit_Cmb.AutoCompleteSource = AutoCompleteSource.ListItems;
            unit_Cmb.DropDownHeight = 200;
            unit_Cmb.DropDownStyle = ComboBoxStyle.DropDownList;
            unit_Cmb.FormattingEnabled = true;
            unit_Cmb.IntegralHeight = false;
            unit_Cmb.Location = new Point(322, 549);
            unit_Cmb.Name = "unit_Cmb";
            unit_Cmb.Size = new Size(303, 23);
            unit_Cmb.TabIndex = 35;
            unit_Cmb.DropDown += unit_Cmb_DropDown;
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.None;
            button1.Location = new Point(749, 679);
            button1.Name = "button1";
            button1.Size = new Size(82, 23);
            button1.TabIndex = 32;
            button1.Text = "SAVE";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click_1;
            // 
            // button2
            // 
            button2.Anchor = AnchorStyles.None;
            button2.Font = new Font("Segoe UI", 14F);
            button2.Location = new Point(406, 581);
            button2.Name = "button2";
            button2.Size = new Size(108, 36);
            button2.TabIndex = 31;
            button2.Text = "Generate";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.None;
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.White;
            label2.Location = new Point(229, 473);
            label2.Name = "label2";
            label2.Size = new Size(326, 30);
            label2.TabIndex = 28;
            label2.Text = "QR Code Generator for Serial No.:";
            // 
            // qr2_pictureBox
            // 
            qr2_pictureBox.Anchor = AnchorStyles.None;
            qr2_pictureBox.BackColor = Color.White;
            qr2_pictureBox.Location = new Point(664, 423);
            qr2_pictureBox.Name = "qr2_pictureBox";
            qr2_pictureBox.Size = new Size(250, 250);
            qr2_pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            qr2_pictureBox.TabIndex = 30;
            qr2_pictureBox.TabStop = false;
            // 
            // serial2_Cb
            // 
            serial2_Cb.Anchor = AnchorStyles.None;
            serial2_Cb.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            serial2_Cb.AutoCompleteSource = AutoCompleteSource.ListItems;
            serial2_Cb.FormattingEnabled = true;
            serial2_Cb.Location = new Point(322, 193);
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
            button3.Location = new Point(749, 334);
            button3.Name = "button3";
            button3.Size = new Size(82, 23);
            button3.TabIndex = 26;
            button3.Text = "SAVE";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // generate_Btn
            // 
            generate_Btn.Anchor = AnchorStyles.None;
            generate_Btn.Font = new Font("Segoe UI", 14F);
            generate_Btn.Location = new Point(406, 222);
            generate_Btn.Name = "generate_Btn";
            generate_Btn.Size = new Size(108, 36);
            generate_Btn.TabIndex = 25;
            generate_Btn.Text = "Generate";
            generate_Btn.UseVisualStyleBackColor = true;
            generate_Btn.Click += generate_Btn_Click;
            // 
            // label10
            // 
            label10.Anchor = AnchorStyles.None;
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label10.ForeColor = Color.White;
            label10.Location = new Point(229, 127);
            label10.Name = "label10";
            label10.Size = new Size(326, 30);
            label10.TabIndex = 22;
            label10.Text = "QR Code Generator for Serial No.:";
            // 
            // qr_pictureBox
            // 
            qr_pictureBox.Anchor = AnchorStyles.None;
            qr_pictureBox.BackColor = Color.White;
            qr_pictureBox.Location = new Point(664, 78);
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
            label12.Location = new Point(229, 196);
            label12.Name = "label12";
            label12.Size = new Size(87, 20);
            label12.TabIndex = 23;
            label12.Text = "Serial No.:";
            // 
            // panel2
            // 
            panel2.BackColor = Color.DarkGray;
            panel2.Controls.Add(label1);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(10, 10);
            panel2.Name = "panel2";
            panel2.Size = new Size(1180, 120);
            panel2.TabIndex = 0;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.None;
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 36F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.Black;
            label1.Location = new Point(356, 28);
            label1.Name = "label1";
            label1.Size = new Size(468, 65);
            label1.TabIndex = 24;
            label1.Text = "QR Code Generator:";
            // 
            // GenerateQR
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1200, 871);
            Controls.Add(panel1);
            Name = "GenerateQR";
            Text = "GenerateQR";
            Load += GenerateQR_Load;
            panel1.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)qr2_pictureBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)qr_pictureBox).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Panel panel3;
        private Label label12;
        private Panel panel2;
        private Button button1;
        private Button button2;
        private Label label2;
        private PictureBox qr2_pictureBox;
        private Label label1;
        private ComboBox serial2_Cb;
        private Button button3;
        private Button generate_Btn;
        private Label label10;
        private PictureBox qr_pictureBox;
        private Label label4;
        private Label label3;
        private ComboBox location_Cmb;
        private ComboBox unit_Cmb;
    }
}