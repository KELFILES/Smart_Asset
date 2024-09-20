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
    public partial class TypeList_Add : Form
    {
        public TypeList_Add()
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

            MyDbMethods.InsertDocument("SmartAssetDb", "Type_List", fields);

            MyDbMethods.showAllItemsInDb("SmartAssetDb", "Type_List", dataGridView1);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Removed successfully");

            MyDbMethods.showAllItemsInDb("SmartAssetDb", "Type_List", dataGridView1);
        }

        private void TypeList_Add_Load(object sender, EventArgs e)
        {
            MyDbMethods.showAllItemsInDb("SmartAssetDb", "Type_List", dataGridView1);
        }
    }
}
