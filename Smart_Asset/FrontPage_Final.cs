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
    public partial class FrontPage_Final : Form
    {
        public FrontPage_Final()
        {
            InitializeComponent();

            // Store the original back color when the form loads
            originalBackColor = sideMenu_Panel.BackColor;


            fileMaintenance_SubMenuPanel.Visible = false;
        }

        // Fields for forms
        Create cr;
        Read rd;
        Update ud;
        Transfer del;
        Dashboard db;
        Deployment dp;
        Swap sw;
        Repairing rep;

        // Declare a variable to store the original background color
        private Color originalBackColor;

        private void FrontPage_Final_Load(object sender, EventArgs e)
        {
            // Scroll the panel to the top
            sideMenu_Panel.AutoScrollPosition = new Point(0, 0);

            // To show the dashboard first
            dashboard_Btn.PerformClick();
        }

        private void customizeDesign()
        {
            fileMaintenance_SubMenuPanel.Visible = false;
        }

        private void hideSubMenu()
        {
            if (fileMaintenance_SubMenuPanel.Visible == true)
            {
                fileMaintenance_SubMenuPanel.Visible = false;
            }
        }

        private void showSubMenu(Panel subMenu)
        {
            if (subMenu.Visible == false)
            {
                hideSubMenu();
                subMenu.Visible = true;
            }
            else
            {
                subMenu.Visible = false;
            }
        }

        // Method to close and dispose any form that is currently in the mainPanel
        private void DisposeCurrentFormInMainPanel()
        {
            if (mainPanel.Controls.Count > 0)
            {
                Form currentForm = mainPanel.Controls[0] as Form;
                if (currentForm != null)
                {
                    currentForm.Close();  // Close the form to free up resources
                    currentForm.Dispose();  // Dispose the form
                    mainPanel.Controls.Clear();  // Clear the panel
                    GC.Collect();  // Force garbage collection
                    GC.WaitForPendingFinalizers();  // Wait for finalizers to complete

                }
            }
        }

        // Helper method to reuse form instance if it is disposed
        private T EnsureFormIsNotDisposed<T>(ref T form) where T : Form, new()
        {
            if (form == null || form.IsDisposed)
            {
                form = new T();
            }
            return form;
        }

        #region File Maintenance

        private void fileMaintenance_Btn_Click(object sender, EventArgs e)
        {
            showSubMenu(fileMaintenance_SubMenuPanel);
        }


        private void showFormSelected<T>(ref T formName, string headerText) where T : Form, new()
        {
            hideSubMenu();

            header_Lbl.Text = headerText;

            // Dispose of the current form in the mainPanel
            DisposeCurrentFormInMainPanel();

            // Ensure the form is not null or disposed
            if (formName == null || formName.IsDisposed)
            {
                formName = new T(); // Create a new instance if the form is disposed or null
            }

            // Configure and display the form
            formName.TopLevel = false;
            formName.FormBorderStyle = FormBorderStyle.None;
            formName.Dock = DockStyle.Fill;
            mainPanel.Controls.Add(formName);
            formName.Show(); // Show the form after configuring
        }



        private void create_Btn_Click(object sender, EventArgs e)
        {
            showFormSelected(ref cr, "ASSET MANAGEMENT: CREATE");

            #region NOTES
            /*
            INSTEAD NA GAWIN KO LAHAT GANITO GINAWA KO NA LANG METHOD PARA MAIKSI
            hideSubMenu();

            header_Lbl.Text = "ASSET MANAGEMENT: CREATE";

            // Reuse or create a new instance of the form, and dispose of the current form in the mainPanel
            DisposeCurrentFormInMainPanel();

            cr = EnsureFormIsNotDisposed(ref cr);
            cr.TopLevel = false;
            cr.FormBorderStyle = FormBorderStyle.None;
            cr.Dock = DockStyle.Fill;
            mainPanel.Controls.Add(cr);
            cr.Show();
            */
            #endregion
        }

        private void read_Btn_Click(object sender, EventArgs e)
        {
            showFormSelected(ref rd, "ASSET MANAGEMENT: READ");
        }

        private void update_Btn_Click(object sender, EventArgs e)
        {
            showFormSelected(ref ud, "ASSET MANAGEMENT: UPDATE");
        }

        private void transfer_Btn_Click(object sender, EventArgs e)
        {
            showFormSelected(ref rep, "ASSET MANAGEMENT: REPAIRING");
        }

        #endregion

        private void dashboard_Btn_Click(object sender, EventArgs e)
        {
            showFormSelected(ref db, "ASSET MANAGEMENT: DASHBOARD");
        }

        private void deployment_Btn_Click(object sender, EventArgs e)
        {
            showFormSelected(ref dp, "ASSET MANAGEMENT: DEPLOYMENT");
        }

        private void swap_Btn_Click(object sender, EventArgs e)
        {
            showFormSelected(ref sw, "ASSET MANAGEMENT: SWAP");
        }

        private void repairing_Btn_Click(object sender, EventArgs e)
        {
            showFormSelected(ref rep, "ASSET MANAGEMENT: REPAIRING");
        }

        private void cleaning_Btn_Click(object sender, EventArgs e)
        {
            hideSubMenu();
        }

        private void disposed_Btn_Click(object sender, EventArgs e)
        {
            hideSubMenu();
        }

        private void recyleBin_Btn_Click(object sender, EventArgs e)
        {
            hideSubMenu();
        }

        private void borrowedItems_Btn_Click(object sender, EventArgs e)
        {
            hideSubMenu();
        }

        private void artificialIntelligence_Btn_Click(object sender, EventArgs e)
        {
            hideSubMenu();
        }

        private void manageRoles_Btn_Click(object sender, EventArgs e)
        {
            hideSubMenu();
        }

        private void createReport_Btn_Click(object sender, EventArgs e)
        {
            hideSubMenu();
        }

        private void logout_Btn_Click(object sender, EventArgs e)
        {
            hideSubMenu();
        }




        private void ButtonEnterColor(Button btnName)
        {
            // Change the back color to red with 20% transparency
            btnName.BackColor = Color.FromArgb(255, 109, 80, 166); // 204 is 20% transparency
        }

        private void ButtonLeaveColor(Button btnName)
        {
            // Restore the original background color
            btnName.BackColor = originalBackColor;
        }


        private void SubButtonEnterColor(Button btnName)
        {
            // Change the back color to red with 20% transparency
            btnName.BackColor = Color.FromArgb(255, 85, 37, 93); // 204 is 20% transparency
        }





        private void dashboard_Btn_MouseEnter(object sender, EventArgs e)
        {
            ButtonEnterColor(dashboard_Btn);
        }

        private void dashboard_Btn_MouseLeave(object sender, EventArgs e)
        {
            ButtonLeaveColor(dashboard_Btn);
        }

        private void fileMaintenance_Btn_MouseEnter(object sender, EventArgs e)
        {
            ButtonEnterColor(fileMaintenance_Btn);
        }

        private void fileMaintenance_Btn_MouseLeave(object sender, EventArgs e)
        {
            ButtonLeaveColor(fileMaintenance_Btn);
        }

        private void deployment_Btn_MouseEnter(object sender, EventArgs e)
        {
            ButtonEnterColor(deployment_Btn);
        }

        private void deployment_Btn_MouseLeave(object sender, EventArgs e)
        {
            ButtonLeaveColor(deployment_Btn);
        }

        private void swap_Btn_MouseEnter(object sender, EventArgs e)
        {
            ButtonEnterColor(swap_Btn);
        }

        private void swap_Btn_MouseLeave(object sender, EventArgs e)
        {
            ButtonLeaveColor(swap_Btn);
        }

        private void repairing_Btn_MouseEnter(object sender, EventArgs e)
        {
            ButtonEnterColor(repairing_Btn);
        }

        private void repairing_Btn_MouseLeave(object sender, EventArgs e)
        {
            ButtonLeaveColor(repairing_Btn);
        }

        private void cleaning_Btn_MouseEnter(object sender, EventArgs e)
        {
            ButtonEnterColor(cleaning_Btn);
        }

        private void cleaning_Btn_MouseLeave(object sender, EventArgs e)
        {
            ButtonLeaveColor(cleaning_Btn);
        }

        private void disposed_Btn_MouseEnter(object sender, EventArgs e)
        {
            ButtonEnterColor(disposed_Btn);
        }

        private void disposed_Btn_MouseLeave(object sender, EventArgs e)
        {
            ButtonLeaveColor(disposed_Btn);
        }

        private void recyleBin_Btn_MouseEnter(object sender, EventArgs e)
        {
            ButtonEnterColor(recyleBin_Btn);
        }

        private void recyleBin_Btn_MouseLeave(object sender, EventArgs e)
        {
            ButtonLeaveColor(recyleBin_Btn);
        }

        private void borrowedItems_Btn_MouseEnter(object sender, EventArgs e)
        {
            ButtonEnterColor(borrowedItems_Btn);
        }

        private void borrowedItems_Btn_MouseLeave(object sender, EventArgs e)
        {
            ButtonLeaveColor(borrowedItems_Btn);
        }

        private void artificialIntelligence_Btn_MouseEnter(object sender, EventArgs e)
        {
            ButtonEnterColor(artificialIntelligence_Btn);
        }

        private void artificialIntelligence_Btn_MouseLeave(object sender, EventArgs e)
        {
            ButtonLeaveColor(artificialIntelligence_Btn);
        }

        private void manageRoles_Btn_MouseEnter(object sender, EventArgs e)
        {
            ButtonEnterColor(manageRoles_Btn);
        }

        private void manageRoles_Btn_MouseLeave(object sender, EventArgs e)
        {
            ButtonLeaveColor(manageRoles_Btn);
        }

        private void createReport_Btn_MouseEnter(object sender, EventArgs e)
        {
            ButtonEnterColor(createReport_Btn);
        }

        private void createReport_Btn_MouseLeave(object sender, EventArgs e)
        {
            ButtonLeaveColor(createReport_Btn);
        }

        private void create_Btn_MouseEnter(object sender, EventArgs e)
        {
            SubButtonEnterColor(create_Btn);
        }

        private void create_Btn_MouseLeave(object sender, EventArgs e)
        {
            ButtonLeaveColor(create_Btn);
        }

        private void read_Btn_MouseEnter(object sender, EventArgs e)
        {
            SubButtonEnterColor(read_Btn);
        }

        private void read_Btn_MouseLeave(object sender, EventArgs e)
        {
            ButtonLeaveColor(read_Btn);
        }

        private void update_Btn_MouseEnter(object sender, EventArgs e)
        {
            SubButtonEnterColor(update_Btn);
        }

        private void update_Btn_MouseLeave(object sender, EventArgs e)
        {
            ButtonLeaveColor(update_Btn);
        }

        private void transfer_Btn_MouseEnter(object sender, EventArgs e)
        {
            SubButtonEnterColor(transfer_Btn);
        }

        private void transfer_Btn_MouseLeave(object sender, EventArgs e)
        {
            ButtonLeaveColor(transfer_Btn);
        }
    }
}