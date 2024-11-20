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
    public partial class ShowQR : Form
    {
        public ShowQR()
        {
            InitializeComponent();

            // Enable double buffering for the entire form
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer |
                          ControlStyles.UserPaint |
                          ControlStyles.AllPaintingInWmPaint, true);
            this.UpdateStyles();
        }

        // Enable double buffering for the entire form
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000; // WS_EX_COMPOSITED
                return cp;
            }
        }

        private async void GenerateQR_Load(object sender, EventArgs e)
        {

            // Clear the previous image from the PictureBox
            if (qr_pictureBox.Image != null)
            {
                qr_pictureBox.Image.Dispose(); // Dispose of the previous image to free resources
                qr_pictureBox.Image = null; // Remove the reference to the old image
            }

            // The text or URL to encode in the QR code (directly using a string here)
            string textToEncode = serial2_Cb.Text; // Replace with the URL or text to encode

            // Get the dimensions from the PictureBox
            int width = qr_pictureBox.Width;
            int height = qr_pictureBox.Height;

            try
            {
                // Generate the QR code and display it in the PictureBox asynchronously
                var qrCodeImage = await MyOtherMethods.GenerateQRCodeAsync(textToEncode, width, height);

                if (qrCodeImage != null)
                {
                    qr_pictureBox.Image = qrCodeImage; // Assign the generated QR code image to the PictureBox
                }
                else
                {
                    MessageBox.Show("Failed to generate the QR code.");
                }
            }
            catch (Exception ex)
            {
                // Handle any errors that may occur
                MessageBox.Show($"Error: {ex.Message}", "QR Code Generation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        

        private void serial2_Cb_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = char.ToUpper(e.KeyChar);
        }

        private async void serial2_Cb_MouseEnter(object sender, EventArgs e)
        {

        }


        

        private void button3_Click(object sender, EventArgs e)
        {
            // Open folder selection dialog
            string folderPath = MyDbMethods.SelectFolderFromFileExplorer();

            // Check if a valid folder path was selected
            if (!string.IsNullOrEmpty(folderPath))
            {
                // Ensure the file path includes the ".png" extension
                string fileName = $"{serial2_Cb.Text}.png"; // Append ".png" to the file name
                string filePath = System.IO.Path.Combine(folderPath, fileName);

                // Save the image from the PictureBox to the full file path
                MyDbMethods.SaveImageFromPictureBox(qr_pictureBox, filePath, System.Drawing.Imaging.ImageFormat.Png);
            }
            else
            {
                // Handle the case where the user cancels the folder selection dialog
                MessageBox.Show("Save operation was canceled. No folder selected.");
            }
        }

        

        

        private async void serial2_Cb_Enter(object sender, EventArgs e)
        {
            await MyDbMethods.LoadDatabase_AllSerialNo("SmartAssetDb", serial2_Cb);
        }
    }
}
