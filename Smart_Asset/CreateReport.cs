using MongoDB.Bson;
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
    public partial class CreateReport : Form
    {
        public CreateReport()
        {
            InitializeComponent();
        }

        private async void CreateReport_Load(object sender, EventArgs e)
        {
            MyOtherMethods.CenterInPanel(topText_Lbl, panel2);

            var retrievedDbData = await MyDbMethods.ReadAllDatabaseInBSON("SmartAssetDb");




            CreateReportsMethod.ShowReports(retrievedDbData, mainboard_Tb);
        }

        private void CreateReport_SizeChanged(object sender, EventArgs e)
        {
            MyOtherMethods.CenterInPanel(topText_Lbl, panel2);
        }

        private async void export_Btn_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(exportTo_Cb.Text) || exportTo_Cb.Text.Equals(""))
            {
                MessageBox.Show("Please select a file format!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                // Set appropriate file filters
                if (exportTo_Cb.Text.Equals("Microsoft Word File (.docx)"))
                {
                    saveFileDialog.Filter = "Word Documents (*.docx)|*.docx";
                    saveFileDialog.FileName = "ExportedFile.docx";
                }
                else if (exportTo_Cb.Text.Equals("PDF File (.pdf)"))
                {
                    saveFileDialog.Filter = "PDF Files (*.pdf)|*.pdf";
                    saveFileDialog.FileName = "ExportedFile.pdf";
                }
                else
                {
                    MessageBox.Show("Please select a valid file format.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Show the SaveFileDialog
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = saveFileDialog.FileName;

                    // Validate and export
                    if (!string.IsNullOrWhiteSpace(filePath))
                    {
                        try
                        {
                            if (exportTo_Cb.Text.Equals("Microsoft Word File (.docx)"))
                            {
                                await Exporter.ExportTextBoxToWord(mainboard_Tb, filePath);
                            }
                            else if (exportTo_Cb.Text.Equals("PDF File (.pdf)"))
                            {
                                await Exporter.ExportTextBoxToPdf(mainboard_Tb, filePath);
                            }

                            //MessageBox.Show($"Export completed successfully!\nFile saved to: {filePath}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Invalid file path selected.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Export canceled.", "Canceled", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }



    }
}
