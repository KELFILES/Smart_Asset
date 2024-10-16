﻿using System;
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
            //FIRST I NEED TO GET THE LOCATION OF serialNoFrom_Cmb
            string location = await MyDbMethods.Get_LocationAsync("SmartAssetDb", $"{serialNoFrom_Cmb.Text}");

            await MyDbMethods.TransferDocumentBySerialNo("SmartAssetDb", "Replacement", $"{serialNoFrom_Cmb.Text}", notes_Tb.Text);

            //OVERRIDE THE LOCATION
            await MyDbMethods.TransferDocumentBySerialNo("SmartAssetDb", $"{location}", $"{serialNoTo_Cmb.Text}", notes_Tb.Text);
        }
    }
}
