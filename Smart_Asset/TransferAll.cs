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
    public partial class TransferAll : Form
    {
        public TransferAll()
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

        private async void location_Cmb_DropDown(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            await MyDbMethods.LoadDatabase_TypeList("SmartAssetDb", "Deployment_Location_List", location_Cmb);
            Cursor = Cursors.Arrow;
        }

        private async void unit_Cmb_DropDown(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;

            // Clear existing items and load from database
            unit_Cmb.Items.Clear();
            await MyDbMethods.LoadDatabase_TypeList("SmartAssetDb", "Deployment_Unit_List", unit_Cmb);

            // Insert "N/A" at the first position
            unit_Cmb.Items.Insert(0, "N/A");

            Cursor = Cursors.Arrow;
        }

        private void serialNo_Cmb_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = char.ToUpper(e.KeyChar);
        }



        










































        //TRANSFER BUTTON2
        private async void transfer2_Btn_Click_1(object sender, EventArgs e)
        {

            string selectedTransfer2 = string.Empty;
            if (repairing2_RadBtn.Checked)
            {
                selectedTransfer2 = "repairing";
            }
            else if (cleaning2_RadBtn.Checked)
            {
                selectedTransfer2 = "cleaning";
            }
            else if (disposal2_RadBtn.Checked)
            {
                selectedTransfer2 = "disposal";
            }
            else if (reservedHardwares2_RadBtn.Checked)
            {
                selectedTransfer2 = "reservedHardwares";
            }
            else if (location2_Rdb.Checked)
            {
                selectedTransfer2 = "location2";
            }

            switch (selectedTransfer2)
            {
                case "repairing":
                    await MyDbMethods.TransferDocumentsByCollectionName("SmartAssetDb", $"{location_Cmb.Text}_{unit_Cmb.Text}", "Repairing", notes2_Tb.Text);
                    break;

                case "cleaning":
                    await MyDbMethods.TransferDocumentsByCollectionName("SmartAssetDb", $"{location_Cmb.Text}_{unit_Cmb.Text}", "Cleaning", notes2_Tb.Text);
                    break;

                case "disposal":
                    await MyDbMethods.TransferDocumentsByCollectionName("SmartAssetDb", $"{location_Cmb.Text}_{unit_Cmb.Text}", "Disposed_Hardwares", notes2_Tb.Text);
                    break;

                case "borrow":
                    await MyDbMethods.TransferDocumentsByCollectionName("SmartAssetDb", $"{location_Cmb.Text}_{unit_Cmb.Text}", "Borrowed_Hardwares", notes2_Tb.Text);
                    break;
                case "delete":
                    await MyDbMethods.TransferDocumentsByCollectionName("SmartAssetDb", $"{location_Cmb.Text}_{unit_Cmb.Text}", "Delete", notes2_Tb.Text);
                    break;
                case "location2":
                    await MyDbMethods.TransferDocumentsByCollectionName("SmartAssetDb", $"{location_Cmb.Text}_{unit_Cmb.Text}", $"{locationType2_Cmb.Text}_{unitType2_Cmb.Text}");
                    break;
            }

            repairing2_RadBtn.Checked = false;
            cleaning2_RadBtn.Checked = false;
            disposal2_RadBtn.Checked = false;
        }


        

        private void location2_Rdb_CheckedChanged(object sender, EventArgs e)
        {
            if (location2_Rdb.Checked)
            {
                locationType2_Cmb.Enabled = true;
                unitType2_Cmb.Enabled = true;
            }
            else
            {
                // Clear selection in ComboBox by setting SelectedIndex to -1
                locationType2_Cmb.SelectedIndex = -1;
                unitType2_Cmb.SelectedIndex = -1;

                locationType2_Cmb.Enabled = false;
                unitType2_Cmb.Enabled = false;
            }
        }

        

        private async void locationType2_Cmb_DropDown(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            await MyDbMethods.LoadDatabase_TypeList("SmartAssetDb", "Deployment_Location_List", locationType2_Cmb);
            Cursor = Cursors.Arrow;
        }

        private async void unitType2_Cmb_DropDown(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            await MyDbMethods.LoadDatabase_TypeList("SmartAssetDb", "Deployment_Unit_List", unitType2_Cmb);
            Cursor = Cursors.Arrow;
        }
    }
}
