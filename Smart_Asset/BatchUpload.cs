using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Smart_Asset
{
    public partial class BatchUpload : Form
    {
        public BatchUpload()
        {
            InitializeComponent();
        }

        private async void uploadFile_Btn_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Excel Files|*.xls;*.xlsx";
                openFileDialog.Title = "Select an Excel File for Batch Upload";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = openFileDialog.FileName;
                    await MyDbMethods.BatchUploadFromExcelAsync(filePath);
                }
            }
        }

        private void BatchUpload_Load(object sender, EventArgs e)
        {
            MyOtherMethods.CenterInPanel(label1, panel2);
            MyOtherMethods.CenterInPanel(instructions_Btn, panel2);
            MyOtherMethods.CenterInPanel(uploadFile_Btn, panel2);
            MyOtherMethods.CenterInPanel(label2, panel2);
        }

        private void instructions_Btn_Click(object sender, EventArgs e)
        {
            Instructions ins = new Instructions();
            ins.StartPosition = FormStartPosition.CenterScreen;
            ins.Show();
        }
    }
}
