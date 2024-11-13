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
    public partial class ChangePassword : Form
    {
        public ChangePassword()
        {
            InitializeComponent();
        }

        private void change_Btn_Click(object sender, EventArgs e)
        {
            MyDbMethods.ChangePassword("SmartAssetDb", "Users", $"{username_Tb.Text}", $"{currentPassword_Tb.Text}", $"{newPassword_Tb.Text}", $"{repeatPassword_Tb.Text}");
        }
    }
}
