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
    public partial class Instructions : Form
    {
        public Instructions()
        {
            InitializeComponent();
        }

        private void Instructions_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            MyOtherMethods.SaveExistingFileToComputer();
        }

        private void uploadFile_Btn_Click(object sender, EventArgs e)
        {
            TypeList_Add tla = new TypeList_Add();
            tla.StartPosition = FormStartPosition.CenterScreen;
            tla.Show();
        }
    }
}
