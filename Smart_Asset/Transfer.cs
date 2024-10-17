using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace Smart_Asset
{
    public partial class Transfer : Form
    {
        public Transfer()
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

        private void serialNo_Cmb_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = char.ToUpper(e.KeyChar);
        }

        private void serialNo_Cmb_MouseEnter(object sender, EventArgs e)
        {
            MyDbMethods.LoadDatabase_AllSerialNo("SmartAssetDb", serialNo_Cmb);
        }

        private async void transfer_Btn_Click(object sender, EventArgs e)
        {
            string selectedTransfer = string.Empty;
            if (cleaning_RadBtn.Checked)
            {
                selectedTransfer = "cleaning";
            }
            else if (disposal_RadBtn.Checked)
            {
                selectedTransfer = "disposal";
            }
            else if (reserved_RadBtn.Checked)
            {
                selectedTransfer = "reservedHardwares";
                notes_Tb.Text = "";
            }
            else if (location_Rdb.Checked)
            {
                selectedTransfer = "location";
            }


            switch (selectedTransfer)
            {
                case "cleaning":
                    await MyDbMethods.TransferDocumentBySerialNo("SmartAssetDb", "Cleaning", $"{serialNo_Cmb.Text}", notes_Tb.Text);
                    break;

                case "disposal":
                    await MyDbMethods.TransferDocumentBySerialNo("SmartAssetDb", "Disposed_Hardwares", $"{serialNo_Cmb.Text}", notes_Tb.Text);
                    break;

                case "borrow":
                    await MyDbMethods.TransferDocumentBySerialNo("SmartAssetDb", "Borrowed_Hardwares", $"{serialNo_Cmb.Text}", notes_Tb.Text);
                    break;
                case "reservedHardwares":
                    await MyDbMethods.TransferDocumentBySerialNo("SmartAssetDb", "Reserved_Hardwares", $"{serialNo_Cmb.Text}");
                    break;
                case "archieve":
                    await MyDbMethods.TransferDocumentBySerialNo("SmartAssetDb", "Archieve", $"{serialNo_Cmb.Text}", notes_Tb.Text);
                    break;
                case "location":
                    await MyDbMethods.TransferDocumentBySerialNo("SmartAssetDb", $"{locationType_Cmb.Text}_{unitType_Cmb.Text}", $"{serialNo_Cmb.Text}");
                    break;
            }
            cleaning_RadBtn.Checked = false;
            disposal_RadBtn.Checked = false;
        }


































        private void location_Rdb_CheckedChanged(object sender, EventArgs e)
        {
            if (location_Rdb.Checked == true)
            {
                locationType_Cmb.Enabled = true;
                unitType_Cmb.Enabled = true;
            }
            else
            {
                // Clear selection in ComboBox by setting SelectedIndex to -1
                locationType_Cmb.SelectedIndex = -1;
                unitType_Cmb.SelectedIndex = -1;

                locationType_Cmb.Enabled = false;
                unitType_Cmb.Enabled = false;
            }



            notes_Tb.Text = "";

            if (location_Rdb.Checked)
            {
                notes_Tb.Text = "NOTES NOT AVAILABLE AT LOCATION";

                notes_Tb.ReadOnly = true;
                notes_Tb.BackColor = Color.DarkGray;
            }
            else
            {
                notes_Tb.ReadOnly = false;
                notes_Tb.BackColor = Color.Silver;
            }
        }



        private async void locationType_Cmb_DropDown(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            await MyDbMethods.LoadDatabase_TypeList("SmartAssetDb", "Deployment_Location_List", locationType_Cmb);
            Cursor = Cursors.Arrow;
        }

        private async void unitType_Cmb_DropDown(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            await MyDbMethods.LoadDatabase_TypeList("SmartAssetDb", "Deployment_Unit_List", unitType_Cmb);
            Cursor = Cursors.Arrow;
        }

        private void cleaning_RadBtn_CheckedChanged(object sender, EventArgs e)
        {
            notes_Tb.Text = "";
        }

        private void reserved_RadBtn_CheckedChanged(object sender, EventArgs e)
        {
            notes_Tb.Text = "NOTES NOT AVAILABLE AT RESERVED";

            if (reserved_RadBtn.Checked)
            {
                notes_Tb.ReadOnly = true;
                notes_Tb.BackColor = Color.DarkGray;
            }
            else
            {
                notes_Tb.ReadOnly = false;
                notes_Tb.BackColor = Color.Silver;
            }
        }

    }
}
