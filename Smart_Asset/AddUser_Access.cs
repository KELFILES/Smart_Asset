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
    public partial class AddUser_Access : Form
    {
        public AddUser_Access()
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
