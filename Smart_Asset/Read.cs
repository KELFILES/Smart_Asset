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

            public string Location { get; set; }  // New property
        }

        private void show1_Btn_Click(object sender, EventArgs e)
        {
            MyDbMethods.Read_LoadData("SmartAssetDb", dataGridView1, serialNo_Cmb.Text);
        }

        public async void reservedHardwares_Btn_Click(object sender, EventArgs e)
        {
            MyDbMethods.LoadAllCollData("SmartAssetDb", "Reserved_Hardwares", dataGridView1);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MyDbMethods.LoadAllCollData("SmartAssetDb", $"{location_Cmb.Text}_{unit_Cmb.Text}", dataGridView1);
        }

        private async void location_Cmb_DropDown(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            await MyDbMethods.LoadDatabase_TypeList("SmartAssetDb", "Deployment_Location_List", location_Cmb);
            Cursor = Cursors.Arrow;
        }

        private async void unit_Cmb_DropDown(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            await MyDbMethods.LoadDatabase_TypeList("SmartAssetDb", "Deployment_Unit_List", unit_Cmb);
            Cursor = Cursors.Arrow;
        }
    }
}
