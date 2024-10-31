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
    public partial class ChangeRole : Form
    {
        public ChangeRole()
        {
            InitializeComponent();
        }

        private void ChangeRole_Load(object sender, EventArgs e)
        {

        }

        private void comboBox1_MouseClick(object sender, MouseEventArgs e)
        {
            switch (currentRoleVal_Lbl.Text)
            {
                case "Super Admin":
                    newRole_Cb.Items.Clear();
                    newRole_Cb.Items.Add("Admin");
                    newRole_Cb.Items.Add("Custom User");
                    break;
                case "Admin":
                    newRole_Cb.Items.Clear();
                    newRole_Cb.Items.Add("Super Admin");
                    newRole_Cb.Items.Add("Custom User");
                    break;
                case "Custom User":
                    newRole_Cb.Items.Clear();
                    newRole_Cb.Items.Add("Super Admin");
                    newRole_Cb.Items.Add("Admin");
                    break;
            }
        }
    }
}
