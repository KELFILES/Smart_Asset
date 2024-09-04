using System.Reflection.Emit;
using System.Windows.Forms;

namespace Smart_Asset
{
    public partial class Startup : Form
    {
        public Startup()
        {
            InitializeComponent();
            MyDbMethods.TestMongoDBConnection();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.ControlBox = false;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
        }


        private void Startup_Shown(object sender, EventArgs e)
        {
            // Construct the relative path to the image
            string imagePath = System.IO.Path.Combine(Application.StartupPath, "Images", "startup_Image.jpg");

            // Load the image from the relative path
            panel1.BackgroundImage = Image.FromFile(imagePath);

            // Set the layout of the background image
            panel1.BackgroundImageLayout = ImageLayout.Stretch; // Or use Tile, Center, Zoom, None
        }

        private void start_Btn_Click_1(object sender, EventArgs e)
        {
            this.Hide();

            Login lg = new Login();
            lg.StartPosition = FormStartPosition.CenterScreen;
            lg.Show();
        }



    }
}
