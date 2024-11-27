namespace Smart_Asset
{
    partial class BatchUpload
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
            label2 = new Label();
            label1 = new Label();
            uploadFile_Btn = new Button();
            instructions_Btn = new Button();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(2, 119, 189);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(uploadFile_Btn);
            panel1.Controls.Add(instructions_Btn);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(7, 7);
            panel1.Name = "panel1";
            panel1.Size = new Size(522, 362);
            panel1.TabIndex = 0;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.FromArgb(255, 242, 0);
            label2.Location = new Point(129, 151);
            label2.Name = "label2";
            label2.Size = new Size(247, 20);
            label2.TabIndex = 18;
            label2.Text = "Reminder: Only use Excel File";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 27.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(125, 92);
            label1.Name = "label1";
            label1.Size = new Size(255, 42);
            label1.TabIndex = 0;
            label1.Text = "Batch Upload";
            // 
            // uploadFile_Btn
            // 
            uploadFile_Btn.Anchor = AnchorStyles.Right;
            uploadFile_Btn.BackColor = Color.White;
            uploadFile_Btn.FlatStyle = FlatStyle.Flat;
            uploadFile_Btn.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            uploadFile_Btn.ForeColor = Color.FromArgb(2, 119, 189);
            uploadFile_Btn.Location = new Point(179, 199);
            uploadFile_Btn.Name = "uploadFile_Btn";
            uploadFile_Btn.Size = new Size(141, 45);
            uploadFile_Btn.TabIndex = 17;
            uploadFile_Btn.Text = "UPLOAD FILE";
            uploadFile_Btn.UseVisualStyleBackColor = false;
            uploadFile_Btn.Click += uploadFile_Btn_Click;
            // 
            // instructions_Btn
            // 
            instructions_Btn.Anchor = AnchorStyles.Right;
            instructions_Btn.BackColor = Color.IndianRed;
            instructions_Btn.FlatStyle = FlatStyle.Flat;
            instructions_Btn.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            instructions_Btn.ForeColor = Color.White;
            instructions_Btn.Location = new Point(396, 13);
            instructions_Btn.Name = "instructions_Btn";
            instructions_Btn.Size = new Size(112, 24);
            instructions_Btn.TabIndex = 14;
            instructions_Btn.Text = "INSTRUCTIONS";
            instructions_Btn.UseVisualStyleBackColor = false;
            instructions_Btn.Click += instructions_Btn_Click;
            // 
            // BatchUpload
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(0, 91, 143);
            ClientSize = new Size(536, 376);
            Controls.Add(panel1);
            Name = "BatchUpload";
            Padding = new Padding(7);
            Text = "BatchUpload";
            Load += BatchUpload_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label label1;
        private Button instructions_Btn;
        private Label label2;
        private Button uploadFile_Btn;
    }
}