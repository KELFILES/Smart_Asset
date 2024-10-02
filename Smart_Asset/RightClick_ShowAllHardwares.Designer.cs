namespace Smart_Asset
{
    partial class RightClick_ShowAllHardwares
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
            refresh_Btn = new Button();
            edit_Btn = new Button();
            archieve_Btn = new Button();
            add_Btn = new Button();
            Transfer = new Button();
            reserve_Btn = new Button();
            repair_Btn = new Button();
            dispose_Btn = new Button();
            clean_Btn = new Button();
            borrow_Btn = new Button();
            SuspendLayout();
            // 
            // refresh_Btn
            // 
            refresh_Btn.Location = new Point(9, 12);
            refresh_Btn.Name = "refresh_Btn";
            refresh_Btn.Size = new Size(172, 31);
            refresh_Btn.TabIndex = 1;
            refresh_Btn.Text = "Refresh";
            refresh_Btn.UseVisualStyleBackColor = true;
            refresh_Btn.Click += refresh_Btn_Click;
            // 
            // edit_Btn
            // 
            edit_Btn.Location = new Point(12, 86);
            edit_Btn.Name = "edit_Btn";
            edit_Btn.Size = new Size(172, 31);
            edit_Btn.TabIndex = 2;
            edit_Btn.Text = "Edit";
            edit_Btn.UseVisualStyleBackColor = true;
            edit_Btn.Click += edit_Btn_Click;
            // 
            // archieve_Btn
            // 
            archieve_Btn.Location = new Point(12, 345);
            archieve_Btn.Name = "archieve_Btn";
            archieve_Btn.Size = new Size(172, 31);
            archieve_Btn.TabIndex = 3;
            archieve_Btn.Text = "Archieve";
            archieve_Btn.UseVisualStyleBackColor = true;
            archieve_Btn.Click += archieve_Btn_Click;
            // 
            // add_Btn
            // 
            add_Btn.Location = new Point(9, 49);
            add_Btn.Name = "add_Btn";
            add_Btn.Size = new Size(172, 31);
            add_Btn.TabIndex = 4;
            add_Btn.Text = "Add";
            add_Btn.UseVisualStyleBackColor = true;
            add_Btn.Click += add_Btn_Click;
            // 
            // Transfer
            // 
            Transfer.Location = new Point(12, 123);
            Transfer.Name = "Transfer";
            Transfer.Size = new Size(172, 31);
            Transfer.TabIndex = 5;
            Transfer.Text = "Transfer";
            Transfer.UseVisualStyleBackColor = true;
            Transfer.Click += Transfer_Click;
            // 
            // reserve_Btn
            // 
            reserve_Btn.Location = new Point(12, 160);
            reserve_Btn.Name = "reserve_Btn";
            reserve_Btn.Size = new Size(172, 31);
            reserve_Btn.TabIndex = 6;
            reserve_Btn.Text = "Reserve";
            reserve_Btn.UseVisualStyleBackColor = true;
            reserve_Btn.Click += reserve_Btn_Click;
            // 
            // repair_Btn
            // 
            repair_Btn.Location = new Point(9, 197);
            repair_Btn.Name = "repair_Btn";
            repair_Btn.Size = new Size(172, 31);
            repair_Btn.TabIndex = 7;
            repair_Btn.Text = "Repair";
            repair_Btn.UseVisualStyleBackColor = true;
            repair_Btn.Click += repair_Btn_Click;
            // 
            // dispose_Btn
            // 
            dispose_Btn.Location = new Point(12, 234);
            dispose_Btn.Name = "dispose_Btn";
            dispose_Btn.Size = new Size(172, 31);
            dispose_Btn.TabIndex = 8;
            dispose_Btn.Text = "Dispose";
            dispose_Btn.UseVisualStyleBackColor = true;
            dispose_Btn.Click += dispose_Btn_Click;
            // 
            // clean_Btn
            // 
            clean_Btn.Location = new Point(12, 271);
            clean_Btn.Name = "clean_Btn";
            clean_Btn.Size = new Size(172, 31);
            clean_Btn.TabIndex = 9;
            clean_Btn.Text = "Clean";
            clean_Btn.UseVisualStyleBackColor = true;
            clean_Btn.Click += clean_Btn_Click;
            // 
            // borrow_Btn
            // 
            borrow_Btn.Location = new Point(12, 308);
            borrow_Btn.Name = "borrow_Btn";
            borrow_Btn.Size = new Size(172, 31);
            borrow_Btn.TabIndex = 10;
            borrow_Btn.Text = "Borrow";
            borrow_Btn.UseVisualStyleBackColor = true;
            borrow_Btn.Click += borrow_Btn_Click;
            // 
            // RightClick_ShowAllHardwares
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(193, 384);
            Controls.Add(borrow_Btn);
            Controls.Add(clean_Btn);
            Controls.Add(dispose_Btn);
            Controls.Add(repair_Btn);
            Controls.Add(reserve_Btn);
            Controls.Add(Transfer);
            Controls.Add(add_Btn);
            Controls.Add(archieve_Btn);
            Controls.Add(edit_Btn);
            Controls.Add(refresh_Btn);
            FormBorderStyle = FormBorderStyle.None;
            Name = "RightClick_ShowAllHardwares";
            Text = "RightClick";
            ResumeLayout(false);
        }

        #endregion
        public Button refresh_Btn;
        public Button edit_Btn;
        public Button archieve_Btn;
        public Button add_Btn;
        public Button Transfer;
        public Button reserve_Btn;
        public Button repair_Btn;
        public Button dispose_Btn;
        public Button clean_Btn;
        public Button borrow_Btn;
    }
}