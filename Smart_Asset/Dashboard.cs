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
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();

            // Enable double buffering for the entire form
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer |
                          ControlStyles.UserPaint |
                          ControlStyles.AllPaintingInWmPaint, true);
            this.UpdateStyles();
        }

        // Alternatively, override CreateParams to enable double buffering
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000; // WS_EX_COMPOSITED
                return cp;
            }
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {

        }

        private void Dashboard_Shown(object sender, EventArgs e)
        {
            // Construct the relative path to the image
            string imagePath = System.IO.Path.Combine(Application.StartupPath, "Images", "chartExample_Image.jpg");

            // Load the image from the relative path
            panel1.BackgroundImage = Image.FromFile(imagePath);

            // Set the layout of the background image
            panel1.BackgroundImageLayout = ImageLayout.Stretch; // Or use Tile, Center, Zoom, None
        }
    }
}
