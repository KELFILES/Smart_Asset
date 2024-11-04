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
    public partial class ResetPassword : Form
    {
        public ResetPassword()
        {
            InitializeComponent();
        }

        //FIELDS
        private string encrypted { get; set; }

        private void ResetPassword_Load(object sender, EventArgs e)
        {
            MyOtherMethods.CenterInPanel(label3, panel2);
        }

        private async void resetPassword_Btn_Click(object sender, EventArgs e)
        {
            // Check if password and re-entered password match
            if (password_Tb.Text != reEnterPassword_Tb.Text)
            {
                MessageBox.Show("Passwords do not match.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Exit the method if passwords don't match
            }

            // Encryption
            encrypted = MyOtherMethods.EncryptPassword(password_Tb.Text);

            await MyDbMethods.UpdateFieldAsync("SmartAssetDb", "Users", userIDVal_Lbl.Text, "password", $"{encrypted}");






        }



    }
}
