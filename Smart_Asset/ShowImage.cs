using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Smart_Asset
{
    public partial class ShowImage : Form
    {
        public ShowImage()
        {
            InitializeComponent();
        }

        //FIELDS
        private float zoomFactor = 1.0f; // Initial zoom level
        bool isImageFound;


        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000; // WS_EX_COMPOSITED
                return cp;
            }
        }

        private async void pictureBox1_LoadCompleted(object sender, AsyncCompletedEventArgs e)
        {

        }

        private async void ShowImage_Load(object sender, EventArgs e)
        {
            await MyDbMethods.ImgGetToPictureBoxAsync($"{serialNoValue_Lb.Text}", "SmartAssetDb", "Images", pictureBox1);

            // Check if the PictureBox still has no image after the method call
            if (pictureBox1.Image == null)
            {
                // If no image was found, load the default image "noImageFound.png"
                pictureBox1.Image = Image.FromFile(System.IO.Path.Combine(Application.StartupPath, "Images", "noImageFound.png"));

                isImageFound = false;
            }
            else
            {
                isImageFound = true;
            }
        }

        private async void upload_Btn_Click(object sender, EventArgs e)
        {
                if(isImageFound == true)
                {
                    DialogResult result = MessageBox.Show(
                    "An image already exists. Do you want to overwrite it?",
                    "Overwrite Confirmation",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                    );

                    if (result == DialogResult.Yes)
                    {
                        // User clicked "Yes" to overwrite the image

                        string pathName = MyDbMethods.SelectImageFromFileExplorer();

                        if (!string.IsNullOrEmpty(pathName))
                        {
                            //Insert image to database
                            await MyDbMethods.ImgInsertToDbAsync(pathName, $"{serialNoValue_Lb.Text}", "SmartAssetDb", "Images");
                        }

                        await MyDbMethods.ImgGetToPictureBoxAsync($"{serialNoValue_Lb.Text}", "SmartAssetDb", "Images", pictureBox1);
                    }
                    else if (result == DialogResult.No)
                    {
                        // User clicked "No" to cancel
                        MessageBox.Show("Operation canceled. The image was not overwritten.");
                    }
                }
                else
                {
                    string pathName = MyDbMethods.SelectImageFromFileExplorer();

                    if (!string.IsNullOrEmpty(pathName))
                    {
                        //Insert image to database
                        await MyDbMethods.ImgInsertToDbAsync(pathName, $"{serialNoValue_Lb.Text}", "SmartAssetDb", "Images");
                    }

                    await MyDbMethods.ImgGetToPictureBoxAsync($"{serialNoValue_Lb.Text}", "SmartAssetDb", "Images", pictureBox1);
                }

        }

        private void save_Btn_Click(object sender, EventArgs e)
        {
            if (isImageFound == true)
            {
                // Open folder selection dialog
                string folderPath = MyDbMethods.SelectFolderFromFileExplorer();

                // Ensure the file path includes the ".png" extension
                string fileName = $"{serialNoValue_Lb.Text}.png"; // Append ".png" to the file name
                string filePath = System.IO.Path.Combine(folderPath, fileName);

                // Save the image from the PictureBox to the full file path
                MyDbMethods.SaveImageFromPictureBox(pictureBox1, filePath, System.Drawing.Imaging.ImageFormat.Png);
            }
            else
            {
                MessageBox.Show("CANNOT SAVE NO IMAGE");
            }
        }


    }
}
