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
    public partial class Replacement : Form
    {
        public Replacement()
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

        private async void button1_Click(object sender, EventArgs e)
        {
            // Get the location of 'SerialNoTop' (bottom ComboBox)
            string locationTo = await MyDbMethods.Get_LocationAsync("SmartAssetDb", serialNoTop_Cmb.Text);

            // Get the location of 'SerialNoBottom' (bottom ComboBox)
            string locationBottom = await MyDbMethods.Get_LocationAsync("SmartAssetDb", serialNoBottom_Cmb.Text);


            Console.WriteLine("Retrieved Location: " + locationTo);


            await MyDbMethods.MoveToReplacement("SmartAssetDb", serialNoTop_Cmb.Text, notes_Tb.Text);



            //await MyDbMethods.TransferSerialNoToLocation("SmartAssetDb", locationTo, serialNoFrom_Cmb.Text, notes_Tb.Text);


            await MyDbMethods.TransferDocumentBySerialNo("SmartAssetDb", locationTo, serialNoBottom_Cmb.Text);
        }






    }
}
