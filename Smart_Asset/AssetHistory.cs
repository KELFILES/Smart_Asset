using MongoDB.Driver.Core.Configuration;
using MongoDB.Driver.Core.Misc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Smart_Asset
{
    public partial class AssetHisotry : Form
    {
        public AssetHisotry()
        {
            InitializeComponent();

            // Enable double buffering for the entire form
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer |
                          ControlStyles.UserPaint |
                          ControlStyles.AllPaintingInWmPaint, true);
            this.UpdateStyles();


            StaticDataGridView1 = dataGridView1;
        }
        public static DataGridView StaticDataGridView1;


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



        //FIELD
        public static string selectedButton = "";
        public static List<string> selectedBackupRestore = new List<string>();
        public static RightClick_BackupAndRestore rcb = new RightClick_BackupAndRestore();
        public static string staticSelectedOneUserID;

        //This is for Restore
        public static string getClickBtnInfo_Restore = "";


        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                // Initialize selectedBackupRestore if it's null
                if (dataGridView1.SelectedRows.Equals("") || dataGridView1.SelectedRows == null)
                {
                    RightClick_BackupAndRestore.getClickBtnInfo_Backup = null;
                }


                if (dataGridView1.SelectedRows.Count == 1)
                {
                    RightClick_BackupAndRestore.getClickBtnInfo_Backup = "1";



                    //FOR RESTORE
                    // Ensure at least one row is selected
                    if (dataGridView1.SelectedRows.Count > 0)
                    {
                        // Get the first selected row
                        DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];

                        // Retrieve values from each cell
                        string date = selectedRow.Cells["Date"].Value?.ToString();
                        int totalCollections = Convert.ToInt32(selectedRow.Cells["Total Collections"].Value);
                        long totalDocuments = Convert.ToInt64(selectedRow.Cells["Total Documents"].Value);

                        RightClick_BackupAndRestore.SendCLickBtnInfo_Restore($"{date},{totalCollections},{totalDocuments} ");


                    }
                }

                if (dataGridView1.SelectedRows.Count >= 2)
                {
                    RightClick_BackupAndRestore.getClickBtnInfo_Backup = "2";
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
                if (rcb != null)
                {
                    rcb.Dispose();
                    rcb = null;
                }

                // Convert the mouse position to screen coordinates
                Point screenPoint = dataGridView1.PointToScreen(e.Location);

                rcb.StartPosition = FormStartPosition.Manual;
                rcb.Location = screenPoint;  // Directly set to the screen position

                rcb.Deactivate += (s, ev) =>
                {
                    rcb.Hide();  // Just hide instead of disposing
                };

                rcb.Show();
            }
        }

        public async static void Refresh_ManageUsers()
        {
            
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
            try
            {
                //---------------string filterText = searchUser_Tb.Text.Trim().ToLower();
                var filterColumns = new[]
                {
                    "Name", "Username", "Role"
                };

                //-----------------bindingSource.Filter = string.Join(" OR ", filterColumns.Select(col => $"{col} LIKE '%{filterText}%'"));
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while filtering data: {ex.Message}", "Filter Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void searchUser_Tb_Click(object sender, EventArgs e)
        {
            // Reload data to refresh the DataGridView
            LoadData();
        }



        private async void backupAndRestore_Load(object sender, EventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error during loading: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }




        private void systemRestore_Btn_Click(object sender, EventArgs e)
        {
            MyDbMethods.RestoreBackup("SmartAssetDb");
        }

        private void systemBackup_Btn_Click(object sender, EventArgs e)
        {
            using (var folderDialog = new FolderBrowserDialog())
            {
                folderDialog.Description = "Select a folder to save the backup.";
                folderDialog.ShowNewFolderButton = true;

                // Show the folder dialog to the user
                if (folderDialog.ShowDialog() == DialogResult.OK)
                {
                    // Get the selected folder path
                    string selectedPath = folderDialog.SelectedPath;

                    // Confirm the backup action
                    DialogResult result = MessageBox.Show(
                        $"Do you want to create a backup in the selected folder?\n\nPath: {selectedPath}",
                        "Confirm Backup",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question
                    );

                    if (result == DialogResult.Yes)
                    {
                        // Call the backup method
                        MyDbMethods.CreateBackup("SmartAssetDb", selectedPath);
                    }
                    else
                    {
                        MessageBox.Show("Backup canceled.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("No folder selected. Backup canceled.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }







    }
}
 