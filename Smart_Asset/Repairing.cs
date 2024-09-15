﻿using System;
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
        //Fields
        private RightClick rc = new RightClick();

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

        private void dataGridView1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                // Dispose of the previous form if it's still open
                if (rc != null)
                {
                    rc.Dispose();
                    rc = null;
                }

                // Create a new instance of RightClick form
                rc = new RightClick();

                // Convert the mouse position to screen coordinates
                Point screenPoint = dataGridView1.PointToScreen(e.Location);

                // Adjust for window borders and toolbars if needed (if the form has non-client areas)
                rc.StartPosition = FormStartPosition.Manual;
                rc.Location = screenPoint;  // Directly set to the screen position

                // Set up an event handler to close the form when clicking outside of it
                rc.Deactivate += (s, ev) =>
                {
                    rc.Dispose();
                    rc = null; // Set to null when disposed
                };

                // Show the new form
                rc.Show();
            }
        }
    }
}