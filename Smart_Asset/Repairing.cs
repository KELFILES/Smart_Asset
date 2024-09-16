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
    public partial class Repairing : Form
    {
        //Fields
        private RightClick rc = new RightClick();

        public Repairing()
        {
            InitializeComponent();
        }

        private void Repairing_Shown(object sender, EventArgs e)
        {
            RefreshDataGrid();
        }

        // Override ProcessCmdKey to handle Ctrl+R
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Control | Keys.R))
            {
                RefreshDataGrid();
                MessageBox.Show("DATA HAS BEEN REFRESHED");
                return true; // Indicate that the key press was handled
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void RefreshDataGrid()
        {
            // Replace MyDbMethods.ReadLocation with your actual data-fetching logic
            MyDbMethods.ReadLocationWithNotes("SmartAssetDb", dataGridView1, "Repairing");
        }

        private void dataGridView1_MouseDown(object sender, MouseEventArgs e)
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


        // A list to store SerialNo values of selected rows
        List<string> selectedSerialNos = new List<string>();

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                // Initialize RightClick before accessing it
                RightClick rc = new RightClick();

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