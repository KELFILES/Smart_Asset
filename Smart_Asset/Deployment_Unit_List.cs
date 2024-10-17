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

        private void add_Btn_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Added successfully");
            var fields = new Dictionary<string, string>
            {
                {"List", $"{item_Tb.Text}"}
            };

            MyDbMethods.InsertDocument("SmartAssetDb", "Deployment_Unit_List", fields);

            //show again the list
            MyDbMethods.showAllItemsInDb("SmartAssetDb", "Deployment_Unit_List", dataGridView1);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Removed successfully");

            //show again the list
            MyDbMethods.showAllItemsInDb("SmartAssetDb", "Deployment_Unit_List", dataGridView1);
        }

        private void Deployment_Unit_List_Load(object sender, EventArgs e)
        {
            MyDbMethods.showAllItemsInDb("SmartAssetDb", "Deployment_Unit_List", dataGridView1);
        }
    }
}
