﻿using MongoDB.Bson;
using MongoDB.Driver;
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
    public partial class AddUser : Form
    {
        public AddUser()
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

        //FIELDS
        private string encryptedPass { get; set; }
        AddUser_Access aua = new AddUser_Access();

        private async void button1_Click(object sender, EventArgs e)
        {
            // Check if any of the TextBoxes are null or empty
            if (string.IsNullOrWhiteSpace(name_Tb.Text) ||
                string.IsNullOrWhiteSpace(email_Tb.Text) ||
                string.IsNullOrWhiteSpace(contactNo_Tb.Text) ||
                string.IsNullOrWhiteSpace(address_Tb.Text) ||
                string.IsNullOrWhiteSpace(username_Tb.Text) ||
                string.IsNullOrWhiteSpace(password_Tb.Text) ||
                string.IsNullOrWhiteSpace(reEnterPassword_Tb.Text) ||
                string.IsNullOrWhiteSpace(role_Cb.Text))
            {
                MessageBox.Show("Please Fill Up The Blanks.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Exit the method if any field is empty
            }

            // Check if the username is already used
            bool isUsernameUsed = await MyDbMethods.IsUsernameAlreadyUsed("SmartAssetDb", "Users", username_Tb.Text);

            if (isUsernameUsed)
            {
                MessageBox.Show("Username is Already Used", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Exit the method if the username is already used
            }

            // Check if password and re-entered password match
            if (password_Tb.Text != reEnterPassword_Tb.Text)
            {
                MessageBox.Show("Passwords do not match.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Exit the method if passwords don't match
            }

            // Encrypt the password
            string encryptedPass = MyOtherMethods.EncryptPassword(password_Tb.Text);
            Console.WriteLine(encryptedPass);

            // Generate the userID once and store it in a variable
            var userIdValue = ObjectId.GenerateNewId().ToString();

            // Prepare the fields to be inserted with user information
            var fields = new Dictionary<string, object>
    {
        { "name", name_Tb.Text },
        { "email", email_Tb.Text },
        { "contactNo", contactNo_Tb.Text },
        { "address", address_Tb.Text },
        { "username", username_Tb.Text },
        { "password", encryptedPass },
        { "role", role_Cb.Text },
        { "userID", userIdValue } // Use the generated userID here
    };

            // Insert the user document into the database
            await MyDbMethods.InsertDocument("SmartAssetDb", "Users", fields);

            if (role_Cb.Text.Equals("Custom User"))
            {
                // Prepare the permissions fields with the same userID
                var permissionsFields = new Dictionary<string, string>
                {
                    { "userID", userIdValue },  // Use the same userID here
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
                    { "Artificial Intelligence", artificialIntelligence.Checked ? "1" : "0" },
                    { "Create Report", createReport_Cb.Checked ? "1" : "0" },
                    { "Backup And Restore Data", backupAndRestoreData_Cb.Checked ? "1" : "0" }
                };

                // Use the UpsertDocumentAsync method to insert or update the permissions document
                await MyDbMethods.UpsertDocumentAsync("SmartAssetDb", "CustomUsers_Permissions", userIdValue, permissionsFields);
            }
        }

        private void role_Cb_TextChanged(object sender, EventArgs e)
        {

        }

        private void AddUser_Load(object sender, EventArgs e)
        {
            lowerLabel_Lbl.Text = "";
            topLabel_Lbl.Text = "";
            panel4.Hide();
            assetEnabled_Panel.Visible = false;

            MyOtherMethods.CenterInPanel(topLabel_Lbl, panel3);
            MyOtherMethods.CenterInPanel(lowerLabel_Lbl, panel3);
        }

        private void role_Cb_TextChanged_1(object sender, EventArgs e)
        {
            
            if (role_Cb.Text.Equals(String.IsNullOrEmpty) || role_Cb.Text.Equals(""))
            {
                lowerLabel_Lbl.Text = "";
                topLabel_Lbl.Text = "";
                panel4.Hide();
                assetEnabled_Panel.Visible = false;
            }

            if (role_Cb.Text.Equals("Super Admin"))
            {
                lowerLabel_Lbl.Text = "All Access Is Allowed Including Manage Users.";
                topLabel_Lbl.Text = "Super Admin";
                panel4.Hide();
            }

            else if (role_Cb.Text.Equals("Admin"))
            {
                lowerLabel_Lbl.Text = "All Access Is Allowed Excluding Manage Users.";
                topLabel_Lbl.Text = "Admin";
                panel4.Hide();
            }

            else if (role_Cb.Text.Equals("Custom User"))
            {
                lowerLabel_Lbl.Text = "Select only the allowed access below.";
                topLabel_Lbl.Text = "Custom User";
                panel4.Show();
            }

            MyOtherMethods.CenterInPanel(topLabel_Lbl, panel3);
            MyOtherMethods.CenterInPanel(lowerLabel_Lbl, panel3);
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

        private void button5_Click(object sender, EventArgs e)
        {
            add_Cb.Checked = true;
            edit_Cb.Checked = true;
            replace_Cb.Checked = true;
            transfer_Cb.Checked = true;
            borrow_Cb.Checked = true;
            archive_Cb.Checked = true;
            showImage_Cb.Checked = true;
        }

        private void button2_Click(object sender, EventArgs e)
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
            artificialIntelligence.Checked = true;
            createReport_Cb.Checked = true;
            backupAndRestoreData_Cb.Checked = true;
            archived_Cb.Checked = true;
            showImage_Cb.Checked = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dashboard_Cb.Checked = false;
            artificialIntelligence.Checked = false;
            createReport_Cb.Checked = false;
            backupAndRestoreData_Cb.Checked = false;
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
    }
}