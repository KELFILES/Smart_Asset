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
    public partial class Deployment : Form
    {
        public Deployment()
        {
            InitializeComponent();
        }

        private void addLocation_Btn_Click(object sender, EventArgs e)
        {
            Deployment_Location_List dll = new Deployment_Location_List();
            dll.Show();
        }

        private void addUnit_Btn_Click(object sender, EventArgs e)
        {
            Deployment_Unit_List dul = new Deployment_Unit_List();
            dul.Show();
        }

        private async void location_DropDown(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            await MyDbMethods.LoadDatabase_TypeList("SmartAssetDb", "Deployment_Location_List", location_Cmb);
            Cursor = Cursors.Arrow;
        }

        private async void unit_DropDown(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            await MyDbMethods.LoadDatabase_TypeList("SmartAssetDb", "Deployment_Unit_List", unit_Cmb);
            Cursor = Cursors.Arrow;
        }

        private async void type_Cmb_DropDown(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            await MyDbMethods.LoadDatabase_TypeList("SmartAssetDb", "Type_List", type_Cmb);
            Cursor = Cursors.Arrow;
        }


        private async void textBox1_MouseClick(object sender, MouseEventArgs e)
        {
            await MyDbMethods.LoadDatabase_SerialNo("SmartAssetDb", "Reserved_Hardwares", serialNo_Cmb, type_Cmb.Text);
        }

        private Action _lastRefreshAction;

        // Override ProcessCmdKey to handle Ctrl+R key press
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            // Check if the Ctrl + R key combination is pressed
            if (keyData == (Keys.Control | Keys.R))
            {
                _lastRefreshAction?.Invoke(); // Invoke the last refresh action
                MessageBox.Show("DATA HAS BEEN REFRESHED");
                return true; // Indicate that the key press was handled
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private async void enter_Btn_Click(object sender, EventArgs e)
        {
            bool success = await MyDbMethods.MoveDocument(
                    "SmartAssetDb",
                    "Reserved_Hardwares",
                    $"{location_Cmb.Text}_{unit_Cmb.Text}",
                    type_Cmb.Text,
                    serialNo_Cmb.Text);

            if (success)
            {
                MessageBox.Show($"{type_Cmb.Text} : {serialNo_Cmb.Text} \n" +
                                $"Has been Deployed to \n" +
                                $"{location_Cmb.Text} : {unit_Cmb.Text}");

                MyDbMethods.ReadLocation("SmartAssetDb", dataGridView1, $"{location_Cmb.Text}_{unit_Cmb.Text}");
                _lastRefreshAction = () => MyDbMethods.ReadLocation("SmartAssetDb", dataGridView1, $"{location_Cmb.Text}_{unit_Cmb.Text}");
            }
            else
            {
                MessageBox.Show("Error: There's a problem in deploying it.",
                                "Deployment Error",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }






    }
}
