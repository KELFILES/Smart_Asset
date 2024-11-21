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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace Smart_Asset
{
    public partial class Login : Form
    {
        // Declare the background image at the class level
        private Image backgroundImage;

        //FIELDS
        private string encrypted { get; set; }

        public Login()
        {
            InitializeComponent();

            // Attach the Resize event handler
            this.Resize += Login_Resize;
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

        private void Login_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private async void submit_Btn_Click_1(object sender, EventArgs e)
        {
            string password = password_Tb.Text;

            if (username_Tb.Text.Equals("SuperAdmin") && password.Equals("SuperAdmin123"))
            {
                //FOR FIRST USE OF DATABASE CREATE FIRST SUPER ADMIN
                await MyDbMethods.EnsureSuperAdminExistsAsync("SmartAssetDb", "Users");
            }





            // Encryption
            encrypted = MyOtherMethods.EncryptPassword(password);

            var userDetails = await MyDbMethods.GetUserDetailsAsync("SmartAssetDb", "Users", $"{username_Tb.Text}", $"{encrypted}");

            if (userDetails != null)
            {
                Console.WriteLine($"Name: {userDetails.Name}");
                Console.WriteLine($"Username: {userDetails.Username}");
                Console.WriteLine($"Role: {userDetails.Role}");
                Console.WriteLine($"UserID: {userDetails.UserID}");


                FrontPage_Final pff = new FrontPage_Final();


                //PASS USER DETAILS TO FRONTPAGE
                FrontPage_Final.login_Name = userDetails.Name;
                FrontPage_Final.login_Username = userDetails.Username;
                FrontPage_Final.login_Role = userDetails.Role;
                FrontPage_Final.login_UserID = userDetails.UserID;


                if (userDetails.Role.Equals("Custom User"))
                {
                    var pulledDataInColl = MyDbMethods.GetPermissions("SmartAssetDb", "CustomUsers_Permissions", $"{userDetails.UserID}");

                    var permissionMapping = new Dictionary<string, Action<string>>
                    {
                        { "Add", value => FrontPage_Final.permission_Add = value },
                        { "Archive", value => FrontPage_Final.permission_Archive = value },
                        { "Archived", value => FrontPage_Final.permission_Archived = value },
                        { "ArtificialIntelligence", value => FrontPage_Final.permission_ArtificialIntelligence = value },
                        { "AssetHistory", value => FrontPage_Final.permission_AssetHistory = value },
                        { "Assets", value => FrontPage_Final.permission_Assets = value },
                        { "BackupAndRestoreData", value => FrontPage_Final.permission_BackupAndRestoreData = value },
                        { "Borrow", value => FrontPage_Final.permission_Borrow = value },
                        { "Borrowed", value => FrontPage_Final.permission_Borrowed = value },
                        { "Cleaning", value => FrontPage_Final.permission_Cleaning = value },
                        { "CreateReport", value => FrontPage_Final.permission_CreateReport = value },
                        { "Dashboard", value => FrontPage_Final.permission_Dashboard = value },
                        { "Disposed", value => FrontPage_Final.permission_Disposed = value },
                        { "Edit", value => FrontPage_Final.permission_Edit = value },
                        { "Replace", value => FrontPage_Final.permission_Replace = value },
                        { "Replacement", value => FrontPage_Final.permission_Replacement = value },
                        { "Reserved", value => FrontPage_Final.permission_Reserved = value },
                        { "ShowImage", value => FrontPage_Final.permission_ShowImage = value },
                        { "Transfer", value => FrontPage_Final.permission_Transfer = value },
                    };

                    foreach (var data in pulledDataInColl)
                    {
                        if (permissionMapping.TryGetValue(data.Key, out var action))
                        {
                            action(data.Value);
                        }

                        //Console.WriteLine($"Key: {data.Key}, Value: {data.Value}");
                    }
                }



                pff.name_Lbl.Text = userDetails.Name;
                pff.userID_Lbl.Text = userDetails.UserID;

                pff.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("User not found or fields missing.");
            }
        }

        private void Login_Shown(object sender, EventArgs e)
        {
            bgBox.BackColor = Color.FromArgb(200, Color.Black); // Set BackColor

            // Construct the relative path to the image
            string imagePath = System.IO.Path.Combine(Application.StartupPath, "Images", "login_Image.jpg");

            // Load the image from the relative path
            backgroundImage = Image.FromFile(imagePath); // Use class-level backgroundImage

            // Assuming panel1 is of type DoubleBufferedPanel
            // Handle the panel's Paint event to draw the background image manually
            panel1.Paint += (s, ev) =>
            {
                // Draw the background image to fit the panel's size
                ev.Graphics.DrawImage(backgroundImage, 0, 0, panel1.Width, panel1.Height);
            };

            // Force the panel to redraw when the form is resized
            this.Resize += (s, ev) =>
            {
                panel1.Invalidate(); // This forces the panel to be redrawn
            };

            // Adjust the initial location of bgBox
            AdjustBgBox();
        }

        private void Login_Resize(object sender, EventArgs e)
        {
            // Adjust the location of bgBox when the form is resized
            AdjustBgBox();
        }

        private void AdjustBgBox()
        {
            // Calculate the new location based on the form's size
            int newX = (this.ClientSize.Width - bgBox.Width) / 2;
            int newY = (this.ClientSize.Height - bgBox.Height) / 2;

            // Set the new location of bgBox without changing its size
            bgBox.Location = new Point(newX, newY);
        }

        private void Login_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                submit_Btn.PerformClick();
            }
        }

        private void password_Tb_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                submit_Btn.PerformClick();
            }
        }

        private void username_Tb_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                submit_Btn.PerformClick();
            }
        }

        private async void Login_Load(object sender, EventArgs e)
        {

        }

        private void forgotPassword_Lbl_Click(object sender, EventArgs e)
        {
            ChangePassword cp = new ChangePassword();
            cp.StartPosition = FormStartPosition.CenterScreen;
            cp.Show();
        }
    }

    public class DoubleBufferedPanel : Panel
    {
        public DoubleBufferedPanel()
        {
            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.UserPaint, true);
        }
    }
}
