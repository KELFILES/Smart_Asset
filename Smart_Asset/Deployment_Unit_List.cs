using Amazon.Runtime.Internal.Transform;
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
    public partial class Deployment_Unit_List : Form
    {
        public Deployment_Unit_List()
        {
            InitializeComponent();
        }

        private void add_Btn_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Added successfully");
            var fields = new Dictionary<string, string>
            {
                {"List", $"{item_Tb.Text}"}
            };

            MyDbMethods.InsertDocument("SmartAssetDb", "Deployment_Unit_List", fields);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Removed successfully");
        }
    }
}
