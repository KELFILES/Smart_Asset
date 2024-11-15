using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZXing;
using ZXing.Common;
using ZXing.QrCode;
using System.Security.Cryptography;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using System.Drawing.Drawing2D;

namespace Smart_Asset
{
    public static class MyOtherMethods
    {
        internal static Settings1 s1 = new Settings1();

        //FOR QR CODE
        public static async Task<Bitmap> GenerateQRCodeAsync(string text, int width, int height)
        {
            try
            {
                // Run the QR code generation on a separate thread
                return await Task.Run(() =>
                {
                    // Create a BarcodeWriterPixelData instance
                    var barcodeWriter = new BarcodeWriterPixelData
                    {
                        Format = BarcodeFormat.QR_CODE, // Set the format to QR Code
                        Options = new EncodingOptions
                        {
                            Width = width,   // Set the width to match the PictureBox width
                            Height = height, // Set the height to match the PictureBox height
                            Margin = 1       // Ensure minimal margin to avoid cropping
                        }
                    };

                    // Generate the pixel data for the QR code
                    var pixelData = barcodeWriter.Write(text);

                    // Create a Bitmap from the pixel data
                    var bitmap = new Bitmap(pixelData.Width, pixelData.Height, PixelFormat.Format32bppRgb);
                    var bitmapData = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height),
                        ImageLockMode.WriteOnly, PixelFormat.Format32bppRgb);

                    try
                    {
                        // Copy the pixel data into the bitmap
                        System.Runtime.InteropServices.Marshal.Copy(pixelData.Pixels, 0, bitmapData.Scan0, pixelData.Pixels.Length);
                    }
                    finally
                    {
                        bitmap.UnlockBits(bitmapData);
                    }

                    // Return the bitmap directly (let PictureBox handle resizing)
                    return bitmap;
                });
            }
            catch (Exception ex)
            {
                // Log or handle the exception
                MessageBox.Show($"Error generating QR code: {ex.Message}");
                return null;
            }
        }








        // Key and IV should be stored securely. For example, you can store them in environment variables.
        private static readonly byte[] Key = Encoding.UTF8.GetBytes("stimunozedsa1234"); // 16 characters
        private static readonly byte[] IV = Encoding.UTF8.GetBytes("edsamunozsti1234"); // 16 characters

        public static string EncryptPassword(string password)
        {
            try
            {
                using (Aes aes = Aes.Create())
                {
                    aes.Key = Key;
                    aes.IV = IV;

                    ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);

                    using (MemoryStream ms = new MemoryStream())
                    {
                        using (CryptoStream cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
                        {
                            using (StreamWriter sw = new StreamWriter(cs))
                            {
                                sw.Write(password);
                            }
                        }
                        return Convert.ToBase64String(ms.ToArray());
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error during encryption: " + ex.Message);
                throw;
            }
        }

        public static string DecryptPassword(string encryptedPassword)
        {
            try
            {
                if (string.IsNullOrEmpty(encryptedPassword))
                {
                    throw new ArgumentException("The encrypted password cannot be null or empty.");
                }

                using (Aes aes = Aes.Create())
                {
                    aes.Key = Key;
                    aes.IV = IV;

                    ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);

                    byte[] buffer = Convert.FromBase64String(encryptedPassword);

                    using (MemoryStream ms = new MemoryStream(buffer))
                    {
                        using (CryptoStream cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read))
                        {
                            using (StreamReader sr = new StreamReader(cs))
                            {
                                return sr.ReadToEnd();
                            }
                        }
                    }
                }
            }
            catch (System.FormatException ex)
            {
                Console.WriteLine("The encryptedPassword is not a valid Base-64 string. " + ex.Message);
                throw;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error during decryption: " + ex.Message);
                throw;
            }
        }



        public static void CenterInPanel(Label lblName, Panel pnlName)
        {
            lblName.Location = new Point((pnlName.Width - lblName.Width) / 2, lblName.Location.Y);
        }
        public static void CenterInPanel(Button BtnName, Panel pnlName)
        {
            BtnName.Location = new Point((pnlName.Width - BtnName.Width) / 2, BtnName.Location.Y);
        }
        public static void CenterInForm(Panel PnlName, Form frmName)
        {
            PnlName.Location = new Point((frmName.Width - PnlName.Width) / 2, PnlName.Location.Y);
        }
        public static void AlignToRightCorner(Panel pnlName, Form frmName)
        {
            // Set the panel's location to the right corner of the form
            pnlName.Location = new Point(frmName.Width - pnlName.Width - 10, pnlName.Location.Y);
        }

        public static void SaveExistingFileToComputer()
        {
            // Path to the file inside your project (adjust as needed)
            string sourceFilePath = System.IO.Path.Combine(Application.StartupPath, "Files", "Example Excel File.xlsx");

            // Extract the original file name
            string originalFileName = Path.GetFileName(sourceFilePath);

            using (FolderBrowserDialog folderDialog = new FolderBrowserDialog())
            {
                folderDialog.Description = "Select a folder to save the file";

                if (folderDialog.ShowDialog() == DialogResult.OK)
                {
                    // Get the selected folder path
                    string destinationFolder = folderDialog.SelectedPath;

                    // Combine the folder path with the original file name
                    string destinationFilePath = Path.Combine(destinationFolder, originalFileName);

                    try
                    {
                        // Copy the file to the selected location with the original file name
                        File.Copy(sourceFilePath, destinationFilePath, true);
                        MessageBox.Show($"File '{originalFileName}' saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error saving file: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }


        public static void ApplyGradient(Panel panel, Color color1, Color color2)
        {
            panel.Paint += (sender, e) =>
            {
                Rectangle rect = panel.ClientRectangle;

                // Create a LinearGradientBrush with two colors
                using (LinearGradientBrush brush = new LinearGradientBrush(rect, color1, color2, 90f))
                {
                    // Fill the Panel with the gradient
                    e.Graphics.FillRectangle(brush, rect);
                }
            };

            // Refresh the panel to trigger the Paint event
            panel.Invalidate();
        }


        public static void CenterAlignPanelsHorizontally(Panel parentPanel, List<Panel> childPanels)
        {
            if (childPanels == null || childPanels.Count == 0) return;

            int gap = 10; // Space between each panel

            // Calculate the total width of all panels including the gaps
            int totalWidth = childPanels.Sum(panel => panel.Width) + gap * (childPanels.Count - 1);

            // Calculate the starting X position to center the panels horizontally
            int startX = (parentPanel.Width - totalWidth) / 2;
            int startY = (parentPanel.Height - childPanels[0].Height) / 2;

            // Align the panels from left to right
            int currentX = startX;

            foreach (var panel in childPanels)
            {
                // Set the location of the current panel
                panel.Location = new Point(currentX, startY);

                // Move the X position for the next panel
                currentX += panel.Width + gap;
            }
        }



        public static void FitMonthCalendarToPanel(Panel pnlName, MonthCalendar monthCalendar)
        {
            // Define padding value
            int padding = 5;

            // Calculate the maximum width and height for the MonthCalendar
            int maxWidth = pnlName.Width - (2 * padding);
            int maxHeight = pnlName.Height - (2 * padding);

            // Set the size of the MonthCalendar while ensuring it fits within the panel
            monthCalendar.Width = maxWidth;
            monthCalendar.Height = maxHeight;

            // Center the MonthCalendar within the panel
            monthCalendar.Left = (pnlName.Width - monthCalendar.Width) / 2;
            monthCalendar.Top = (pnlName.Height - monthCalendar.Height) / 2;
        }




    }
}
    
