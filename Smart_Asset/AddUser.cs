using MongoDB.Bson;
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
    public partial class AddUser : Form
    {
        public AddUser()
        {
            InitializeComponent();
        }

        //FIELDS
        private string encryptedPass { get; set; }

        private async void button1_Click(object sender, EventArgs e)
        {

            // Check if any of the TextBoxes are null or empty
            if (string.IsNullOrWhiteSpace(name_Tb.Text) ||
                string.IsNullOrWhiteSpace(email_Tb.Text) ||
                string.IsNullOrWhiteSpace(contactNo_Tb.Text) ||
                string.IsNullOrWhiteSpace(address_Tb.Text) ||
                string.IsNullOrWhiteSpace(username_Tb.Text) ||
                string.IsNullOrWhiteSpace(password_Tb.Text) ||
                string.IsNullOrWhiteSpace(reEnterPassword_Tb.Text) ||
                string.IsNullOrWhiteSpace(role_Cb.Text))
            {
                MessageBox.Show("Please Fill Up The Blanks.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Exit the method if any field is empty
            }

            // Check if password and re-entered password match
            if (password_Tb.Text != reEnterPassword_Tb.Text)
            {
                MessageBox.Show("Passwords do not match.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Exit the method if passwords don't match
            }

            // Encrypt the password
            string encryptedPass = MyOtherMethods.EncryptPassword(password_Tb.Text);
            Console.WriteLine(encryptedPass);

            // Prepare the fields to be inserted
            var fields = new Dictionary<string, object>
            {
                { "name", name_Tb.Text },
                { "email", email_Tb.Text },
                { "contactNo", contactNo_Tb.Text },
                { "address", address_Tb.Text },
                { "username", username_Tb.Text },
                { "password",  encryptedPass },
                { "role", role_Cb.Text },
                { "userID", ObjectId.GenerateNewId() }
            };

            // Insert the document into the database
            await MyDbMethods.InsertDocument("SmartAssetDb", "Users", fields);
        }
    }
}