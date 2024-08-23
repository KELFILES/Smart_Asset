namespace Smart_Asset
{
    public partial class Startup : Form
    {
        public Startup()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.ControlBox = false;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
        }

        private void start_Btn_Click(object sender, EventArgs e)
        {
            this.Hide();

            Login lg = new Login();
            lg.StartPosition = FormStartPosition.CenterScreen;
            lg.Show();
        }
    }
}
