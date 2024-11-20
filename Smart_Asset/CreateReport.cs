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
    public partial class CreateReport : Form
    {
        public CreateReport()
        {
            InitializeComponent();
        }

        private async void CreateReport_Load(object sender, EventArgs e)
        {
            MyOtherMethods.CenterInPanel(topText_Lbl, panel2);

            var retrievedDbData = await MyDbMethods.ReadAllDatabaseInBSON("SmartAssetDb");




            CreateReportsMethod.ShowReports(retrievedDbData, mainboard_Tb);
        }

        private void CreateReport_SizeChanged(object sender, EventArgs e)
        {
            MyOtherMethods.CenterInPanel(topText_Lbl, panel2);
        }
    }
}
