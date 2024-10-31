namespace Smart_Asset
{
    partial class RightClick_ManageUsers
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
            editInformation_Btn = new Button();
            refresh_Btn = new Button();
            button1 = new Button();
            button2 = new Button();
            changeRole_Btn = new Button();
            SuspendLayout();
            // 
            // editInformation_Btn
            // 
            editInformation_Btn.Location = new Point(12, 49);
            editInformation_Btn.Name = "editInformation_Btn";
            editInformation_Btn.Size = new Size(172, 31);
            editInformation_Btn.TabIndex = 0;
            editInformation_Btn.Text = "Edit Information";
            editInformation_Btn.UseVisualStyleBackColor = true;
            editInformation_Btn.Click += markAsRepaired_Btn_Click;
            // 
            // refresh_Btn
            // 
            refresh_Btn.Location = new Point(12, 12);
            refresh_Btn.Name = "refresh_Btn";
            refresh_Btn.Size = new Size(172, 31);
            refresh_Btn.TabIndex = 1;
            refresh_Btn.Text = "Refresh";
            refresh_Btn.UseVisualStyleBackColor = true;
            refresh_Btn.Click += refresh_Btn_Click;
            // 
            // button1
            // 
            button1.Location = new Point(12, 123);
            button1.Name = "button1";
            button1.Size = new Size(172, 31);
            button1.TabIndex = 2;
            button1.Text = "Reset Password";
            button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.Location = new Point(12, 160);
            button2.Name = "button2";
            button2.Size = new Size(172, 31);
            button2.TabIndex = 3;
            button2.Text = "Remove";
            button2.UseVisualStyleBackColor = true;
            // 
            // changeRole_Btn
            // 
            changeRole_Btn.Location = new Point(12, 86);
            changeRole_Btn.Name = "changeRole_Btn";
            changeRole_Btn.Size = new Size(172, 31);
            changeRole_Btn.TabIndex = 4;
            changeRole_Btn.Text = "Change Role";
            changeRole_Btn.UseVisualStyleBackColor = true;
            changeRole_Btn.Click += changeRole_Btn_Click;
            // 
            // RightClick_ManageUsers
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(193, 262);
            Controls.Add(changeRole_Btn);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(refresh_Btn);
            Controls.Add(editInformation_Btn);
            FormBorderStyle = FormBorderStyle.None;
            Name = "RightClick_ManageUsers";
            Text = "RightClick";
            ResumeLayout(false);
        }

        #endregion

        private Button editInformation_Btn;
        public Button refresh_Btn;
        private Button button1;
        private Button button2;
        private Button changeRole_Btn;
    }
}