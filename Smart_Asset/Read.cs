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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Smart_Asset.Images;


namespace Smart_Asset
{
    public partial class Read : Form
    {

        // Declare the debounce timer as a class-level variable
        private System.Timers.Timer debounceTimer;

        //FIELD
        public static string selectedButton = "";
        RightClick_RepairingHardwares rh = new RightClick_RepairingHardwares();
        RightClick_ShowAllHardwares sah = new RightClick_ShowAllHardwares();
        RightClick_DisposedHardwares dp = new RightClick_DisposedHardwares();
        RightClick_Replacement rep = new RightClick_Replacement();
        Settings1 s1 = new Settings1();
        HideColumn hc = new HideColumn();
        private int previousTextLength = 0;


        public Read()
        {
            InitializeComponent();

            // Enable double buffering for the entire form
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer |
                          ControlStyles.UserPaint |
                          ControlStyles.AllPaintingInWmPaint, true);
            this.UpdateStyles();

            //Double Buffering for DataGridView
            EnableDoubleBuffering(dataGridView1);

            // Subscribe to the MouseWheel event for additional functionality
            dataGridView1.MouseWheel += DataGridView1_MouseWheel;

            //static fields
            StaticDataGridView = dataGridView1;
            p8 = panel8;

            // Initialize the debounce timer
            debounceTimer = new System.Timers.Timer(500); // 500 milliseconds debounce time
            debounceTimer.AutoReset = false; // Trigger only once after the delay
            debounceTimer.Elapsed += DebounceTimer_Elapsed;
        }
        //static fields
        public static DataGridView StaticDataGridView;
        public static Panel p8;

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



        private void EnableDoubleBuffering(DataGridView dgv)
        {
            typeof(DataGridView).InvokeMember("DoubleBuffered",
                System.Reflection.BindingFlags.NonPublic |
                System.Reflection.BindingFlags.Instance |
                System.Reflection.BindingFlags.SetProperty,
                null,
                dgv,
                new object[] { true });

            dataGridView1.VirtualMode = true;
            dataGridView1.EnableHeadersVisualStyles = false;
        }

        private void Read_Load(object sender, EventArgs e)
        {
            // Load data initially
            LoadData();
        }



        private void Read_Resize(object sender, EventArgs e)
        {

        }

        private async void export_Btn_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count == 0)
            {
                MessageBox.Show("There is no data to export.", "Export", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Commit any pending edits in the DataGridView
            dataGridView1.EndEdit();
            dataGridView1.CommitEdit(DataGridViewDataErrorContexts.Commit);

            string selectedFormat = exportTo_Cb.SelectedItem?.ToString();

            if (string.IsNullOrEmpty(selectedFormat))
            {
                MessageBox.Show("Please select a file format to export.", "Export", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Title = "Select Download Location";

                if (selectedFormat.Equals("Microsoft Excel File (.xlsx)"))
                {
                    saveFileDialog.Filter = "Excel Files (*.xlsx)|*.xlsx";
                }
                else if (selectedFormat.Equals("Microsoft Word File (.docx)"))
                {
                    saveFileDialog.Filter = "Word Files (*.docx)|*.docx";
                }
                else if (selectedFormat.Equals("PDF File (.pdf)"))
                {
                    saveFileDialog.Filter = "PDF Files (*.pdf)|*.pdf";
                }
                else if (selectedFormat.Equals("CSV File (.csv)"))
                {
                    saveFileDialog.Filter = "CSV Files (*.csv)|*.csv";
                }
                else if (selectedFormat.Equals("XML File (.xml)"))
                {
                    saveFileDialog.Filter = "XML Files (*.xml)|*.xml";
                }
                else if (selectedFormat.Equals("JSON File (.json)"))
                {
                    saveFileDialog.Filter = "JSON Files (*.json)|*.json";
                }
                else if (selectedFormat.Equals("HTML File (.html)"))
                {
                    saveFileDialog.Filter = "HTML Files (*.html)|*.html";
                }
                else if (selectedFormat.Equals("Text File (.txt)"))
                {
                    saveFileDialog.Filter = "Text Files (*.txt)|*.txt";
                }
                else
                {
                    MessageBox.Show("Unsupported file format selected.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = saveFileDialog.FileName;

                    try
                    {
                        // Change cursor to wait state
                        Cursor.Current = Cursors.WaitCursor;

                        // Export the DataGridView content based on the selected format
                        if (selectedFormat.Equals("Microsoft Excel File (.xlsx)"))
                        {
                            Exporter.ExportDataGridViewToExcel(dataGridView1, filePath, true);
                        }
                        else if (selectedFormat.Equals("Microsoft Word File (.docx)"))
                        {
                            Exporter.ExportDataGridViewToWord(dataGridView1, filePath, true);
                        }
                        else if (selectedFormat.Equals("PDF File (.pdf)"))
                        {
                            Exporter.ExportDataGridViewToPDF(dataGridView1, filePath);
                        }
                        else if (selectedFormat.Equals("CSV File (.csv)"))
                        {
                            Exporter.ExportDataGridViewToCSV(dataGridView1, filePath);
                        }
                        else if (selectedFormat.Equals("XML File (.xml)"))
                        {
                            Exporter.ExportDataGridViewToXML(dataGridView1, filePath);
                        }
                        else if (selectedFormat.Equals("JSON File (.json)"))
                        {
                            Exporter.ExportDataGridViewToJSON(dataGridView1, filePath);
                        }
                        else if (selectedFormat.Equals("HTML File (.html)"))
                        {
                            Exporter.ExportDataGridViewToHTML(dataGridView1, filePath);
                        }
                        else if (selectedFormat.Equals("Text File (.txt)"))
                        {
                            Exporter.ExportDataGridViewToTXT(dataGridView1, filePath);
                        }

                        // Notify user of successful export
                        MessageBox.Show("Data exported successfully!", "Export", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"An error occurred during export: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        // Revert cursor back to default
                        Cursor.Current = Cursors.Default;
                    }
                }
            }
        }



        public class Read_Model
        {
            public string Type { get; set; }
            public string Brand { get; set; }
            public string Model { get; set; }
            public string PropertyID { get; set; }
            public string SerialNo { get; set; }
            public string PONumber { get; set; }
            public string SINumber { get; set; }
            public string Cost { get; set; }
            public string Warranty { get; set; }
            public string Supplier { get; set; }
            public string WarrantyStatus { get; set; }
            public string PurchaseDate { get; set; }
            public string Usage { get; set; }
            public string Location { get; set; }
        }

        public class Read_ModelWithNotes
        {
            public string Type { get; set; }
            public string Brand { get; set; }
            public string Model { get; set; }
            public string PropertyID { get; set; }
            public string SerialNo { get; set; }
            public string PONumber { get; set; }
            public string SINumber { get; set; }
            public string Cost { get; set; }
            public string Warranty { get; set; }
            public string Supplier { get; set; }
            public string WarrantyStatus { get; set; }
            public string PurchaseDate { get; set; }
            public string Usage { get; set; }
            public string Location { get; set; }
            public string Notes { get; set; }
        }

        public class Read_Model_ForBorrow
        {
            public string Type { get; set; }
            public string Brand { get; set; }
            public string Model { get; set; }
            public string PropertyID { get; set; }
            public string SerialNo { get; set; }
            public string PONumber { get; set; }
            public string SINumber { get; set; }
            public string Cost { get; set; }
            public string Warranty { get; set; }
            public string Supplier { get; set; }
            public string WarrantyStatus { get; set; }
            public string PurchaseDate { get; set; }
            public string Usage { get; set; }
            public string Location { get; set; }
            public string Name { get; set; }
            public string ReturnDate { get; set; }
            public string Notes { get; set; }
        }

        public class Read_Model_ForManageUsers
        {
            public string UserID { get; set; }
            public string Name { get; set; }
            public string Username { get; set; }
        }
        private void SendButtonInfo()
        {
            rh.SendClickBtnInfo(selectedButton);
            sah.SendClickBtnInfo(selectedButton);
            dp.SendClickBtnInfo(selectedButton);
        }



        private void reservedHardwares_Btn_Click_1(object sender, EventArgs e)
        {
            selectedButton = "reservedHardwares";

            SendButtonInfo();

            MyDbMethods.ReadLocation("SmartAssetDb", dataGridView1, "Reserved_Hardwares");
            _lastRefreshAction = () => MyDbMethods.ReadLocation("SmartAssetDb", dataGridView1, "Reserved_Hardwares");
        }


        private async void location_Cmb_DropDown_1(object sender, EventArgs e)
        {


            // Clear existing items and load from database
            location_Cmb.Items.Clear();

            Cursor = Cursors.WaitCursor;
            await MyDbMethods.LoadDatabase_TypeList("SmartAssetDb", "Deployment_Location_List", location_Cmb);
            Cursor = Cursors.Arrow;

            // Insert "N/A" at the first position
            location_Cmb.Items.Insert(0, "N/A");
        }

        private async void unit_Cmb_DropDown_1(object sender, EventArgs e)
        {
            // Clear existing items and load from database
            unit_Cmb.Items.Clear();

            Cursor = Cursors.WaitCursor;
            await MyDbMethods.LoadDatabase_TypeList("SmartAssetDb", "Deployment_Unit_List", unit_Cmb);
            Cursor = Cursors.Arrow;

            // Insert "N/A" at the first position
            unit_Cmb.Items.Insert(0, "N/A");
        }

        private void serialNo_Cmb_MouseEnter(object sender, EventArgs e)
        {

        }

        private void serialNo_Cmb_KeyPress(object sender, KeyPressEventArgs e)
        {

        }





        private Action _lastRefreshAction; // Action to store the last refresh operation

        // Override ProcessCmdKey to handle Ctrl+R key press
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            // Check if the Ctrl + R key combination is pressed
            if (keyData == (Keys.Control | Keys.R) || keyData == Keys.F5)
            {
                if (selectedButton == "replacement")
                {
                    // Ensure the correct button is selected before invoking the action
                    replacement_Btn.PerformClick();


                    // Show confirmation
                    MessageBox.Show("Replacement HAS BEEN REFRESHED");

                }
                else if (selectedButton == "cleaningHardwares")
                {
                    // Ensure the correct button is selected before invoking the action
                    cleaningHardwares_Btn.PerformClick();

                    // Show confirmation
                    MessageBox.Show("Cleaning HAS BEEN REFRESHED");

                }
                else if (selectedButton == "disposedHardwares")
                {
                    // Ensure the correct button is selected before invoking the action
                    disposedHardwares_Btn.PerformClick();

                    // Show confirmation
                    MessageBox.Show("Disposed HAS BEEN REFRESHED");

                }
                else if (selectedButton == "borrowedHardwares")
                {
                    // Ensure the correct button is selected before invoking the action
                    borrowedHardwares_Btn.PerformClick();

                    // Show confirmation
                    MessageBox.Show("Borrowed HAS BEEN REFRESHED");
                }
                else if (selectedButton == "archive")
                {
                    // Ensure the correct button is selected before invoking the action
                    archive_Btn.PerformClick();

                    // Show confirmation
                    MessageBox.Show("Borrowed HAS BEEN REFRESHED");
                }
            }

            // If key press is not handled, return the base method result
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void Refresh_Btn_Click(object? sender, EventArgs e)
        {
            throw new NotImplementedException();
        }



        private void disposedHardwares_Btn_Click(object sender, EventArgs e)
        {
            selectedButton = "disposedHardwares";

            SendButtonInfo();

            MyDbMethods.ReadLocationWithNotes("SmartAssetDb", dataGridView1, "Disposed_Hardwares");
            _lastRefreshAction = () => MyDbMethods.ReadLocation("SmartAssetDb", dataGridView1, "Disposed_Hardwares");
        }

        public void repairingHardwares_Btn_Click(object sender, EventArgs e)
        {

            selectedButton = "replacement";

            SendButtonInfo();

            MyDbMethods.ReadLocationWithNotes("SmartAssetDb", dataGridView1, "Replacement");
            _lastRefreshAction = () => MyDbMethods.ReadLocation("SmartAssetDb", dataGridView1, "replacement");
        }

        private void cleaningHardwares_Btn_Click(object sender, EventArgs e)
        {
            selectedButton = "cleaningHardwares";

            SendButtonInfo();

            MyDbMethods.ReadLocationWithNotes("SmartAssetDb", dataGridView1, "Cleaning");
            _lastRefreshAction = () => MyDbMethods.ReadLocation("SmartAssetDb", dataGridView1, "Cleaning");
        }

        private async void showAllHardwares_Btn_Click(object sender, EventArgs e)
        {
            selectedButton = "showAllHardwares";

            SendButtonInfo();

            await MyDbMethods.ReadAllInDatabase("SmartAssetDb", dataGridView1);
        }

        private void borrowedHardwares_Btn_Click(object sender, EventArgs e)
        {
            selectedButton = "borrowedHardwares";

            SendButtonInfo();

            MyDbMethods.ReadLocationWithNotes("SmartAssetDb", dataGridView1, "Borrowed", true);
            _lastRefreshAction = () => MyDbMethods.ReadLocation("SmartAssetDb", dataGridView1, "Borrowed_Hardwares");
        }

        private void dataGridView1_MouseDown(object sender, MouseEventArgs e)
        {
            if (selectedButton.Equals("showAllHardwares") ||
                selectedButton.Equals("reservedHardwares") ||
                selectedButton.Equals("ASSETS") ||
                selectedButton.Equals("show1") ||
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

            if (selectedButton.Equals("replacement"))
            {
                if (e.Button == MouseButtons.Right)
                {
                    // Dispose of the previous form if it's still open
                    if (rep != null)
                    {
                        rep.Dispose();
                        rep = null;
                    }

                    // Always pass the current instance of Read to the RightClick form
                    rep = new RightClick_Replacement(this);  // Pass 'this' to ensure form1 is initialized

                    // Convert the mouse position to screen coordinates
                    Point screenPoint = dataGridView1.PointToScreen(e.Location);

                    rep.StartPosition = FormStartPosition.Manual;
                    rep.Location = screenPoint;  // Directly set to the screen position

                    rep.Deactivate += (s, ev) =>
                    {
                        rep.Hide();  // Just hide instead of disposing
                    };

                    rep.Show();
                }
            }

            if (selectedButton.Equals("disposedHardwares") ||
                selectedButton.Equals("archive") ||
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
        public static List<string> selectedSerialNos = new List<string>();

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

                    // Check if dp is null before using it
                    if (rep == null)
                    {
                        rep = new RightClick_Replacement(this); // Reinitialize rc if it was disposed
                    }


                    rh.GetRetrievingSerial(null);
                    sah.GetRetrievingSerial(null);
                    dp.GetRetrievingSerial(null);
                    rep.GetRetrievingSerial(null);

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

                    // Reinitialize dp if it's null
                    if (rep == null)
                    {
                        rep = new RightClick_Replacement(this); // Reinitialize rc if it was disposed
                    }

                    // Wrap the single serialNo in a list and pass it to GetRetrievingSerial
                    rh.GetRetrievingSerial(new List<string> { serialNo });
                    sah.GetRetrievingSerial(new List<string> { serialNo });
                    dp.GetRetrievingSerial(new List<string> { serialNo });
                    rep.GetRetrievingSerial(new List<string> { serialNo });
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

                    // Reinitialize sah if it's null
                    if (sah == null)
                    {
                        sah = new RightClick_ShowAllHardwares(this); // Reinitialize rh if it was disposed
                    }

                    if (dp == null)
                    {
                        dp = new RightClick_DisposedHardwares(this); // Reinitialize rh if it was disposed
                    }

                    if (rep == null)
                    {
                        rep = new RightClick_Replacement(this); // Reinitialize rc if it was disposed
                    }

                    // Pass the list of serialNos to RightClick for multiple rows
                    rh.GetRetrievingSerial(selectedSerialNos);
                    sah.GetRetrievingSerial(selectedSerialNos);
                    dp.GetRetrievingSerial(selectedSerialNos);
                    rep.GetRetrievingSerial(selectedSerialNos);

                }
            }
            catch (Exception ex)
            {
                // Handle any unexpected errors
                MessageBox.Show($"An error occurred while processing the selection: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine($"Error: {ex.Message}\n{ex.StackTrace}");
            }
        }


        private void recycleBin_Btn_Click(object sender, EventArgs e)
        {
            selectedButton = "archive";

            SendButtonInfo();

            MyDbMethods.ReadLocation("SmartAssetDb", dataGridView1, "Archive");
            _lastRefreshAction = () => MyDbMethods.ReadLocation("SmartAssetDb", dataGridView1, "Archive");
        }

        // Method to refresh the DataGridView


        public void Refresh_ShowAllHardwares()
        {
            panel5.Show();
            panel7.Show();

            showAllHardwares_Btn.PerformClick();

            panel5.Hide();
            panel7.Hide();
        }

        public void Refresh_Archive()
        {
            panel5.Show();
            panel7.Show();

            archive_Btn.PerformClick();

            panel5.Hide();
            panel7.Hide();
        }

        public void Refresh_ReservedHardwares()
        {
            panel5.Show();
            panel7.Show();

            reservedHardwares_Btn.PerformClick();

            panel5.Hide();
            panel7.Hide();
        }

        public void Refresh_show1()
        {
            panel5.Show();
            panel7.Show();

            panel5.Hide();
            panel7.Hide();
        }

        public void Refresh_show2()
        {
            panel5.Show();
            panel7.Show();

            search2_Btn.PerformClick();

            panel5.Hide();
            panel7.Hide();
        }


        public void Refresh_ReplacementHarwares()
        {
            panel5.Show();
            panel7.Show();

            replacement_Btn.PerformClick();

            panel5.Hide();
            panel7.Hide();
        }

        public void Refresh_DisposedHardwares()
        {
            panel5.Show();
            panel7.Show();

            disposedHardwares_Btn.PerformClick();

            panel5.Hide();
            panel7.Hide();
        }

        public void Refresh_Cleaning()
        {
            panel5.Show();
            panel7.Show();

            cleaningHardwares_Btn.PerformClick();

            panel5.Hide();
            panel7.Hide();
        }

        public void Refresh_Borrowed()
        {
            panel5.Show();
            panel7.Show();

            borrowedHardwares_Btn.PerformClick();

            panel5.Hide();
            panel7.Hide();
        }

        private async void type_Cmb_DropDown(object sender, EventArgs e)
        {
            // Clear existing items and load from database
            type_Cmb.Items.Clear();

            Cursor = Cursors.WaitCursor;
            await MyDbMethods.LoadDatabase_TypeList("SmartAssetDb", "Type_List", type_Cmb);
            Cursor = Cursors.Arrow;

            // Insert "N/A" at the first position
            type_Cmb.Items.Insert(0, "N/A");


        }






        private void LoadData()
        {
            InitializeDataSource();
        }

        private BindingSource bindingSource = new BindingSource();
        private void InitializeDataSource()
        {
            dataGridView1.AllowUserToAddRows = false;
            DataTable dataTable = new DataTable();

            foreach (DataGridViewColumn col in dataGridView1.Columns)
                dataTable.Columns.Add(col.Name, typeof(string));

            foreach (DataGridViewRow row in dataGridView1.Rows)
                if (!row.IsNewRow)
                    dataTable.Rows.Add(row.Cells.Cast<DataGridViewCell>().Select(c => c.Value).ToArray());

            bindingSource.DataSource = dataTable;
            dataGridView1.DataSource = bindingSource;

            // Cache the loaded data
            cachedDataTable = dataTable.Copy();
        }


        private DataTable cachedDataTable = null;
        private void serialNo_Cmb_TextChanged(object sender, EventArgs e)
        {

        }


        private void RefreshBasedOnSelectedButton()
        {
            switch (selectedButton)
            {
                case "reservedHardwares":
                    Refresh_ReservedHardwares();
                    break;
                case "cleaningHardwares":
                    Refresh_Cleaning();
                    break;
                case "replacement":
                    Refresh_ReplacementHarwares();
                    break;
                case "disposedHardwares":
                    Refresh_DisposedHardwares();
                    break;
                case "borrowedHardwares":
                    Refresh_Borrowed();
                    break;
                case "archive":
                    Refresh_Archive();
                    break;
                default:
                    Refresh_ShowAllHardwares();
                    break;
            }
        }


        // This method will be called when the debounce timer elapses
        private void DebounceTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            // Invoke on the UI thread
            this.Invoke(new Action(() =>
            {
                try
                {
                    // Reload data to refresh the DataGridView
                    LoadData();

                    string filterText = search_Cmb.Text.Trim().ToLower();

                    if (string.IsNullOrEmpty(filterText))
                    {
                        // Text is cleared, remove filter
                        bindingSource.RemoveFilter();

                        // Refresh based on the current selectedButton
                        switch (selectedButton)
                        {
                            case "reservedHardwares":
                                Refresh_ReservedHardwares();
                                break;
                            case "cleaningHardwares":
                                Refresh_Cleaning();
                                break;
                            case "replacement":
                                Refresh_ReplacementHarwares();
                                break;
                            case "disposedHardwares":
                                Refresh_DisposedHardwares();
                                break;
                            case "borrowedHardwares":
                                Refresh_Borrowed();
                                break;
                            case "archive":
                                Refresh_Archive();
                                break;
                            default:
                                // If no specific module is selected, show all hardwares
                                Refresh_ShowAllHardwares();
                                break;
                        }
                    }
                    else
                    {
                        // Apply filter based on entered text
                        var filterColumns = new[]
                        {
                    "Type", "Brand", "Model", "PropertyID", "SerialNo",
                    "PONumber", "SINumber", "Cost", "Warranty", "Supplier",
                    "WarrantyStatus", "PurchaseDate", "Usage", "Location"
                };

                        bindingSource.Filter = string.Join(" OR ", filterColumns.Select(col => $"{col} LIKE '%{filterText}%'"));
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred while filtering data: {ex.Message}", "Filter Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }));
        }



        private void add_Btn_Click(object sender, EventArgs e)
        {
            Create cr = new Create();
            cr.Show();
        }

        private void hideColumn_Btn_Click(object sender, EventArgs e)
        {
            s1.Reload();
            HideColumn hc = new HideColumn();
            hc.Show();
        }

        private async void search2_Btn_Click(object sender, EventArgs e)
        {
            // Check if all the combo boxes are empty or null
            if (string.IsNullOrWhiteSpace(location_Cmb.Text) &&
                string.IsNullOrWhiteSpace(unit_Cmb.Text) &&
                string.IsNullOrWhiteSpace(type_Cmb.Text))
            {
                MessageBox.Show("Please select properly!");

                // Reload Datagridview
                LoadData();
                HideColumnsBasedOnS1(); // Ensure columns are hidden when reloading
                return;
            }

            selectedButton = "show2";
            SendButtonInfo();

            // Perform the relevant database operation based on selection
            if ((string.IsNullOrWhiteSpace(location_Cmb.Text) || location_Cmb.Text.Equals("N/A")) &&
                !string.IsNullOrWhiteSpace(unit_Cmb.Text) &&
                (string.IsNullOrWhiteSpace(type_Cmb.Text) || type_Cmb.Text.Equals("N/A")))
            {
                await MyDbMethods.ShowDocuContainsTextAsync("SmartAssetDb", dataGridView1, unit_Cmb.Text);
            }
            else if ((string.IsNullOrWhiteSpace(unit_Cmb.Text) || unit_Cmb.Text.Equals("N/A")) &&
                     (string.IsNullOrWhiteSpace(type_Cmb.Text) || type_Cmb.Text.Equals("N/A")) &&
                     !string.IsNullOrWhiteSpace(location_Cmb.Text))
            {
                MyDbMethods.ReadLocation("SmartAssetDb", dataGridView1, $"{location_Cmb.Text}_", true);
            }
            else if ((string.IsNullOrWhiteSpace(unit_Cmb.Text) || unit_Cmb.Text.Equals("N/A")) &&
                     (string.IsNullOrWhiteSpace(location_Cmb.Text) || location_Cmb.Text.Equals("N/A")) &&
                     !string.IsNullOrWhiteSpace(type_Cmb.Text))
            {
                MyDbMethods.ReadLocation("SmartAssetDb", dataGridView1, "", true, "Type", $"{type_Cmb.Text}");
            }
            else if (string.IsNullOrWhiteSpace(type_Cmb.Text) || type_Cmb.Text.Equals("N/A"))
            {
                MyDbMethods.ReadLocation("SmartAssetDb", dataGridView1, $"{location_Cmb.Text}_{unit_Cmb.Text}");
            }
            else if (string.IsNullOrWhiteSpace(unit_Cmb.Text) || unit_Cmb.Text.Equals("N/A"))
            {
                MyDbMethods.ReadLocation("SmartAssetDb", dataGridView1, $"{location_Cmb.Text}_", true, "Type", $"{type_Cmb.Text}");
            }
            else
            {
                MyDbMethods.ReadLocation("SmartAssetDb", dataGridView1, $"{location_Cmb.Text}_{unit_Cmb.Text}", true, "Type", $"{type_Cmb.Text}");
            }




            // Call HideColumnsBasedOnS1 to apply column visibility after data has loaded
            // Check if the column exists before trying to set its visibility
            s1.Reload();

            if (Read.StaticDataGridView.Columns["Type"] != null)
                Read.StaticDataGridView.Columns["Type"].Visible = !s1.type;

            if (Read.StaticDataGridView.Columns["Brand"] != null)
                Read.StaticDataGridView.Columns["Brand"].Visible = !s1.brand;

            if (Read.StaticDataGridView.Columns["Model"] != null)
                Read.StaticDataGridView.Columns["Model"].Visible = !s1.model;

            if (Read.StaticDataGridView.Columns["PropertyID"] != null)
                Read.StaticDataGridView.Columns["PropertyID"].Visible = !s1.propertyID;

            if (Read.StaticDataGridView.Columns["SerialNo"] != null)
                Read.StaticDataGridView.Columns["SerialNo"].Visible = !s1.serialNo;

            if (Read.StaticDataGridView.Columns["PONumber"] != null)
                Read.StaticDataGridView.Columns["PONumber"].Visible = !s1.poNumber;

            if (Read.StaticDataGridView.Columns["SINumber"] != null)
                Read.StaticDataGridView.Columns["SINumber"].Visible = !s1.siNumber;

            if (Read.StaticDataGridView.Columns["Cost"] != null)
                Read.StaticDataGridView.Columns["Cost"].Visible = !s1.cost;

            if (Read.StaticDataGridView.Columns["Warranty"] != null)
                Read.StaticDataGridView.Columns["Warranty"].Visible = !s1.warranty;

            if (Read.StaticDataGridView.Columns["Supplier"] != null)
                Read.StaticDataGridView.Columns["Supplier"].Visible = !s1.supplier;

            if (Read.StaticDataGridView.Columns["WarrantyStatus"] != null)
                Read.StaticDataGridView.Columns["WarrantyStatus"].Visible = !s1.warrantyStatus;

            if (Read.StaticDataGridView.Columns["PurchaseDate"] != null)
                Read.StaticDataGridView.Columns["PurchaseDate"].Visible = !s1.purchaseDate;

            if (Read.StaticDataGridView.Columns["Usage"] != null)
                Read.StaticDataGridView.Columns["Usage"].Visible = !s1.usage;

            if (Read.StaticDataGridView.Columns["Location"] != null)
                Read.StaticDataGridView.Columns["Location"].Visible = !s1.location;

        }


        public void HideColumnsBasedOnS1()
        {
            // Check if the column exists before trying to set its visibility
            if (dataGridView1.Columns["Type"] != null)
                dataGridView1.Columns["Type"].Visible = !s1.type;

            if (dataGridView1.Columns["Brand"] != null)
                dataGridView1.Columns["Brand"].Visible = !s1.brand;

            if (dataGridView1.Columns["Model"] != null)
                dataGridView1.Columns["Model"].Visible = !s1.model;

            if (dataGridView1.Columns["PropertyID"] != null)
                dataGridView1.Columns["PropertyID"].Visible = !s1.propertyID;

            if (dataGridView1.Columns["SerialNo"] != null)
                dataGridView1.Columns["SerialNo"].Visible = !s1.serialNo;

            if (dataGridView1.Columns["PONumber"] != null)
                dataGridView1.Columns["PONumber"].Visible = !s1.poNumber;

            if (dataGridView1.Columns["SINumber"] != null)
                dataGridView1.Columns["SINumber"].Visible = !s1.siNumber;

            if (dataGridView1.Columns["Cost"] != null)
                dataGridView1.Columns["Cost"].Visible = !s1.cost;

            if (dataGridView1.Columns["Warranty"] != null)
                dataGridView1.Columns["Warranty"].Visible = !s1.warranty;

            if (dataGridView1.Columns["Supplier"] != null)
                dataGridView1.Columns["Supplier"].Visible = !s1.supplier;

            if (dataGridView1.Columns["WarrantyStatus"] != null)
                dataGridView1.Columns["WarrantyStatus"].Visible = !s1.warrantyStatus;

            if (dataGridView1.Columns["PurchaseDate"] != null)
                dataGridView1.Columns["PurchaseDate"].Visible = !s1.purchaseDate;

            if (dataGridView1.Columns["Usage"] != null)
                dataGridView1.Columns["Usage"].Visible = !s1.usage;

            if (dataGridView1.Columns["Location"] != null)
                dataGridView1.Columns["Location"].Visible = !s1.location;
        }

        private void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            HideColumnsBasedOnS1();
        }



        private void DataGridView1_MouseWheel(object sender, MouseEventArgs e)
        {
            // Check if Ctrl key is held down
            if (Control.ModifierKeys == Keys.Control)
            {
                AdjustFontSize(e);
            }
            // Check if Shift key is held down
            else if (Control.ModifierKeys == Keys.Shift)
            {
                ScrollHorizontally(e);
            }
        }

        // Method to adjust the font size of the DataGridView
        private void AdjustFontSize(MouseEventArgs e)
        {
            // Get the current font size
            float currentFontSize = dataGridView1.DefaultCellStyle.Font.Size;
            float newFontSize = currentFontSize;

            // Increase or decrease the font size based on scroll direction
            if (e.Delta > 0)
            {
                newFontSize += 1; // Scroll up, increase font size
            }
            else if (e.Delta < 0)
            {
                newFontSize -= 1; // Scroll down, decrease font size
            }

            // Set minimum and maximum font size limits
            if (newFontSize < 5) newFontSize = 5;
            if (newFontSize > 30) newFontSize = 30;

            // Update the DataGridView font
            dataGridView1.DefaultCellStyle.Font = new Font(dataGridView1.DefaultCellStyle.Font.FontFamily, newFontSize);
        }

        // Method to scroll the DataGridView horizontally
        private void ScrollHorizontally(MouseEventArgs e)
        {
            // Scroll left if the mouse wheel is scrolled up
            if (e.Delta > 0)
            {
                // Move to the previous visible column if possible
                int index = dataGridView1.FirstDisplayedScrollingColumnIndex;
                while (index > 0)
                {
                    index--;
                    if (dataGridView1.Columns[index].Visible)
                    {
                        dataGridView1.FirstDisplayedScrollingColumnIndex = index;
                        break;
                    }
                }
            }
            // Scroll right if the mouse wheel is scrolled down
            else if (e.Delta < 0)
            {
                // Move to the next visible column if possible
                int index = dataGridView1.FirstDisplayedScrollingColumnIndex;
                while (index < dataGridView1.Columns.Count - 1)
                {
                    index++;
                    if (dataGridView1.Columns[index].Visible)
                    {
                        dataGridView1.FirstDisplayedScrollingColumnIndex = index;
                        break;
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            BatchUpload bu = new BatchUpload();
            bu.StartPosition = FormStartPosition.CenterScreen;
            bu.Show();

        }

        private void search_Cmb_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string filterText = search_Cmb.Text.Trim().ToLower();

                // If the text is cleared, immediately refresh based on the selected module
                if (string.IsNullOrEmpty(filterText))
                {
                    RefreshBasedOnSelectedButton();
                }
                else if (filterText.Length < previousTextLength)
                {
                    // If the text length is reduced (Backspace pressed), immediately apply the filter
                    ApplyFilter(filterText);
                }
                else
                {
                    // Reset and start the debounce timer for regular text changes
                    debounceTimer.Stop();
                    debounceTimer.Start();
                }

                // Update the previous text length
                previousTextLength = filterText.Length;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ApplyFilter(string filterText)
        {
            try
            {
                if (string.IsNullOrEmpty(filterText))
                {
                    // Remove filter
                    bindingSource.RemoveFilter();
                    RefreshBasedOnSelectedButton();
                }
                else
                {
                    // Apply filter based on entered text
                    var filterColumns = new[]
                    {
                "Type", "Brand", "Model", "PropertyID", "SerialNo",
                "PONumber", "SINumber", "Cost", "Warranty", "Supplier",
                "WarrantyStatus", "PurchaseDate", "Usage", "Location"
            };

                    bindingSource.Filter = string.Join(" OR ", filterColumns.Select(col => $"{col} LIKE '%{filterText}%'"));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while applying the filter: {ex.Message}", "Filter Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void search_Cmb_KeyDown(object sender, KeyEventArgs e)
        {
            // Check if Backspace key is pressed and the text is empty
            if (e.KeyCode == Keys.Back && string.IsNullOrWhiteSpace(search_Cmb.Text))
            {
                // Immediately refresh based on the selected module
                RefreshBasedOnSelectedButton();
                e.SuppressKeyPress = true; // Optional: Prevent further processing of the Backspace key
            }
        }
    }
}