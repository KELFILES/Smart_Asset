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
    public partial class Transfer : Form
    {
        public Transfer()
        {
            InitializeComponent();
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
            if (repairing_RadBtn.Checked)
            {
                selectedTransfer = "repairing";
            }
            else if (cleaning_RadBtn.Checked)
            {
                selectedTransfer = "cleaning";
            }
            else if (disposal_RadBtn.Checked)
            {
                selectedTransfer = "disposal";
            }
            else if (borrow_RadBtn.Checked)
            {
                selectedTransfer = "borrow";
            }
            else if (delete_RadBtn.Checked)
            {
                selectedTransfer = "delete";
            }

            switch (selectedTransfer)
            {
                case "repairing":
                    await MyDbMethods.TransferDocumentBySerialNo("SmartAssetDb", "Repairing", $"{serialNo_Cmb.Text}", notes_Tb.Text);
                    break;

                case "cleaning":
                    await MyDbMethods.TransferDocumentBySerialNo("SmartAssetDb", "Cleaning", $"{serialNo_Cmb.Text}", notes_Tb.Text);
                    break;

                case "disposal":
                    await MyDbMethods.TransferDocumentBySerialNo("SmartAssetDb", "Disposal", $"{serialNo_Cmb.Text}", notes_Tb.Text);
                    break;

                case "borrow":
                    await MyDbMethods.TransferDocumentBySerialNo("SmartAssetDb", "BorrowedItems", $"{serialNo_Cmb.Text}", notes_Tb.Text);
                    break;
                case "delete":
                    await MyDbMethods.TransferDocumentBySerialNo("SmartAssetDb", "Delete", $"{serialNo_Cmb.Text}", notes_Tb.Text);
                    break;
            }

            repairing_RadBtn.Checked = false;
            cleaning_RadBtn.Checked = false;
            disposal_RadBtn.Checked = false;
            borrow_RadBtn.Checked = false;
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
            else if (borrow2_RadBtn.Checked)
            {
                selectedTransfer2 = "borrow";
            }
            else if (delete2_RadBtn.Checked)
            {
                selectedTransfer2 = "delete";
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
                    await MyDbMethods.TransferDocumentsByCollectionName("SmartAssetDb", $"{location_Cmb.Text}_{unit_Cmb.Text}", "Disposal", notes2_Tb.Text);
                    break;

                case "borrow":
                    await MyDbMethods.TransferDocumentsByCollectionName("SmartAssetDb", $"{location_Cmb.Text}_{unit_Cmb.Text}", "BorrowedItems", notes2_Tb.Text);
                    break;
                case "delete":
                    await MyDbMethods.TransferDocumentsByCollectionName("SmartAssetDb", $"{location_Cmb.Text}_{unit_Cmb.Text}", "Delete", notes2_Tb.Text);
                    break;
            }

            repairing2_RadBtn.Checked = false;
            cleaning2_RadBtn.Checked = false;
            disposal2_RadBtn.Checked = false;
            borrow2_RadBtn.Checked = false;
        }











    }
}
