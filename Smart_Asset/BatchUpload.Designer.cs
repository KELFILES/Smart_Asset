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
            instructions_Btn = new Button();
            label1 = new Label();
            uploadFile_Btn = new Button();
            label2 = new Label();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.DimGray;
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
            // instructions_Btn
            // 
            instructions_Btn.Anchor = AnchorStyles.Right;
            instructions_Btn.BackColor = Color.IndianRed;
            instructions_Btn.FlatStyle = FlatStyle.Flat;
            instructions_Btn.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            instructions_Btn.ForeColor = Color.White;
            instructions_Btn.Location = new Point(188, 133);
            instructions_Btn.Name = "instructions_Btn";
            instructions_Btn.Size = new Size(142, 34);
            instructions_Btn.TabIndex = 14;
            instructions_Btn.Text = "INSTRUCTIONS";
            instructions_Btn.UseVisualStyleBackColor = false;
            instructions_Btn.Click += instructions_Btn_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 27.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(137, 59);
            label1.Name = "label1";
            label1.Size = new Size(242, 50);
            label1.TabIndex = 0;
            label1.Text = "Batch Upload";
            // 
            // uploadFile_Btn
            // 
            uploadFile_Btn.Anchor = AnchorStyles.Right;
            uploadFile_Btn.BackColor = Color.RoyalBlue;
            uploadFile_Btn.FlatStyle = FlatStyle.Flat;
            uploadFile_Btn.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            uploadFile_Btn.ForeColor = Color.White;
            uploadFile_Btn.Location = new Point(197, 189);
            uploadFile_Btn.Name = "uploadFile_Btn";
            uploadFile_Btn.Size = new Size(126, 32);
            uploadFile_Btn.TabIndex = 17;
            uploadFile_Btn.Text = "Upload File";
            uploadFile_Btn.UseVisualStyleBackColor = false;
            uploadFile_Btn.Click += uploadFile_Btn_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.IndianRed;
            label2.Location = new Point(102, 242);
            label2.Name = "label2";
            label2.Size = new Size(317, 25);
            label2.TabIndex = 18;
            label2.Text = "Select an Excel File for Batch Upload";
            // 
            // BatchUpload
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Gray;
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