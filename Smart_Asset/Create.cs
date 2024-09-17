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

                MessageBox.Show("Registered Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Clear or reset fields after registration
                if (!autoFill_Cb.Checked) ClearText();
                else serial_Tb.Text = string.Empty;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
    }
}
