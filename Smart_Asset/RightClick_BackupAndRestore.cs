using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.DataFormats;

namespace Smart_Asset
{
    public partial class RightClick_BackupAndRestore : Form
    {

        // Parameterless constructor (still needed by the designer)
        public RightClick_BackupAndRestore()
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

        private void RightClick_DisposedHardwares_Load(object sender, EventArgs e)
        {
            if (getClickBtnInfo_Backup.Equals("replacement"))
            {

            }

        }

        private backupAndRestore form1;  // Reference to Form1 (Read)

        // Constructor that accepts Form1 (Read) as a parameter
        public RightClick_BackupAndRestore(backupAndRestore form1)
        {
            InitializeComponent();
            this.form1 = form1;
        }




        //This is for Backup
        public static string getClickBtnInfo_Backup = "";

        //This is for Restore
        public static string getClickBtnInfo_Restore = "";



        public void SendClickBtnInfo(string data)
        {
            getClickBtnInfo_Backup = data;
        }

        public static void SendCLickBtnInfo_Restore(string data)
        {
            getClickBtnInfo_Restore = data;
        }

        // Change getData to be a list of serial numbers
        static List<string> getData = new List<string>();

        // Method to accept a list of serial numbers



        private async void markAsRepaired_Btn_Click(object sender, EventArgs e)
        {
            try
            {
                if (getData == null || getData.Count == 0)
                {
                    MessageBox.Show("No Row selected. Please select one row only.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (getData.Count == 0)
                {
                    MessageBox.Show("No Row selected. Please select one row only.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
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
            backupAndRestore.Refresh_ManageUsers();


            // Close the form after the operation is complete
            this.Close();
            this.Dispose();
        }

        private void localBackup_Btn_Click(object sender, EventArgs e)
        {


            using (FolderBrowserDialog folderDialog = new FolderBrowserDialog())
            {
                folderDialog.Description = "Select a folder to save the MongoDB backup";
                folderDialog.ShowNewFolderButton = true;

                if (folderDialog.ShowDialog() == DialogResult.OK)
                {
                    string selectedPath = folderDialog.SelectedPath;

                    try
                    {
                        string dbName = "SmartAssetDb"; // Replace with your actual database name
                        MyDbMethods.CreateBackup(dbName, selectedPath);

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string restoreTable = getClickBtnInfo_Restore;
            Console.WriteLine(restoreTable);

        }











    }
}
