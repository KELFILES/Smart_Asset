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
    public partial class GenerateQR : Form
    {
        public GenerateQR()
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

        private void GenerateQR_Load(object sender, EventArgs e)
        {

        }

        //FIELDS
        private bool isQr1havePhoto = false;
        private bool isQr2havePhoto = false;

        private async void location_Cmb_DropDown(object sender, EventArgs e)
        {
            // Clear existing items and load from database
            location_Cmb.Items.Clear();

            Cursor = Cursors.WaitCursor;
            await MyDbMethods.LoadDatabase_TypeList("SmartAssetDb", "Deployment_Location_List", location_Cmb);
            Cursor = Cursors.Arrow;
        }

        private async void unit_Cmb_DropDown(object sender, EventArgs e)
        {
            // Clear existing items and load from database
            unit_Cmb.Items.Clear();

            Cursor = Cursors.WaitCursor;
            await MyDbMethods.LoadDatabase_TypeList("SmartAssetDb", "Deployment_Unit_List", unit_Cmb);
            Cursor = Cursors.Arrow;

            // Insert "N/A" at the first position
            //unit_Cmb.Items.Insert(0, "N/A");
        }

        private void serial2_Cb_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = char.ToUpper(e.KeyChar);
        }

        private async void serial2_Cb_MouseEnter(object sender, EventArgs e)
        {

        }

        private async void generate_Btn_Click(object sender, EventArgs e)
        {
            isQr1havePhoto = true;

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

        private async void button2_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(location_Cmb.Text) && String.IsNullOrEmpty(unit_Cmb.Text) ||
                location_Cmb.Text.Equals("") && unit_Cmb.Text.Equals(""))
            {
                MessageBox.Show("Location and Unit is Required");
                return;
            }

            else if (String.IsNullOrEmpty(location_Cmb.Text) || location_Cmb.Text.Equals(""))
            {
                MessageBox.Show("Location is Required");
                return;
            }

            else if (String.IsNullOrEmpty(unit_Cmb.Text) || unit_Cmb.Text.Equals(""))
            {
                MessageBox.Show("Unit is Required");
                return;
            }








            isQr2havePhoto = true;

            // Clear the previous image from the PictureBox
            if (qr2_pictureBox.Image != null)
            {
                qr2_pictureBox.Image.Dispose(); // Dispose of the previous image to free resources
                qr2_pictureBox.Image = null; // Remove the reference to the old image
            }

            // The text or URL to encode in the QR code (directly using a string here)
            string textToEncode = location_Cmb.Text + "_" + unit_Cmb.Text; // Replace with the URL or text to encode
            Console.WriteLine("EYYY" + textToEncode);
            // Get the dimensions from the PictureBox
            int width = qr2_pictureBox.Width;
            int height = qr2_pictureBox.Height;

            try
            {
                // Generate the QR code and display it in the PictureBox asynchronously
                var qrCodeImage = await MyOtherMethods.GenerateQRCodeAsync(textToEncode, width, height);

                if (qrCodeImage != null)
                {
                    qr2_pictureBox.Image = qrCodeImage; // Assign the generated QR code image to the PictureBox
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

        private void button3_Click(object sender, EventArgs e)
        {
            if (qr_pictureBox != null && isQr1havePhoto == true)
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
            else
            {
                MessageBox.Show("CANNOT SAVE NO IMAGE");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (qr_pictureBox != null && isQr1havePhoto == true)
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
            else
            {
                MessageBox.Show("CANNOT SAVE NO IMAGE");
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (qr_pictureBox != null && isQr2havePhoto == true)
            {
                // Open folder selection dialog
                string folderPath = MyDbMethods.SelectFolderFromFileExplorer();

                // Check if a valid folder path was selected
                if (!string.IsNullOrEmpty(folderPath))
                {
                    // Ensure the file path includes the ".png" extension
                    string fileName = $"{location_Cmb.Text}_{unit_Cmb.Text}.png"; // Append ".png" to the file name
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
            else
            {
                MessageBox.Show("CANNOT SAVE NO IMAGE");
            }
        }

        private async void serial2_Cb_Enter(object sender, EventArgs e)
        {
            await MyDbMethods.LoadDatabase_AllSerialNo("SmartAssetDb", serial2_Cb);
        }
    }
}
