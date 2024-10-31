using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Smart_Asset.MyDbMethods;
using static System.Windows.Forms.DataFormats;

namespace Smart_Asset
{
    public partial class FrontPage_Final : Form
    {
        public FrontPage_Final()
        {
            InitializeComponent();


            // Enable double buffering for the entire form
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer |
                          ControlStyles.UserPaint |
                          ControlStyles.AllPaintingInWmPaint, true);
            this.UpdateStyles();



            // Store the original back color when the form loads
            originalBackColor = sideMenu_Panel.BackColor;
            SubOriginalBackColor = fileMaintenance_SubMenuPanel.BackColor;

            fileMaintenance_SubMenuPanel.Visible = false;


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

        // Fields for forms
        Create cr;
        Read rd;
        Update ud;
        Transfer del;
        Dashboard db;
        Deployment dp;
        Swap sw;
        Borrow br = new Borrow();
        ManageUsers mu = new ManageUsers();

        public static string selectedButton = "";
        RightClick_RepairingHardwares rh = new RightClick_RepairingHardwares();
        RightClick_ShowAllHardwares sah = new RightClick_ShowAllHardwares();
        RightClick_DisposedHardwares dsp = new RightClick_DisposedHardwares();

        public static string name = "";
        public static string email = "";
        public static string contactNo = "";
        public static string address = "";
        public static string username = "";
        public static string role = "";
        public static string userID = "";

        private Action _lastRefreshAction; // Action to store the last refresh operation

        private void SendButtonInfo()
        {
            rh.SendClickBtnInfo(selectedButton);
            sah.SendClickBtnInfo(selectedButton);
            dsp.SendClickBtnInfo(selectedButton);
        }

        // Declare a variable to store the original background color
        private Color originalBackColor;
        private Color SubOriginalBackColor;

        private Button toggleButton;
        private bool isMaximized = false;
        private Rectangle originalBounds;

        private void FrontPage_Final_Load(object sender, EventArgs e)
        {
            ManageUsers_Btn.Hide();

            // Scroll the panel to the top
            sideMenu_Panel.AutoScrollPosition = new Point(0, 0);

            // To show the dashboard first
            dashboard_Btn.PerformClick();

            this.WindowState = FormWindowState.Maximized;


            //SET BUTTONS ICON IMAGE
            dashboard_Btn.Image = Image.FromFile(System.IO.Path.Combine(Application.StartupPath, "Images", "dashboard_Icon.ico"));
            dashboard_Btn.Padding = new Padding(10, 0, 20, 0);

            assets_Btn.Image = Image.FromFile(System.IO.Path.Combine(Application.StartupPath, "Images", "asset_Icon.ico"));
            assets_Btn.Padding = new Padding(35, 0, 20, 0);

            replacement_Btn.Image = Image.FromFile(System.IO.Path.Combine(Application.StartupPath, "Images", "replacement_Icon.ico"));
            replacement_Btn.Padding = new Padding(35, 0, 20, 0);

            cleaning_Btn.Image = Image.FromFile(System.IO.Path.Combine(Application.StartupPath, "Images", "cleaning_Icon.ico"));
            cleaning_Btn.Padding = new Padding(35, 0, 20, 0);

            disposed_Btn.Image = Image.FromFile(System.IO.Path.Combine(Application.StartupPath, "Images", "disposed_Icon.ico"));
            disposed_Btn.Padding = new Padding(35, 0, 20, 0);

            borrowed_Btn.Image = Image.FromFile(System.IO.Path.Combine(Application.StartupPath, "Images", "borrowed_Icon.ico"));
            borrowed_Btn.Padding = new Padding(35, 0, 20, 0);

            archived_Btn.Image = Image.FromFile(System.IO.Path.Combine(Application.StartupPath, "Images", "archive_Icon.ico"));
            archived_Btn.Padding = new Padding(35, 0, 20, 0);

            assetHistory_Btn.Image = Image.FromFile(System.IO.Path.Combine(Application.StartupPath, "Images", "assetHistory_Icon.ico"));
            assetHistory_Btn.Padding = new Padding(35, 0, 20, 0);

            reserved_Btn.Image = Image.FromFile(System.IO.Path.Combine(Application.StartupPath, "Images", "assetCategories_Icon.ico"));
            reserved_Btn.Padding = new Padding(35, 0, 20, 0);

            artificialIntelligence_Btn.Image = Image.FromFile(System.IO.Path.Combine(Application.StartupPath, "Images", "artificialIntelligence_Icon.ico"));
            artificialIntelligence_Btn.Padding = new Padding(10, 0, 20, 0);

            ManageUsers_Btn.Image = Image.FromFile(System.IO.Path.Combine(Application.StartupPath, "Images", "manageUsers_Icon.ico"));
            ManageUsers_Btn.Padding = new Padding(10, 0, 20, 0);

            createReport_Btn.Image = Image.FromFile(System.IO.Path.Combine(Application.StartupPath, "Images", "createReport_Icon.ico"));
            createReport_Btn.Padding = new Padding(10, 0, 20, 0);

            backupData_Btn.Image = Image.FromFile(System.IO.Path.Combine(Application.StartupPath, "Images", "backupData_Icon.ico"));
            backupData_Btn.Padding = new Padding(10, 0, 20, 0);
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

        }

        private void update_Btn_Click(object sender, EventArgs e)
        {

        }

        private void transfer_Btn_Click(object sender, EventArgs e)
        {

        }

        #endregion

        private void dashboard_Btn_Click(object sender, EventArgs e)
        {
            showFormSelected(ref db, "DASHBOARD");
            headerPicture_Pb.Image = Image.FromFile(System.IO.Path.Combine(Application.StartupPath, "Images", "dashboard_Icon.ico"));
        }

        private void swap_Btn_Click(object sender, EventArgs e)
        {
            showFormSelected(ref sw, "ASSET MANAGEMENT: SWAP");
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

        private void ManageUsers_Btn_Click_1(object sender, EventArgs e)
        {
            showFormSelected(ref mu, "MANAGE USERS");
            headerPicture_Pb.Image = Image.FromFile(System.IO.Path.Combine(Application.StartupPath, "Images", "manageUsers_Icon.ico"));
            //MyDbMethods.ReadManageUsers("SmartAssetDb", mu.dataGridView1, "Users");


        }

        private void createReport_Btn_Click(object sender, EventArgs e)
        {
            hideSubMenu();
        }

        private void logout_Btn_Click(object sender, EventArgs e)
        {
            hideSubMenu();
        }


        private void SubButtonEnterColor(Button btnName)
        {
            // Change the back color to red with 20% transparency
            btnName.BackColor = Color.FromArgb(255, 102, 187, 106); // 204 is 20% transparency
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


        private void SubButtonLeaveColor(Button btnName)
        {
            // Restore the original background color
            btnName.BackColor = SubOriginalBackColor;
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
            ButtonEnterColor(ManageAsset_Btn);

            ManageAsset_Btn.Image = Image.FromFile(System.IO.Path.Combine(Application.StartupPath, "Images", "arrow_Icon.ico"));
            ManageAsset_Btn.Padding = new Padding(10, 0, 100, 0);
        }

        private void fileMaintenance_Btn_MouseLeave(object sender, EventArgs e)
        {
            ButtonLeaveColor(ManageAsset_Btn);

            ManageAsset_Btn.Image = null;
        }

        private void artificialIntelligence_Btn_MouseEnter(object sender, EventArgs e)
        {
            ButtonEnterColor(artificialIntelligence_Btn);
        }

        private void artificialIntelligence_Btn_MouseLeave(object sender, EventArgs e)
        {
            ButtonLeaveColor(artificialIntelligence_Btn);
        }

        private void questionMark_Btn_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (isMaximized)
            {
                // Restore the form to its original size and position
                this.Bounds = originalBounds;
                isMaximized = false;
            }
            else
            {
                // Store the original bounds before maximizing
                originalBounds = this.Bounds;

                // Maximize the form within the working area (excluding taskbar)
                Rectangle workingArea = Screen.FromControl(this).WorkingArea;
                this.Location = workingArea.Location;
                this.Size = workingArea.Size;
                isMaximized = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // Check if an instance of QuestionMark is already open and close it
            foreach (Form openForm in Application.OpenForms)
            {
                if (openForm is QuestionMark)
                {
                    openForm.Close();
                    break; // Exit the loop after closing the form
                }
            }

            // Now create a new instance of QuestionMark
            QuestionMark qm = new QuestionMark();
            qm.Size = new Size(this.Width / 2, this.Height / 2);

            // Optionally center Form2 on the screen or relative to Form1
            qm.StartPosition = FormStartPosition.Manual;
            qm.Location = new Point(this.Location.X + this.Width / 4, this.Location.Y + this.Height / 4); // Center relative to Form1

            qm.Show();

            // Check header_Lbl.Text for specific actions
            if (header_Lbl.Text.Equals("ASSET MANAGEMENT: IMPORT HARDWARES DATA"))
            {
                qm.Text = "MANUAL FOR " + header_Lbl.Text;
            }
            if (header_Lbl.Text.Equals("ASSET MANAGEMENT: MONITOR HARDWARES DATA"))
            {
                qm.Text = "MANUAL FOR " + header_Lbl.Text;
            }
            if (header_Lbl.Text.Equals("ASSET MANAGEMENT: MODIFY HARDWARES DATA"))
            {
                qm.Text = "MANUAL FOR " + header_Lbl.Text;
            }
            if (header_Lbl.Text.Equals("ASSET MANAGEMENT: TRANSFER HARDWARES DATA"))
            {
                qm.Text = "MANUAL FOR " + header_Lbl.Text;
            }
            if (header_Lbl.Text.Equals("ASSET MANAGEMENT: DEPLOY HARDWARES"))
            {
                qm.Text = "MANUAL FOR " + header_Lbl.Text;
            }
            if (header_Lbl.Text.Equals("ASSET MANAGEMENT: SWAP HARDWARES"))
            {
                qm.Text = "MANUAL FOR " + header_Lbl.Text;
            }
            if (header_Lbl.Text.Equals("ASSET MANAGEMENT: RECYCLE BIN"))
            {
                qm.Text = "MANUAL FOR " + header_Lbl.Text;
            }


        }




        private void artificialIntelligence_Btn_Click_1(object sender, EventArgs e)
        {
            //showFormSelected(ref db, "DASHBOARD");
            headerPicture_Pb.Image = Image.FromFile(System.IO.Path.Combine(Application.StartupPath, "Images", "artificialIntelligence_Icon.ico"));
            MessageBox.Show("STILL ON PROGRESS!");
        }
        private void ManageRoles_Btn_Click_1(object sender, EventArgs e)
        {
            //showFormSelected(ref mngrl, "MANAGE ROLES");
            MessageBox.Show("STILL ON PROGRESS!");
        }

        private void createReport_Btn_Click_1(object sender, EventArgs e)
        {
            //showFormSelected(ref mngrl, "CREATE REPORT");
            headerPicture_Pb.Image = Image.FromFile(System.IO.Path.Combine(Application.StartupPath, "Images", "createReport_Icon.ico"));
            MessageBox.Show("STILL ON PROGRESS!");
        }

        private void logout_Btn_Click_1(object sender, EventArgs e)
        {
            // Hide and dispose of the main form
            this.Hide();
            DisposeCurrentFormInMainPanel(); // Clear any open forms in the main panel
            this.Dispose();

            // Release any application-level resources or reset static fields if necessary
            ClearApplicationResources();

            // Open the login form in a new context to avoid dependency on the main form
            using (Login lg = new Login())
            {
                lg.ShowDialog();
            }
        }

        private void ManageAsset_Btn_Click(object sender, EventArgs e)
        {
            showSubMenu(fileMaintenance_SubMenuPanel);
        }

        private void asset_Btn_Click(object sender, EventArgs e)
        {
            //RESET THE SERIALNO. SELECTED
            //Read.selectedSerialNos.Clear();


            sah.SendClickBtnInfo("ASSETS");

            showFormSelected(ref rd, "ASSETS");
            rd.showAllHardwares_Btn.PerformClick();

            rd.panel5.Visible = false;
            rd.panel7.Visible = false;




            headerPicture_Pb.Image = Image.FromFile(System.IO.Path.Combine(Application.StartupPath, "Images", "asset_Icon.ico"));
        }

        private void AssetCategories_Btn_Click(object sender, EventArgs e)
        {
            //showFormSelected(ref rd, "ASSET CATEGORIES");
            headerPicture_Pb.Image = Image.FromFile(System.IO.Path.Combine(Application.StartupPath, "Images", "assetCategories_Icon.ico"));
            MessageBox.Show("STILL ON PROGRESS!");
        }

        private void backupData_Btn_Click(object sender, EventArgs e)
        {
            //showFormSelected(ref rd, "BACKUP DATA");
            headerPicture_Pb.Image = Image.FromFile(System.IO.Path.Combine(Application.StartupPath, "Images", "backupData_Icon.ico"));
            MessageBox.Show("STILL ON PROGRESS!");
        }

        private void ManageUsers_Btn_MouseEnter(object sender, EventArgs e)
        {
            ButtonEnterColor(ManageUsers_Btn);
        }

        private void createReport_Btn_MouseEnter(object sender, EventArgs e)
        {
            ButtonEnterColor(createReport_Btn);
        }

        private void ManageUsers_Btn_MouseLeave(object sender, EventArgs e)
        {
            ButtonLeaveColor(ManageUsers_Btn);
        }

        private void createReport_Btn_MouseLeave(object sender, EventArgs e)
        {
            ButtonLeaveColor(createReport_Btn);
        }

        private void asset_Btn_MouseEnter(object sender, EventArgs e)
        {
            SubButtonEnterColor(assets_Btn);
        }

        private void asset_Btn_MouseLeave(object sender, EventArgs e)
        {
            SubButtonLeaveColor(assets_Btn);
        }

        private void AssetHistory_Btn_MouseEnter(object sender, EventArgs e)
        {
            SubButtonEnterColor(assetHistory_Btn);
        }

        private void AssetHistory_Btn_MouseLeave(object sender, EventArgs e)
        {
            SubButtonLeaveColor(assetHistory_Btn);
        }

        private void AssetCategories_Btn_MouseEnter(object sender, EventArgs e)
        {
            SubButtonEnterColor(reserved_Btn);
        }

        private void AssetCategories_Btn_MouseLeave(object sender, EventArgs e)
        {
            SubButtonLeaveColor(reserved_Btn);
        }

        private void backupData_Btn_MouseEnter(object sender, EventArgs e)
        {
            ButtonEnterColor(backupData_Btn);
        }

        private void backupData_Btn_MouseLeave(object sender, EventArgs e)
        {
            ButtonLeaveColor(backupData_Btn);
        }

        private void repairingHardwares_Btn_MouseEnter(object sender, EventArgs e)
        {
            SubButtonEnterColor(replacement_Btn);
        }

        private void repairingHardwares_Btn_MouseLeave(object sender, EventArgs e)
        {
            SubButtonLeaveColor(replacement_Btn);
        }

        private void cleaning_Btn_MouseEnter(object sender, EventArgs e)
        {
            SubButtonEnterColor(cleaning_Btn);
        }

        private void cleaning_Btn_MouseLeave(object sender, EventArgs e)
        {
            SubButtonLeaveColor(cleaning_Btn);
        }

        private void disposed_Btn_MouseEnter(object sender, EventArgs e)
        {
            SubButtonEnterColor(disposed_Btn);
        }

        private void disposed_Btn_MouseLeave(object sender, EventArgs e)
        {
            SubButtonLeaveColor(disposed_Btn);
        }

        private void borrowed_Btn_MouseEnter(object sender, EventArgs e)
        {
            SubButtonEnterColor(borrowed_Btn);
        }

        private void borrowed_Btn_MouseLeave(object sender, EventArgs e)
        {
            SubButtonLeaveColor(borrowed_Btn);
        }

        private void reserved_Btn_MouseEnter(object sender, EventArgs e)
        {
            SubButtonEnterColor(reserved_Btn);
        }

        private void reserved_Btn_MouseLeave(object sender, EventArgs e)
        {
            SubButtonLeaveColor(reserved_Btn);
        }

        private void archived_Btn_MouseEnter(object sender, EventArgs e)
        {
            SubButtonEnterColor(archived_Btn);
        }

        private void archived_Btn_MouseLeave(object sender, EventArgs e)
        {
            SubButtonLeaveColor(archived_Btn);
        }

        private void AssetHistory_Btn_MouseEnter_1(object sender, EventArgs e)
        {
            SubButtonEnterColor(assetHistory_Btn);
        }

        private void assetHistory_Btn_MouseLeave_1(object sender, EventArgs e)
        {
            SubButtonLeaveColor(assetHistory_Btn);
        }



        private void repairing_Btn_Click(object sender, EventArgs e)
        {
            //RESET THE SERIALNO. SELECTED
            //Read.selectedSerialNos.Clear();

            showFormSelected(ref rd, "REPLACEMENT");

            rd.replacement_Btn.PerformClick();
            rd.panel5.Hide();
            rd.panel6.Hide();
            rd.panel7.Hide();



            rd.panel4.Anchor = AnchorStyles.Left;
            rd.panel4.Dock = DockStyle.Left;
            rd.panel2.Padding = new Padding(10, 10, 0, 10);
            HideColumnIfExists("Location");



            headerPicture_Pb.Image = Image.FromFile(System.IO.Path.Combine(Application.StartupPath, "Images", "replacement_Icon.ico"));
        }

        private void cleaning_Btn_Click_1(object sender, EventArgs e)
        {
            //RESET THE SERIALNO. SELECTED
            //Read.selectedSerialNos.Clear();

            showFormSelected(ref rd, "CLEANING");

            rd.cleaningHardwares_Btn.PerformClick();
            rd.panel5.Hide();
            rd.panel6.Hide();
            rd.panel7.Hide();


            rd.panel4.Anchor = AnchorStyles.Left;
            rd.panel4.Dock = DockStyle.Left;
            rd.panel2.Padding = new Padding(10, 10, 0, 10);
            HideColumnIfExists("Location");

            headerPicture_Pb.Image = Image.FromFile(System.IO.Path.Combine(Application.StartupPath, "Images", "cleaning_Icon.ico"));
        }

        private void disposed_Btn_Click_1(object sender, EventArgs e)
        {
            //RESET THE SERIALNO. SELECTED
            //Read.selectedSerialNos.Clear();

            showFormSelected(ref rd, "DISPOSED");


            rd.disposedHardwares_Btn.PerformClick();
            rd.panel5.Hide();
            rd.panel6.Hide();
            rd.panel7.Hide();

            rd.panel4.Anchor = AnchorStyles.Left;
            rd.panel4.Dock = DockStyle.Left;
            rd.panel2.Padding = new Padding(10, 10, 0, 10);
            HideColumnIfExists("Location");

            headerPicture_Pb.Image = Image.FromFile(System.IO.Path.Combine(Application.StartupPath, "Images", "disposed_Icon.ico"));
        }

        private void borrowed_Btn_Click(object sender, EventArgs e)
        {
            //RESET THE SERIALNO. SELECTED
            //Read.selectedSerialNos.Clear();

            showFormSelected(ref rd, "BORROWED");

            rd.borrowedHardwares_Btn.PerformClick();
            rd.panel5.Hide();
            rd.panel6.Hide();
            rd.panel7.Hide();
            rd.panel5.Visible = false;
            rd.panel6.Visible = false;
            rd.panel7.Visible = false;


            rd.panel4.Anchor = AnchorStyles.Left;
            rd.panel4.Dock = DockStyle.Left;
            rd.panel2.Padding = new Padding(10, 10, 0, 10);
            HideColumnIfExists("Location");

            headerPicture_Pb.Image = Image.FromFile(System.IO.Path.Combine(Application.StartupPath, "Images", "borrowed_Icon.ico"));
        }

        private async void reserved_Btn_Click(object sender, EventArgs e)
        {
            //RESET THE SERIALNO. SELECTED
            //Read.selectedSerialNos.Clear();

            showFormSelected(ref rd, "RESERVED");

            rd.reservedHardwares_Btn.PerformClick();

            rd.panel5.Visible = false;
            rd.panel6.Visible = false;
            rd.panel7.Visible = false;



            rd.panel4.Anchor = AnchorStyles.Left;
            rd.panel4.Dock = DockStyle.Left;
            rd.panel2.Padding = new Padding(10, 10, 0, 10);
            HideColumnIfExists("Location");

            headerPicture_Pb.Image = Image.FromFile(System.IO.Path.Combine(Application.StartupPath, "Images", "assetCategories_Icon.ico"));
        }

        private void archived_Btn_Click(object sender, EventArgs e)
        {
            //RESET THE SERIALNO. SELECTED
            //Read.selectedSerialNos.Clear();

            showFormSelected(ref rd, "ARCHIVE");

            rd.archive_Btn.PerformClick();
            rd.panel5.Hide();
            rd.panel6.Hide();
            rd.panel7.Hide();


            rd.panel4.Anchor = AnchorStyles.Left;
            rd.panel4.Dock = DockStyle.Left;
            rd.panel2.Padding = new Padding(10, 10, 0, 10);
            HideColumnIfExists("Location");

            headerPicture_Pb.Image = Image.FromFile(System.IO.Path.Combine(Application.StartupPath, "Images", "archive_Icon.ico"));
        }


        private void AssetHistory_Button_Click(object sender, EventArgs e)
        {
            //showFormSelected(ref rd, "ASSET HISTORY");
            MessageBox.Show("STILL ON PROGRESS!");

            headerPicture_Pb.Image = Image.FromFile(System.IO.Path.Combine(Application.StartupPath, "Images", "assetHistory_Icon.ico"));
        }


        void HideColumnIfExists(string columnName)
        {
            if (rd.dataGridView1.Columns.Contains(columnName))
            {
                rd.dataGridView1.Columns[columnName].Visible = false;
            }
        }

        private void FrontPage_Final_FormClosed(object sender, FormClosedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void ClearApplicationResources()
        {
            GC.Collect(); // Force garbage collection
            GC.WaitForPendingFinalizers(); // Ensure all finalizers have completed
        }
    }
}