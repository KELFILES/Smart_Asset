using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZXing;
using ZXing.Common;
using ZXing.QrCode;

namespace Smart_Asset
{
    public static class MyOtherMethods
    {

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


    }
}
