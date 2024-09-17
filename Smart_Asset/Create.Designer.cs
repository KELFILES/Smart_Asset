namespace Smart_Asset
{
    partial class Create
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
            panel2 = new Panel();
            panel1 = new Panel();
            panel3 = new Panel();
            serial2_Tb = new TextBox();
            button3 = new Button();
            generate_Btn = new Button();
            label10 = new Label();
            qr_pictureBox = new PictureBox();
            label12 = new Label();
            panel4 = new Panel();
            Clear_Btn = new Button();
            register_Btn = new Button();
            autoFill_checkBox = new CheckBox();
            purchaseDate_Dtp = new DateTimePicker();
            supplier_Tb = new TextBox();
            days_numericUpDown = new NumericUpDown();
            months_numericUpDown = new NumericUpDown();
            years_numericUpDown = new NumericUpDown();
            cost_Tb = new TextBox();
            serial_Tb = new TextBox();
            model_Tb = new TextBox();
            type_Cmb = new ComboBox();
            add_Btn = new Button();
            label15 = new Label();
            label14 = new Label();
            label13 = new Label();
            PurchaseDate_Lbl = new Label();
            Supplier_Lbl = new Label();
            Warranty_Lbl = new Label();
            Cost_Lbl = new Label();
            Serial_Lbl = new Label();
            Model_Lbl = new Label();
            type_Lbl = new Label();
            panel5 = new Panel();
            label1 = new Label();
            autoFill_Cb = new CheckBox();
            clear2_Btn = new Button();
            panel2.SuspendLayout();
            panel1.SuspendLayout();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)qr_pictureBox).BeginInit();
            panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)days_numericUpDown).BeginInit();
            ((System.ComponentModel.ISupportInitialize)months_numericUpDown).BeginInit();
            ((System.ComponentModel.ISupportInitialize)years_numericUpDown).BeginInit();
            panel5.SuspendLayout();
            SuspendLayout();
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(10, 18, 45);
            panel2.BorderStyle = BorderStyle.FixedSingle;
            panel2.Controls.Add(panel1);
            panel2.Controls.Add(panel5);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Padding = new Padding(8);
            panel2.Size = new Size(1584, 861);
            panel2.TabIndex = 3;
            // 
            // panel1
            // 
            panel1.Controls.Add(panel3);
            panel1.Controls.Add(panel4);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(8, 48);
            panel1.Name = "panel1";
            panel1.Size = new Size(1566, 803);
            panel1.TabIndex = 53;
            // 
            // panel3
            // 
            panel3.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel3.AutoScroll = true;
            panel3.BackColor = Color.DimGray;
            panel3.Controls.Add(serial2_Tb);
            panel3.Controls.Add(button3);
            panel3.Controls.Add(generate_Btn);
            panel3.Controls.Add(label10);
            panel3.Controls.Add(qr_pictureBox);
            panel3.Controls.Add(label12);
            panel3.Location = new Point(0, 405);
            panel3.Name = "panel3";
            panel3.Size = new Size(1566, 398);
            panel3.TabIndex = 53;
            // 
            // serial2_Tb
            // 
            serial2_Tb.Anchor = AnchorStyles.None;
            serial2_Tb.Font = new Font("Microsoft Sans Serif", 12.75F);
            serial2_Tb.Location = new Point(534, 157);
            serial2_Tb.Name = "serial2_Tb";
            serial2_Tb.Size = new Size(319, 27);
            serial2_Tb.TabIndex = 27;
            // 
            // button3
            // 
            button3.Anchor = AnchorStyles.None;
            button3.Location = new Point(961, 316);
            button3.Name = "button3";
            button3.Size = new Size(82, 23);
            button3.TabIndex = 26;
            button3.Text = "SAVE";
            button3.UseVisualStyleBackColor = true;
            // 
            // generate_Btn
            // 
            generate_Btn.Anchor = AnchorStyles.None;
            generate_Btn.Font = new Font("Segoe UI", 14F);
            generate_Btn.Location = new Point(618, 200);
            generate_Btn.Name = "generate_Btn";
            generate_Btn.Size = new Size(108, 36);
            generate_Btn.TabIndex = 25;
            generate_Btn.Text = "Generate";
            generate_Btn.UseVisualStyleBackColor = true;
            // 
            // label10
            // 
            label10.Anchor = AnchorStyles.None;
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label10.ForeColor = Color.White;
            label10.Location = new Point(441, 91);
            label10.Name = "label10";
            label10.Size = new Size(199, 30);
            label10.TabIndex = 22;
            label10.Text = "QR Code Generator:";
            // 
            // qr_pictureBox
            // 
            qr_pictureBox.Anchor = AnchorStyles.None;
            qr_pictureBox.BackColor = Color.White;
            qr_pictureBox.Location = new Point(876, 60);
            qr_pictureBox.Name = "qr_pictureBox";
            qr_pictureBox.Size = new Size(250, 250);
            qr_pictureBox.TabIndex = 24;
            qr_pictureBox.TabStop = false;
            // 
            // label12
            // 
            label12.Anchor = AnchorStyles.None;
            label12.AutoSize = true;
            label12.Font = new Font("Microsoft Sans Serif", 12.75F);
            label12.ForeColor = Color.White;
            label12.Location = new Point(441, 160);
            label12.Name = "label12";
            label12.Size = new Size(87, 20);
            label12.TabIndex = 23;
            label12.Text = "Serial No.:";
            // 
            // panel4
            // 
            panel4.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel4.AutoScroll = true;
            panel4.BackColor = Color.DarkGray;
            panel4.Controls.Add(clear2_Btn);
            panel4.Controls.Add(autoFill_Cb);
            panel4.Controls.Add(Clear_Btn);
            panel4.Controls.Add(register_Btn);
            panel4.Controls.Add(autoFill_checkBox);
            panel4.Controls.Add(purchaseDate_Dtp);
            panel4.Controls.Add(supplier_Tb);
            panel4.Controls.Add(days_numericUpDown);
            panel4.Controls.Add(months_numericUpDown);
            panel4.Controls.Add(years_numericUpDown);
            panel4.Controls.Add(cost_Tb);
            panel4.Controls.Add(serial_Tb);
            panel4.Controls.Add(model_Tb);
            panel4.Controls.Add(type_Cmb);
            panel4.Controls.Add(add_Btn);
            panel4.Controls.Add(label15);
            panel4.Controls.Add(label14);
            panel4.Controls.Add(label13);
            panel4.Controls.Add(PurchaseDate_Lbl);
            panel4.Controls.Add(Supplier_Lbl);
            panel4.Controls.Add(Warranty_Lbl);
            panel4.Controls.Add(Cost_Lbl);
            panel4.Controls.Add(Serial_Lbl);
            panel4.Controls.Add(Model_Lbl);
            panel4.Controls.Add(type_Lbl);
            panel4.Location = new Point(0, 0);
            panel4.MinimumSize = new Size(200, 200);
            panel4.Name = "panel4";
            panel4.Size = new Size(1566, 399);
            panel4.TabIndex = 52;
            // 
            // Clear_Btn
            // 
            Clear_Btn.Anchor = AnchorStyles.Top;
            Clear_Btn.Location = new Point(1974, 93);
            Clear_Btn.Name = "Clear_Btn";
            Clear_Btn.Size = new Size(80, 30);
            Clear_Btn.TabIndex = 71;
            Clear_Btn.Text = "CLEAR";
            Clear_Btn.UseVisualStyleBackColor = true;
            // 
            // register_Btn
            // 
            register_Btn.Anchor = AnchorStyles.Top;
            register_Btn.Font = new Font("Microsoft Sans Serif", 12.75F);
            register_Btn.Location = new Point(739, 344);
            register_Btn.Name = "register_Btn";
            register_Btn.Size = new Size(125, 30);
            register_Btn.TabIndex = 70;
            register_Btn.Text = "REGISTER";
            register_Btn.UseVisualStyleBackColor = true;
            register_Btn.Click += register_Btn_Click;
            // 
            // autoFill_checkBox
            // 
            autoFill_checkBox.Anchor = AnchorStyles.Top;
            autoFill_checkBox.AutoSize = true;
            autoFill_checkBox.Location = new Point(1974, 68);
            autoFill_checkBox.Name = "autoFill_checkBox";
            autoFill_checkBox.Size = new Size(80, 19);
            autoFill_checkBox.TabIndex = 69;
            autoFill_checkBox.Text = "AUTO FILL";
            autoFill_checkBox.UseVisualStyleBackColor = true;
            // 
            // purchaseDate_Dtp
            // 
            purchaseDate_Dtp.Anchor = AnchorStyles.Top;
            purchaseDate_Dtp.Checked = false;
            purchaseDate_Dtp.Location = new Point(504, 308);
            purchaseDate_Dtp.Name = "purchaseDate_Dtp";
            purchaseDate_Dtp.Size = new Size(211, 23);
            purchaseDate_Dtp.TabIndex = 68;
            // 
            // supplier_Tb
            // 
            supplier_Tb.Anchor = AnchorStyles.Top;
            supplier_Tb.Font = new Font("Microsoft Sans Serif", 12.75F);
            supplier_Tb.Location = new Point(504, 275);
            supplier_Tb.Name = "supplier_Tb";
            supplier_Tb.Size = new Size(695, 27);
            supplier_Tb.TabIndex = 67;
            // 
            // days_numericUpDown
            // 
            days_numericUpDown.Anchor = AnchorStyles.Top;
            days_numericUpDown.Location = new Point(843, 238);
            days_numericUpDown.Name = "days_numericUpDown";
            days_numericUpDown.Size = new Size(48, 23);
            days_numericUpDown.TabIndex = 66;
            // 
            // months_numericUpDown
            // 
            months_numericUpDown.Anchor = AnchorStyles.Top;
            months_numericUpDown.Location = new Point(713, 237);
            months_numericUpDown.Name = "months_numericUpDown";
            months_numericUpDown.Size = new Size(48, 23);
            months_numericUpDown.TabIndex = 65;
            // 
            // years_numericUpDown
            // 
            years_numericUpDown.Anchor = AnchorStyles.Top;
            years_numericUpDown.Location = new Point(567, 238);
            years_numericUpDown.Name = "years_numericUpDown";
            years_numericUpDown.Size = new Size(48, 23);
            years_numericUpDown.TabIndex = 64;
            // 
            // cost_Tb
            // 
            cost_Tb.Anchor = AnchorStyles.Top;
            cost_Tb.Font = new Font("Microsoft Sans Serif", 12.75F);
            cost_Tb.Location = new Point(504, 199);
            cost_Tb.Name = "cost_Tb";
            cost_Tb.Size = new Size(695, 27);
            cost_Tb.TabIndex = 63;
            cost_Tb.KeyPress += cost_Tb_KeyPress;
            // 
            // serial_Tb
            // 
            serial_Tb.Anchor = AnchorStyles.Top;
            serial_Tb.CharacterCasing = CharacterCasing.Upper;
            serial_Tb.Font = new Font("Microsoft Sans Serif", 12.75F);
            serial_Tb.Location = new Point(504, 166);
            serial_Tb.Name = "serial_Tb";
            serial_Tb.Size = new Size(695, 27);
            serial_Tb.TabIndex = 62;
            // 
            // model_Tb
            // 
            model_Tb.Anchor = AnchorStyles.Top;
            model_Tb.CharacterCasing = CharacterCasing.Upper;
            model_Tb.Font = new Font("Microsoft Sans Serif", 12.75F);
            model_Tb.Location = new Point(504, 133);
            model_Tb.Name = "model_Tb";
            model_Tb.Size = new Size(695, 27);
            model_Tb.TabIndex = 61;
            // 
            // type_Cmb
            // 
            type_Cmb.Anchor = AnchorStyles.Top;
            type_Cmb.AutoCompleteSource = AutoCompleteSource.CustomSource;
            type_Cmb.DropDownHeight = 150;
            type_Cmb.DropDownStyle = ComboBoxStyle.DropDownList;
            type_Cmb.Font = new Font("Microsoft Sans Serif", 12.75F);
            type_Cmb.FormattingEnabled = true;
            type_Cmb.IntegralHeight = false;
            type_Cmb.Location = new Point(504, 98);
            type_Cmb.MaxDropDownItems = 20;
            type_Cmb.Name = "type_Cmb";
            type_Cmb.Size = new Size(656, 28);
            type_Cmb.TabIndex = 60;
            type_Cmb.DropDown += type_Cmb_DropDown;
            // 
            // add_Btn
            // 
            add_Btn.Anchor = AnchorStyles.Top;
            add_Btn.Font = new Font("Segoe UI", 12F);
            add_Btn.Location = new Point(1166, 98);
            add_Btn.Name = "add_Btn";
            add_Btn.Size = new Size(33, 28);
            add_Btn.TabIndex = 59;
            add_Btn.Text = "+";
            add_Btn.UseVisualStyleBackColor = true;
            add_Btn.Click += add_Btn_Click;
            // 
            // label15
            // 
            label15.Anchor = AnchorStyles.Top;
            label15.AutoSize = true;
            label15.BackColor = Color.White;
            label15.Font = new Font("Microsoft Sans Serif", 12.75F);
            label15.Location = new Point(784, 240);
            label15.Name = "label15";
            label15.Size = new Size(53, 20);
            label15.TabIndex = 58;
            label15.Text = "Days:";
            // 
            // label14
            // 
            label14.Anchor = AnchorStyles.Top;
            label14.AutoSize = true;
            label14.BackColor = Color.White;
            label14.Font = new Font("Microsoft Sans Serif", 12.75F);
            label14.Location = new Point(637, 240);
            label14.Name = "label14";
            label14.Size = new Size(69, 20);
            label14.TabIndex = 57;
            label14.Text = "Months:";
            // 
            // label13
            // 
            label13.Anchor = AnchorStyles.Top;
            label13.AutoSize = true;
            label13.BackColor = Color.White;
            label13.Font = new Font("Microsoft Sans Serif", 12.75F);
            label13.Location = new Point(504, 240);
            label13.Name = "label13";
            label13.Size = new Size(57, 20);
            label13.TabIndex = 56;
            label13.Text = "Years:";
            // 
            // PurchaseDate_Lbl
            // 
            PurchaseDate_Lbl.Anchor = AnchorStyles.Top;
            PurchaseDate_Lbl.AutoSize = true;
            PurchaseDate_Lbl.Font = new Font("Microsoft Sans Serif", 12.75F);
            PurchaseDate_Lbl.Location = new Point(362, 308);
            PurchaseDate_Lbl.Name = "PurchaseDate_Lbl";
            PurchaseDate_Lbl.Size = new Size(126, 20);
            PurchaseDate_Lbl.TabIndex = 55;
            PurchaseDate_Lbl.Text = "Purchase Date:";
            // 
            // Supplier_Lbl
            // 
            Supplier_Lbl.Anchor = AnchorStyles.Top;
            Supplier_Lbl.AutoSize = true;
            Supplier_Lbl.Font = new Font("Microsoft Sans Serif", 12.75F);
            Supplier_Lbl.Location = new Point(361, 272);
            Supplier_Lbl.Name = "Supplier_Lbl";
            Supplier_Lbl.Size = new Size(75, 20);
            Supplier_Lbl.TabIndex = 54;
            Supplier_Lbl.Text = "Supplier:";
            // 
            // Warranty_Lbl
            // 
            Warranty_Lbl.Anchor = AnchorStyles.Top;
            Warranty_Lbl.AutoSize = true;
            Warranty_Lbl.Font = new Font("Microsoft Sans Serif", 12.75F);
            Warranty_Lbl.Location = new Point(361, 238);
            Warranty_Lbl.Name = "Warranty_Lbl";
            Warranty_Lbl.Size = new Size(82, 20);
            Warranty_Lbl.TabIndex = 53;
            Warranty_Lbl.Text = "Warranty:";
            // 
            // Cost_Lbl
            // 
            Cost_Lbl.Anchor = AnchorStyles.Top;
            Cost_Lbl.AutoSize = true;
            Cost_Lbl.Font = new Font("Microsoft Sans Serif", 12.75F);
            Cost_Lbl.Location = new Point(362, 203);
            Cost_Lbl.Name = "Cost_Lbl";
            Cost_Lbl.Size = new Size(49, 20);
            Cost_Lbl.TabIndex = 52;
            Cost_Lbl.Text = "Cost:";
            // 
            // Serial_Lbl
            // 
            Serial_Lbl.Anchor = AnchorStyles.Top;
            Serial_Lbl.AutoSize = true;
            Serial_Lbl.Font = new Font("Microsoft Sans Serif", 12.75F);
            Serial_Lbl.Location = new Point(361, 173);
            Serial_Lbl.Name = "Serial_Lbl";
            Serial_Lbl.Size = new Size(87, 20);
            Serial_Lbl.TabIndex = 51;
            Serial_Lbl.Text = "Serial No.:";
            // 
            // Model_Lbl
            // 
            Model_Lbl.Anchor = AnchorStyles.Top;
            Model_Lbl.AutoSize = true;
            Model_Lbl.Font = new Font("Microsoft Sans Serif", 12.75F);
            Model_Lbl.Location = new Point(361, 138);
            Model_Lbl.Name = "Model_Lbl";
            Model_Lbl.Size = new Size(59, 20);
            Model_Lbl.TabIndex = 50;
            Model_Lbl.Text = "Model:";
            // 
            // type_Lbl
            // 
            type_Lbl.Anchor = AnchorStyles.Top;
            type_Lbl.AutoSize = true;
            type_Lbl.Font = new Font("Microsoft Sans Serif", 12.75F);
            type_Lbl.Location = new Point(361, 104);
            type_Lbl.Name = "type_Lbl";
            type_Lbl.Size = new Size(50, 20);
            type_Lbl.TabIndex = 49;
            type_Lbl.Text = "Type:";
            // 
            // panel5
            // 
            panel5.Controls.Add(label1);
            panel5.Dock = DockStyle.Top;
            panel5.Location = new Point(8, 8);
            panel5.Name = "panel5";
            panel5.Size = new Size(1566, 40);
            panel5.TabIndex = 54;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 21.75F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(686, 0);
            label1.Name = "label1";
            label1.Size = new Size(194, 40);
            label1.TabIndex = 56;
            label1.Text = "INSERT DATA";
            // 
            // autoFill_Cb
            // 
            autoFill_Cb.AutoSize = true;
            autoFill_Cb.Location = new Point(1284, 24);
            autoFill_Cb.Name = "autoFill_Cb";
            autoFill_Cb.Size = new Size(70, 19);
            autoFill_Cb.TabIndex = 72;
            autoFill_Cb.Text = "Auto Fill";
            autoFill_Cb.UseVisualStyleBackColor = true;
            // 
            // clear2_Btn
            // 
            clear2_Btn.Location = new Point(1284, 49);
            clear2_Btn.Name = "clear2_Btn";
            clear2_Btn.Size = new Size(75, 23);
            clear2_Btn.TabIndex = 73;
            clear2_Btn.Text = "CLEAR";
            clear2_Btn.UseVisualStyleBackColor = true;
            clear2_Btn.Click += Clear_Btn_Click;
            // 
            // Create
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1584, 861);
            Controls.Add(panel2);
            Name = "Create";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "INSERT DATA";
            FormClosed += Create_FormClosed;
            Load += Create_Load;
            Resize += Create_Resize;
            panel2.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)qr_pictureBox).EndInit();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)days_numericUpDown).EndInit();
            ((System.ComponentModel.ISupportInitialize)months_numericUpDown).EndInit();
            ((System.ComponentModel.ISupportInitialize)years_numericUpDown).EndInit();
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private Panel panel2;
        private Panel panel1;
        private Panel panel4;
        private Button Clear_Btn;
        private Button register_Btn;
        private CheckBox autoFill_checkBox;
        private DateTimePicker purchaseDate_Dtp;
        private TextBox supplier_Tb;
        private NumericUpDown days_numericUpDown;
        private NumericUpDown months_numericUpDown;
        private NumericUpDown years_numericUpDown;
        private TextBox cost_Tb;
        private TextBox serial_Tb;
        private TextBox model_Tb;
        private ComboBox type_Cmb;
        private Button add_Btn;
        private Label label15;
        private Label label14;
        private Label label13;
        private Label PurchaseDate_Lbl;
        private Label Supplier_Lbl;
        private Label Warranty_Lbl;
        private Label Cost_Lbl;
        private Label Serial_Lbl;
        private Label Model_Lbl;
        private Label type_Lbl;
        private Panel panel3;
        private TextBox serial2_Tb;
        private Button button3;
        private Button generate_Btn;
        private Label label10;
        private PictureBox qr_pictureBox;
        private Label label12;
        private Panel panel5;
        private Label label1;
        private Button clear2_Btn;
        private CheckBox autoFill_Cb;
    }
}