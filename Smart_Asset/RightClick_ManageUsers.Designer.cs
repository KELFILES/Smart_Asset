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
            panel1 = new Panel();
            panel6 = new Panel();
            button2 = new Button();
            panel5 = new Panel();
            button1 = new Button();
            panel4 = new Panel();
            changePermission_Btn = new Button();
            panel3 = new Panel();
            changeRole_Btn = new Button();
            panel2 = new Panel();
            editInformation_Btn = new Button();
            panel7 = new Panel();
            refresh_Btn = new Button();
            panel6.SuspendLayout();
            panel5.SuspendLayout();
            panel4.SuspendLayout();
            panel3.SuspendLayout();
            panel2.SuspendLayout();
            panel7.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(193, 17);
            panel1.TabIndex = 0;
            // 
            // panel6
            // 
            panel6.Controls.Add(button2);
            panel6.Dock = DockStyle.Top;
            panel6.Location = new Point(0, 222);
            panel6.Name = "panel6";
            panel6.Size = new Size(193, 41);
            panel6.TabIndex = 16;
            // 
            // button2
            // 
            button2.Location = new Point(12, 6);
            button2.Name = "button2";
            button2.Size = new Size(172, 31);
            button2.TabIndex = 3;
            button2.Text = "Remove";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // panel5
            // 
            panel5.Controls.Add(button1);
            panel5.Dock = DockStyle.Top;
            panel5.Location = new Point(0, 181);
            panel5.Name = "panel5";
            panel5.Size = new Size(193, 41);
            panel5.TabIndex = 15;
            // 
            // button1
            // 
            button1.Location = new Point(12, 6);
            button1.Name = "button1";
            button1.Size = new Size(172, 31);
            button1.TabIndex = 2;
            button1.Text = "Reset Password";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // panel4
            // 
            panel4.Controls.Add(changePermission_Btn);
            panel4.Dock = DockStyle.Top;
            panel4.Location = new Point(0, 140);
            panel4.Name = "panel4";
            panel4.Size = new Size(193, 41);
            panel4.TabIndex = 14;
            // 
            // changePermission_Btn
            // 
            changePermission_Btn.Location = new Point(10, 5);
            changePermission_Btn.Name = "changePermission_Btn";
            changePermission_Btn.Size = new Size(172, 31);
            changePermission_Btn.TabIndex = 5;
            changePermission_Btn.Text = "Change Permission";
            changePermission_Btn.UseVisualStyleBackColor = true;
            changePermission_Btn.Click += changePermission_Btn_Click;
            // 
            // panel3
            // 
            panel3.Controls.Add(changeRole_Btn);
            panel3.Dock = DockStyle.Top;
            panel3.Location = new Point(0, 99);
            panel3.Name = "panel3";
            panel3.Size = new Size(193, 41);
            panel3.TabIndex = 13;
            // 
            // changeRole_Btn
            // 
            changeRole_Btn.Location = new Point(11, 4);
            changeRole_Btn.Name = "changeRole_Btn";
            changeRole_Btn.Size = new Size(172, 31);
            changeRole_Btn.TabIndex = 4;
            changeRole_Btn.Text = "Change Role";
            changeRole_Btn.UseVisualStyleBackColor = true;
            changeRole_Btn.Click += changeRole_Btn_Click;
            // 
            // panel2
            // 
            panel2.Controls.Add(editInformation_Btn);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(0, 58);
            panel2.Name = "panel2";
            panel2.Size = new Size(193, 41);
            panel2.TabIndex = 12;
            // 
            // editInformation_Btn
            // 
            editInformation_Btn.Location = new Point(12, 4);
            editInformation_Btn.Name = "editInformation_Btn";
            editInformation_Btn.Size = new Size(172, 31);
            editInformation_Btn.TabIndex = 0;
            editInformation_Btn.Text = "Edit Information";
            editInformation_Btn.UseVisualStyleBackColor = true;
            editInformation_Btn.Click += editInformation_Btn_Click;
            // 
            // panel7
            // 
            panel7.Controls.Add(refresh_Btn);
            panel7.Dock = DockStyle.Top;
            panel7.Location = new Point(0, 17);
            panel7.Name = "panel7";
            panel7.Size = new Size(193, 41);
            panel7.TabIndex = 11;
            // 
            // refresh_Btn
            // 
            refresh_Btn.Location = new Point(11, 5);
            refresh_Btn.Name = "refresh_Btn";
            refresh_Btn.Size = new Size(172, 31);
            refresh_Btn.TabIndex = 1;
            refresh_Btn.Text = "Refresh";
            refresh_Btn.UseVisualStyleBackColor = true;
            refresh_Btn.Click += refresh_Btn_Click;
            // 
            // RightClick_ManageUsers
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(193, 290);
            Controls.Add(panel6);
            Controls.Add(panel5);
            Controls.Add(panel4);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(panel7);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "RightClick_ManageUsers";
            Text = "RightClick";
            Load += RightClick_ManageUsers_Load;
            panel6.ResumeLayout(false);
            panel5.ResumeLayout(false);
            panel4.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel7.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Panel panel6;
        private Button button2;
        private Panel panel5;
        private Button button1;
        private Panel panel4;
        private Button changePermission_Btn;
        private Panel panel3;
        private Button changeRole_Btn;
        private Panel panel2;
        private Button editInformation_Btn;
        private Panel panel7;
        public Button refresh_Btn;
    }
}