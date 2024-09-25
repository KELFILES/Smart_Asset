namespace Smart_Asset
{
    partial class EditPage
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
            crud_Panel = new Panel();
            swap_Rdb = new RadioButton();
            deployment_Rdb = new RadioButton();
            transfer_Rdb = new RadioButton();
            update_Rdb = new RadioButton();
            mainPanel = new Panel();
            qmark_Btn = new Button();
            crud_Panel.SuspendLayout();
            SuspendLayout();
            // 
            // crud_Panel
            // 
            crud_Panel.AutoScroll = true;
            crud_Panel.BackColor = Color.DimGray;
            crud_Panel.Controls.Add(qmark_Btn);
            crud_Panel.Controls.Add(swap_Rdb);
            crud_Panel.Controls.Add(deployment_Rdb);
            crud_Panel.Controls.Add(transfer_Rdb);
            crud_Panel.Controls.Add(update_Rdb);
            crud_Panel.Dock = DockStyle.Top;
            crud_Panel.Location = new Point(0, 0);
            crud_Panel.Margin = new Padding(3, 3, 10, 3);
            crud_Panel.Name = "crud_Panel";
            crud_Panel.Padding = new Padding(8, 0, 8, 0);
            crud_Panel.Size = new Size(1584, 47);
            crud_Panel.TabIndex = 8;
            // 
            // swap_Rdb
            // 
            swap_Rdb.AutoSize = true;
            swap_Rdb.Dock = DockStyle.Left;
            swap_Rdb.ForeColor = Color.White;
            swap_Rdb.Location = new Point(580, 0);
            swap_Rdb.Name = "swap_Rdb";
            swap_Rdb.Padding = new Padding(50, 0, 0, 0);
            swap_Rdb.Size = new Size(162, 47);
            swap_Rdb.TabIndex = 5;
            swap_Rdb.TabStop = true;
            swap_Rdb.Text = "Swap Hardwares";
            swap_Rdb.UseVisualStyleBackColor = true;
            swap_Rdb.CheckedChanged += swap_Rdb_CheckedChanged;
            // 
            // deployment_Rdb
            // 
            deployment_Rdb.AutoSize = true;
            deployment_Rdb.Dock = DockStyle.Left;
            deployment_Rdb.ForeColor = Color.White;
            deployment_Rdb.Location = new Point(409, 0);
            deployment_Rdb.Name = "deployment_Rdb";
            deployment_Rdb.Padding = new Padding(50, 0, 0, 0);
            deployment_Rdb.Size = new Size(171, 47);
            deployment_Rdb.TabIndex = 4;
            deployment_Rdb.TabStop = true;
            deployment_Rdb.Text = "Deploy Hardwares";
            deployment_Rdb.UseVisualStyleBackColor = true;
            deployment_Rdb.CheckedChanged += deployment_Rdb_CheckedChanged;
            // 
            // transfer_Rdb
            // 
            transfer_Rdb.AutoSize = true;
            transfer_Rdb.Dock = DockStyle.Left;
            transfer_Rdb.ForeColor = Color.White;
            transfer_Rdb.Location = new Point(207, 0);
            transfer_Rdb.Name = "transfer_Rdb";
            transfer_Rdb.Padding = new Padding(50, 0, 0, 0);
            transfer_Rdb.Size = new Size(202, 47);
            transfer_Rdb.TabIndex = 3;
            transfer_Rdb.TabStop = true;
            transfer_Rdb.Text = "Transfer Hardwares Data";
            transfer_Rdb.UseVisualStyleBackColor = true;
            transfer_Rdb.CheckedChanged += transfer_Rdb_CheckedChanged;
            // 
            // update_Rdb
            // 
            update_Rdb.AutoSize = true;
            update_Rdb.Dock = DockStyle.Left;
            update_Rdb.ForeColor = Color.White;
            update_Rdb.Location = new Point(8, 0);
            update_Rdb.Name = "update_Rdb";
            update_Rdb.Padding = new Padding(50, 0, 0, 0);
            update_Rdb.Size = new Size(199, 47);
            update_Rdb.TabIndex = 2;
            update_Rdb.TabStop = true;
            update_Rdb.Text = "Modify Hardwares Data";
            update_Rdb.UseVisualStyleBackColor = true;
            update_Rdb.CheckedChanged += update_Rdb_CheckedChanged;
            // 
            // mainPanel
            // 
            mainPanel.AutoScroll = true;
            mainPanel.BackColor = Color.FromArgb(30, 30, 45);
            mainPanel.Dock = DockStyle.Fill;
            mainPanel.Location = new Point(0, 47);
            mainPanel.Name = "mainPanel";
            mainPanel.Size = new Size(1584, 814);
            mainPanel.TabIndex = 9;
            // 
            // qmark_Btn
            // 
            qmark_Btn.FlatStyle = FlatStyle.Flat;
            qmark_Btn.Font = new Font("Segoe UI", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            qmark_Btn.ForeColor = SystemColors.ButtonFace;
            qmark_Btn.Image = Properties.Resources.questionMark_Icon;
            qmark_Btn.Location = new Point(1551, 13);
            qmark_Btn.Name = "qmark_Btn";
            qmark_Btn.Size = new Size(21, 21);
            qmark_Btn.TabIndex = 58;
            qmark_Btn.UseVisualStyleBackColor = true;
            // 
            // EditPage
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1584, 861);
            Controls.Add(mainPanel);
            Controls.Add(crud_Panel);
            Name = "EditPage";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Edit";
            crud_Panel.ResumeLayout(false);
            crud_Panel.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel crud_Panel;
        private RadioButton swap_Rdb;
        private RadioButton deployment_Rdb;
        private RadioButton transfer_Rdb;
        private RadioButton update_Rdb;
        private Panel mainPanel;
        private Button qmark_Btn;
    }
}