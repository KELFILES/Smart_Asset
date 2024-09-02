using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Smart_Asset
{
    public partial class Update : Form
    {
        public Update()
        {
            InitializeComponent();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            MyDbMethods.UpdateChangesToDatabase("SmartAssetDb", dataGridView1, $"{location_Cmb.Text}_{unit_Cmb.Text}");
        }

        private void show_Btn_Click(object sender, EventArgs e)
        {
            MyDbMethods.UpdateUsingLocation("SmartAssetDb", dataGridView1, $"{location_Cmb.Text}_{unit_Cmb.Text}");
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


        private void serialNo_Cmb_MouseEnter(object sender, EventArgs e)
        {
            MyDbMethods.LoadDatabase_AllSerialNo("SmartAssetDb", serialNo_Cmb);
        }

        private void show2_Btn_Click(object sender, EventArgs e)
        {
            MyDbMethods.UpdateUsingSerialNo("SmartAssetDb", dataGridView1, $"{serialNo_Cmb.Text}");
        }

        private void serialNo_Cmb_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = char.ToUpper(e.KeyChar);
        }
    }
}
