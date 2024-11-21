using MongoDB.Bson;
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
                await MyDbMethods.RemoveDocumentAsync("SmartAssetDb", "CustomUsers_Permissions", $"{userIDVal_Lbl.Text}");

            }

            if (newRole_Cb.Text.Equals("Admin"))
            {
                await MyDbMethods.UpdateFieldAsync("SmartAssetDb", "Users", $"{userIDVal_Lbl.Text}", "role", $"{newRole_Cb.Text}");

                //DELETE IN DB IF THERE ARE PERMISSION DATA IN CUSTOMUSERS_PERMISSIONS COLLECTION TO SAVE STORAGE
                await MyDbMethods.RemoveDocumentAsync("SmartAssetDb", "CustomUsers_Permissions", $"{userIDVal_Lbl.Text}");

            }

            if (newRole_Cb.Text.Equals("Custom User"))
            {
                try
                {
                    // UPDATE IN USER COLLECTION
                    await MyDbMethods.UpdateFieldAsync("SmartAssetDb", "Users", userIDVal_Lbl.Text, "role", newRole_Cb.Text);

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
                        { "AssetHistory", assetHistory_Cb.Checked ? "1" : "0" },
                        { "Add", add_Cb.Checked ? "1" : "0" },
                        { "Edit", edit_Cb.Checked ? "1" : "0" },
                        { "Replace", replace_Cb.Checked ? "1" : "0" },
                        { "Transfer", transfer_Cb.Checked ? "1" : "0" },
                        { "Borrow", borrow_Cb.Checked ? "1" : "0" },
                        { "Archive", archive_Cb.Checked ? "1" : "0" },
                        { "ShowImage", showImage_Cb.Checked ? "1" : "0" },
                        { "Dashboard", dashboard_Cb.Checked ? "1" : "0" },
                        { "ArtificialIntelligence", artificialIntelligence_Cb.Checked ? "1" : "0" },
                        { "CreateReport", createReport_Cb.Checked ? "1" : "0" },
                        { "BackupAndRestoreData", backupAndRestoreData_Cb.Checked ? "1" : "0" }
                    };

                    // Use the UpsertDocumentAsync method to insert or update the permissions document
                    await MyDbMethods.UpsertDocumentAsync("SmartAssetDb", "CustomUsers_Permissions", userIDVal_Lbl.Text, permissionsFields);

                    // If both operations are successful, update the currentRoleVal_Lbl.Text
                    currentRoleVal_Lbl.Text = newRole_Cb.Text;
                }
                catch (Exception ex)
                {
                    // Handle exceptions (optional: log the exception or show a message)
                    Console.WriteLine($"An error occurred: {ex.Message}");
                }
            }


            if (newRole_Cb.Text.Equals("") || newRole_Cb.Text.Equals(String.IsNullOrEmpty))
            {
                MessageBox.Show("Enter Role Properly!");
            }

        }

        private async void userIDVal_Lbl_TextChanged(object sender, EventArgs e)
        {

        }

        private void ChangeRole_FormClosed(object sender, FormClosedEventArgs e)
        {
            //Refresh
            ManageUsers.Refresh_ManageUsers();
        }
    }
}
