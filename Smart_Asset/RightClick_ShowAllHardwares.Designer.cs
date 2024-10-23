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
            archive_Btn = new Button();
            add_Btn = new Button();
            Transfer = new Button();
            replace_Btn = new Button();
            borrow_Btn = new Button();
            showImage_Btn = new Button();
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
            // archive_Btn
            // 
            archive_Btn.Location = new Point(12, 234);
            archive_Btn.Name = "archive_Btn";
            archive_Btn.Size = new Size(172, 31);
            archive_Btn.TabIndex = 3;
            archive_Btn.Text = "Archive";
            archive_Btn.UseVisualStyleBackColor = true;
            archive_Btn.Click += archieve_Btn_Click;
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
            Transfer.Location = new Point(12, 160);
            Transfer.Name = "Transfer";
            Transfer.Size = new Size(172, 31);
            Transfer.TabIndex = 5;
            Transfer.Text = "Transfer";
            Transfer.UseVisualStyleBackColor = true;
            Transfer.Click += Transfer_Click;
            // 
            // replace_Btn
            // 
            replace_Btn.Location = new Point(12, 123);
            replace_Btn.Name = "replace_Btn";
            replace_Btn.Size = new Size(172, 31);
            replace_Btn.TabIndex = 6;
            replace_Btn.Text = "Replace";
            replace_Btn.UseVisualStyleBackColor = true;
            replace_Btn.Click += replace_Btn_Click;
            // 
            // borrow_Btn
            // 
            borrow_Btn.Location = new Point(12, 197);
            borrow_Btn.Name = "borrow_Btn";
            borrow_Btn.Size = new Size(172, 31);
            borrow_Btn.TabIndex = 7;
            borrow_Btn.Text = "Borrow";
            borrow_Btn.UseVisualStyleBackColor = true;
            borrow_Btn.Click += borrow_Btn_Click;
            // 
            // showImage_Btn
            // 
            showImage_Btn.Location = new Point(12, 271);
            showImage_Btn.Name = "showImage_Btn";
            showImage_Btn.Size = new Size(172, 31);
            showImage_Btn.TabIndex = 8;
            showImage_Btn.Text = "Show Image";
            showImage_Btn.UseVisualStyleBackColor = true;
            showImage_Btn.Click += showImage_Btn_Click;
            // 
            // RightClick_ShowAllHardwares
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(193, 331);
            Controls.Add(showImage_Btn);
            Controls.Add(borrow_Btn);
            Controls.Add(replace_Btn);
            Controls.Add(Transfer);
            Controls.Add(add_Btn);
            Controls.Add(archive_Btn);
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
        public Button archive_Btn;
        public Button add_Btn;
        public Button Transfer;
        public Button replace_Btn;
        public Button borrow_Btn;
        public Button showImage_Btn;
    }
}