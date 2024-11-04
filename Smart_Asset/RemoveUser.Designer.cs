namespace Smart_Asset
{
    partial class RemoveUser
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
            removeUser_Btn = new Button();
            password_Tb = new TextBox();
            label4 = new Label();
            label3 = new Label();
            nameVal_Lbl = new Label();
            userIDVal_Lbl = new Label();
            label2 = new Label();
            label1 = new Label();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.DimGray;
            panel1.Controls.Add(panel2);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Padding = new Padding(7);
            panel1.Size = new Size(600, 350);
            panel1.TabIndex = 0;
            // 
            // panel2
            // 
            panel2.BackColor = Color.Gray;
            panel2.Controls.Add(removeUser_Btn);
            panel2.Controls.Add(password_Tb);
            panel2.Controls.Add(label4);
            panel2.Controls.Add(label3);
            panel2.Controls.Add(nameVal_Lbl);
            panel2.Controls.Add(userIDVal_Lbl);
            panel2.Controls.Add(label2);
            panel2.Controls.Add(label1);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(7, 7);
            panel2.Name = "panel2";
            panel2.Size = new Size(586, 336);
            panel2.TabIndex = 8;
            // 
            // removeUser_Btn
            // 
            removeUser_Btn.Location = new Point(216, 262);
            removeUser_Btn.Name = "removeUser_Btn";
            removeUser_Btn.Size = new Size(130, 32);
            removeUser_Btn.TabIndex = 15;
            removeUser_Btn.Text = "Remove User";
            removeUser_Btn.UseVisualStyleBackColor = true;
            removeUser_Btn.Click += removeUser_Btn_Click;
            // 
            // password_Tb
            // 
            password_Tb.Location = new Point(263, 205);
            password_Tb.Name = "password_Tb";
            password_Tb.PasswordChar = '*';
            password_Tb.Size = new Size(234, 23);
            password_Tb.TabIndex = 14;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.White;
            label4.Location = new Point(88, 207);
            label4.Name = "label4";
            label4.Size = new Size(169, 21);
            label4.TabIndex = 13;
            label4.Text = "Enter Your Password:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.White;
            label3.Location = new Point(31, 42);
            label3.Name = "label3";
            label3.Size = new Size(524, 30);
            label3.TabIndex = 12;
            label3.Text = "ARE YOU SURE YOU WANT TO REMOVE THIS USER?";
            // 
            // nameVal_Lbl
            // 
            nameVal_Lbl.AutoSize = true;
            nameVal_Lbl.Font = new Font("Segoe UI", 15.75F);
            nameVal_Lbl.ForeColor = Color.White;
            nameVal_Lbl.Location = new Point(184, 137);
            nameVal_Lbl.Name = "nameVal_Lbl";
            nameVal_Lbl.Size = new Size(96, 30);
            nameVal_Lbl.TabIndex = 11;
            nameVal_Lbl.Text = "NameVal";
            // 
            // userIDVal_Lbl
            // 
            userIDVal_Lbl.AutoSize = true;
            userIDVal_Lbl.Font = new Font("Segoe UI", 15.75F);
            userIDVal_Lbl.ForeColor = Color.White;
            userIDVal_Lbl.Location = new Point(184, 97);
            userIDVal_Lbl.Name = "userIDVal_Lbl";
            userIDVal_Lbl.Size = new Size(106, 30);
            userIDVal_Lbl.TabIndex = 10;
            userIDVal_Lbl.Text = "UserIDVal:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.White;
            label2.Location = new Point(88, 137);
            label2.Name = "label2";
            label2.Size = new Size(77, 30);
            label2.TabIndex = 9;
            label2.Text = "Name:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(88, 97);
            label1.Name = "label1";
            label1.Size = new Size(90, 30);
            label1.TabIndex = 8;
            label1.Text = "User ID:";
            // 
            // RemoveUser
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(600, 350);
            Controls.Add(panel1);
            Name = "RemoveUser";
            Text = "RemoveUser";
            FormClosed += RemoveUser_FormClosed;
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Panel panel2;
        private Button removeUser_Btn;
        private TextBox password_Tb;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        public Label nameVal_Lbl;
        public Label userIDVal_Lbl;
    }
}