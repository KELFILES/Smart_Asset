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


namespace Smart_Asset
{
    public partial class Read : Form
    {

        //FIELD
        string selectedButton = "";

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
            if (keyData == (Keys.Control | Keys.R))
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


        private void Show2_Click_1(object sender, EventArgs e)
        {
            selectedButton = "show2";
            MyDbMethods.ReadLocation("SmartAssetDb", dataGridView1, $"{location_Cmb.Text}_{unit_Cmb.Text}");
            _lastRefreshAction = () => MyDbMethods.ReadLocation("SmartAssetDb", dataGridView1, $"{location_Cmb.Text}_{unit_Cmb.Text}");
        }

        private void disposedHardwares_Btn_Click(object sender, EventArgs e)
        {
            selectedButton = "disposedHardwares";
            MyDbMethods.ReadLocation("SmartAssetDb", dataGridView1, "Disposed");
            _lastRefreshAction = () => MyDbMethods.ReadLocation("SmartAssetDb", dataGridView1, "Reserved_Hardwares");
        }

        private void repairingHardwares_Btn_Click(object sender, EventArgs e)
        {
            selectedButton = "repairingHardwares";
            MyDbMethods.ReadLocation("SmartAssetDb", dataGridView1, "Repairing");
            _lastRefreshAction = () => MyDbMethods.ReadLocation("SmartAssetDb", dataGridView1, "Reserved_Hardwares");
        }

        private void cleaningHardwares_Btn_Click(object sender, EventArgs e)
        {
            selectedButton = "cleaningHardwares";
            MyDbMethods.ReadLocation("SmartAssetDb", dataGridView1, "Cleaning");
            _lastRefreshAction = () => MyDbMethods.ReadLocation("SmartAssetDb", dataGridView1, "Reserved_Hardwares");
        }

        private async void showAllHardwares_Btn_Click(object sender, EventArgs e)
        {
            selectedButton = "showAllHardwares";
            await MyDbMethods.ReadAllInDatabase("SmartAssetDb", dataGridView1);
        }

        private void borrowedHardwares_Btn_Click(object sender, EventArgs e)
        {
            selectedButton = "borrowedHardwares";
            MyDbMethods.ReadLocation("SmartAssetDb", dataGridView1, "Borrowed");
            _lastRefreshAction = () => MyDbMethods.ReadLocation("SmartAssetDb", dataGridView1, "Borrowed_Hardwares");
        }

        private void dataGridView1_MouseDown(object sender, MouseEventArgs e)
        {
            // Check if there are any selected rows before proceeding
            if (dataGridView1.SelectedRows.Count == 0)
            {
                Console.WriteLine("No row is selected. Right-click context menu will not be shown.");
                return; // Exit the method if no row is selected
            }

            if (selectedButton.Equals("repairingHardwares"))
            {
                if (e.Button == MouseButtons.Right)
                {
                    // Avoid multiple form instances
                    RightClick rc = new RightClick();

                    // Convert the mouse position to screen coordinates
                    Point screenPoint = dataGridView1.PointToScreen(e.Location);

                    // Adjust for window borders and toolbars if needed (if the form has non-client areas)
                    rc.StartPosition = FormStartPosition.Manual;
                    rc.Location = screenPoint;  // Directly set to the screen position

                    // Ensure the form is not minimized when clicking the button
                    rc.TopMost = true;  // This ensures that the form stays on top of other windows

                    // Set up an event handler to close the form when clicking outside of it
                    rc.Deactivate += (s, ev) =>
                    {
                        rc.Dispose();
                        rc = null; // Set to null when disposed
                    };

                    // Show the new form without minimizing the main form
                    rc.ShowDialog();  // ShowDialog keeps focus on the current form until the dialog is closed

                    // After dialog is closed, ensure the main form stays in Normal state
                    this.WindowState = FormWindowState.Normal;  // Ensure the main form doesn't minimize
                }
            }

        }


        // A list to store SerialNo values of selected rows
        List<string> selectedSerialNos = new List<string>();

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (selectedButton.Equals("repairingHardwares"))
            {
                try
                {
                    // Check if DataGridView has any rows
                    if (dataGridView1.Rows.Count == 0)
                    {
                        Console.WriteLine("No data available in the DataGridView.");
                        return; // Exit if no data is present in the DataGridView
                    }

                    // Initialize RightClick before accessing it
                    RightClick rc = new RightClick();

                    // Initialize selectedSerialNos if it's null
                    if (selectedSerialNos == null)
                    {
                        selectedSerialNos = new List<string>();
                    }

                    // If no rows are selected, clear selectedSerialNos and return
                    if (dataGridView1.SelectedRows.Count == 0)
                    {
                        selectedSerialNos.Clear();
                        Console.WriteLine("No rows selected.");
                        rc.GetRetrievingSerial(null);  // Pass null to handle no selection case in RightClick
                        return;
                    }

                    // Clear the previous data from the list
                    selectedSerialNos.Clear();

                    if (dataGridView1.SelectedRows.Count == 1)
                    {
                        // If only one row is selected, store the SerialNo of that row
                        string serialNo = dataGridView1.SelectedRows[0].Cells["SerialNo"].Value?.ToString();
                        if (!string.IsNullOrEmpty(serialNo))
                        {
                            selectedSerialNos.Add(serialNo);
                            Console.WriteLine("Selected SerialNo: " + serialNo);

                            // Wrap the single serialNo in a list and pass it to GetRetrievingSerial
                            rc.GetRetrievingSerial(new List<string> { serialNo });
                        }
                        else
                        {
                            Console.WriteLine("SerialNo is null or empty.");
                        }
                    }
                    else if (dataGridView1.SelectedRows.Count > 1)
                    {
                        // If multiple rows are selected, store all their SerialNos
                        foreach (DataGridViewRow row in dataGridView1.SelectedRows)
                        {
                            string serialNo = row.Cells["SerialNo"].Value?.ToString();
                            if (!string.IsNullOrEmpty(serialNo))
                            {
                                selectedSerialNos.Add(serialNo);
                            }
                        }

                        Console.WriteLine("Multiple SerialNos: " + string.Join(", ", selectedSerialNos));

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
        }










    }
}
