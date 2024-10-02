using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.DataFormats;

namespace Smart_Asset
{
    public partial class RightClick_ShowAllHardwares : Form
    {

        // Parameterless constructor (still needed by the designer)
        public RightClick_ShowAllHardwares()
        {
            InitializeComponent();
        }


        private Read form1;  // Reference to Form1 (Read)

        // Constructor that accepts Form1 (Read) as a parameter
        public RightClick_ShowAllHardwares(Read form1)
        {
            InitializeComponent();
            this.form1 = form1;
        }




        //FOR GETTING DATA FROM READ.CS
        static string getClickBtnInfo;
        public void SendClickBtnInfo(string data)
        {
            getClickBtnInfo = data;
        }

        // Change getData to be a list of serial numbers
        static List<string> getData = new List<string>();

        // Method to accept a list of serial numbers
        public void GetRetrievingSerial(List<string> data)
        {
            getData = data;
        }


        private void refresh_Btn_Click(object sender, EventArgs e)
        {
            // Call the method to refresh the DataGridView in Form1
            form1.Refresh_ShowAllHardwares();

            // Close the form after the operation is complete
            this.Close();
            this.Dispose();
        }



    }
}
