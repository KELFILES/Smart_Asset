﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.DataFormats;

namespace Smart_Asset
{
    public partial class RightClick_ManageUsers : Form
    {
        private ManageUsers form1;  // Reference to Form1 (Read)

        //FIELDS
        Update_Users us = new Update_Users();
        ChangeRole cr = new ChangeRole();
        ChangePermission cp = new ChangePermission();
        ResetPassword rp = new ResetPassword();
        RemoveUser ru = new RemoveUser();



        // Parameterless constructor (still needed by the designer)
        public RightClick_ManageUsers()
        {
            InitializeComponent();
        }

        private void RightClick_ManageUsers_Load(object sender, EventArgs e)
        {
            try
            {
                // Ensure all lists have at least one element before accessing the first item
                if (userIDs.Count > 0 && names.Count > 0 && roles.Count > 0)
                {
                    panel4.Visible = false;

                    // Continue if only one row is selected
                    string userID = userIDs[0];
                    string name = names[0];
                    string role = roles[0];

                    if (userIDs.Count == 1)
                    {
                        Console.WriteLine(role);
                        if (role.Equals("Custom User"))
                        {
                            panel4.Visible = true;
                        }
                    }
                    else
                    {
                        panel4.Visible = false;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                // Optionally, handle or log the exception in a way that helps with debugging
            }
        }


        // Constructor that accepts Form1 (Read) as a parameter
        public RightClick_ManageUsers(ManageUsers form1)
        {
            InitializeComponent();
            this.form1 = form1;
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




        //FOR GETTING DATA FROM READ.CS
        static string getClickBtnInfo;
        public void SendClickBtnInfo(string data)
        {
            getClickBtnInfo = data;
        }

        // Change getData to be a list of serial numbers
        static List<string> getData = new List<string>();

        // Method to accept a list of serial numbers
        public void GetRetrievingUserID(List<string> data)
        {
            getData = data;
        }

        // Define separate lists for userID, name, and role
        static List<string> userIDs = new List<string>();
        static List<string> names = new List<string>();
        static List<string> roles = new List<string>();

        // Method to accept lists of userID, name, and role
        public void GetRetrievingUserID(List<string> userIDList, List<string> nameList, List<string> roleList)
        {
            userIDs = userIDList;
            names = nameList;
            roles = roleList;
        }


        private void editInformation_Btn_Click(object sender, EventArgs e)
        {
            /*
            try
            {
                // Check if getData is null or empty
                if (getData == null || getData.Count == 0)
                {
                    // Log diagnostic message for debugging
                    Console.WriteLine("getData is either null or empty.");

                    MessageBox.Show("No Row selected. Please select at least one row.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Log the selected user IDs for debugging
                Console.WriteLine("Selected userIDs: " + string.Join(", ", getData));
                Console.WriteLine("Number of selected userIDs: " + getData.Count);

                // Proceed with form display and setup
                us.FormBorderStyle = FormBorderStyle.FixedSingle;
                us.StartPosition = FormStartPosition.CenterScreen;
                us.userID_Cmb.Text = string.Join(", ", getData);
                us.Show();
                us.show2_Btn.PerformClick();
            }
            catch (Exception ex)
            {
                // Handle any exceptions and display an error message
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine($"Error: {ex.Message}\n{ex.StackTrace}");
            }
            */




            try
            {
                if (userIDs == null || userIDs.Count == 0)
                {
                    // Log diagnostic message for debugging
                    Console.WriteLine("getData is either null or empty.");

                    MessageBox.Show("No Row selected. Please select at least one row.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }


                // Continue if only one row is selected
                string userID = userIDs[0];
                string name = names[0];
                string role = roles[0];

                us.FormBorderStyle = FormBorderStyle.FixedSingle;
                us.StartPosition = FormStartPosition.CenterScreen;

                us.FormBorderStyle = FormBorderStyle.FixedSingle;
                us.StartPosition = FormStartPosition.CenterScreen;
                us.userID_Cmb.Text = string.Join(", ", userIDs);
                us.Show();
                us.show2_Btn.PerformClick();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine($"Error: {ex.Message}\n{ex.StackTrace}");
            }
        }


        private void refresh_Btn_Click(object sender, EventArgs e)
        {
            //Refresh
            ManageUsers.Refresh_ManageUsers();

            // Close the form after the operation is complete
            this.Close();
            this.Dispose();
        }

        private void changeRole_Btn_Click(object sender, EventArgs e)
        {
            try
            {
                if (userIDs == null || userIDs.Count == 0)
                {
                    MessageBox.Show("No Row selected. Please select at least one Row.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (userIDs.Count > 1)
                {
                    MessageBox.Show("Only one row selection allowed for changing the Role.", "Multiple Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Continue if only one row is selected
                string userID = userIDs[0];
                string name = names[0];
                string role = roles[0];

                cr.FormBorderStyle = FormBorderStyle.FixedSingle;
                cr.StartPosition = FormStartPosition.CenterScreen;

                // Set the values in the ChangeRole form
                cr.userIDVal_Lbl.Text = userID;
                cr.nameVal_Lbl.Text = name;
                cr.currentRoleVal_Lbl.Text = role;

                cr.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine($"Error: {ex.Message}\n{ex.StackTrace}");
            }
        }

        private void changePermission_Btn_Click(object sender, EventArgs e)
        {
            try
            {
                if (userIDs == null || userIDs.Count == 0)
                {
                    MessageBox.Show("No Row selected. Please select at least one Row.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (userIDs.Count > 1)
                {
                    MessageBox.Show("Only one row selection allowed for changing the Role.", "Multiple Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Continue if only one row is selected
                string userID = userIDs[0];
                string name = names[0];
                string role = roles[0];

                cp.FormBorderStyle = FormBorderStyle.FixedSingle;
                cp.StartPosition = FormStartPosition.CenterScreen;

                // Set the values in the ChangeRole form
                cp.userIDVal_Lbl.Text = userID;
                cp.nameVal_Lbl.Text = name;

                cp.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine($"Error: {ex.Message}\n{ex.StackTrace}");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (userIDs == null || userIDs.Count == 0)
                {
                    // Log diagnostic message for debugging
                    MessageBox.Show("No row selected. Please select at least one row.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (userIDs.Count == 1)
                {
                    // Continue if only one row is selected
                    string userID = userIDs[0];
                    string name = names[0];
                    string role = roles[0];

                    rp.FormBorderStyle = FormBorderStyle.FixedSingle;
                    rp.StartPosition = FormStartPosition.CenterScreen;

                    // Set the values in the ChangeRole form
                    rp.userIDVal_Lbl.Text = userID;
                    rp.nameVal_Lbl.Text = name;

                    rp.Show();
                }
                else if (userIDs.Count > 1)
                {
                    MessageBox.Show("Please Select Only One Row!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine($"Error: {ex.Message}\n{ex.StackTrace}");
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            try
            {
                if (userIDs == null || userIDs.Count == 0)
                {
                    // Log diagnostic message for debugging
                    MessageBox.Show("No row selected. Please select at least one row.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (userIDs.Count == 1)
                {
                    // Continue if only one row is selected
                    string userID = userIDs[0];
                    string name = names[0];
                    string role = roles[0];

                    ru.FormBorderStyle = FormBorderStyle.FixedSingle;
                    ru.StartPosition = FormStartPosition.CenterScreen;

                    // Set the values in the ChangeRole form
                    ru.userIDVal_Lbl.Text = userID;
                    ru.nameVal_Lbl.Text = name;

                    ru.Show();
                }
                else if (userIDs.Count > 1)
                {
                    MessageBox.Show("Please Select Only One Row!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine($"Error: {ex.Message}\n{ex.StackTrace}");
            }
            
        }
    }
}
