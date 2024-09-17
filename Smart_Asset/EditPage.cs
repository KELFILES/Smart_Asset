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
    public partial class EditPage : Form
    {
        public EditPage()
        {
            InitializeComponent();
        }


        private void ShowFormInPanel(Form formName, Panel panelName)
        {
            formName.TopLevel = false;
            formName.Dock = DockStyle.Fill;
            mainPanel.Controls.Add(formName);
            formName.Show(); // Show the form after configuring
        }


        private Update up = null;
        private Transfer tr = null;
        private Deployment dep = null;
        private Swap sw = null;

        private void update_Rdb_CheckedChanged(object sender, EventArgs e)
        {
            if (update_Rdb.Checked)
            {
                // Create the form if it doesn't exist and show it
                if (up == null || up.IsDisposed)
                {
                    up = new Update();
                    ShowFormInPanel(up, mainPanel);
                }
            }
            else
            {
                // Dispose of the form if it's currently open
                if (up != null && !up.IsDisposed)
                {
                    up.Dispose();
                    up = null; // Set the reference to null after disposing
                }
            }
        }

        private void transfer_Rdb_CheckedChanged(object sender, EventArgs e)
        {
            if (transfer_Rdb.Checked)
            {
                // Create the form if it doesn't exist and show it
                if (tr == null || tr.IsDisposed)
                {
                    tr = new Transfer();
                    ShowFormInPanel(tr, mainPanel);
                }
            }
            else
            {
                // Dispose of the form if it's currently open
                if (tr != null && !tr.IsDisposed)
                {
                    tr.Dispose();
                    tr = null; // Set the reference to null after disposing
                }
            }
        }

        private void deployment_Rdb_CheckedChanged(object sender, EventArgs e)
        {
            if (deployment_Rdb.Checked)
            {
                // Create the form if it doesn't exist and show it
                if (dep == null || dep.IsDisposed)
                {
                    dep = new Deployment();
                    ShowFormInPanel(dep, mainPanel);
                }
            }
            else
            {
                // Dispose of the form if it's currently open
                if (dep != null && !dep.IsDisposed)
                {
                    dep.Dispose();
                    dep = null; // Set the reference to null after disposing
                }
            }
        }

        private void swap_Rdb_CheckedChanged(object sender, EventArgs e)
        {
            if (swap_Rdb.Checked)
            {
                // Create the form if it doesn't exist and show it
                if (sw == null || sw.IsDisposed)
                {
                    sw = new Swap();
                    ShowFormInPanel(sw, mainPanel);
                }
            }
            else
            {
                // Dispose of the form if it's currently open
                if (sw != null && !sw.IsDisposed)
                {
                    sw.Dispose();
                    sw = null; // Set the reference to null after disposing
                }
            }
        }



    }
}
