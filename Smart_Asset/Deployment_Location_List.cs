using Amazon.Runtime.Internal.Transform;
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
    public partial class Deployment_Location_List : Form
    {
        public Deployment_Location_List()
        {
            InitializeComponent();

            // Load data initially
            LoadData();
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
        }








        private async void add_Btn_Click(object sender, EventArgs e)
        {
            // Verify if the item exists in the DataGridView
            bool itemFoundInGrid = dataGridView1.Rows
                .Cast<DataGridViewRow>()
                .Any(row => row.Cells["List"].Value?.ToString() == item_Tb.Text); // Replace "LocationName" with the correct column name

            //CHECK IF ITEM NOT FOUND
            if (itemFoundInGrid)
            {
                MessageBox.Show("Item already exist in list!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Validate that the text field is not empty
            if (String.IsNullOrEmpty(item_Tb.Text) || item_Tb.Text.Equals(""))
            {
                MessageBox.Show("Field Cannot Be Empty!");
                return;
            }

            // Display a confirmation prompt
            var dialogResult = MessageBox.Show(
                $"Are you sure you want to add \"{item_Tb.Text}\" to the list?",
                "Confirmation",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            // Proceed only if the user clicks "Yes"
            if (dialogResult == DialogResult.Yes)
            {
                // Prepare the fields to insert
                var fields = new Dictionary<string, string>
                {
                    {"List", $"{item_Tb.Text}"}
                };

                // Insert the item into the database
                await MyDbMethods.InsertDocument("SmartAssetDb", "Deployment_Location_List", fields, true);

                // Refresh the DataGridView to show the updated list
                await MyDbMethods.showAllItemsInDb("SmartAssetDb", "Deployment_Location_List", dataGridView1);
            }
            else
            {
                // Optional: Log or display a message for cancellation
                MessageBox.Show("Action canceled.");
            }
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

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Removed successfully");

            //show again the list
            MyDbMethods.showAllItemsInDb("SmartAssetDb", "Deployment_Location_List", dataGridView1);
        }

        private void Deployment_Location_List_Load(object sender, EventArgs e)
        {
            MyDbMethods.showAllItemsInDb("SmartAssetDb", "Deployment_Location_List", dataGridView1);
        }

        private void search_Tb_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string filterText = search_Tb.Text.Trim().ToLower();
                var filterColumns = new[]
                {
                    "List"
                };

                bindingSource.Filter = string.Join(" OR ", filterColumns.Select(col => $"{col} LIKE '%{filterText}%'"));
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while filtering data: {ex.Message}", "Filter Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void search_Tb_Click(object sender, EventArgs e)
        {
            // Reload data to refresh the DataGridView
            LoadData();
        }

        private void dataGridView2_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            if (dataGridView1.Columns["Id"] != null)
            {
                dataGridView1.Columns["Id"].Visible = false;
            }
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            // Validate that the text field is not empty
            if (string.IsNullOrEmpty(item_Tb.Text))
            {
                MessageBox.Show("Field Cannot Be Empty!");
                return;
            }

            string itemToCheck = item_Tb.Text;
            string dbName = "SmartAssetDb";

            // Check if any collection name matches the specified pattern
            bool exists = await MyDbMethods.CheckDocumentExistsAsync_ForLocationList(dbName, itemToCheck);
            if (exists)
            {
                MessageBox.Show($"You cannot delete {item_Tb.Text} because it has been used. Try remove or transfer document uses Location: {item_Tb.Text} first.");
                return;
            }


            // Verify if the item exists in the DataGridView
            bool itemFoundInGrid = dataGridView1.Rows
                .Cast<DataGridViewRow>()
                .Any(row => row.Cells["List"].Value?.ToString() == itemToCheck); // Replace "LocationName" with the correct column name

            if (!itemFoundInGrid)
            {
                MessageBox.Show("Item Not Found in the list!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Display a confirmation prompt
            var dialogResult = MessageBox.Show(
                $"Are you sure you want to remove \"{itemToCheck}\" from the list?",
                "Confirmation",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            // Proceed only if the user clicks "Yes"
            if (dialogResult == DialogResult.Yes)
            {
                // Remove the item from the database
                await MyDbMethods.RemoveDocumentAsync(dbName, "Deployment_Location_List", "List", itemToCheck);

                // Refresh the DataGridView to show the updated list
                await MyDbMethods.showAllItemsInDb(dbName, "Deployment_Location_List", dataGridView1);

                MessageBox.Show($"\"{itemToCheck}\" has been successfully removed.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Action canceled.");
            }
        }



    }
}
