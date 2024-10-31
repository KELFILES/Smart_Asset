namespace Smart_Asset
{
    partial class ChangeRole
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
            panel2 = new Panel();
            currentRoleVal_Lbl = new Label();
            label5 = new Label();
            nameVal_Lbl = new Label();
            label4 = new Label();
            newRole_Cb = new ComboBox();
            change_Btn = new Button();
            label2 = new Label();
            label6 = new Label();
            userIDVal_Lbl = new Label();
            label3 = new Label();
            topLabel_Lbl = new Label();
            label1 = new Label();
            panel1.SuspendLayout();
            panel3.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.Gray;
            panel1.Controls.Add(panel3);
            panel1.Controls.Add(panel2);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Padding = new Padding(7);
            panel1.Size = new Size(1250, 343);
            panel1.TabIndex = 0;
            // 
            // panel3
            // 
            panel3.BackColor = Color.DimGray;
            panel3.Controls.Add(label1);
            panel3.Controls.Add(topLabel_Lbl);
            panel3.Dock = DockStyle.Right;
            panel3.Location = new Point(618, 7);
            panel3.Name = "panel3";
            panel3.Padding = new Padding(7);
            panel3.Size = new Size(625, 329);
            panel3.TabIndex = 10;
            // 
            // panel2
            // 
            panel2.BackColor = Color.DimGray;
            panel2.Controls.Add(currentRoleVal_Lbl);
            panel2.Controls.Add(label5);
            panel2.Controls.Add(nameVal_Lbl);
            panel2.Controls.Add(label4);
            panel2.Controls.Add(newRole_Cb);
            panel2.Controls.Add(change_Btn);
            panel2.Controls.Add(label2);
            panel2.Controls.Add(label6);
            panel2.Controls.Add(userIDVal_Lbl);
            panel2.Controls.Add(label3);
            panel2.Dock = DockStyle.Left;
            panel2.Location = new Point(7, 7);
            panel2.Name = "panel2";
            panel2.Padding = new Padding(7);
            panel2.Size = new Size(605, 329);
            panel2.TabIndex = 9;
            // 
            // currentRoleVal_Lbl
            // 
            currentRoleVal_Lbl.AutoSize = true;
            currentRoleVal_Lbl.Font = new Font("Segoe UI", 14.25F);
            currentRoleVal_Lbl.ForeColor = Color.White;
            currentRoleVal_Lbl.Location = new Point(215, 144);
            currentRoleVal_Lbl.Name = "currentRoleVal_Lbl";
            currentRoleVal_Lbl.Size = new Size(138, 25);
            currentRoleVal_Lbl.TabIndex = 14;
            currentRoleVal_Lbl.Text = "CurrentRoleVal";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.White;
            label5.Location = new Point(85, 144);
            label5.Name = "label5";
            label5.Size = new Size(130, 25);
            label5.TabIndex = 13;
            label5.Text = "Current Role:";
            // 
            // nameVal_Lbl
            // 
            nameVal_Lbl.AutoSize = true;
            nameVal_Lbl.Font = new Font("Segoe UI", 14.25F);
            nameVal_Lbl.ForeColor = Color.White;
            nameVal_Lbl.Location = new Point(215, 119);
            nameVal_Lbl.Name = "nameVal_Lbl";
            nameVal_Lbl.Size = new Size(88, 25);
            nameVal_Lbl.TabIndex = 12;
            nameVal_Lbl.Text = "NameVal";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.White;
            label4.Location = new Point(85, 119);
            label4.Name = "label4";
            label4.Size = new Size(69, 25);
            label4.TabIndex = 11;
            label4.Text = "Name:";
            // 
            // newRole_Cb
            // 
            newRole_Cb.DropDownStyle = ComboBoxStyle.DropDownList;
            newRole_Cb.FormattingEnabled = true;
            newRole_Cb.Location = new Point(192, 205);
            newRole_Cb.Name = "newRole_Cb";
            newRole_Cb.Size = new Size(247, 23);
            newRole_Cb.TabIndex = 10;
            newRole_Cb.MouseClick += comboBox1_MouseClick;
            // 
            // change_Btn
            // 
            change_Btn.Location = new Point(241, 247);
            change_Btn.Name = "change_Btn";
            change_Btn.Size = new Size(112, 31);
            change_Btn.TabIndex = 9;
            change_Btn.Text = "CHANGE";
            change_Btn.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.White;
            label2.Location = new Point(215, 29);
            label2.Name = "label2";
            label2.Size = new Size(179, 32);
            label2.TabIndex = 4;
            label2.Text = "CHANGE ROLE";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.ForeColor = Color.White;
            label6.Location = new Point(85, 205);
            label6.Name = "label6";
            label6.Size = new Size(101, 25);
            label6.TabIndex = 7;
            label6.Text = "New Role:";
            // 
            // userIDVal_Lbl
            // 
            userIDVal_Lbl.AutoSize = true;
            userIDVal_Lbl.Font = new Font("Segoe UI", 14.25F);
            userIDVal_Lbl.ForeColor = Color.White;
            userIDVal_Lbl.Location = new Point(215, 94);
            userIDVal_Lbl.Name = "userIDVal_Lbl";
            userIDVal_Lbl.Size = new Size(94, 25);
            userIDVal_Lbl.TabIndex = 6;
            userIDVal_Lbl.Text = "UserIDVal";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.White;
            label3.Location = new Point(85, 94);
            label3.Name = "label3";
            label3.Size = new Size(82, 25);
            label3.TabIndex = 5;
            label3.Text = "User ID:";
            // 
            // topLabel_Lbl
            // 
            topLabel_Lbl.AutoSize = true;
            topLabel_Lbl.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            topLabel_Lbl.ForeColor = Color.White;
            topLabel_Lbl.Location = new Point(236, 29);
            topLabel_Lbl.Name = "topLabel_Lbl";
            topLabel_Lbl.Size = new Size(137, 32);
            topLabel_Lbl.TabIndex = 5;
            topLabel_Lbl.Text = "TOP LABEL";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.ForeColor = Color.White;
            label1.Location = new Point(91, 72);
            label1.Name = "label1";
            label1.Size = new Size(468, 15);
            label1.TabIndex = 6;
            label1.Text = "Notes- if selected(Super Admin(All Access w/ Manage Users) Admin, Custom User etc...";
            // 
            // ChangeRole
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1250, 343);
            Controls.Add(panel1);
            Name = "ChangeRole";
            Text = "ChangeRole";
            Load += ChangeRole_Load;
            panel1.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Panel panel2;
        private Label label2;
        private Label label6;
        private Button change_Btn;
        private ComboBox newRole_Cb;
        private Panel panel3;
        private Label label3;
        private Label label4;
        private Label label5;
        public Label nameVal_Lbl;
        public Label currentRoleVal_Lbl;
        public Label userIDVal_Lbl;
        private Label topLabel_Lbl;
        private Label label1;
    }
}