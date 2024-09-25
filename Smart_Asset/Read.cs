using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;
using System.Windows.Forms;
using MongoDB.Bson;
using static Smart_Asset.Read;
using static System.Windows.Forms.DataFormats;


namespace Smart_Asset
{
    public partial class Read : Form
    {

        //FIELD
        public static string selectedButton = "";
        RightClick rc = new RightClick();

        public Read()
        {
            InitializeComponent();
        }



        private void Read_Load(object sender, EventArgs e)
        {

        }

        private void Read_Resize(object sender, EventArgs e)
        {

        }

        private async void export_Btn_Click(object sender, EventArgs e)
        {
            //MyDbMethods.ReadDocument("SmartAssetDb", "Reserved_Hardwares", "Type", "CPU");
        }

        public class Read_Model
        {
            public string Id { get; set; }
            public string Type { get; set; }
            public string Model { get; set; }
            public string SerialNo { get; set; }
            public string Cost { get; set; }
            public string Supplier { get; set; }
            public string Warranty { get; set; }
            public string WarrantyStatus { get; set; }
            public string PurchaseDate { get; set; }
            public string Usage { get; set; }
            public string Location { get; set; }
        }

        public class Read_ModelWithNotes
        {
            public string Id { get; set; }
            public string Type { get; set; }
            public string Model { get; set; }
            public string SerialNo { get; set; }
            public string Cost { get; set; }
            public string Supplier { get; set; }
            public string Warranty { get; set; }
            public string WarrantyStatus { get; set; }
            public string PurchaseDate { get; set; }
            public string Usage { get; set; }
            public string Location { get; set; }
            public string Notes { get; set; }
        }


        private void show1_Btn_Click(object sender, EventArgs e)
        {
            selectedButton = "show1";
            MyDbMethods.Read_SerialNo("SmartAssetDb", dataGridView1, serialNo_Cmb.Text);
            _lastRefreshAction = () => MyDbMethods.Read_SerialNo("SmartAssetDb", dataGridView1, serialNo_Cmb.Text);
        }

        private void reservedHardwares_Btn_Click_1(object sender, EventArgs e)
        {
            selectedButton = "reservedHardwares";
            title_Lbl.Text = "RESERVED HARDWARE LISTS";
            MyDbMethods.ReadLocation("SmartAssetDb", dataGridView1, "Reserved_Hardwares");
            _lastRefreshAction = () => MyDbMethods.ReadLocation("SmartAssetDb", dataGridView1, "Reserved_Hardwares");
        }


        private async void location_Cmb_DropDown_1(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            await MyDbMethods.LoadDatabase_TypeList("SmartAssetDb", "Deployment_Location_List", location_Cmb);
            Cursor = Cursors.Arrow;
        }

        private async void unit_Cmb_DropDown_1(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            await MyDbMethods.LoadDatabase_TypeList("SmartAssetDb", "Deployment_Unit_List", unit_Cmb);
            Cursor = Cursors.Arrow;
        }

        private void serialNo_Cmb_MouseEnter(object sender, EventArgs e)
        {
            MyDbMethods.LoadDatabase_AllSerialNo("SmartAssetDb", serialNo_Cmb);
        }

        private void serialNo_Cmb_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = char.ToUpper(e.KeyChar);
        }





        private Action _lastRefreshAction; // Action to store the last refresh operation

        // Override ProcessCmdKey to handle Ctrl+R key press
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            // Check if the Ctrl + R key combination is pressed
            if (keyData == (Keys.Control | Keys.R) || keyData == Keys.F5)
            {
                // Check if the selected button is "repairingHardwares"
                if (selectedButton == "repairingHardwares")
                {
                    // Ensure the correct button is selected before invoking the action
                    repairingHardwares_Btn.PerformClick();


                    // Show confirmation
                    MessageBox.Show("Repairing Hardwares HAS BEEN REFRESHED");

                }
                else if (selectedButton == "cleaningHardwares")
                {
                    // Ensure the correct button is selected before invoking the action
                    cleaningHardwares_Btn.PerformClick();

                    // Show confirmation
                    MessageBox.Show("Cleaning Hardwares HAS BEEN REFRESHED");

                }
                else if (selectedButton == "disposedHardwares")
                {
                    // Ensure the correct button is selected before invoking the action
                    cleaningHardwares_Btn.PerformClick();

                    // Show confirmation
                    MessageBox.Show("Disposed Hardwares HAS BEEN REFRESHED");

                }
                else if (selectedButton == "borrowedHardwares")
                {
                    // Ensure the correct button is selected before invoking the action
                    cleaningHardwares_Btn.PerformClick();

                    // Show confirmation
                    MessageBox.Show("Borrowed Hardwares HAS BEEN REFRESHED");

                }
            }

            // If key press is not handled, return the base method result
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void Refresh_Btn_Click(object? sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void Show2_Click_1(object sender, EventArgs e)
        {
            selectedButton = "show2";
            MyDbMethods.ReadLocation("SmartAssetDb", dataGridView1, $"{location_Cmb.Text}_{unit_Cmb.Text}");
            _lastRefreshAction = () => MyDbMethods.ReadLocation("SmartAssetDb", dataGridView1, $"{location_Cmb.Text}_{unit_Cmb.Text}");
        }

        private void disposedHardwares_Btn_Click(object sender, EventArgs e)
        {
            selectedButton = "disposedHardwares";
            title_Lbl.Text = "DISPOSED HARDWARE LISTS";
            MyDbMethods.ReadLocationWithNotes("SmartAssetDb", dataGridView1, "Disposed_Hardwares");
            _lastRefreshAction = () => MyDbMethods.ReadLocation("SmartAssetDb", dataGridView1, "Disposed_Hardwares");
        }

        public void repairingHardwares_Btn_Click(object sender, EventArgs e)
        {
            selectedButton = "repairingHardwares";
            title_Lbl.Text = "REPAIRING HARDWARE LISTS";
            MyDbMethods.ReadLocationWithNotes("SmartAssetDb", dataGridView1, "Repairing");
            _lastRefreshAction = () => MyDbMethods.ReadLocation("SmartAssetDb", dataGridView1, "Repairing");
        }

        private void cleaningHardwares_Btn_Click(object sender, EventArgs e)
        {
            selectedButton = "cleaningHardwares";
            title_Lbl.Text = "CLEANING HARDWARE LISTS";
            MyDbMethods.ReadLocationWithNotes("SmartAssetDb", dataGridView1, "Cleaning");
            _lastRefreshAction = () => MyDbMethods.ReadLocation("SmartAssetDb", dataGridView1, "Cleaning");
        }

        private async void showAllHardwares_Btn_Click(object sender, EventArgs e)
        {
            selectedButton = "showAllHardwares";
            await MyDbMethods.ReadAllInDatabase("SmartAssetDb", dataGridView1);
            title_Lbl.Text = "ASSET LISTS";
        }

        private void borrowedHardwares_Btn_Click(object sender, EventArgs e)
        {
            selectedButton = "borrowedHardwares";
            title_Lbl.Text = "BORROWED HARDWARE LISTS";
            MyDbMethods.ReadLocationWithNotes("SmartAssetDb", dataGridView1, "Borrowed_Hardwares");
            _lastRefreshAction = () => MyDbMethods.ReadLocation("SmartAssetDb", dataGridView1, "Borrowed_Hardwares");
        }

        private void dataGridView1_MouseDown(object sender, MouseEventArgs e)
        {
            if (selectedButton.Equals("repairingHardwares"))
            {
                if (e.Button == MouseButtons.Right)
                {
                    // Dispose of the previous form if it's still open
                    if (rc != null)
                    {
                        rc.Dispose();
                        rc = null;
                    }

                    // Always pass the current instance of Read to the RightClick form
                    rc = new RightClick(this);  // Pass 'this' to ensure form1 is initialized

                    // Convert the mouse position to screen coordinates
                    Point screenPoint = dataGridView1.PointToScreen(e.Location);

                    rc.StartPosition = FormStartPosition.Manual;
                    rc.Location = screenPoint;  // Directly set to the screen position

                    rc.Deactivate += (s, ev) =>
                    {
                        rc.Hide();  // Just hide instead of disposing
                    };

                    rc.Show();
                }
            }

        }


        // A list to store SerialNo values of selected rows
        List<string> selectedSerialNos = new List<string>();

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                // Initialize selectedSerialNos if it's null
                if (selectedSerialNos == null)
                {
                    selectedSerialNos = new List<string>();
                }

                // If no rows are selected, set selectedSerialNos to null
                if (dataGridView1.SelectedRows.Count == 0)
                {
                    selectedSerialNos = null;
                    Console.WriteLine("No rows selected. selectedSerialNos is now null.");

                    // Check if rc is null before using it
                    if (rc == null)
                    {
                        rc = new RightClick(this); // Reinitialize rc if it was disposed
                    }
                    rc.GetRetrievingSerial(null);  // Pass null to handle no selection case in RightClick
                    return;
                }

                // Clear the previous data from the list
                selectedSerialNos.Clear();

                if (dataGridView1.SelectedRows.Count == 1)
                {
                    // If only one row is selected, store the SerialNo of that row
                    string serialNo = dataGridView1.SelectedRows[0].Cells["SerialNo"].Value.ToString();
                    selectedSerialNos.Add(serialNo);
                    Console.WriteLine("Selected SerialNo: " + serialNo);

                    // Reinitialize rc if it's null
                    if (rc == null)
                    {
                        rc = new RightClick(this); // Reinitialize rc if it was disposed
                    }

                    // Wrap the single serialNo in a list and pass it to GetRetrievingSerial
                    rc.GetRetrievingSerial(new List<string> { serialNo });
                }
                else if (dataGridView1.SelectedRows.Count > 1)
                {
                    // If multiple rows are selected, store all their SerialNos
                    foreach (DataGridViewRow row in dataGridView1.SelectedRows)
                    {
                        string serialNo = row.Cells["SerialNo"].Value.ToString();
                        selectedSerialNos.Add(serialNo);
                    }
                    Console.WriteLine("Multiple SerialNos: " + string.Join(", ", selectedSerialNos));

                    // Reinitialize rc if it's null
                    if (rc == null)
                    {
                        rc = new RightClick(this); // Reinitialize rc if it was disposed
                    }

                    // Pass the list of serialNos to RightClick for multiple rows
                    rc.GetRetrievingSerial(selectedSerialNos);
                }
            }
            catch (Exception ex)
            {
                // Handle any unexpected errors
                MessageBox.Show($"An error occurred while processing the selection: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine($"Error: {ex.Message}\n{ex.StackTrace}");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Create cr = new Create();
            cr.Show();
        }

        private void edit_Btn_Click(object sender, EventArgs e)
        {
            EditPage ep = new EditPage();
            ep.Show();
        }


        private void recycleBin_Btn_Click(object sender, EventArgs e)
        {
            selectedButton = "recycleBin";
            title_Lbl.Text = "RECYCLE BIN LISTS";
            rc.SendClickBtnInfo(selectedButton);
            MyDbMethods.ReadLocation("SmartAssetDb", dataGridView1, "Recycle_Bin");
            _lastRefreshAction = () => MyDbMethods.ReadLocation("SmartAssetDb", dataGridView1, "Recycle_Bin");
        }

        // Method to refresh the DataGridView
        public void RefreshDataGridView()
        {
            repairingHardwares_Btn.PerformClick();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex].Name == "Modify")
            {
                MessageBox.Show("Modify this serialNo.");
            }
            if (dataGridView1.Columns[e.ColumnIndex].Name == "Delete")
            {
                MessageBox.Show("Delete this serialNo.");
            }
        }
    }
}