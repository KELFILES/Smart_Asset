namespace Smart_Asset
{
    partial class Swap
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
            panel2 = new Panel();
            unit2_Cmb = new ComboBox();
            location2_Cmb = new ComboBox();
            label5 = new Label();
            label6 = new Label();
            unit_Cmb = new ComboBox();
            location_Cmb = new ComboBox();
            label3 = new Label();
            label4 = new Label();
            panel3 = new Panel();
            label2 = new Label();
            label1 = new Label();
            serialNo2 = new TextBox();
            serialNo1 = new TextBox();
            button1 = new Button();
            label7 = new Label();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.ActiveBorder;
            panel1.Controls.Add(panel2);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1125, 800);
            panel1.TabIndex = 0;
            // 
            // panel2
            // 
            panel2.Anchor = AnchorStyles.Top;
            panel2.BackColor = SystemColors.ButtonShadow;
            panel2.Controls.Add(unit2_Cmb);
            panel2.Controls.Add(location2_Cmb);
            panel2.Controls.Add(label5);
            panel2.Controls.Add(label6);
            panel2.Controls.Add(unit_Cmb);
            panel2.Controls.Add(location_Cmb);
            panel2.Controls.Add(label3);
            panel2.Controls.Add(label4);
            panel2.Controls.Add(panel3);
            panel2.Location = new Point(90, 75);
            panel2.Name = "panel2";
            panel2.Size = new Size(954, 641);
            panel2.TabIndex = 4;
            // 
            // unit2_Cmb
            // 
            unit2_Cmb.Anchor = AnchorStyles.Top;
            unit2_Cmb.AutoCompleteSource = AutoCompleteSource.CustomSource;
            unit2_Cmb.DropDownStyle = ComboBoxStyle.DropDownList;
            unit2_Cmb.FormattingEnabled = true;
            unit2_Cmb.Location = new Point(570, 107);
            unit2_Cmb.Name = "unit2_Cmb";
            unit2_Cmb.Size = new Size(242, 23);
            unit2_Cmb.TabIndex = 50;
            unit2_Cmb.DropDown += unit2_Cmb_DropDown;
            // 
            // location2_Cmb
            // 
            location2_Cmb.Anchor = AnchorStyles.Top;
            location2_Cmb.AutoCompleteSource = AutoCompleteSource.CustomSource;
            location2_Cmb.DropDownStyle = ComboBoxStyle.DropDownList;
            location2_Cmb.FormattingEnabled = true;
            location2_Cmb.Location = new Point(570, 77);
            location2_Cmb.Name = "location2_Cmb";
            location2_Cmb.Size = new Size(242, 23);
            location2_Cmb.TabIndex = 49;
            location2_Cmb.DropDown += location2_Cmb_DropDown;
            // 
            // label5
            // 
            label5.Anchor = AnchorStyles.Top;
            label5.AutoSize = true;
            label5.BackColor = SystemColors.ScrollBar;
            label5.Font = new Font("Segoe UI", 12F);
            label5.Location = new Point(482, 109);
            label5.Name = "label5";
            label5.Size = new Size(42, 21);
            label5.TabIndex = 48;
            label5.Text = "Unit:";
            // 
            // label6
            // 
            label6.Anchor = AnchorStyles.Top;
            label6.AutoSize = true;
            label6.BackColor = SystemColors.ScrollBar;
            label6.Font = new Font("Segoe UI", 12F);
            label6.Location = new Point(482, 79);
            label6.Name = "label6";
            label6.Size = new Size(72, 21);
            label6.TabIndex = 47;
            label6.Text = "Location:";
            // 
            // unit_Cmb
            // 
            unit_Cmb.Anchor = AnchorStyles.Top;
            unit_Cmb.AutoCompleteSource = AutoCompleteSource.CustomSource;
            unit_Cmb.DropDownStyle = ComboBoxStyle.DropDownList;
            unit_Cmb.FormattingEnabled = true;
            unit_Cmb.Location = new Point(213, 107);
            unit_Cmb.Name = "unit_Cmb";
            unit_Cmb.Size = new Size(242, 23);
            unit_Cmb.TabIndex = 46;
            unit_Cmb.DropDown += unit_Cmb_DropDown;
            // 
            // location_Cmb
            // 
            location_Cmb.Anchor = AnchorStyles.Top;
            location_Cmb.AutoCompleteSource = AutoCompleteSource.CustomSource;
            location_Cmb.DropDownStyle = ComboBoxStyle.DropDownList;
            location_Cmb.FormattingEnabled = true;
            location_Cmb.Location = new Point(213, 77);
            location_Cmb.Name = "location_Cmb";
            location_Cmb.Size = new Size(242, 23);
            location_Cmb.TabIndex = 45;
            location_Cmb.DropDown += location_Cmb_DropDown;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Top;
            label3.AutoSize = true;
            label3.BackColor = SystemColors.ScrollBar;
            label3.Font = new Font("Segoe UI", 12F);
            label3.Location = new Point(125, 109);
            label3.Name = "label3";
            label3.Size = new Size(42, 21);
            label3.TabIndex = 44;
            label3.Text = "Unit:";
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Top;
            label4.AutoSize = true;
            label4.BackColor = SystemColors.ScrollBar;
            label4.Font = new Font("Segoe UI", 12F);
            label4.Location = new Point(125, 79);
            label4.Name = "label4";
            label4.Size = new Size(72, 21);
            label4.TabIndex = 43;
            label4.Text = "Location:";
            // 
            // panel3
            // 
            panel3.Anchor = AnchorStyles.Top;
            panel3.BackColor = SystemColors.ScrollBar;
            panel3.Controls.Add(label7);
            panel3.Controls.Add(label2);
            panel3.Controls.Add(label1);
            panel3.Controls.Add(serialNo2);
            panel3.Controls.Add(serialNo1);
            panel3.Controls.Add(button1);
            panel3.Location = new Point(67, 26);
            panel3.Name = "panel3";
            panel3.Size = new Size(828, 234);
            panel3.TabIndex = 53;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top;
            label2.AutoSize = true;
            label2.BackColor = SystemColors.ScrollBar;
            label2.Font = new Font("Segoe UI", 12F);
            label2.Location = new Point(415, 112);
            label2.Name = "label2";
            label2.Size = new Size(82, 21);
            label2.TabIndex = 56;
            label2.Text = "SerialNo.2";
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top;
            label1.AutoSize = true;
            label1.BackColor = SystemColors.ScrollBar;
            label1.Font = new Font("Segoe UI", 12F);
            label1.Location = new Point(58, 110);
            label1.Name = "label1";
            label1.Size = new Size(82, 21);
            label1.TabIndex = 55;
            label1.Text = "SerialNo.1";
            // 
            // serialNo2
            // 
            serialNo2.Anchor = AnchorStyles.Top;
            serialNo2.Location = new Point(503, 110);
            serialNo2.Name = "serialNo2";
            serialNo2.Size = new Size(242, 23);
            serialNo2.TabIndex = 54;
            // 
            // serialNo1
            // 
            serialNo1.Anchor = AnchorStyles.Top;
            serialNo1.Location = new Point(146, 110);
            serialNo1.Name = "serialNo1";
            serialNo1.Size = new Size(242, 23);
            serialNo1.TabIndex = 53;
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.Top;
            button1.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.Location = new Point(312, 157);
            button1.Name = "button1";
            button1.Size = new Size(207, 48);
            button1.TabIndex = 13;
            button1.Text = "SWAP";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.ForeColor = Color.Red;
            label7.Location = new Point(58, 22);
            label7.Name = "label7";
            label7.Size = new Size(202, 15);
            label7.TabIndex = 57;
            label7.Text = "*Note: Swapping must be same type.";
            // 
            // Swap
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1125, 800);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Swap";
            Text = "Swap";
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Panel panel2;
        private Button button1;
        private ComboBox unit2_Cmb;
        private ComboBox location2_Cmb;
        private Label label5;
        private Label label6;
        private ComboBox unit_Cmb;
        private ComboBox location_Cmb;
        private Label label3;
        private Label label4;
        private Panel panel3;
        private Label label2;
        private Label label1;
        private TextBox serialNo2;
        private TextBox serialNo1;
        private Label label7;
    }
}