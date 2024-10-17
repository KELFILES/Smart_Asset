using System.Reflection.Emit;
using System.Windows.Forms;

namespace Smart_Asset
{
    public partial class Startup : Form
    {
        public Startup()
        {
            InitializeComponent();

            // Enable double buffering for the entire form
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer |
                          ControlStyles.UserPaint |
                          ControlStyles.AllPaintingInWmPaint, true);
            this.UpdateStyles();;

            MyDbMethods.TestMongoDBConnection();
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




        private void Form1_Load(object sender, EventArgs e)
        {
            this.ControlBox = false;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;

            pictureBox1.BackColor = Color.FromArgb(200, Color.Black); // Set BackColor
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
