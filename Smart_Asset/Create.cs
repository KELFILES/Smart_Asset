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
                string warrantyVal = "";
                bool yy;
                bool mm;
                bool dd;

                if (years_numericUpDown.Value != 0 &&
                    months_numericUpDown.Value == 0 &&
                    days_numericUpDown.Value == 0)
                {
                    warrantyVal = $"years:{years_numericUpDown.Value.ToString()}";
                }
                else if (years_numericUpDown.Value == 0 &&
                    months_numericUpDown.Value != 0 &&
                    days_numericUpDown.Value == 0)
                {
                    warrantyVal = $"months:{months_numericUpDown.Value.ToString()}";
                }
                else if (years_numericUpDown.Value == 0 &&
                    months_numericUpDown.Value == 0 &&
                    days_numericUpDown.Value != 0)
                {
                    warrantyVal = $"days:{days_numericUpDown.Value.ToString()}";
                }
                else if (years_numericUpDown.Value != 0 &&
                    months_numericUpDown.Value != 0 &&
                    days_numericUpDown.Value == 0)
                {
                    warrantyVal = $"years:{years_numericUpDown.Value.ToString()} months:{months_numericUpDown.Value.ToString()}";
                }
                else if (years_numericUpDown.Value != 0 &&
                    months_numericUpDown.Value == 0 &&
                    days_numericUpDown.Value != 0)
                {
                    warrantyVal = $"years:{years_numericUpDown.Value.ToString()} days:{days_numericUpDown.Value.ToString()}";
                }
                else if (years_numericUpDown.Value != 0 &&
                    months_numericUpDown.Value != 0 &&
                    days_numericUpDown.Value != 0)
                {
                    warrantyVal = $"years:{years_numericUpDown.Value.ToString()} months:{months_numericUpDown.Value.ToString()} days:{days_numericUpDown.Value.ToString()}";
                }
                else
                {
                    warrantyVal = "N/A";
                }


                var fields = new Dictionary<string, string>
                {
                    { $"Type", $"{type_Cmb.Text}" },
                    { $"Model", $"{model_Tb.Text}" },
                    { $"SerialNo", $"{serial_Tb.Text}" },
                    { $"Cost", $"{cost_Tb.Text}" },
                    { $"Warranty", $"{warrantyVal}" },
                    { $"Supplier", $"{supplier_Tb.Text}" },
                    { $"PurchaseDate", $"{purchaseDate_Dtp.Text}" }
                };

                await MyDbMethods.InsertDocument("SmartAssetDb", "Reserved_Hardwares", fields);

                MessageBox.Show("Registered Successfully");


                if (!autoFill_checkBox.Checked)
                {
                    ClearText();
                }
                else
                {
                    serial_Tb.Text = string.Empty;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Register Error ");
            }
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







    }
}
