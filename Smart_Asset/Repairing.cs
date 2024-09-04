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
    public partial class Repairing : Form
    {
        public Repairing()
        {
            InitializeComponent();
        }

        private void Repairing_Shown(object sender, EventArgs e)
        {
            RefreshDataGrid();
        }

        // Override ProcessCmdKey to handle Ctrl+R
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Control | Keys.R))
            {
                RefreshDataGrid();
                MessageBox.Show("DATA HAS BEEN REFRESHED");
                return true; // Indicate that the key press was handled
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void RefreshDataGrid()
        {
            // Replace MyDbMethods.ReadLocation with your actual data-fetching logic
            MyDbMethods.ReadLocation("SmartAssetDb", dataGridView1, "Repairing");
        }
    }
}