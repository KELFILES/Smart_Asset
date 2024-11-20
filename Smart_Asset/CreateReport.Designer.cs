namespace Smart_Asset
{
    partial class CreateReport
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
            panel5 = new Panel();
            mainboard_Tb = new TextBox();
            panel4 = new Panel();
            exportTo_Cb = new ComboBox();
            exportTo_Lbl = new Label();
            export_Btn = new Button();
            panel2 = new Panel();
            topText_Lbl = new Label();
            panel1.SuspendLayout();
            panel3.SuspendLayout();
            panel5.SuspendLayout();
            panel4.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(4, 9, 64);
            panel1.Controls.Add(panel3);
            panel1.Controls.Add(panel4);
            panel1.Controls.Add(panel2);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Padding = new Padding(7);
            panel1.Size = new Size(1904, 1041);
            panel1.TabIndex = 1;
            // 
            // panel3
            // 
            panel3.Controls.Add(panel5);
            panel3.Dock = DockStyle.Fill;
            panel3.Location = new Point(7, 71);
            panel3.Name = "panel3";
            panel3.Padding = new Padding(30);
            panel3.Size = new Size(1890, 822);
            panel3.TabIndex = 3;
            // 
            // panel5
            // 
            panel5.BackColor = Color.FromArgb(255, 243, 26);
            panel5.Controls.Add(mainboard_Tb);
            panel5.Dock = DockStyle.Fill;
            panel5.Location = new Point(30, 30);
            panel5.Name = "panel5";
            panel5.Padding = new Padding(7);
            panel5.Size = new Size(1830, 762);
            panel5.TabIndex = 0;
            // 
            // mainboard_Tb
            // 
            mainboard_Tb.BorderStyle = BorderStyle.None;
            mainboard_Tb.Dock = DockStyle.Fill;
            mainboard_Tb.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            mainboard_Tb.Location = new Point(7, 7);
            mainboard_Tb.Multiline = true;
            mainboard_Tb.Name = "mainboard_Tb";
            mainboard_Tb.ReadOnly = true;
            mainboard_Tb.ScrollBars = ScrollBars.Both;
            mainboard_Tb.Size = new Size(1816, 748);
            mainboard_Tb.TabIndex = 13;
            // 
            // panel4
            // 
            panel4.Controls.Add(exportTo_Cb);
            panel4.Controls.Add(exportTo_Lbl);
            panel4.Controls.Add(export_Btn);
            panel4.Dock = DockStyle.Bottom;
            panel4.Location = new Point(7, 893);
            panel4.Name = "panel4";
            panel4.Size = new Size(1890, 141);
            panel4.TabIndex = 2;
            // 
            // exportTo_Cb
            // 
            exportTo_Cb.Anchor = AnchorStyles.Top;
            exportTo_Cb.DropDownStyle = ComboBoxStyle.DropDownList;
            exportTo_Cb.FlatStyle = FlatStyle.Flat;
            exportTo_Cb.FormattingEnabled = true;
            exportTo_Cb.Items.AddRange(new object[] { "Microsoft Word File (.docx)", "PDF File (.pdf)" });
            exportTo_Cb.Location = new Point(836, 53);
            exportTo_Cb.Name = "exportTo_Cb";
            exportTo_Cb.Size = new Size(294, 23);
            exportTo_Cb.TabIndex = 15;
            exportTo_Cb.Tag = "";
            // 
            // exportTo_Lbl
            // 
            exportTo_Lbl.Anchor = AnchorStyles.Top;
            exportTo_Lbl.AutoSize = true;
            exportTo_Lbl.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            exportTo_Lbl.ForeColor = Color.White;
            exportTo_Lbl.Location = new Point(929, 18);
            exportTo_Lbl.Name = "exportTo_Lbl";
            exportTo_Lbl.Size = new Size(104, 30);
            exportTo_Lbl.TabIndex = 13;
            exportTo_Lbl.Text = "Export To:";
            // 
            // export_Btn
            // 
            export_Btn.Anchor = AnchorStyles.Top;
            export_Btn.BackColor = Color.SteelBlue;
            export_Btn.FlatAppearance.BorderColor = Color.FromArgb(255, 255, 128);
            export_Btn.FlatAppearance.MouseDownBackColor = Color.Red;
            export_Btn.FlatAppearance.MouseOverBackColor = Color.Lime;
            export_Btn.FlatStyle = FlatStyle.Flat;
            export_Btn.ForeColor = Color.White;
            export_Btn.Location = new Point(938, 82);
            export_Btn.Name = "export_Btn";
            export_Btn.Size = new Size(88, 31);
            export_Btn.TabIndex = 14;
            export_Btn.Text = "EXPORT";
            export_Btn.UseVisualStyleBackColor = false;
            export_Btn.Click += export_Btn_Click;
            // 
            // panel2
            // 
            panel2.Controls.Add(topText_Lbl);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(7, 7);
            panel2.Name = "panel2";
            panel2.Size = new Size(1890, 64);
            panel2.TabIndex = 0;
            // 
            // topText_Lbl
            // 
            topText_Lbl.AutoSize = true;
            topText_Lbl.Font = new Font("Segoe UI Semibold", 21.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            topText_Lbl.ForeColor = Color.White;
            topText_Lbl.Location = new Point(895, 11);
            topText_Lbl.Name = "topText_Lbl";
            topText_Lbl.Size = new Size(138, 40);
            topText_Lbl.TabIndex = 0;
            topText_Lbl.Text = "REPORTS";
            // 
            // CreateReport
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1904, 1041);
            Controls.Add(panel1);
            Name = "CreateReport";
            Text = "CreateReport";
            Load += CreateReport_Load;
            SizeChanged += CreateReport_SizeChanged;
            panel1.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Panel panel3;
        private Panel panel4;
        private ComboBox exportTo_Cb;
        private Label exportTo_Lbl;
        private Button export_Btn;
        private Panel panel2;
        private Label topText_Lbl;
        private Panel panel5;
        private TextBox mainboard_Tb;
    }
}