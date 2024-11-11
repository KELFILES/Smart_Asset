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



    }
}
    
