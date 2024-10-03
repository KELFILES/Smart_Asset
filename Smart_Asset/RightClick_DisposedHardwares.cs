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
    public partial class RightClick_DisposedHardwares : Form
    {

        // Parameterless constructor (still needed by the designer)
        public RightClick_DisposedHardwares()
        {
            InitializeComponent();
        }

        private void RightClick_DisposedHardwares_Load(object sender, EventArgs e)
        {
            if (getClickBtnInfo.Equals("repairingHardwares"))
            {
                // Call the method to refresh the DataGridView in Form1
                markAs_Btn.Text = "Mark As Repaired";
            }
            else if (getClickBtnInfo.Equals("disposedHardwares"))
            {
                // Call the method to refresh the DataGridView in Form1
                markAs_Btn.Text = "Retrieve";
            }
            else if (getClickBtnInfo.Equals("cleaningHardwares"))
            {
                // Call the method to refresh the DataGridView in Form1
                markAs_Btn.Text = "Mark As Cleaned";
            }
            else if (getClickBtnInfo.Equals("borrowedHardwares"))
            {
                // Call the method to refresh the DataGridView in Form1
                markAs_Btn.Text = "Mark As Returned";
            }
            else if (getClickBtnInfo.Equals("archive"))
            {
                // Call the method to refresh the DataGridView in Form1
                markAs_Btn.Text = "Retrieve";
            }
        }

        private Read form1;  // Reference to Form1 (Read)

        // Constructor that accepts Form1 (Read) as a parameter
        public RightClick_DisposedHardwares(Read form1)
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
                await MyDbMethods.TransferManyUsingSerialNo("SmartAssetDb", getData);

                // Reactivate the main form after the MessageBox
                Application.OpenForms[0].Activate();

                if (getClickBtnInfo.Equals("repairingHardwares"))
                {
                    // Call the method to refresh the DataGridView in Form1
                    markAs_Btn.Text = "Mark As Repaired";
                    form1.Refresh_RepairingHarwares();
                }
                else if (getClickBtnInfo.Equals("disposedHardwares"))
                {
                    // Call the method to refresh the DataGridView in Form1
                    markAs_Btn.Text = "Retrieve";
                    form1.Refresh_DisposedHardwares();
                }
                else if (getClickBtnInfo.Equals("cleaningHardwares"))
                {
                    // Call the method to refresh the DataGridView in Form1
                    markAs_Btn.Text = "Mark As Cleaned";
                    form1.Refresh_Cleaning();
                }
                else if (getClickBtnInfo.Equals("borrowedHardwares"))
                {
                    // Call the method to refresh the DataGridView in Form1
                    markAs_Btn.Text = "Mark As Returned";
                    form1.Refresh_Borrowed();
                }
                else if (getClickBtnInfo.Equals("archive"))
                {
                    // Call the method to refresh the DataGridView in Form1
                    markAs_Btn.Text = "Retrieve";
                    form1.Refresh_Archive();
                }

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
            if (getClickBtnInfo.Equals("archive"))
            {
                // Call the method to refresh the DataGridView in Form1
                form1.Refresh_Archive();
            }
            else if (getClickBtnInfo.Equals("disposedHardwares"))
            {
                // Call the method to refresh the DataGridView in Form1
                form1.Refresh_DisposedHardwares();
            }
            else if (getClickBtnInfo.Equals("borrow"))
            {
                // Call the method to refresh the DataGridView in Form1
                form1.Refresh_Borrowed();
            }
            else if (getClickBtnInfo.Equals("cleaningHardwares"))
            {
                // Call the method to refresh the DataGridView in Form1
                form1.Refresh_Cleaning();
            }
            else if (getClickBtnInfo.Equals("borrowedHardwares"))
            {
                // Call the method to refresh the DataGridView in Form1
                form1.Refresh_Borrowed();
            }


            // Close the form after the operation is complete
            this.Close();
            this.Dispose();
        }


    }
}
