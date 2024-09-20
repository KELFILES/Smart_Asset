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
    public partial class Deployment_Location_List : Form
    {
        public Deployment_Location_List()
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

            MyDbMethods.InsertDocument("SmartAssetDb", "Deployment_Location_List", fields);

            //show again the list
            MyDbMethods.showAllItemsInDb("SmartAssetDb", "Deployment_Location_List", dataGridView1);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Removed successfully");

            //show again the list
            MyDbMethods.showAllItemsInDb("SmartAssetDb", "Deployment_Location_List", dataGridView1);
        }

        private void Deployment_Location_List_Load(object sender, EventArgs e)
        {
            MyDbMethods.showAllItemsInDb("SmartAssetDb", "Deployment_Location_List", dataGridView1);
        }
    }
}
