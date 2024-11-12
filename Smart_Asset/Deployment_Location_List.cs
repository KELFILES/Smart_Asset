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

            var fields = new Dictionary<string, string>
            {
                {"List", $"{item_Tb.Text}"}
            };

            await MyDbMethods.InsertDocument("SmartAssetDb", "Deployment_Location_List", fields, true);


            //show again the list
            await MyDbMethods.showAllItemsInDb("SmartAssetDb", "Deployment_Location_List", dataGridView1);
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
            await MyDbMethods.RemoveDocumentAsync("SmartAssetDb", "Deployment_Location_List", "List", $"{item_Tb.Text}");

            //show again the list
            await MyDbMethods.showAllItemsInDb("SmartAssetDb", "Deployment_Location_List", dataGridView1);
        }
    }
}
