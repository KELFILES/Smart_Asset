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
        RightClick_RepairingHardwares rh = new RightClick_RepairingHardwares();
        RightClick_ShowAllHardwares sah = new RightClick_ShowAllHardwares();
        RightClick_DisposedHardwares dp = new RightClick_DisposedHardwares();

        public Read()
        {
            InitializeComponent();
        }



        private void Read_Load(object sender, EventArgs e)
        {
            add_Btn.Image = Image.FromFile(System.IO.Path.Combine(Application.StartupPath, "Images", "add_Icon.png"));
            add_Btn.Padding = new Padding(0, 0, 0, 0);

            edit_Btn.Image = Image.FromFile(System.IO.Path.Combine(Application.StartupPath, "Images", "edit_Icon.png"));
            edit_Btn.Padding = new Padding(0, 0, 0, 0);
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

        public class Read_Model_ForBorrow
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
            public string Name { get; set; }
            public string ReturnDate { get; set; }
            public string Notes { get; set; }
        }

        private void SendButtonInfo()
        {
            rh.SendClickBtnInfo(selectedButton);
            sah.SendClickBtnInfo(selectedButton);
            dp.SendClickBtnInfo(selectedButton);
        }

        private void show1_Btn_Click(object sender, EventArgs e)
        {
            selectedButton = "show1";

            SendButtonInfo();

            MyDbMethods.Read_SerialNo("SmartAssetDb", dataGridView1, serialNo_Cmb.Text);
            _lastRefreshAction = () => MyDbMethods.Read_SerialNo("SmartAssetDb", dataGridView1, serialNo_Cmb.Text);
        }

        private void reservedHardwares_Btn_Click_1(object sender, EventArgs e)
        {
            selectedButton = "reservedHardwares";

            SendButtonInfo();

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
                    disposedHardwares_Btn.PerformClick();

                    // Show confirmation
                    MessageBox.Show("Disposed Hardwares HAS BEEN REFRESHED");

                }
                else if (selectedButton == "borrowedHardwares")
                {
                    // Ensure the correct button is selected before invoking the action
                    borrowedHardwares_Btn.PerformClick();

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

            SendButtonInfo();

            MyDbMethods.ReadLocation("SmartAssetDb", dataGridView1, $"{location_Cmb.Text}_{unit_Cmb.Text}");
            _lastRefreshAction = () => MyDbMethods.ReadLocation("SmartAssetDb", dataGridView1, $"{location_Cmb.Text}_{unit_Cmb.Text}");
        }

        private void disposedHardwares_Btn_Click(object sender, EventArgs e)
        {
            selectedButton = "disposedHardwares";

            SendButtonInfo();

            title_Lbl.Text = "DISPOSED HARDWARE LISTS";
            MyDbMethods.ReadLocationWithNotes("SmartAssetDb", dataGridView1, "Disposed_Hardwares");
            _lastRefreshAction = () => MyDbMethods.ReadLocation("SmartAssetDb", dataGridView1, "Disposed_Hardwares");
        }

        public void repairingHardwares_Btn_Click(object sender, EventArgs e)
        {
            selectedButton = "repairingHardwares";

            SendButtonInfo();

            title_Lbl.Text = "REPAIRING HARDWARE LISTS";
            MyDbMethods.ReadLocationWithNotes("SmartAssetDb", dataGridView1, "Repairing");
            _lastRefreshAction = () => MyDbMethods.ReadLocation("SmartAssetDb", dataGridView1, "Repairing");
        }

        private void cleaningHardwares_Btn_Click(object sender, EventArgs e)
        {
            selectedButton = "cleaningHardwares";

            SendButtonInfo();

            title_Lbl.Text = "CLEANING HARDWARE LISTS";
            MyDbMethods.ReadLocationWithNotes("SmartAssetDb", dataGridView1, "Cleaning");
            _lastRefreshAction = () => MyDbMethods.ReadLocation("SmartAssetDb", dataGridView1, "Cleaning");
        }

        private async void showAllHardwares_Btn_Click(object sender, EventArgs e)
        {
            selectedButton = "showAllHardwares";

            SendButtonInfo();

            await MyDbMethods.ReadAllInDatabase("SmartAssetDb", dataGridView1);
            title_Lbl.Text = "ASSET LISTS";
        }

        private void borrowedHardwares_Btn_Click(object sender, EventArgs e)
        {
            selectedButton = "borrowedHardwares";

            SendButtonInfo();

            title_Lbl.Text = "BORROWED HARDWARE LISTS";
            MyDbMethods.ReadLocationWithNotes("SmartAssetDb", dataGridView1, "Borrowed_Hardwares", true);
            _lastRefreshAction = () => MyDbMethods.ReadLocation("SmartAssetDb", dataGridView1, "Borrowed_Hardwares");
        }

        private void dataGridView1_MouseDown(object sender, MouseEventArgs e)
        {
            if (selectedButton.Equals("showAllHardwares") ||
                selectedButton.Equals("reservedHardwares")||
                selectedButton.Equals("show1")||
                selectedButton.Equals("show2"))
            {
                if (e.Button == MouseButtons.Right)
                {
                    // Dispose of the previous form if it's still open
                    if (sah != null)
                    {
                        sah.Dispose();
                        sah = null;
                    }

                    // Always pass the current instance of Read to the RightClick form
                    sah = new RightClick_ShowAllHardwares(this);  // Pass 'this' to ensure form1 is initialized

                    // Convert the mouse position to screen coordinates
                    Point screenPoint = dataGridView1.PointToScreen(e.Location);

                    sah.StartPosition = FormStartPosition.Manual;
                    sah.Location = screenPoint;  // Directly set to the screen position

                    sah.Deactivate += (s, ev) =>
                    {
                        sah.Hide();  // Just hide instead of disposing
                    };

                    sah.Show();
                }
            }

            if (selectedButton.Equals("repairingHardwares"))
            {
                if (e.Button == MouseButtons.Right)
                {
                    // Dispose of the previous form if it's still open
                    if (rh != null)
                    {
                        rh.Dispose();
                        rh = null;
                    }

                    // Always pass the current instance of Read to the RightClick form
                    rh = new RightClick_RepairingHardwares(this);  // Pass 'this' to ensure form1 is initialized

                    // Convert the mouse position to screen coordinates
                    Point screenPoint = dataGridView1.PointToScreen(e.Location);

                    rh.StartPosition = FormStartPosition.Manual;
                    rh.Location = screenPoint;  // Directly set to the screen position

                    rh.Deactivate += (s, ev) =>
                    {
                        rh.Hide();  // Just hide instead of disposing
                    };

                    rh.Show();
                }
            }

            if (selectedButton.Equals("disposedHardwares") ||
                selectedButton.Equals("archieve") ||
                selectedButton.Equals("cleaningHardwares") ||
                selectedButton.Equals("borrowedHardwares"))
            {
                if (e.Button == MouseButtons.Right)
                {
                    // Dispose of the previous form if it's still open
                    if (dp != null)
                    {
                        dp.Dispose();
                        dp = null;
                    }

                    // Always pass the current instance of Read to the RightClick form
                    dp = new RightClick_DisposedHardwares(this);  // Pass 'this' to ensure form1 is initialized

                    // Convert the mouse position to screen coordinates
                    Point screenPoint = dataGridView1.PointToScreen(e.Location);

                    dp.StartPosition = FormStartPosition.Manual;
                    dp.Location = screenPoint;  // Directly set to the screen position

                    dp.Deactivate += (s, ev) =>
                    {
                        dp.Hide();  // Just hide instead of disposing
                    };

                    dp.Show();

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

                    // Check if rh is null before using it
                    if (rh == null)
                    {
                        rh = new RightClick_RepairingHardwares(this); // Reinitialize rc if it was disposed
                    }
                    rh.GetRetrievingSerial(null);  // Pass null to handle no selection case in RightClick

                    // Check if sah is null before using it
                    if (sah == null)
                    {
                        sah = new RightClick_ShowAllHardwares(this); // Reinitialize rc if it was disposed
                    }
                    sah.GetRetrievingSerial(null);

                    // Check if dp is null before using it
                    if (dp == null)
                    {
                        dp = new RightClick_DisposedHardwares(this); // Reinitialize rc if it was disposed
                    }

                    rh.GetRetrievingSerial(null);
                    sah.GetRetrievingSerial(null);
                    dp.GetRetrievingSerial(null);

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

                    // Reinitialize rh if it's null
                    if (rh == null)
                    {
                        rh = new RightClick_RepairingHardwares(this); // Reinitialize rc if it was disposed
                    }

                    // Wrap the single serialNo in a list and pass it to GetRetrievingSerial
                    rh.GetRetrievingSerial(new List<string> { serialNo });

                    // Reinitialize sah if it's null
                    if (sah == null)
                    {
                        sah = new RightClick_ShowAllHardwares(this); // Reinitialize rc if it was disposed
                    }

                    // Reinitialize dp if it's null
                    if (dp == null)
                    {
                        dp = new RightClick_DisposedHardwares(this); // Reinitialize rc if it was disposed
                    }

                    // Wrap the single serialNo in a list and pass it to GetRetrievingSerial
                    rh.GetRetrievingSerial(new List<string> { serialNo });
                    sah.GetRetrievingSerial(new List<string> { serialNo });
                    dp.GetRetrievingSerial(new List<string> { serialNo });
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

                    // Reinitialize rh if it's null
                    if (rh == null)
                    {
                        rh = new RightClick_RepairingHardwares(this); // Reinitialize rh if it was disposed
                    }

                    // Pass the list of serialNos to RightClick for multiple rows
                    rh.GetRetrievingSerial(selectedSerialNos);
                    sah.GetRetrievingSerial(selectedSerialNos);
                    dp.GetRetrievingSerial(selectedSerialNos);

                    // Reinitialize sah if it's null
                    if (sah == null)
                    {
                        sah = new RightClick_ShowAllHardwares(this); // Reinitialize rh if it was disposed
                    }

                    if (dp == null)
                    {
                        dp = new RightClick_DisposedHardwares(this); // Reinitialize rh if it was disposed
                    }

                    // Pass the list of serialNos to RightClick for multiple rows
                    rh.GetRetrievingSerial(selectedSerialNos);
                    sah.GetRetrievingSerial(selectedSerialNos);
                    dp.GetRetrievingSerial(selectedSerialNos);

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
            selectedButton = "archieve";
            title_Lbl.Text = "ARCHIEVE LISTS";

            SendButtonInfo();

            MyDbMethods.ReadLocation("SmartAssetDb", dataGridView1, "Archieve");
            _lastRefreshAction = () => MyDbMethods.ReadLocation("SmartAssetDb", dataGridView1, "Archieve");
        }

        // Method to refresh the DataGridView


        public void Refresh_ShowAllHardwares()
        {
            showAllHardwares_Btn.PerformClick();
        }

        public void Refresh_Archieve()
        {
            archieve_Btn.PerformClick();
        }

        public void Refresh_ReservedHardwares()
        {
            reservedHardwares_Btn.PerformClick();
        }

        public void Refresh_show1()
        {
            show1_Btn.PerformClick();
        }

        public void Refresh_show2()
        {
            show2_Btn.PerformClick();
        }


        public void Refresh_RepairingHarwares()
        {
            repairingHardwares_Btn.PerformClick();
        }

        public void Refresh_DisposedHardwares()
        {
            disposedHardwares_Btn.PerformClick();
        }

        public void Refresh_Cleaning()
        {
            cleaningHardwares_Btn.PerformClick();
        }

        public void Refresh_Borrowed()
        {
            borrowedHardwares_Btn.PerformClick();
        }

    }
}