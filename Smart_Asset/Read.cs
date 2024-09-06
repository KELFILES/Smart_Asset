using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;
using System.Windows.Forms;
using MongoDB.Bson;
using static Smart_Asset.Read;


namespace Smart_Asset
{
    public partial class Read : Form
    {
        public Read()
        {
            InitializeComponent();
        }

        private void Read_Load(object sender, EventArgs e)
        {

        }

        private void Read_Resize(object sender, EventArgs e)
        {

        }

        private async void export_Btn_Click(object sender, EventArgs e)
        {
            //MyDbMethods.ReadDocument("SmartAssetDb", "Reserved_Hardwares", "Type", "CPU");
        }

        public class Read_Model
        {
            public string Id { get; set; }
            public string Type { get; set; }
            public string Model { get; set; }
            public string SerialNo { get; set; }
            public string Cost { get; set; }
            public string Supplier { get; set; }
            public string Warranty { get; set; }
            public string WarrantyStatus { get; set; }
            public string PurchaseDate { get; set; }
            public string Usage { get; set; }
            public string Location { get; set; }
        }



        private void show1_Btn_Click(object sender, EventArgs e)
        {
            MyDbMethods.Read_SerialNo("SmartAssetDb", dataGridView1, serialNo_Cmb.Text);
            _lastRefreshAction = () => MyDbMethods.Read_SerialNo("SmartAssetDb", dataGridView1, serialNo_Cmb.Text);
        }

        private void reservedHardwares_Btn_Click_1(object sender, EventArgs e)
        {
            MyDbMethods.ReadLocation("SmartAssetDb", dataGridView1, "Reserved_Hardwares");
            _lastRefreshAction = () => MyDbMethods.ReadLocation("SmartAssetDb", dataGridView1, "Reserved_Hardwares");
        }


        private async void location_Cmb_DropDown_1(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            await MyDbMethods.LoadDatabase_TypeList("SmartAssetDb", "Deployment_Location_List", location_Cmb);
            Cursor = Cursors.Arrow;
        }

        private async void unit_Cmb_DropDown_1(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            await MyDbMethods.LoadDatabase_TypeList("SmartAssetDb", "Deployment_Unit_List", unit_Cmb);
            Cursor = Cursors.Arrow;
        }

        private void serialNo_Cmb_MouseEnter(object sender, EventArgs e)
        {
            MyDbMethods.LoadDatabase_AllSerialNo("SmartAssetDb", serialNo_Cmb);
        }

        private void serialNo_Cmb_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = char.ToUpper(e.KeyChar);
        }





        private Action _lastRefreshAction;

        // Override ProcessCmdKey to handle Ctrl+R key press
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            // Check if the Ctrl + R key combination is pressed
            if (keyData == (Keys.Control | Keys.R))
            {
                _lastRefreshAction?.Invoke(); // Invoke the last refresh action
                MessageBox.Show("DATA HAS BEEN REFRESHED");
                return true; // Indicate that the key press was handled
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            MyDbMethods.ReadLocation("SmartAssetDb", dataGridView1, $"{location_Cmb.Text}_{unit_Cmb.Text}");
            _lastRefreshAction = () => MyDbMethods.ReadLocation("SmartAssetDb", dataGridView1, $"{location_Cmb.Text}_{unit_Cmb.Text}");
        }
    }
}
