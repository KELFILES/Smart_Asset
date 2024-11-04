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
    public partial class RemoveUser : Form
    {
        public RemoveUser()
        {
            InitializeComponent();
        }

        //FIELDS
        private string encrypted { get; set; }


        private async void removeUser_Btn_Click(object sender, EventArgs e)
        {
            // Encryption
            encrypted = MyOtherMethods.EncryptPassword(password_Tb.Text);

            bool isCorrectPass = await MyDbMethods.ValidateUserUsingUserID("SmartAssetDb", "Users", FrontPage_Final.StaticUserID.Text, encrypted);
            Console.WriteLine("UserID: " + $"{FrontPage_Final.StaticUserID.Text}");

            if (isCorrectPass)
            {
                await MyDbMethods.DeleteUserByUserIDAsync("SmartAssetDb", "Users", userIDVal_Lbl.Text);
            }
            else
            {
                MessageBox.Show("Invalid UserID or Password.", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void RemoveUser_FormClosed(object sender, FormClosedEventArgs e)
        {
            //Refresh
            ManageUsers.Refresh_ManageUsers();
        }
    }
}
