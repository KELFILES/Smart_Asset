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
    public partial class FrontPage : Form
    {

        private int operations_Num { get; set; }


        public FrontPage()
        {
            InitializeComponent();
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            dashboard_Btn.PerformClick();
        }

        Create cr = new Create();
        Read rd = new Read();
        Update ud = new Update();
        Transfer del = new Transfer();
        Dashboard db = new Dashboard();
        Deployment dp = new Deployment();
        Swap sw = new Swap();
        Repairing rep = new Repairing();

        private void cREATEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            header_Lbl.Text = "ASSET MANAGEMENT: CREATE";

            if (cREATEToolStripMenuItem.Enabled)
            {
                cr.TopLevel = false;
                cr.FormBorderStyle = FormBorderStyle.None;
                cr.Dock = DockStyle.Fill;
                mainPanel.Controls.Add(cr);
                cr.Show();
                rd.Hide();
                ud.Hide();
                del.Hide();
                dp.Hide();
                db.Hide();
                sw.Hide();
                rep.Hide();
            }
            else
            {
                cr.Dispose();
            }
        }

        private void rEADToolStripMenuItem_Click(object sender, EventArgs e)
        {
            header_Lbl.Text = "ASSET MANAGEMENT: READ";

            if (rEADToolStripMenuItem.Enabled)
            {
                rd.TopLevel = false;
                rd.FormBorderStyle = FormBorderStyle.None;
                rd.Dock = DockStyle.Fill;
                mainPanel.Controls.Add(rd);
                cr.Hide();
                rd.Show();
                ud.Hide();
                del.Hide();
                dp.Hide();
                db.Hide();
                sw.Hide();
                rep.Hide();
            }
            else
            {
                rd.Dispose();
            }
        }

        private void uPDATEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            header_Lbl.Text = "ASSET MANAGEMENT: UPDATE";

            if (rEADToolStripMenuItem.Enabled)
            {
                ud.TopLevel = false;
                ud.FormBorderStyle = FormBorderStyle.None;
                ud.Dock = DockStyle.Fill;
                mainPanel.Controls.Add(ud);
                cr.Hide();
                rd.Hide();
                ud.Show();
                del.Hide();
                dp.Hide();
                db.Hide();
                sw.Hide();
                rep.Hide();
            }
            else
            {
                ud.Dispose();
            }
        }

        private void rEMOVEToolStripMenuItem_Click(object sender, EventArgs e)
        {
            header_Lbl.Text = "ASSET MANAGEMENT: REMOVE";

            if (rEADToolStripMenuItem.Enabled)
            {
                del.TopLevel = false;
                del.FormBorderStyle = FormBorderStyle.None;
                del.Dock = DockStyle.Fill;
                mainPanel.Controls.Add(del);
                cr.Hide();
                rd.Hide();
                ud.Hide();
                del.Show();
                dp.Hide();
                db.Hide();
                sw.Hide();
                rep.Hide();
            }
            else
            {
                del.Dispose();
            }
        }


        private void dashboard_Btn_Click(object sender, EventArgs e)
        {
            header_Lbl.Text = "ASSET MANAGEMENT: Dashboard";
            if (dashboard_Btn.Enabled)
            {
                db.TopLevel = false;
                db.FormBorderStyle = FormBorderStyle.None;
                db.Dock = DockStyle.Fill;
                mainPanel.Controls.Add(db);

                cr.Hide();
                rd.Hide();
                ud.Hide();
                del.Hide();
                dp.Hide();
                db.Show();
                sw.Hide();
                rep.Hide();
            }
            else
            {
                db.Dispose();
            }
        }

        private void Deployment_Btn_Click(object sender, EventArgs e)
        {
            header_Lbl.Text = "ASSET MANAGEMENT: DEPLOYMENT";
            if (dashboard_Btn.Enabled)
            {
                dp.TopLevel = false;
                dp.FormBorderStyle = FormBorderStyle.None;
                dp.Dock = DockStyle.Fill;
                mainPanel.Controls.Add(dp);

                cr.Hide();
                rd.Hide();
                ud.Hide();
                del.Hide();
                db.Hide();
                dp.Show();
                sw.Hide();
                rep.Hide();
            }
            else
            {
                dp.Dispose();
            }
        }

        private void swap_Btn_Click(object sender, EventArgs e)
        {
            header_Lbl.Text = "ASSET MANAGEMENT: SWAP";
            if (dashboard_Btn.Enabled)
            {
                sw.TopLevel = false;
                sw.FormBorderStyle = FormBorderStyle.None;
                sw.Dock = DockStyle.Fill;
                mainPanel.Controls.Add(sw);

                cr.Hide();
                rd.Hide();
                ud.Hide();
                del.Hide();
                db.Hide();
                dp.Hide();
                sw.Show();
                rep.Hide();
            }
            else
            {
                sw.Dispose();
            }
        }

        private void repairing_Btn_Click(object sender, EventArgs e)
        {
            this.Refresh();

            header_Lbl.Text = "ASSET MANAGEMENT: REPAIRING";
            if (dashboard_Btn.Enabled)
            {
                rep.TopLevel = false;
                rep.FormBorderStyle = FormBorderStyle.None;
                rep.Dock = DockStyle.Fill;
                mainPanel.Controls.Add(rep);

                cr.Hide();
                rd.Hide();
                ud.Hide();
                del.Hide();
                db.Hide();
                dp.Hide();
                sw.Hide();
                rep.Show();
            }
            else
            {
                rep.Dispose();
            }
        }
















    }
}
