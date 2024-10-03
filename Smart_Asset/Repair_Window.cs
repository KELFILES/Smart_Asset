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
    public partial class Repair_Window : Form
    {
        public Repair_Window()
        {
            InitializeComponent();
        }

        private void serialNo_Cmb_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = char.ToUpper(e.KeyChar);
        }

        private void serialNo_Cmb_MouseEnter(object sender, EventArgs e)
        {
            MyDbMethods.LoadDatabase_AllSerialNo("SmartAssetDb", serialNo_Cmb);
        }

        private async void transfer_Btn_Click(object sender, EventArgs e)
        {
            await MyDbMethods.TransferDocumentBySerialNo("SmartAssetDb", "Repairing", $"{serialNo_Cmb.Text}", notes_Tb.Text);
        }

    }
}