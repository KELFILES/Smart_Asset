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
            // Get the location of 'SerialNoTo' (bottom ComboBox)
            string locationTo = await MyDbMethods.Get_LocationAsync("SmartAssetDb", serialNoTo_Cmb.Text);

            // Move 'SerialNoTo' (bottom ComboBox) to the "Replacement" collection
            await MyDbMethods.MoveToReplacement("SmartAssetDb", serialNoTo_Cmb.Text, notes_Tb.Text);

            // Transfer 'SerialNoFrom' (top ComboBox) to the location of 'SerialNoTo'
            await MyDbMethods.TransferSerialNoToLocation("SmartAssetDb", locationTo, serialNoFrom_Cmb.Text, notes_Tb.Text);
        }
    }
}
