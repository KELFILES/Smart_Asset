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
    public partial class FrontPage_Final : Form
    {
        public FrontPage_Final()
        {
            InitializeComponent();
            fileMaintenance_SubMenuPanel.Visible = false;
        }


        private void customizeDesign()
        {
            fileMaintenance_SubMenuPanel.Visible = false;
        }

        private void hideSubMenu()
        {
            if (fileMaintenance_SubMenuPanel.Visible == true)
            {
                fileMaintenance_SubMenuPanel.Visible = false;
            }
        }

        private void showSubMenu(Panel subMenu)
        {
            if (subMenu.Visible == false)
            {
                hideSubMenu();
                subMenu.Visible = true;
            }
            else
            {
                subMenu.Visible = false;
            }
        }

        #region File Maintenance

        private void fileMaintenance_Btn_Click(object sender, EventArgs e)
        {
            showSubMenu(fileMaintenance_SubMenuPanel);
            Console.WriteLine("FILEMENU CLICKED");
        }

        private void create_Btn_Click(object sender, EventArgs e)
        {
            hideSubMenu();
            Console.WriteLine("CREATE CLICKED");
        }

        private void read_Btn_Click(object sender, EventArgs e)
        {
            hideSubMenu();
            Console.WriteLine("READ CLICKED");
        }

        private void update_Btn_Click(object sender, EventArgs e)
        {
            hideSubMenu();
            Console.WriteLine("UPDATE CLICKED");
        }

        private void transfer_Btn_Click(object sender, EventArgs e)
        {
            hideSubMenu();
            Console.WriteLine("TRANSFER CLICKED");
        }

        #endregion

        private void dashboard_Btn_Click(object sender, EventArgs e)
        {
            hideSubMenu();
            Console.WriteLine("DASHBOARD CLICKED");
        }

        private void deployment_Btn_Click(object sender, EventArgs e)
        {
            hideSubMenu();
            Console.WriteLine("DEPLOYMENT CLICKED");
        }

        private void swap_Btn_Click(object sender, EventArgs e)
        {
            hideSubMenu();
            Console.WriteLine("SWAP CLICKED");
        }

        private void repairing_Btn_Click(object sender, EventArgs e)
        {
            hideSubMenu();
            Console.WriteLine("REPAIRING CLICKED");
        }

        private void cleaning_Btn_Click(object sender, EventArgs e)
        {
            hideSubMenu();
            Console.WriteLine("CLEANING CLICKED");
        }

        private void disposed_Btn_Click(object sender, EventArgs e)
        {
            hideSubMenu();
            Console.WriteLine("DISPOSED CLICKED");
        }

        private void recyleBin_Btn_Click(object sender, EventArgs e)
        {
            hideSubMenu();
            Console.WriteLine("RECYCLE CLICKED");
        }

        private void borrowedItems_Btn_Click(object sender, EventArgs e)
        {
            hideSubMenu();
            Console.WriteLine("BORROWED CLICKED");
        }

        private void artificialIntelligence_Btn_Click(object sender, EventArgs e)
        {
            hideSubMenu();
            Console.WriteLine("AI CLICKED");
        }

        private void manageRoles_Btn_Click(object sender, EventArgs e)
        {
            hideSubMenu();
            Console.WriteLine("MANAGE ROLES CLICKED");
        }

        private void createReport_Btn_Click(object sender, EventArgs e)
        {
            hideSubMenu();
            Console.WriteLine("CREATE REPORT CLICKED");
        }

        private void logout_Btn_Click(object sender, EventArgs e)
        {
            hideSubMenu();
            Console.WriteLine("LOGOUT CLICKED");
        }

    }
}
