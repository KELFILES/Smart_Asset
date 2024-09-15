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
    public partial class Update : Form
    {

        private RightClick rc = new RightClick();


        public Update()
        {
            InitializeComponent();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            MyDbMethods.UpdateChangesToDatabase("SmartAssetDb", dataGridView1, $"{location_Cmb.Text}_{unit_Cmb.Text}");
        }

        private void show_Btn_Click(object sender, EventArgs e)
        {
            MyDbMethods.UpdateUsingLocation("SmartAssetDb", dataGridView1, $"{location_Cmb.Text}_{unit_Cmb.Text}");
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


        private void serialNo_Cmb_MouseEnter(object sender, EventArgs e)
        {
            MyDbMethods.LoadDatabase_AllSerialNo("SmartAssetDb", serialNo_Cmb);
        }

        private void show2_Btn_Click(object sender, EventArgs e)
        {
            MyDbMethods.UpdateUsingSerialNo("SmartAssetDb", dataGridView1, $"{serialNo_Cmb.Text}");
        }

        private void serialNo_Cmb_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = char.ToUpper(e.KeyChar);
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                // Dispose of the previous form if it's still open
                if (rc != null)
                {
                    rc.Dispose();
                    rc = null;
                }

                // Create a new instance of RightClick form
                rc = new RightClick();

                // Convert the mouse position to screen coordinates
                Point screenPoint = dataGridView1.PointToScreen(e.Location);

                // Adjust for window borders and toolbars if needed (if the form has non-client areas)
                rc.StartPosition = FormStartPosition.Manual;
                rc.Location = screenPoint;  // Directly set to the screen position

                // Set up an event handler to close the form when clicking outside of it
                rc.Deactivate += (s, ev) =>
                {
                    rc.Dispose();
                    rc = null; // Set to null when disposed
                };

                // Show the new form
                rc.Show();
            }
        }















    }
}
