﻿using System;
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

        private void newRole_Cb_TextChanged(object sender, EventArgs e)
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
    }
}
