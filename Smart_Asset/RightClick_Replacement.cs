using Smart_Asset.Images;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.DataFormats;

namespace Smart_Asset
{
    public partial class RightClick_Replacement : Form
    {

        // Parameterless constructor (still needed by the designer)
        public RightClick_Replacement()
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

        private void RightClick_RepairingHardwares_Load(object sender, EventArgs e)
        {

        }


        private Read form1;  // Reference to Form1 (Read)

        // Constructor that accepts Form1 (Read) as a parameter
        public RightClick_Replacement(Read form1)
        {
            InitializeComponent();
            this.form1 = form1;
        }




        //FOR GETTING DATA FROM READ.CS
        static string getClickBtnInfo;
        public void SendClickBtnInfo(string data)
        {
            getClickBtnInfo = data;
        }

        // Change getData to be a list of serial numbers
        static List<string> getData = new List<string>();

        // Method to accept a list of serial numbers
        public void GetRetrievingSerial(List<string> data)
        {
            getData = data;
        }


        private async void markAsRepaired_Btn_Click(object sender, EventArgs e)
        {
            try
            {
                if (getData == null || getData.Count == 0)
                {
                    MessageBox.Show("No Row selected. Please select at least one Row.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Log the selected SerialNos for debugging purposes
                Console.WriteLine("Selected SerialNos: " + string.Join(", ", getData));
                await MyDbMethods.TransferManyUsingSerialNo("SmartAssetDb", getData, "Reserved_Hardwares");

                // Reactivate the main form after the MessageBox
                Application.OpenForms[0].Activate();

                // Call the method to refresh the DataGridView in Form1
                form1.Refresh_ReplacementHarwares();
            }
            catch (Exception ex)
            {
                // Handle any exceptions and display an error message
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine($"Error: {ex.Message}\n{ex.StackTrace}");
            }
        }


        private void refresh_Btn_Click(object sender, EventArgs e)
        {
            // Call the method to refresh the DataGridView in Form1
            form1.Refresh_ReplacementHarwares();

            // Close the form after the operation is complete
            this.Close();
            this.Dispose();
        }

        private async void dispose_Btn_Click(object sender, EventArgs e)
        {
            try
            {
                if (getData == null || getData.Count == 0)
                {
                    MessageBox.Show("No Row selected. Please select at least one Row.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Log the selected SerialNos for debugging purposes
                Console.WriteLine("Selected SerialNos: " + string.Join(", ", getData));
                await MyDbMethods.TransferManyUsingSerialNo("SmartAssetDb", getData, "Disposed_Hardwares");

                // Reactivate the main form after the MessageBox
                Application.OpenForms[0].Activate();

                // Call the method to refresh the DataGridView in Form1
                form1.Refresh_ReplacementHarwares();
            }
            catch (Exception ex)
            {
                // Handle any exceptions and display an error message
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine($"Error: {ex.Message}\n{ex.StackTrace}");
            }
        }

        private void hideTableColumn_Btn_Click(object sender, EventArgs e)
        {
            HideColumn hc = new HideColumn();
            hc.Show();
        }
    }
}
