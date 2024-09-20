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
    public partial class Login : Form
    {

        // Declare the background image at the class level
        private Image backgroundImage;


        public Login()
        {
            InitializeComponent();
        }

        private void Login_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void submit_Btn_Click_1(object sender, EventArgs e)
        {
            if (username_Tb.Text.Equals("Admin") && password_Tb.Text.Equals("Admin123"))
            {
                MessageBox.Show("Login Successful");

                FrontPage_Final pff = new FrontPage_Final();
                pff.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Wrong Username or Password");
            }
            Console.WriteLine(password_Lbl.Text);
        }

        private void Login_Shown(object sender, EventArgs e)
        {
            // Construct the relative path to the image
            string imagePath = System.IO.Path.Combine(Application.StartupPath, "Images", "login_Image.jpg");

            // Load the image from the relative path
            Image backgroundImage = Image.FromFile(imagePath);

            // Assuming panel1 is of type DoubleBufferedPanel
            // Handle the panel's Paint event to draw the background image manually
            panel1.Paint += (s, ev) =>
            {
                // Draw the background image to fit the panel's size
                ev.Graphics.DrawImage(backgroundImage, 0, 0, panel1.Width, panel1.Height);
            };

            // Force the panel to redraw when the form is resized
            this.Resize += (s, ev) =>
            {
                panel1.Invalidate(); // This forces the panel to be redrawn
            };
        }

        private void Login_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                submit_Btn.PerformClick();
            }

        }

        private void password_Tb_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                submit_Btn.PerformClick();
            }
        }

        private void username_Tb_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                submit_Btn.PerformClick();
            }
        }
    }

    public class DoubleBufferedPanel : Panel
    {
        public DoubleBufferedPanel()
        {
            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.UserPaint, true);
        }
    }
}
