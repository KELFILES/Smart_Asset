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
    public partial class Update_Users : Form
    {

        private RightClick_RepairingHardwares rc = new RightClick_RepairingHardwares();


        public Update_Users()
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

        private void button1_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Are you sure you want to update changes?", "Confirm Update", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                MyDbMethods.UpdateChangesToUsers("SmartAssetDb", dataGridView1, "Users");
            }
            else
            {
                MessageBox.Show("Update canceled.", "Update Canceled", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void show_Btn_Click(object sender, EventArgs e)
        {

        }

        private async void location_Cmb_DropDown(object sender, EventArgs e)
        {

        }

        private async void unit_Cmb_DropDown(object sender, EventArgs e)
        {

        }


        private void serialNo_Cmb_MouseEnter(object sender, EventArgs e)
        {
            MyDbMethods.LoadDatabase_AllSerialNo("SmartAssetDb", userID_Cmb);
        }

        private void show2_Btn_Click(object sender, EventArgs e)
        {
            MyDbMethods.UpdateUsingUserID("SmartAssetDb","Users", dataGridView1, $"{userID_Cmb.Text}");
        }

        private void serialNo_Cmb_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = char.ToUpper(e.KeyChar);
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            
        }















    }
}
