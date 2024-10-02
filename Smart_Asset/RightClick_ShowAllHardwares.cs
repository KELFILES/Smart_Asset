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
    public partial class RightClick_ShowAllHardwares : Form
    {

        // Parameterless constructor (still needed by the designer)
        public RightClick_ShowAllHardwares()
        {
            InitializeComponent();
        }

        //Fields
        private Read form1;  // Reference to Form1 (Read)
        Update up = new Update();
        Transfer tf = new Transfer();
        Borrow br = new Borrow();

        // Constructor that accepts Form1 (Read) as a parameter
        public RightClick_ShowAllHardwares(Read form1)
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


        private void refresh_Btn_Click(object sender, EventArgs e)
        {
            // Call the method to refresh the DataGridView in Form1
            form1.Refresh_ShowAllHardwares();

            // Close the form after the operation is complete
            this.Close();
            this.Dispose();
        }

        private void add_Btn_Click(object sender, EventArgs e)
        {
            Create cr = new Create();
            cr.Show();
        }

        private async void remove_Btn_Click(object sender, EventArgs e)
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

                // Call the method to refresh the DataGridView in Form1
                form1.Refresh_ShowAllHardwares();
            }
            catch (Exception ex)
            {
                // Handle any exceptions and display an error message
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine($"Error: {ex.Message}\n{ex.StackTrace}");
            }
        }

        private async void archieve_Btn_Click(object sender, EventArgs e)
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
                await MyDbMethods.TransferManyUsingSerialNo("SmartAssetDb", getData, "Archieve");

                // Call the method to refresh the DataGridView in Form1
                form1.Refresh_ShowAllHardwares();
            }
            catch (Exception ex)
            {
                // Handle any exceptions and display an error message
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine($"Error: {ex.Message}\n{ex.StackTrace}");
            }
        }

        private async void reserve_Btn_Click(object sender, EventArgs e)
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

                // Call the method to refresh the DataGridView in Form1
                form1.Refresh_ShowAllHardwares();
            }
            catch (Exception ex)
            {
                // Handle any exceptions and display an error message
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine($"Error: {ex.Message}\n{ex.StackTrace}");
            }
        }

        private async void repair_Btn_Click(object sender, EventArgs e)
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
                await MyDbMethods.TransferManyUsingSerialNo("SmartAssetDb", getData, "Repairing");

                // Call the method to refresh the DataGridView in Form1
                form1.Refresh_ShowAllHardwares();
            }
            catch (Exception ex)
            {
                // Handle any exceptions and display an error message
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine($"Error: {ex.Message}\n{ex.StackTrace}");
            }
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

                // Call the method to refresh the DataGridView in Form1
                form1.Refresh_ShowAllHardwares();
            }
            catch (Exception ex)
            {
                // Handle any exceptions and display an error message
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine($"Error: {ex.Message}\n{ex.StackTrace}");
            }
        }

        private async void clean_Btn_Click(object sender, EventArgs e)
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
                await MyDbMethods.TransferManyUsingSerialNo("SmartAssetDb", getData, "Cleaning");

                // Call the method to refresh the DataGridView in Form1
                form1.Refresh_ShowAllHardwares();
            }
            catch (Exception ex)
            {
                // Handle any exceptions and display an error message
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine($"Error: {ex.Message}\n{ex.StackTrace}");
            }
        }

        private async void borrow_Btn_Click(object sender, EventArgs e)
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

                br.FormBorderStyle = FormBorderStyle.FixedSingle;
                br.StartPosition = FormStartPosition.CenterScreen;
                br.serialNo_Cmb.Text = string.Join(", ", getData);
                br.Show();
            }
            catch (Exception ex)
            {
                // Handle any exceptions and display an error message
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine($"Error: {ex.Message}\n{ex.StackTrace}");
            }
        }

        private async void edit_Btn_Click(object sender, EventArgs e)
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

                up.FormBorderStyle = FormBorderStyle.FixedSingle;
                up.StartPosition = FormStartPosition.CenterScreen;
                up.serialNo_Cmb.Text = string.Join(", ", getData);
                up.Show();
                up.show2_Btn.PerformClick();
            }
            catch (Exception ex)
            {
                // Handle any exceptions and display an error message
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine($"Error: {ex.Message}\n{ex.StackTrace}");
            }
        }

        private void Transfer_Click(object sender, EventArgs e)
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

                tf.FormBorderStyle = FormBorderStyle.FixedSingle;
                tf.StartPosition = FormStartPosition.CenterScreen;
                tf.serialNo_Cmb.Text = string.Join(", ", getData);
                tf.Show();
            }
            catch (Exception ex)
            {
                // Handle any exceptions and display an error message
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine($"Error: {ex.Message}\n{ex.StackTrace}");
            }
        }
    }
}
