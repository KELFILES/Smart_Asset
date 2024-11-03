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
    public partial class ChangeRole : Form
    {
        public ChangeRole()
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

            lowerLabel_Lbl.Text = "";
            topLabel_Lbl.Text = "";
            panel4.Hide();
            assetEnabled_Panel.Visible = false;

            MyOtherMethods.CenterInPanel(changeRoleTopLabel_Lbl, panel2);
        }

        private void comboBox1_MouseClick(object sender, MouseEventArgs e)
        {
            switch (currentRoleVal_Lbl.Text)
            {
                case "Super Admin":
                    newRole_Cb.Items.Clear();
                    newRole_Cb.Items.Add("Admin");
                    newRole_Cb.Items.Add("Custom User");
                    break;
                case "Admin":
                    newRole_Cb.Items.Clear();
                    newRole_Cb.Items.Add("Super Admin");
                    newRole_Cb.Items.Add("Custom User");
                    break;
                case "Custom User":
                    newRole_Cb.Items.Clear();
                    newRole_Cb.Items.Add("Super Admin");
                    newRole_Cb.Items.Add("Admin");
                    break;
            }
        }

        private async void newRole_Cb_TextChanged(object sender, EventArgs e)
        {
            if (newRole_Cb.Text.Equals(String.IsNullOrEmpty) || newRole_Cb.Text.Equals(""))
            {
                lowerLabel_Lbl.Text = "";
                topLabel_Lbl.Text = "";
                panel4.Hide();
                assetEnabled_Panel.Visible = false;
            }

            if (newRole_Cb.Text.Equals("Super Admin"))
            {
                lowerLabel_Lbl.Text = "All Access Is Allowed Including Manage Users.";
                topLabel_Lbl.Text = "Super Admin";
                panel4.Hide();
            }

            else if (newRole_Cb.Text.Equals("Admin"))
            {
                lowerLabel_Lbl.Text = "All Access Is Allowed Excluding Manage Users.";
                topLabel_Lbl.Text = "Admin";
                panel4.Hide();
            }

            else if (newRole_Cb.Text.Equals("Custom User"))
            {
                lowerLabel_Lbl.Text = "Select only the allowed access below.";
                topLabel_Lbl.Text = "Custom User";
                panel4.Show();




                //RETRIEVE USER PERMISSION THEN CHECK OR UNCHECK IF 1 CHECK 0 UNCHECK

                // Retrieve permissions dictionary
                var permissions = await MyDbMethods.RetrievePermissionsAsync("SmartAssetDb", "CustomUsers_Permissions", finalUserIDVal);

                if (permissions == null)
                {
                    Console.WriteLine("Failed to load permissions.");
                    return;
                }

                // Set each checkbox based on the permissions dictionary values
                assets_Cb.Checked = permissions.TryGetValue("Assets", out var assets) && assets == "1";
                replacement_Cb.Checked = permissions.TryGetValue("Replacement", out var replacement) && replacement == "1";
                cleaning_Cb.Checked = permissions.TryGetValue("Cleaning", out var cleaning) && cleaning == "1";
                disposed_Cb.Checked = permissions.TryGetValue("Disposed", out var disposed) && disposed == "1";
                borrowed_Cb.Checked = permissions.TryGetValue("Borrowed", out var borrowed) && borrowed == "1";
                reserved_Cb.Checked = permissions.TryGetValue("Reserved", out var reserved) && reserved == "1";
                archived_Cb.Checked = permissions.TryGetValue("Archived", out var archived) && archived == "1";
                assetHistory_Cb.Checked = permissions.TryGetValue("Asset History", out var assetHistory) && assetHistory == "1";

                add_Cb.Checked = permissions.TryGetValue("Add", out var add) && add == "1";
                edit_Cb.Checked = permissions.TryGetValue("Edit", out var edit) && edit == "1";
                replace_Cb.Checked = permissions.TryGetValue("Replace", out var replace) && replace == "1";
                transfer_Cb.Checked = permissions.TryGetValue("Transfer", out var transfer) && transfer == "1";
                borrow_Cb.Checked = permissions.TryGetValue("Borrow", out var borrow) && borrow == "1";
                archive_Cb.Checked = permissions.TryGetValue("Archive", out var archive) && archive == "1";
                showImage_Cb.Checked = permissions.TryGetValue("Show Image", out var showImage) && showImage == "1";

                dashboard_Cb.Checked = permissions.TryGetValue("Dashboard", out var dashboard) && dashboard == "1";
                artificialIntelligence_Cb.Checked = permissions.TryGetValue("Artificial Intelligence", out var artificialIntelligence) && artificialIntelligence == "1";
                createReport_Cb.Checked = permissions.TryGetValue("Create Report", out var createReport) && createReport == "1";
                backupAndRestoreData_Cb.Checked = permissions.TryGetValue("Backup And Restore Data", out var backupAndRestoreData) && backupAndRestoreData == "1";
            }



            MyOtherMethods.CenterInPanel(lowerLabel_Lbl, panel3);
            MyOtherMethods.CenterInPanel(topLabel_Lbl, panel3);
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
            archived_Cb.Checked = true;
            showImage_Cb.Checked = true;
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
            if (newRole_Cb.Text.Equals("Super Admin"))
            {
                await MyDbMethods.UpdateFieldAsync("SmartAssetDb", "Users", $"{userIDVal_Lbl.Text}", "role", $"{newRole_Cb.Text}");

                //DELETE IN DB IF THERE ARE PERMISSION DATA IN CUSTOMUSERS_PERMISSIONS COLLECTION TO SAVE STORAGE

            }

            if (newRole_Cb.Text.Equals("Admin"))
            {
                await MyDbMethods.UpdateFieldAsync("SmartAssetDb", "Users", $"{userIDVal_Lbl.Text}", "role", $"{newRole_Cb.Text}");

                //DELETE IN DB IF THERE ARE PERMISSION DATA IN CUSTOMUSERS_PERMISSIONS COLLECTION TO SAVE STORAGE

            }

            if (newRole_Cb.Text.Equals("Custom User"))
            {
                //UPDATE IN USER COLLECTION
                await MyDbMethods.UpdateFieldAsync("SmartAssetDb", "Users", $"{userIDVal_Lbl.Text}", "role", $"{newRole_Cb.Text}");

                //UPDATE IN CUSTOMUSERS_PERMISSIONS COLLECTION
                var permissions_Dictionary = new Dictionary<string, string>
                {
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

                // Assuming userId is the ID of the user you want to update
                await MyDbMethods.UpdatePermissionsAsync("SmartAssetDb", "CustomUsers_Permissions", "6727979b0e7ea38de8056322", permissions_Dictionary);

            }

            if (newRole_Cb.Text.Equals("") || newRole_Cb.Text.Equals(String.IsNullOrEmpty))
            {
                MessageBox.Show("Enter Role Properly!");
            }

        }

        private async void userIDVal_Lbl_TextChanged(object sender, EventArgs e)
        {
            finalUserIDVal = userIDVal_Lbl.Text;

        }
    }
}
