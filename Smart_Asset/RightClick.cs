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
    public partial class RightClick : Form
    {
        public RightClick()
        {
            InitializeComponent();
        }

        // Change getData to be a list of serial numbers
        static List<string> getData = new List<string>();

        // Method to accept a list of serial numbers
        public void GetRetrievingSerial(List<string> data)
        {
            getData = data;
        }

        private async void retrieve_Btn_Click(object sender, EventArgs e)
        {
            try
            {
                if (getData == null || getData.Count == 0)
                {
                    MessageBox.Show("No SerialNos selected. Please select at least one SerialNo.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Log the selected SerialNos for debugging purposes
                Console.WriteLine("Selected SerialNos: " + string.Join(", ", getData));

                // Ask the user for confirmation before proceeding
                var result = MessageBox.Show($"Do you want to retrieve data for these SerialNos?\n{string.Join(", ", getData)}", "Retrieve Data", MessageBoxButtons.YesNo, MessageBoxIcon.Question);


                await MyDbMethods.TransferManyUsingSerialNo("SmartAssetDb", getData);

            }
            catch (Exception ex)
            {
                // Handle any exceptions and display an error message
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine($"Error: {ex.Message}\n{ex.StackTrace}");
            }
            finally
            {
                // Close the form after the operation is complete
                this.Close();
                this.Dispose();
            }
        }






    }
}
