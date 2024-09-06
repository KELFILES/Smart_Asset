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
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {

        }

        private void Dashboard_Shown(object sender, EventArgs e)
        {
            // Construct the relative path to the image
            string imagePath = System.IO.Path.Combine(Application.StartupPath, "Images", "chartExample_Image.png");

            // Load the image from the relative path
            panel1.BackgroundImage = Image.FromFile(imagePath);

            // Set the layout of the background image
            panel1.BackgroundImageLayout = ImageLayout.Stretch; // Or use Tile, Center, Zoom, None
        }
    }
}
