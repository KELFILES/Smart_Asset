namespace Smart_Asset
{
    partial class RightClick
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
            retrieve_Btn = new Button();
            SuspendLayout();
            // 
            // retrieve_Btn
            // 
            retrieve_Btn.Location = new Point(12, 12);
            retrieve_Btn.Name = "retrieve_Btn";
            retrieve_Btn.Size = new Size(147, 34);
            retrieve_Btn.TabIndex = 0;
            retrieve_Btn.Text = "Retrive";
            retrieve_Btn.UseVisualStyleBackColor = true;
            // 
            // RightClick
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(171, 254);
            Controls.Add(retrieve_Btn);
            FormBorderStyle = FormBorderStyle.None;
            Name = "RightClick";
            Text = "RightClick";
            ResumeLayout(false);
        }

        #endregion

        private Button retrieve_Btn;
    }
}