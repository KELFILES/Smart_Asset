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

        private void Create_Load(object sender, EventArgs e)
        {
            uploadImage_Pb.Image = Image.FromFile(System.IO.Path.Combine(Application.StartupPath, "Images", "X_Icon.ico"));
            uploadImage_Pb.Padding = new Padding(10, 0, 20, 0);
        }


        //FIELDS
        Transfer tf = new Transfer();
        public string pathName = null;
        private bool isQr1havePhoto = false;


        private void Create_Resize(object sender, EventArgs e)
        {

        }

        private async void register_Btn_Click(object sender, EventArgs e)
        {

            try
            {
                bool isExist = await MyDbMethods.CheckIfCollValueExists("SmartAssetDb", "Serial_List", "Serial", serial_Tb.Text);

                if (isExist)
                {
                    MessageBox.Show("SERIAL NO. ALREADY USED!");
                }
                else
                {
                    string dateNow = DateTime.Now.ToString("dddd, MMMM dd, yyyy");

                    // Validate all required fields
                    if (IsFieldEmpty(type_Cmb.Text, "Type") ||
                        IsFieldEmpty(brand_Tb.Text, "Brand") ||
                        IsFieldEmpty(model_Tb.Text, "Model") ||
                        IsFieldEmpty(propertyID_Tb.Text, "Property ID") ||
                        IsFieldEmpty(serial_Tb.Text, "Serial Number") ||
                        IsFieldEmpty(poNumber_Tb.Text, "PO Number") ||
                        IsFieldEmpty(siNumber_Tb.Text, "SI Number") ||
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
                        { "Brand", brand_Tb.Text },
                        { "Model", model_Tb.Text },
                        { "PropertyID", propertyID_Tb.Text },
                        { "SerialNo", serial_Tb.Text },
                        { "PONumber", poNumber_Tb.Text },
                        { "SINumber", siNumber_Tb.Text },
                        { "Cost", cost_Tb.Text },
                        { "Warranty", CalculateWarranty() },
                        { "Supplier", supplier_Tb.Text },
                        { "PurchaseDate", purchaseDate_Dtp.Text },
                        { "DateThisAdded", dateNow}
                    };

                    // Insert the document into the database
                    await MyDbMethods.InsertDocument("SmartAssetDb", "Reserved_Hardwares", fields, true);




                    if (pathName != null)
                    {
                        //Insert image to database
                        await MyDbMethods.ImgInsertToDbAsync(pathName, $"{serial_Tb.Text}", "SmartAssetDb", "Images");
                    }

                    pathName = null;
                    uploadImage_Pb.Image = Image.FromFile(System.IO.Path.Combine(Application.StartupPath, "Images", "X_Icon.ico"));
                    uploadImage_Pb.Padding = new Padding(10, 0, 20, 0);



                    // CREATE QR CODE
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
                            return;
                        }
                    }
                    catch (Exception ex)
                    {
                        // Handle any errors that may occur
                        MessageBox.Show($"Error: {ex.Message}", "QR Code Generation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }



                    //ADD SERIAL TO SERIAL_LIST
                    var serialFields = new Dictionary<string, string>
                    {
                        {"Serial", $"{serial_Tb.Text}"}
                    };

                    MyDbMethods.InsertDocument("SmartAssetDb", "Serial_List", serialFields, false);



                    // After all operations are successful, show the MessageBox with Yes and No
                    DialogResult result = MessageBox.Show("Do you want to deploy it now?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        tf.StartPosition = FormStartPosition.CenterScreen;
                        tf.Show();
                        tf.location_Rdb.PerformClick();
                        tf.serialNo_Cmb.Text = serial_Tb.Text;
                    }
                    else if (result == DialogResult.No)
                    {
                        Console.WriteLine("Don't go");
                    }



                    //CLEAR TEXTBOX IF FILL IS ENABLED
                    if (autoFill_Cb.Checked)
                    {
                        propertyID_Tb.Text = "";
                        serial_Tb.Text = "";
                        poNumber_Tb.Text = "";
                        siNumber_Tb.Text = "";
                    }
                    else
                    {
                        clearAllField();
                    }



                }

            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        public void clearAllField()
        {
            type_Cmb.Text = "";
            type_Cmb.SelectedIndex = -1; // Reset the selection
            brand_Tb.Text = string.Empty;
            model_Tb.Text = string.Empty;
            propertyID_Tb.Text = string.Empty;
            serial_Tb.Text = string.Empty;
            poNumber_Tb.Text = string.Empty;
            siNumber_Tb.Text = string.Empty;
            cost_Tb.Text = string.Empty;
            years_numericUpDown.Value = 0;
            months_numericUpDown.Value = 0;
            days_numericUpDown.Value = 0;
            supplier_Tb.Text = string.Empty;
            purchaseDate_Dtp.Value = DateTime.Now;

            pathName = null;
            uploadImage_Pb.Image = Image.FromFile(System.IO.Path.Combine(Application.StartupPath, "Images", "X_Icon.ico"));
            uploadImage_Pb.Padding = new Padding(10, 0, 20, 0);
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
            clearAllField();
        }

        private void cost_Tb_KeyPress(object sender, KeyPressEventArgs e)
        {

            PressNumberDotOnly(sender, e, false);
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

        private void serial2_Cb_MouseEnter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            pathName = MyDbMethods.SelectImageFromFileExplorer();

            if (!string.IsNullOrEmpty(pathName))
            {
                uploadImage_Pb.Image = Image.FromFile(System.IO.Path.Combine(Application.StartupPath, "Images", "Check_Icon.ico"));
                uploadImage_Pb.Padding = new Padding(10, 0, 20, 0);
            }


        }

        private void poNumber_Tb_KeyPress(object sender, KeyPressEventArgs e)
        {
            PressNumberDotOnly(sender, e, true);
        }

        private void siNumber_Tb_KeyPress(object sender, KeyPressEventArgs e)
        {
            PressNumberDotOnly(sender, e, true);
        }


        private void PressNumberDotOnly(object sender, KeyPressEventArgs e, bool isMultipleDot)
        {
            // Cast the sender to a TextBox
            System.Windows.Forms.TextBox textBox = sender as System.Windows.Forms.TextBox;

            // Allow control keys (like backspace, delete) and Ctrl+A (Select All)
            if (char.IsControl(e.KeyChar) || (e.KeyChar == (char)1)) // Ctrl+A is ASCII code 1
            {
                return; // Allow control keys
            }

            // Allow only digits and decimal points
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true; // Block non-digit and non-decimal point characters
            }

            // Prevent entering more than one decimal point if isMultipleDot is false
            if (!isMultipleDot && e.KeyChar == '.' && textBox.Text.Contains('.'))
            {
                e.Handled = true; // Block additional decimal points when only one is allowed
            }

            // Disallow space key
            if (e.KeyChar == ' ')
            {
                e.Handled = true; // Block spaces
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

        private async void serial2_Cb_Enter(object sender, EventArgs e)
        {
            await MyDbMethods.LoadDatabase_AllSerialNo("SmartAssetDb", serial2_Cb);
        }
    }
}
