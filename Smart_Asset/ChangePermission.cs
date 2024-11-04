using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Smart_Asset
{
    public partial class ChangePermission : Form
    {
        public ChangePermission()
        {
            InitializeComponent();
        }
        //FIELDS
        string finalUserIDVal;

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

        private void ChangeRole_Load(object sender, EventArgs e)
        {
            assetEnabled_Panel.Visible = false;
            MyOtherMethods.CenterInPanel(changePermission_Btn, panel5);
        }

        private void comboBox1_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private async void newRole_Cb_TextChanged(object sender, EventArgs e)
        {

        }

        private void assets_Cb_CheckedChanged(object sender, EventArgs e)
        {
            if (assets_Cb.Checked)
            {
                assetEnabled_Panel.Visible = true;
            }
            else
            {
                //Disable all included in assetEnabled_Panel
                add_Cb.Checked = false;
                edit_Cb.Checked = false;
                replace_Cb.Checked = false;
                transfer_Cb.Checked = false;
                borrow_Cb.Checked = false;
                archive_Cb.Checked = false;
                showImage_Cb.Checked = false;

                assetEnabled_Panel.Visible = false;

            }
        }

        private void selectAll_Btn_Click(object sender, EventArgs e)
        {
            assets_Cb.Checked = true;
            replacement_Cb.Checked = true;
            cleaning_Cb.Checked = true;
            disposed_Cb.Checked = true;
            borrowed_Cb.Checked = true;
            reserved_Cb.Checked = true;
            archived_Cb.Checked = true;
            assetHistory_Cb.Checked = true;
        }

        private void clear_Btn_Click(object sender, EventArgs e)
        {
            assets_Cb.Checked = false;
            replacement_Cb.Checked = false;
            cleaning_Cb.Checked = false;
            disposed_Cb.Checked = false;
            borrowed_Cb.Checked = false;
            reserved_Cb.Checked = false;
            archived_Cb.Checked = false;
            assetHistory_Cb.Checked = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            add_Cb.Checked = true;
            edit_Cb.Checked = true;
            replace_Cb.Checked = true;
            transfer_Cb.Checked = true;
            borrow_Cb.Checked = true;
            archive_Cb.Checked = true;
            showImage_Cb.Checked = true;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            add_Cb.Checked = false;
            edit_Cb.Checked = false;
            replace_Cb.Checked = false;
            transfer_Cb.Checked = false;
            borrow_Cb.Checked = false;
            archive_Cb.Checked = false;
            showImage_Cb.Checked = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            dashboard_Cb.Checked = true;
            artificialIntelligence_Cb.Checked = true;
            createReport_Cb.Checked = true;
            backupAndRestoreData_Cb.Checked = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dashboard_Cb.Checked = false;
            artificialIntelligence_Cb.Checked = false;
            createReport_Cb.Checked = false;
            backupAndRestoreData_Cb.Checked = false;
        }

        private async void change_Btn_Click(object sender, EventArgs e)
        {



        }

        private async void userIDVal_Lbl_TextChanged(object sender, EventArgs e)
        {
            finalUserIDVal = userIDVal_Lbl.Text;

            // Retrieve permissions from the database
            var permissions = await MyDbMethods.GetPermissionsAsync("SmartAssetDb", "CustomUsers_Permissions", finalUserIDVal);

            if (permissions != null)
            {
                // Set each checkbox based on the permission value (true or false)
                assets_Cb.Checked = permissions.Assets;
                replacement_Cb.Checked = permissions.Replacement;
                cleaning_Cb.Checked = permissions.Cleaning;
                disposed_Cb.Checked = permissions.Disposed;
                borrowed_Cb.Checked = permissions.Borrowed;
                reserved_Cb.Checked = permissions.Reserved;
                archived_Cb.Checked = permissions.Archived;
                assetHistory_Cb.Checked = permissions.AssetHistory;
                add_Cb.Checked = permissions.Add;
                edit_Cb.Checked = permissions.Edit;
                replace_Cb.Checked = permissions.Replace;
                transfer_Cb.Checked = permissions.Transfer;
                borrow_Cb.Checked = permissions.Borrow;
                archive_Cb.Checked = permissions.Archive;
                showImage_Cb.Checked = permissions.ShowImage;
                dashboard_Cb.Checked = permissions.Dashboard;
                artificialIntelligence_Cb.Checked = permissions.ArtificialIntelligence;
                createReport_Cb.Checked = permissions.CreateReport;
                backupAndRestoreData_Cb.Checked = permissions.BackupAndRestoreData;
            }
            else
            {
                Console.WriteLine("No permissions found for the specified userID.");
                // Optionally, uncheck all checkboxes if no permissions are found
                assets_Cb.Checked = false;
                replacement_Cb.Checked = false;
                cleaning_Cb.Checked = false;
                disposed_Cb.Checked = false;
                borrowed_Cb.Checked = false;
                reserved_Cb.Checked = false;
                archived_Cb.Checked = false;
                assetHistory_Cb.Checked = false;
                add_Cb.Checked = false;
                edit_Cb.Checked = false;
                replace_Cb.Checked = false;
                transfer_Cb.Checked = false;
                borrow_Cb.Checked = false;
                archive_Cb.Checked = false;
                showImage_Cb.Checked = false;
                dashboard_Cb.Checked = false;
                artificialIntelligence_Cb.Checked = false;
                createReport_Cb.Checked = false;
                backupAndRestoreData_Cb.Checked = false;
            }
        }



        private void button4_Click_1(object sender, EventArgs e)
        {

        }

        private async void changePermission_Btn_Click(object sender, EventArgs e)
        {
            // Prepare the permissions fields as Dictionary<string, string>
            var permissionsFields = new Dictionary<string, string>
            {
                { "userID", userIDVal_Lbl.Text },  // Convert ObjectId to string
                { "Assets", assets_Cb.Checked ? "1" : "0" },
                { "Replacement", replacement_Cb.Checked ? "1" : "0" },
                { "Cleaning", cleaning_Cb.Checked ? "1" : "0" },
                { "Disposed", disposed_Cb.Checked ? "1" : "0" },
                { "Borrowed", borrowed_Cb.Checked ? "1" : "0" },
                { "Reserved", reserved_Cb.Checked ? "1" : "0" },
                { "Archived", archived_Cb.Checked ? "1" : "0" },
                { "Asset History", assetHistory_Cb.Checked ? "1" : "0" },
                { "Add", add_Cb.Checked ? "1" : "0" },
                { "Edit", edit_Cb.Checked ? "1" : "0" },
                { "Replace", replace_Cb.Checked ? "1" : "0" },
                { "Transfer", transfer_Cb.Checked ? "1" : "0" },
                { "Borrow", borrow_Cb.Checked ? "1" : "0" },
                { "Archive", archive_Cb.Checked ? "1" : "0" },
                { "Show Image", showImage_Cb.Checked ? "1" : "0" },
                { "Dashboard", dashboard_Cb.Checked ? "1" : "0" },
                { "Artificial Intelligence", artificialIntelligence_Cb.Checked ? "1" : "0" },
                { "Create Report", createReport_Cb.Checked ? "1" : "0" },
                { "Backup And Restore Data", backupAndRestoreData_Cb.Checked ? "1" : "0" }
            };

            // Call the UpsertDocumentAsync method and check the result
            bool isSuccess = await MyDbMethods.UpsertDocumentAsync("SmartAssetDb", "CustomUsers_Permissions", userIDVal_Lbl.Text, permissionsFields);

            // Display success or failure message
            if (isSuccess)
            {
                MessageBox.Show("Permissions updated successfully.");
            }
            else
            {
                MessageBox.Show("Failed to update permissions.");
            }
        }

    }
}
