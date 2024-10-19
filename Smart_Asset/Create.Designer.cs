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
            serial2_Cb = new ComboBox();
            button3 = new Button();
            generate_Btn = new Button();
            label10 = new Label();
            qr_pictureBox = new PictureBox();
            label12 = new Label();
            panel4 = new Panel();
            uploadImage_Pb = new PictureBox();
            brand_Tb = new TextBox();
            label5 = new Label();
            button1 = new Button();
            siNumber_Tb = new TextBox();
            label4 = new Label();
            poNumber_Tb = new TextBox();
            label3 = new Label();
            propertyID_Tb = new TextBox();
            label2 = new Label();
            clear2_Btn = new Button();
            autoFill_Cb = new CheckBox();
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
            qmark_Btn = new Button();
            label1 = new Label();
            panel2.SuspendLayout();
            panel1.SuspendLayout();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)qr_pictureBox).BeginInit();
            panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)uploadImage_Pb).BeginInit();
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
            panel3.Controls.Add(serial2_Cb);
            panel3.Controls.Add(button3);
            panel3.Controls.Add(generate_Btn);
            panel3.Controls.Add(label10);
            panel3.Controls.Add(qr_pictureBox);
            panel3.Controls.Add(label12);
            panel3.Location = new Point(0, 504);
            panel3.Name = "panel3";
            panel3.Size = new Size(1566, 299);
            panel3.TabIndex = 53;
            // 
            // serial2_Cb
            // 
            serial2_Cb.Anchor = AnchorStyles.None;
            serial2_Cb.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            serial2_Cb.AutoCompleteSource = AutoCompleteSource.ListItems;
            serial2_Cb.FormattingEnabled = true;
            serial2_Cb.Location = new Point(534, 107);
            serial2_Cb.Name = "serial2_Cb";
            serial2_Cb.Size = new Size(303, 23);
            serial2_Cb.TabIndex = 27;
            serial2_Cb.KeyPress += serial2_Cb_KeyPress;
            serial2_Cb.MouseEnter += serial2_Cb_MouseEnter;
            // 
            // button3
            // 
            button3.Anchor = AnchorStyles.None;
            button3.Location = new Point(961, 266);
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
            generate_Btn.Location = new Point(618, 150);
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
            label10.Location = new Point(441, 41);
            label10.Name = "label10";
            label10.Size = new Size(199, 30);
            label10.TabIndex = 22;
            label10.Text = "QR Code Generator:";
            // 
            // qr_pictureBox
            // 
            qr_pictureBox.Anchor = AnchorStyles.None;
            qr_pictureBox.BackColor = Color.White;
            qr_pictureBox.Location = new Point(876, 10);
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
            label12.Location = new Point(441, 110);
            label12.Name = "label12";
            label12.Size = new Size(87, 20);
            label12.TabIndex = 23;
            label12.Text = "Serial No.:";
            // 
            // panel4
            // 
            panel4.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel4.AutoScroll = true;
            panel4.BackColor = Color.Gray;
            panel4.Controls.Add(uploadImage_Pb);
            panel4.Controls.Add(brand_Tb);
            panel4.Controls.Add(label5);
            panel4.Controls.Add(button1);
            panel4.Controls.Add(siNumber_Tb);
            panel4.Controls.Add(label4);
            panel4.Controls.Add(poNumber_Tb);
            panel4.Controls.Add(label3);
            panel4.Controls.Add(propertyID_Tb);
            panel4.Controls.Add(label2);
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
            panel4.Size = new Size(1566, 498);
            panel4.TabIndex = 52;
            // 
            // uploadImage_Pb
            // 
            uploadImage_Pb.Anchor = AnchorStyles.Top;
            uploadImage_Pb.Location = new Point(627, 399);
            uploadImage_Pb.Name = "uploadImage_Pb";
            uploadImage_Pb.Size = new Size(43, 30);
            uploadImage_Pb.SizeMode = PictureBoxSizeMode.CenterImage;
            uploadImage_Pb.TabIndex = 84;
            uploadImage_Pb.TabStop = false;
            // 
            // brand_Tb
            // 
            brand_Tb.Anchor = AnchorStyles.Top;
            brand_Tb.CharacterCasing = CharacterCasing.Upper;
            brand_Tb.Font = new Font("Microsoft Sans Serif", 12.75F);
            brand_Tb.Location = new Point(450, 68);
            brand_Tb.Name = "brand_Tb";
            brand_Tb.Size = new Size(695, 27);
            brand_Tb.TabIndex = 83;
            // 
            // label5
            // 
            label5.Anchor = AnchorStyles.Top;
            label5.AutoSize = true;
            label5.Font = new Font("Microsoft Sans Serif", 12.75F);
            label5.Location = new Point(307, 73);
            label5.Name = "label5";
            label5.Size = new Size(59, 20);
            label5.TabIndex = 82;
            label5.Text = "Brand:";
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.Top;
            button1.FlatAppearance.MouseDownBackColor = Color.Red;
            button1.FlatAppearance.MouseOverBackColor = Color.Lime;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Microsoft Sans Serif", 12.75F);
            button1.Location = new Point(451, 399);
            button1.Name = "button1";
            button1.Size = new Size(170, 30);
            button1.TabIndex = 81;
            button1.Text = "UPLOAD IMAGE";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // siNumber_Tb
            // 
            siNumber_Tb.Anchor = AnchorStyles.Top;
            siNumber_Tb.CharacterCasing = CharacterCasing.Upper;
            siNumber_Tb.Font = new Font("Microsoft Sans Serif", 12.75F);
            siNumber_Tb.Location = new Point(450, 233);
            siNumber_Tb.Name = "siNumber_Tb";
            siNumber_Tb.Size = new Size(695, 27);
            siNumber_Tb.TabIndex = 79;
            siNumber_Tb.KeyPress += siNumber_Tb_KeyPress;
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Top;
            label4.AutoSize = true;
            label4.Font = new Font("Microsoft Sans Serif", 12.75F);
            label4.Location = new Point(307, 240);
            label4.Name = "label4";
            label4.Size = new Size(97, 20);
            label4.TabIndex = 78;
            label4.Text = "S.I Number:";
            // 
            // poNumber_Tb
            // 
            poNumber_Tb.Anchor = AnchorStyles.Top;
            poNumber_Tb.CharacterCasing = CharacterCasing.Upper;
            poNumber_Tb.Font = new Font("Microsoft Sans Serif", 12.75F);
            poNumber_Tb.Location = new Point(450, 200);
            poNumber_Tb.Name = "poNumber_Tb";
            poNumber_Tb.Size = new Size(695, 27);
            poNumber_Tb.TabIndex = 77;
            poNumber_Tb.KeyPress += poNumber_Tb_KeyPress;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Top;
            label3.AutoSize = true;
            label3.Font = new Font("Microsoft Sans Serif", 12.75F);
            label3.Location = new Point(307, 207);
            label3.Name = "label3";
            label3.Size = new Size(106, 20);
            label3.TabIndex = 76;
            label3.Text = "P.O Number:";
            // 
            // propertyID_Tb
            // 
            propertyID_Tb.Anchor = AnchorStyles.Top;
            propertyID_Tb.CharacterCasing = CharacterCasing.Upper;
            propertyID_Tb.Font = new Font("Microsoft Sans Serif", 12.75F);
            propertyID_Tb.Location = new Point(450, 134);
            propertyID_Tb.Name = "propertyID_Tb";
            propertyID_Tb.Size = new Size(695, 27);
            propertyID_Tb.TabIndex = 75;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top;
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft Sans Serif", 12.75F);
            label2.Location = new Point(307, 141);
            label2.Name = "label2";
            label2.Size = new Size(99, 20);
            label2.TabIndex = 74;
            label2.Text = "Property ID:";
            // 
            // clear2_Btn
            // 
            clear2_Btn.Anchor = AnchorStyles.Top;
            clear2_Btn.Location = new Point(1245, 58);
            clear2_Btn.Name = "clear2_Btn";
            clear2_Btn.Size = new Size(75, 23);
            clear2_Btn.TabIndex = 73;
            clear2_Btn.Text = "CLEAR";
            clear2_Btn.UseVisualStyleBackColor = true;
            clear2_Btn.Click += Clear_Btn_Click;
            // 
            // autoFill_Cb
            // 
            autoFill_Cb.Anchor = AnchorStyles.Top;
            autoFill_Cb.AutoSize = true;
            autoFill_Cb.Location = new Point(1245, 33);
            autoFill_Cb.Name = "autoFill_Cb";
            autoFill_Cb.Size = new Size(70, 19);
            autoFill_Cb.TabIndex = 72;
            autoFill_Cb.Text = "Auto Fill";
            autoFill_Cb.UseVisualStyleBackColor = true;
            // 
            // Clear_Btn
            // 
            Clear_Btn.Anchor = AnchorStyles.Top;
            Clear_Btn.Location = new Point(1983, 93);
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
            register_Btn.Location = new Point(731, 439);
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
            autoFill_checkBox.Location = new Point(1983, 68);
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
            purchaseDate_Dtp.Location = new Point(450, 364);
            purchaseDate_Dtp.Name = "purchaseDate_Dtp";
            purchaseDate_Dtp.Size = new Size(211, 23);
            purchaseDate_Dtp.TabIndex = 68;
            // 
            // supplier_Tb
            // 
            supplier_Tb.Anchor = AnchorStyles.Top;
            supplier_Tb.Font = new Font("Microsoft Sans Serif", 12.75F);
            supplier_Tb.Location = new Point(450, 299);
            supplier_Tb.Name = "supplier_Tb";
            supplier_Tb.Size = new Size(695, 27);
            supplier_Tb.TabIndex = 67;
            // 
            // days_numericUpDown
            // 
            days_numericUpDown.Anchor = AnchorStyles.Top;
            days_numericUpDown.Location = new Point(790, 335);
            days_numericUpDown.Name = "days_numericUpDown";
            days_numericUpDown.Size = new Size(48, 23);
            days_numericUpDown.TabIndex = 66;
            // 
            // months_numericUpDown
            // 
            months_numericUpDown.Anchor = AnchorStyles.Top;
            months_numericUpDown.Location = new Point(660, 334);
            months_numericUpDown.Name = "months_numericUpDown";
            months_numericUpDown.Size = new Size(48, 23);
            months_numericUpDown.TabIndex = 65;
            // 
            // years_numericUpDown
            // 
            years_numericUpDown.Anchor = AnchorStyles.Top;
            years_numericUpDown.Location = new Point(514, 335);
            years_numericUpDown.Name = "years_numericUpDown";
            years_numericUpDown.Size = new Size(48, 23);
            years_numericUpDown.TabIndex = 64;
            // 
            // cost_Tb
            // 
            cost_Tb.Anchor = AnchorStyles.Top;
            cost_Tb.Font = new Font("Microsoft Sans Serif", 12.75F);
            cost_Tb.Location = new Point(450, 266);
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
            serial_Tb.Location = new Point(450, 167);
            serial_Tb.Name = "serial_Tb";
            serial_Tb.Size = new Size(695, 27);
            serial_Tb.TabIndex = 62;
            // 
            // model_Tb
            // 
            model_Tb.Anchor = AnchorStyles.Top;
            model_Tb.CharacterCasing = CharacterCasing.Upper;
            model_Tb.Font = new Font("Microsoft Sans Serif", 12.75F);
            model_Tb.Location = new Point(450, 101);
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
            type_Cmb.Location = new Point(450, 33);
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
            add_Btn.Location = new Point(1112, 33);
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
            label15.Location = new Point(731, 337);
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
            label14.Location = new Point(584, 337);
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
            label13.Location = new Point(451, 337);
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
            PurchaseDate_Lbl.Location = new Point(308, 367);
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
            Supplier_Lbl.Location = new Point(307, 306);
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
            Warranty_Lbl.Location = new Point(308, 338);
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
            Cost_Lbl.Location = new Point(307, 273);
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
            Serial_Lbl.Location = new Point(307, 174);
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
            Model_Lbl.Location = new Point(307, 106);
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
            type_Lbl.Location = new Point(307, 39);
            type_Lbl.Name = "type_Lbl";
            type_Lbl.Size = new Size(50, 20);
            type_Lbl.TabIndex = 49;
            type_Lbl.Text = "Type:";
            // 
            // panel5
            // 
            panel5.Controls.Add(qmark_Btn);
            panel5.Controls.Add(label1);
            panel5.Dock = DockStyle.Top;
            panel5.Location = new Point(8, 8);
            panel5.Name = "panel5";
            panel5.Size = new Size(1566, 40);
            panel5.TabIndex = 54;
            // 
            // qmark_Btn
            // 
            qmark_Btn.FlatStyle = FlatStyle.Flat;
            qmark_Btn.Font = new Font("Segoe UI", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            qmark_Btn.ForeColor = SystemColors.ButtonFace;
            qmark_Btn.Image = Properties.Resources.questionMark_Icon;
            qmark_Btn.Location = new Point(1537, 9);
            qmark_Btn.Name = "qmark_Btn";
            qmark_Btn.Size = new Size(21, 21);
            qmark_Btn.TabIndex = 57;
            qmark_Btn.UseVisualStyleBackColor = true;
            qmark_Btn.Click += qmark_Btn_Click;
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
            ((System.ComponentModel.ISupportInitialize)uploadImage_Pb).EndInit();
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
        private Button button3;
        private Button generate_Btn;
        private Label label10;
        private PictureBox qr_pictureBox;
        private Label label12;
        private Panel panel5;
        private Label label1;
        private Button clear2_Btn;
        private CheckBox autoFill_Cb;
        private Button qmark_Btn;
        private ComboBox serial2_Cb;
        private TextBox siNumber_Tb;
        private Label label4;
        private TextBox poNumber_Tb;
        private Label label3;
        private TextBox propertyID_Tb;
        private Label label2;
        private Button button1;
        private TextBox brand_Tb;
        private Label label5;
        private PictureBox uploadImage_Pb;
    }
}