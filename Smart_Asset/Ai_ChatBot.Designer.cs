
namespace Smart_Asset
{
    partial class Ai_ChatBot
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
            panel4 = new Panel();
            panel2 = new Panel();
            panel3 = new Panel();
            mainFlowLayoutPanel = new FlowLayoutPanel();
            panel5 = new Panel();
            groupBox1 = new GroupBox();
            panel8 = new Panel();
            panel6 = new Panel();
            insertFile_Btn = new Button();
            panel7 = new Panel();
            label1 = new Label();
            send_Btn = new Button();
            typeQuestion_Rt = new RichTextBox();
            progress_Lbl = new Label();
            panel1.SuspendLayout();
            panel4.SuspendLayout();
            panel3.SuspendLayout();
            groupBox1.SuspendLayout();
            panel8.SuspendLayout();
            panel6.SuspendLayout();
            panel7.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(panel4);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1648, 1083);
            panel1.TabIndex = 0;
            // 
            // panel4
            // 
            panel4.AutoScroll = true;
            panel4.BackColor = Color.FromArgb(0, 108, 183);
            panel4.Controls.Add(panel2);
            panel4.Controls.Add(panel3);
            panel4.Controls.Add(groupBox1);
            panel4.Dock = DockStyle.Fill;
            panel4.Location = new Point(0, 0);
            panel4.Name = "panel4";
            panel4.Padding = new Padding(50, 20, 50, 20);
            panel4.Size = new Size(1648, 1083);
            panel4.TabIndex = 2;

            // 
            // panel2
            // 
            panel2.Dock = DockStyle.Bottom;
            panel2.Location = new Point(50, 912);
            panel2.Name = "panel2";
            panel2.Size = new Size(1548, 10);
            panel2.TabIndex = 13;
            // 
            // panel3
            // 
            panel3.Controls.Add(mainFlowLayoutPanel);
            panel3.Controls.Add(panel5);
            panel3.Dock = DockStyle.Fill;
            panel3.Location = new Point(50, 20);
            panel3.Name = "panel3";
            panel3.Size = new Size(1548, 902);
            panel3.TabIndex = 11;
            // 
            // mainFlowLayoutPanel
            // 
            mainFlowLayoutPanel.AutoScroll = true;
            mainFlowLayoutPanel.AutoSize = true;
            mainFlowLayoutPanel.BackColor = Color.FromArgb(231, 235, 221);
            mainFlowLayoutPanel.Dock = DockStyle.Fill;
            mainFlowLayoutPanel.FlowDirection = FlowDirection.TopDown;
            mainFlowLayoutPanel.Location = new Point(0, 0);
            mainFlowLayoutPanel.Name = "mainFlowLayoutPanel";
            mainFlowLayoutPanel.Size = new Size(1548, 892);
            mainFlowLayoutPanel.TabIndex = 12;
            mainFlowLayoutPanel.WrapContents = false;

            // 
            // panel5
            // 
            panel5.Dock = DockStyle.Bottom;
            panel5.Location = new Point(0, 892);
            panel5.Name = "panel5";
            panel5.Size = new Size(1548, 10);
            panel5.TabIndex = 13;
            // 
            // groupBox1
            // 
            groupBox1.BackColor = Color.FromArgb(253, 175, 23);
            groupBox1.Controls.Add(panel8);
            groupBox1.Dock = DockStyle.Bottom;
            groupBox1.FlatStyle = FlatStyle.Popup;
            groupBox1.Location = new Point(50, 922);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(1548, 141);
            groupBox1.TabIndex = 12;
            groupBox1.TabStop = false;
            // 
            // panel8
            // 
            panel8.Controls.Add(panel6);
            panel8.Controls.Add(panel7);
            panel8.Dock = DockStyle.Fill;
            panel8.Location = new Point(3, 19);
            panel8.Name = "panel8";
            panel8.Size = new Size(1542, 119);
            panel8.TabIndex = 14;
            // 
            // panel6
            // 
            panel6.Controls.Add(insertFile_Btn);
            panel6.Controls.Add(progress_Lbl);
            panel6.Dock = DockStyle.Top;
            panel6.Location = new Point(0, 0);
            panel6.Name = "panel6";
            panel6.Size = new Size(1542, 53);
            panel6.TabIndex = 0;
            // 
            // insertFile_Btn
            // 
            insertFile_Btn.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            insertFile_Btn.BackColor = Color.FromArgb(255, 243, 26);
            insertFile_Btn.FlatStyle = FlatStyle.Flat;
            insertFile_Btn.Font = new Font("Segoe UI", 11.25F);
            insertFile_Btn.Location = new Point(702, 10);
            insertFile_Btn.Name = "insertFile_Btn";
            insertFile_Btn.Size = new Size(155, 35);
            insertFile_Btn.TabIndex = 13;
            insertFile_Btn.Text = "Insert File";
            insertFile_Btn.UseVisualStyleBackColor = false;

            // 
            // panel7
            // 
            panel7.Controls.Add(label1);
            panel7.Controls.Add(send_Btn);
            panel7.Controls.Add(typeQuestion_Rt);
            panel7.Dock = DockStyle.Fill;
            panel7.Location = new Point(0, 0);
            panel7.Name = "panel7";
            panel7.Size = new Size(1542, 119);
            panel7.TabIndex = 1;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(80, 65);
            label1.Name = "label1";
            label1.Size = new Size(83, 21);
            label1.TabIndex = 8;
            label1.Text = "Question:";
            // 
            // send_Btn
            // 
            send_Btn.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            send_Btn.BackColor = Color.FromArgb(255, 243, 26);
            send_Btn.FlatStyle = FlatStyle.Flat;
            send_Btn.Font = new Font("Segoe UI", 11.25F);
            send_Btn.Location = new Point(1299, 56);
            send_Btn.Name = "send_Btn";
            send_Btn.Size = new Size(135, 36);
            send_Btn.TabIndex = 6;
            send_Btn.Text = "Send";
            send_Btn.UseVisualStyleBackColor = false;

            // 
            // typeQuestion_Rt
            // 
            typeQuestion_Rt.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            typeQuestion_Rt.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            typeQuestion_Rt.Location = new Point(166, 61);
            typeQuestion_Rt.Name = "typeQuestion_Rt";
            typeQuestion_Rt.ScrollBars = RichTextBoxScrollBars.None;
            typeQuestion_Rt.Size = new Size(1117, 27);
            typeQuestion_Rt.TabIndex = 10;
            typeQuestion_Rt.Text = "";

            // 
            // progress_Lbl
            // 
            progress_Lbl.AutoSize = true;
            progress_Lbl.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            progress_Lbl.ForeColor = SystemColors.ControlLightLight;
            progress_Lbl.Location = new Point(89, 17);
            progress_Lbl.Name = "progress_Lbl";
            progress_Lbl.Size = new Size(0, 20);
            progress_Lbl.TabIndex = 12;
            // 
            // AiChat
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1648, 1083);
            Controls.Add(panel1);
            Name = "AiChat";
            Text = "AiChat";
            panel1.ResumeLayout(false);
            panel4.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            groupBox1.ResumeLayout(false);
            panel8.ResumeLayout(false);
            panel6.ResumeLayout(false);
            panel6.PerformLayout();
            panel7.ResumeLayout(false);
            panel7.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Panel panel4;
        private Panel panel3;
        private FlowLayoutPanel mainFlowLayoutPanel;
        private Panel panel5;
        private Panel panel2;
        private GroupBox groupBox1;
        private Panel panel8;
        private Panel panel6;
        private Button insertFile_Btn;
        private Panel panel7;
        private Label label1;
        private Button send_Btn;
        private RichTextBox typeQuestion_Rt;
        private Label progress_Lbl;
    }
}