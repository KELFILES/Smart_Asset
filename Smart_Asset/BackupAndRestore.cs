using DocumentFormat.OpenXml.Drawing;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Smart_Asset
{
    public partial class backup_Btn : Form
    {
        public backup_Btn()
        {
            InitializeComponent();
        }

        private void dataGridView1_MouseDown(object sender, MouseEventArgs e)
        {

        }


        Backup bc = new Backup();
        Restore rs = new Restore();



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
    }
}
