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
    public partial class ManageUsers : Form
    {
        public ManageUsers()
        {
            InitializeComponent();
            StaticDataGridView1 = dataGridView1;
        }

        public static DataGridView StaticDataGridView1;

        //FIELD
        public static string selectedButton = "";
        public static List<string> selectedUserIDs = new List<string>();
        RightClick_ManageUsers rcm = new RightClick_ManageUsers();


        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                // Initialize selectedUserIDs if it's null
                if (selectedUserIDs == null)
                {
                    selectedUserIDs = new List<string>();
                }

                if (dataGridView1.SelectedRows.Count > 0)
                {
                    // Clear previous selections
                    selectedUserIDs.Clear();

                    foreach (DataGridViewRow row in dataGridView1.SelectedRows)
                    {
                        string userID = row.Cells["UserID"].Value.ToString();
                        string name = row.Cells["Name"].Value.ToString();
                        string role = row.Cells["Role"].Value.ToString();

                        // Add only unique userID values
                        if (!selectedUserIDs.Contains(userID))
                        {
                            selectedUserIDs.Add(userID);
                        }
                    }

                    // For multiple rows, pass lists of each field to the RightClick form
                    rcm.GetRetrievingUserID(
                        selectedUserIDs,
                        dataGridView1.SelectedRows.Cast<DataGridViewRow>().Select(r => r.Cells["Name"].Value.ToString()).Distinct().ToList(),
                        dataGridView1.SelectedRows.Cast<DataGridViewRow>().Select(r => r.Cells["Role"].Value.ToString()).Distinct().ToList()
                    );
                }

                if (dataGridView1.SelectedRows.Count == 1)
                {
                    string userID = dataGridView1.SelectedRows[0].Cells["UserID"].Value.ToString();
                    string name = dataGridView1.SelectedRows[0].Cells["Name"].Value.ToString();
                    string role = dataGridView1.SelectedRows[0].Cells["Role"].Value.ToString();

                    if (!selectedUserIDs.Contains(userID))
                    {
                        selectedUserIDs.Add(userID);
                    }

                    rcm.GetRetrievingUserID(new List<string> { userID }, new List<string> { name }, new List<string> { role });

                    Console.WriteLine("SELECTED USER ID: " + userID + ", SELECTED NAME: " + name + ", SELECTED ROLE: " + role);

                }
                else if (dataGridView1.SelectedRows.Count > 1)
                {
                    // Lists to hold the information of each selected user
                    List<string> userIds = new List<string>();
                    List<string> names = new List<string>();
                    List<string> roles = new List<string>();

                    Console.WriteLine("Multiple Users Selected:\n");

                    foreach (DataGridViewRow row in dataGridView1.SelectedRows)
                    {
                        string userID = row.Cells["UserID"].Value.ToString();
                        string name = row.Cells["Name"].Value.ToString();
                        string role = row.Cells["Role"].Value.ToString();

                        userIds.Add(userID);
                        names.Add(name);
                        roles.Add(role);

                        // Print each user's details
                        Console.WriteLine($"UserID: {userID}");
                        Console.WriteLine($"Name: {name}");
                        Console.WriteLine($"Role: {role}\n");
                    }

                    // Display combined information
                    Console.WriteLine("Summary of All Selected Users:");
                    Console.WriteLine("UserIDs: " + string.Join(", ", userIds));
                    Console.WriteLine("Names: " + string.Join(", ", names));
                    Console.WriteLine("Roles: " + string.Join(", ", roles));

                    // Pass all lists to GetRetrievingUserID
                    rcm.GetRetrievingUserID(userIds, names, roles);
                }
            }
            catch (Exception ex)
            {
                // Handle any unexpected errors
                MessageBox.Show($"An error occurred while processing the selection: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine($"Error: {ex.Message}\n{ex.StackTrace}");
            }
        }

        // Add this at the class level to keep track of the form instance
        private AddUser _addUserForm;

        private void addUsers_Btn_Click(object sender, EventArgs e)
        {
            // Check if the form is already open
            if (_addUserForm != null && !_addUserForm.IsDisposed)
            {
                _addUserForm.Dispose(); // Dispose of the existing form
            }

            // Create a new instance of the form and show it
            _addUserForm = new AddUser();
            _addUserForm.StartPosition = FormStartPosition.CenterScreen;
            _addUserForm.FormBorderStyle = FormBorderStyle.FixedSingle;
            _addUserForm.Show();
        }

        private void dataGridView1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                // Dispose of the previous form if it's still open
                if (rcm != null)
                {
                    rcm.Dispose();
                    rcm = null;
                }

                // Always pass the current instance of Read to the RightClick form
                rcm = new RightClick_ManageUsers(this);  // Pass 'this' to ensure form1 is initialized

                // Convert the mouse position to screen coordinates
                Point screenPoint = dataGridView1.PointToScreen(e.Location);

                rcm.StartPosition = FormStartPosition.Manual;
                rcm.Location = screenPoint;  // Directly set to the screen position

                rcm.Deactivate += (s, ev) =>
                {
                    rcm.Hide();  // Just hide instead of disposing
                };

                rcm.Show();
            }
        }

        public static void Refresh_ManageUsers()
        {
            MyDbMethods.ReadManageUsers("SmartAssetDb", StaticDataGridView1, "Users");
        }

        private void ManageUsers_Load(object sender, EventArgs e)
        {
            // Load data initially
            LoadData();
        }

        private void LoadData()
        {
            MyDbMethods.ReadManageUsers("SmartAssetDb", dataGridView1, "Users");
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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string filterText = searchUser_Tb.Text.Trim().ToLower();
            bindingSource.Filter = $"Name LIKE '%{filterText}%' OR Username LIKE '%{filterText}%' OR Email LIKE '%{filterText}%' OR UserID LIKE '%{filterText}%'";
        }

        private void searchUser_Tb_Click(object sender, EventArgs e)
        {
            // Reload data to refresh the DataGridView
            LoadData();
        }
    }
}
