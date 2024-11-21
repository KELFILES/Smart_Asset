using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
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

            StaticUserID = userID_Lbl;
            StaticAsset = assets_Btn;
            StaticName = name_Lbl;
            StaticManageAsset = ManageAsset_Btn;
            StaticCleaning = cleaning_Btn;
            StaticReplaced = replaced_Btn;
            StaticDisposed = disposed_Btn;
            StaticBorrowed = borrowed_Btn;
            StaticReserved = reserved_Btn;
            StaticArchived = archived_Btn;


        }
        //STATIC
        public static Label StaticUserID;
        public static Button StaticAsset;
        public static Label StaticName;
        public static Button StaticManageAsset;
        public static Button StaticCleaning;
        public static Button StaticReplaced;
        public static Button StaticDisposed;
        public static Button StaticBorrowed;
        public static Button StaticReserved;
        public static Button StaticArchived;




            //FOR LOGGED IN USER INFO
            public static string login_Name { get; set; }
            public static string login_Username { get; set; }
            public static string login_Role { get; set; }
            public static string login_UserID { get; set; }
        


            //FOR USER PERMISSION
            public static string permission_Add { get; set; }
            public static string permission_Archive { get; set; }
            public static string permission_Archived { get; set; }
            public static string permission_ArtificialIntelligence { get; set; }
            public static string permission_AssetHistory { get; set; }
            public static string permission_Assets { get; set; }
            public static string permission_BackupAndRestoreData { get; set; }
            public static string permission_Borrow { get; set; }
            public static string permission_Borrowed { get; set; }
            public static string permission_Cleaning { get; set; }
            public static string permission_CreateReport { get; set; }
            public static string permission_Dashboard { get; set; }
            public static string permission_Disposed { get; set; }
            public static string permission_Edit { get; set; }
            public static string permission_Replace { get; set; }
            public static string permission_Replacement { get; set; }
            public static string permission_Reserved { get; set; }
            public static string permission_ShowImage { get; set; }
            public static string permission_Transfer { get; set; }
        



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
        CreateReport crtRep = new CreateReport();
        Settings1 s1 = new Settings1();

        public static string selectedButton = "";
        RightClick_RepairingHardwares rh = new RightClick_RepairingHardwares();
        RightClick_ShowAllHardwares sah = new RightClick_ShowAllHardwares();
        RightClick_DisposedHardwares dsp = new RightClick_DisposedHardwares();

        public static string name = "";
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

            
            // Print all static properties of permission
            var properties = typeof(FrontPage_Final).GetProperties(BindingFlags.Static | BindingFlags.Public);

            foreach (var property in properties)
            {
                if (property.Name.StartsWith("permission_")) // Filter for permission properties
                {
                    var value = property.GetValue(null); // Get static property value
                    Console.WriteLine($"{property.Name}: {value}");
                }
            }
            


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

            replaced_Btn.Image = Image.FromFile(System.IO.Path.Combine(Application.StartupPath, "Images", "replacement_Icon.ico"));
            replaced_Btn.Padding = new Padding(35, 0, 20, 0);

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

            aIChat_Btn.Image = Image.FromFile(System.IO.Path.Combine(Application.StartupPath, "Images", "artificialIntelligence_Icon.ico"));
            aIChat_Btn.Padding = new Padding(10, 0, 20, 0);

            ManageUsers_Btn.Image = Image.FromFile(System.IO.Path.Combine(Application.StartupPath, "Images", "manageUsers_Icon.ico"));
            ManageUsers_Btn.Padding = new Padding(10, 0, 20, 0);

            createReport_Btn.Image = Image.FromFile(System.IO.Path.Combine(Application.StartupPath, "Images", "createReport_Icon.ico"));
            createReport_Btn.Padding = new Padding(10, 0, 20, 0);

            backupAndRestoreData_Btn.Image = Image.FromFile(System.IO.Path.Combine(Application.StartupPath, "Images", "backupData_Icon.ico"));
            backupAndRestoreData_Btn.Padding = new Padding(10, 0, 20, 0);
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
                    currentForm.Close();   // Close the form to free up resources
                    currentForm.Dispose(); // Dispose the form
                }

                mainPanel.Controls.Clear(); // Clear the panel
            }

            // Suggest garbage collection as a last resort
            GC.Collect();
            GC.WaitForPendingFinalizers();
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
            ButtonEnterColor(aIChat_Btn);
        }

        private void artificialIntelligence_Btn_MouseLeave(object sender, EventArgs e)
        {
            ButtonLeaveColor(aIChat_Btn);
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

            //UPDATE HEADER IMAGE
            headerPicture_Pb.Image = Image.FromFile(System.IO.Path.Combine(Application.StartupPath, "Images", "createReport_Icon.ico"));


            showFormSelected(ref crtRep, "CREATE REPORTS");
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

            // Dispose of the previous instance of the 'Read' form properly
            if (rd != null && !rd.IsDisposed)
            {
                rd.Dispose();
                rd = null;
            }

            // Recreate the form instance
            rd = new Read();

            showFormSelected(ref rd, "ASSETS");
            rd.showAllHardwares_Btn.PerformClick();

            rd.panel5.Visible = false;
            rd.panel7.Visible = false;

            Read.selectedButton = "ASSETS";

            headerPicture_Pb.Image = Image.FromFile(System.IO.Path.Combine(Application.StartupPath, "Images", "asset_Icon.ico"));

        }



        private void backupData_Btn_Click(object sender, EventArgs e)
        {
            //showFormSelected(ref rd, "BACKUP DATA");
            headerPicture_Pb.Image = Image.FromFile(System.IO.Path.Combine(Application.StartupPath, "Images", "backupData_Icon.ico"));

            MessageBox.Show("STILL ON PROGRESS!");
            //showFormSelected(ref crtRep, "BACKUP AND RESTORE");
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
            ButtonEnterColor(backupAndRestoreData_Btn);
        }

        private void backupData_Btn_MouseLeave(object sender, EventArgs e)
        {
            ButtonLeaveColor(backupAndRestoreData_Btn);
        }

        private void repairingHardwares_Btn_MouseEnter(object sender, EventArgs e)
        {
            SubButtonEnterColor(replaced_Btn);
        }

        private void repairingHardwares_Btn_MouseLeave(object sender, EventArgs e)
        {
            SubButtonLeaveColor(replaced_Btn);
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
            // Dispose of the previous instance of 'Read' form properly
            if (rd != null && !rd.IsDisposed)
            {
                rd.Dispose();
                rd = null;
            }

            // Create a new instance of the 'Read' form
            rd = new Read();

            showFormSelected(ref rd, "REPLACED");

            // Trigger the replacement button click on the 'Read' form
            rd.replacement_Btn.PerformClick();

            // Hide unnecessary panels
            rd.panel5.Hide();
            rd.panel9.Hide();
            rd.panel7.Hide();

            // Adjust layout and docking
            rd.panel4.Anchor = AnchorStyles.Left;
            rd.panel4.Dock = DockStyle.Left;
            rd.panel2.Padding = new Padding(10, 10, 0, 10);

            // Hide the 'Location' column if it exists
            HideColumnIfExists("Location");

            // Update the header picture
            headerPicture_Pb.Image = Image.FromFile(System.IO.Path.Combine(Application.StartupPath, "Images", "replacement_Icon.ico"));
        }

        private void cleaning_Btn_Click_1(object sender, EventArgs e)
        {
            // Dispose of the previous instance of 'Read' form properly
            if (rd != null && !rd.IsDisposed)
            {
                rd.Dispose();
                rd = null;
            }

            // Create a new instance of the 'Read' form
            rd = new Read();

            showFormSelected(ref rd, "CLEANING");

            // Trigger the cleaning button click on the 'Read' form
            rd.cleaningHardwares_Btn.PerformClick();

            // Hide unnecessary panels
            rd.panel5.Hide();
            rd.panel9.Hide();
            rd.panel7.Hide();

            // Adjust layout and docking
            rd.panel4.Anchor = AnchorStyles.Left;
            rd.panel4.Dock = DockStyle.Left;
            rd.panel2.Padding = new Padding(10, 10, 0, 10);

            // Hide the 'Location' column if it exists
            HideColumnIfExists("Location");

            // Update the header picture
            headerPicture_Pb.Image = Image.FromFile(System.IO.Path.Combine(Application.StartupPath, "Images", "cleaning_Icon.ico"));
        }


        private void disposed_Btn_Click_1(object sender, EventArgs e)
        {
            // Dispose of the previous instance of 'Read' form properly
            if (rd != null && !rd.IsDisposed)
            {
                rd.Dispose();
                rd = null;
            }

            // Create a new instance of the 'Read' form
            rd = new Read();

            showFormSelected(ref rd, "DISPOSED");

            // Trigger the disposed button click on the 'Read' form
            rd.disposedHardwares_Btn.PerformClick();

            // Hide unnecessary panels
            rd.panel5.Hide();
            rd.panel9.Hide();
            rd.panel7.Hide();

            // Adjust layout and docking
            rd.panel4.Anchor = AnchorStyles.Left;
            rd.panel4.Dock = DockStyle.Left;
            rd.panel2.Padding = new Padding(10, 10, 0, 10);

            // Hide the 'Location' column if it exists
            HideColumnIfExists("Location");

            // Update the header picture
            headerPicture_Pb.Image = Image.FromFile(System.IO.Path.Combine(Application.StartupPath, "Images", "disposed_Icon.ico"));
        }

        private void borrowed_Btn_Click(object sender, EventArgs e)
        {
            // Dispose of the previous instance of 'Read' form properly
            if (rd != null && !rd.IsDisposed)
            {
                rd.Dispose();
                rd = null;
            }

            // Create a new instance of the 'Read' form
            rd = new Read();

            showFormSelected(ref rd, "BORROWED");

            // Trigger the borrowed button click on the 'Read' form
            rd.borrowedHardwares_Btn.PerformClick();

            // Hide unnecessary panels
            rd.panel5.Hide();
            rd.panel9.Hide();
            rd.panel7.Hide();

            // Ensure the panels are hidden (in case they are shown by some other action)
            rd.panel5.Visible = false;
            rd.panel9.Visible = false;
            rd.panel7.Visible = false;

            // Adjust layout and docking
            rd.panel4.Anchor = AnchorStyles.Left;
            rd.panel4.Dock = DockStyle.Left;
            rd.panel2.Padding = new Padding(10, 10, 0, 10);

            // Hide the 'Location' column if it exists
            HideColumnIfExists("Location");

            // Update the header picture
            headerPicture_Pb.Image = Image.FromFile(System.IO.Path.Combine(Application.StartupPath, "Images", "borrowed_Icon.ico"));
        }


        private async void reserved_Btn_Click(object sender, EventArgs e)
        {
            // Dispose of the previous instance of 'Read' form properly
            if (rd != null && !rd.IsDisposed)
            {
                rd.Dispose();
                rd = null;
            }

            // Create a new instance of the 'Read' form
            rd = new Read();

            showFormSelected(ref rd, "RESERVED");

            // Trigger the reserved button click on the 'Read' form
            rd.reservedHardwares_Btn.PerformClick();

            // Ensure the panels are hidden
            rd.panel5.Visible = false;
            rd.panel9.Visible = false;
            rd.panel7.Visible = false;

            // Adjust layout and docking
            rd.panel4.Anchor = AnchorStyles.Left;
            rd.panel4.Dock = DockStyle.Left;
            rd.panel2.Padding = new Padding(10, 10, 0, 10);

            // Hide the 'Location' column if it exists
            HideColumnIfExists("Location");

            // Update the header picture
            headerPicture_Pb.Image = Image.FromFile(System.IO.Path.Combine(Application.StartupPath, "Images", "assetCategories_Icon.ico"));

            // Optionally await any async operations if needed
            await Task.Yield(); // This is just a placeholder for any async work you might have
        }


        private void archived_Btn_Click(object sender, EventArgs e)
        {
            // Dispose of the previous instance of 'Read' form properly
            if (rd != null && !rd.IsDisposed)
            {
                rd.Dispose();
                rd = null;
            }

            // Create a new instance of the 'Read' form
            rd = new Read();

            showFormSelected(ref rd, "ARCHIVE");

            // Trigger the archive button click on the 'Read' form
            rd.archive_Btn.PerformClick();

            // Hide unnecessary panels
            rd.panel5.Hide();
            rd.panel9.Hide();
            rd.panel7.Hide();

            // Adjust layout and docking
            rd.panel4.Anchor = AnchorStyles.Left;
            rd.panel4.Dock = DockStyle.Left;
            rd.panel2.Padding = new Padding(10, 10, 0, 10);

            // Hide the 'Location' column if it exists
            HideColumnIfExists("Location");

            // Update the header picture
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

        private void userID_Lbl_TabIndexChanged(object sender, EventArgs e)
        {

        }

        private void changePassword_Lbl_Click(object sender, EventArgs e)
        {
            ChangePassword cp = new ChangePassword();
            cp.StartPosition = FormStartPosition.CenterScreen;
            cp.Show();
        }

        private void header_Lbl_TextChanged(object sender, EventArgs e)
        {
            this.Text = header_Lbl.Text;
        }
    }
}