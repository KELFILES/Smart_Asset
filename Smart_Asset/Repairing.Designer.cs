namespace Smart_Asset
{
    partial class Repairing
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
            components = new System.ComponentModel.Container();
            panel1 = new Panel();
            panel3 = new Panel();
            dataGridView1 = new DataGridView();
            panel2 = new Panel();
            panel5 = new Panel();
            panel4 = new Panel();
            myDbMethodsBindingSource = new BindingSource(components);
            panel1.SuspendLayout();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)myDbMethodsBindingSource).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(panel3);
            panel1.Controls.Add(panel2);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1109, 761);
            panel1.TabIndex = 0;
            // 
            // panel3
            // 
            panel3.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel3.BackColor = SystemColors.ControlDark;
            panel3.Controls.Add(dataGridView1);
            panel3.Location = new Point(12, 445);
            panel3.Name = "panel3";
            panel3.Size = new Size(1085, 304);
            panel3.TabIndex = 1;
            // 
            // dataGridView1
            // 
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.Dock = DockStyle.Fill;
            dataGridView1.Location = new Point(0, 0);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.Size = new Size(1085, 304);
            dataGridView1.TabIndex = 0;
            // 
            // panel2
            // 
            panel2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panel2.BackColor = Color.Gray;
            panel2.Controls.Add(panel5);
            panel2.Controls.Add(panel4);
            panel2.Location = new Point(12, 12);
            panel2.Name = "panel2";
            panel2.Size = new Size(1085, 427);
            panel2.TabIndex = 0;
            // 
            // panel5
            // 
            panel5.Anchor = AnchorStyles.Top;
            panel5.BackColor = Color.DimGray;
            panel5.Location = new Point(545, 13);
            panel5.Name = "panel5";
            panel5.Size = new Size(524, 400);
            panel5.TabIndex = 1;
            // 
            // panel4
            // 
            panel4.Anchor = AnchorStyles.Top;
            panel4.BackColor = Color.DimGray;
            panel4.Location = new Point(15, 13);
            panel4.Name = "panel4";
            panel4.Size = new Size(524, 400);
            panel4.TabIndex = 0;
            // 
            // myDbMethodsBindingSource
            // 
            myDbMethodsBindingSource.DataSource = typeof(MyDbMethods);
            // 
            // Repairing
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1109, 761);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Repairing";
            Text = "Repairing";
            Shown += Repairing_Shown;
            panel1.ResumeLayout(false);
            panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)myDbMethodsBindingSource).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Panel panel3;
        private Panel panel2;
        private Panel panel5;
        private Panel panel4;
        private DataGridView dataGridView1;
        private BindingSource myDbMethodsBindingSource;
    }
}