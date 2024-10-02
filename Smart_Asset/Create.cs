using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using MongoDB.Driver.Core.Configuration;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static Smart_Asset.MyDbMethods;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Smart_Asset
{
    public partial class Create : Form
    {

        public Create()
        {
            InitializeComponent();
        }

        private void Create_Load(object sender, EventArgs e)
        {

        }


        private void Create_Resize(object sender, EventArgs e)
        {

        }

        private async void register_Btn_Click(object sender, EventArgs e)
        {
            try
            {
                // Validate all required fields
                if (IsFieldEmpty(type_Cmb.Text, "Type") ||
                    IsFieldEmpty(model_Tb.Text, "Model") ||
                    IsFieldEmpty(serial_Tb.Text, "Serial Number") ||
                    IsFieldEmpty(cost_Tb.Text, "Cost") ||
                    IsFieldEmpty(supplier_Tb.Text, "Supplier") ||
                    IsFieldEmpty(purchaseDate_Dtp.Text, "Purchase Date"))
                {
                    return; // Stop execution if any field is empty
                }

                // Prepare the fields to be inserted
                var fields = new Dictionary<string, string>
        {
            { "Type", type_Cmb.Text },
            { "Model", model_Tb.Text },
            { "SerialNo", serial_Tb.Text },
            { "Cost", cost_Tb.Text },
            { "Warranty", CalculateWarranty() },
            { "Supplier", supplier_Tb.Text },
            { "PurchaseDate", purchaseDate_Dtp.Text }
        };

                // Insert the document into the database
                await MyDbMethods.InsertDocument("SmartAssetDb", "Reserved_Hardwares", fields);





                //CREATE QR CODE
                // Clear the previous image from the PictureBox
                if (qr_pictureBox.Image != null)
                {
                    qr_pictureBox.Image.Dispose(); // Dispose of the previous image to free resources
                    qr_pictureBox.Image = null; // Remove the reference to the old image
                }

                // The text or URL to encode in the QR code (directly using a string here)
                string textToEncode = serial_Tb.Text; // Replace with the URL or text to encode

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
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }





            MessageBox.Show("Registered Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Clear or reset fields after registration
                if (!autoFill_Cb.Checked) ClearText();
                else serial_Tb.Text = string.Empty;





                


        }

        private bool IsFieldEmpty(string field, string fieldName)
        {
            if (string.IsNullOrWhiteSpace(field))
            {
                MessageBox.Show($"{fieldName} is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return true;
            }
            return false;
        }

        private string CalculateWarranty()
        {
            var warrantyParts = new List<string>();

            if (years_numericUpDown.Value > 0)
                warrantyParts.Add($"years:{years_numericUpDown.Value}");

            if (months_numericUpDown.Value > 0)
                warrantyParts.Add($"months:{months_numericUpDown.Value}");

            if (days_numericUpDown.Value > 0)
                warrantyParts.Add($"days:{days_numericUpDown.Value}");

            return warrantyParts.Count > 0 ? string.Join(" ", warrantyParts) : "N/A";
        }

        public void ClearText()
        {
            type_Cmb.Items.Clear();
            model_Tb.Text = string.Empty;
            serial_Tb.Text = string.Empty;
            cost_Tb.Text = string.Empty;
            years_numericUpDown.Value = years_numericUpDown.Minimum;
            months_numericUpDown.Value = months_numericUpDown.Minimum;
            days_numericUpDown.Value = months_numericUpDown.Minimum;
            supplier_Tb.Text = string.Empty;
            purchaseDate_Dtp.Text = string.Empty;
        }


        private void add_Btn_Click(object sender, EventArgs e)
        {
            TypeList_Add tla = new TypeList_Add();
            tla.Show();
        }

        private async void type_Cmb_DropDown(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            await MyDbMethods.LoadDatabase_TypeList("SmartAssetDb", "Type_List", type_Cmb);
            Cursor = Cursors.Arrow;
        }

        private void Clear_Btn_Click(object sender, EventArgs e)
        {
            type_Cmb.Text = "";
            type_Cmb.SelectedIndex = -1; // Reset the selection
            model_Tb.Text = string.Empty;
            serial_Tb.Text = string.Empty;
            cost_Tb.Text = string.Empty;
            years_numericUpDown.Value = 0;
            months_numericUpDown.Value = 0;
            days_numericUpDown.Value = 0;
            supplier_Tb.Text = string.Empty;
            purchaseDate_Dtp.Value = DateTime.Now;
        }

        private void cost_Tb_KeyPress(object sender, KeyPressEventArgs e)
        {

            System.Windows.Forms.TextBox textBox = sender as System.Windows.Forms.TextBox;

            // Allow digits, control keys (backspace, etc.), and Ctrl+A
            if (char.IsControl(e.KeyChar) || (e.KeyChar == (char)1)) // Ctrl+A is ASCII code 1
            {
                return; // Allow control keys
            }

            // Allow only digits and a single decimal point
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true; // Ignore if it's not a digit or decimal point
            }

            // Allow only one decimal point
            if (e.KeyChar == '.' && textBox.Text.Contains('.'))
            {
                e.Handled = true; // Ignore if another decimal point is entered
            }

            // Disallow space
            if (e.KeyChar == ' ')
            {
                e.Handled = true; // Ignore space key
            }
        }

        private void Create_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Dispose();
        }

        private void qmark_Btn_Click(object sender, EventArgs e)
        {
            //EXAMPLE ONLY CREATE MANUAL FORM
            // Check if an instance of QuestionMark is already open and close it
            foreach (Form openForm in Application.OpenForms)
            {
                if (openForm is QuestionMark)
                {
                    openForm.Close();
                    break; // Exit the loop after closing the form
                }
            }

            // Now create a new instance of QuestionMark
            QuestionMark qm = new QuestionMark();
            qm.Size = new Size(this.Width / 2, this.Height / 2);

            // Optionally center Form2 on the screen or relative to Form1
            qm.StartPosition = FormStartPosition.Manual;
            qm.Location = new Point(this.Location.X + this.Width / 4, this.Location.Y + this.Height / 4); // Center relative to Form1

            qm.Show();
        }

        private async void generate_Btn_Click(object sender, EventArgs e)
        {
            // Clear the previous image from the PictureBox
            if (qr_pictureBox.Image != null)
            {
                qr_pictureBox.Image.Dispose(); // Dispose of the previous image to free resources
                qr_pictureBox.Image = null; // Remove the reference to the old image
            }

            // The text or URL to encode in the QR code (directly using a string here)
            string textToEncode = serial2_Tb.Text; // Replace with the URL or text to encode

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
    }
}
