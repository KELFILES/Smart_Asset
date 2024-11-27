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
    public partial class backupAndRestore : Form
    {
        public backupAndRestore()
        {
            InitializeComponent();

            // Enable double buffering for the entire form
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer |
                          ControlStyles.UserPaint |
                          ControlStyles.AllPaintingInWmPaint, true);
            this.UpdateStyles();



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
 