using OxyPlot.Series;
using OxyPlot;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OxyPlot.WindowsForms;
using OxyPlot.Axes;
using Microsoft.Office.Interop.Word;
using Microsoft.Office.Interop.Outlook;
using MigraDoc.DocumentObjectModel.Internals;
using MigraDoc.DocumentObjectModel;


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

        private async void Dashboard_Load(object sender, EventArgs e)
        {
            UIAdjustment();


            //CreateScatterPlot(panel4);
            //CreateDiagonalLineChart(panel6);

            //LOAD DATABASE DATA
            var retrievedDbData = await MyDbMethods.ReadAllDatabaseInBSON("SmartAssetDb");
            DataRetriever.SummarizeData(retrievedDbData);


            loadAllData();

            //MyOtherMethods.ShowCalendarAtCenter(panel3);

        }

        void UIAdjustment()
        {
            //MyOtherMethods.CenterInForm(flowLayoutPanel1, this);

            List<Panel> panels = new List<Panel> { panel9, panel21, panel19, panel17, panel15, panel14, panel10, panel12 };
            MyOtherMethods.CenterAlignPanelsHorizontally(panel16, panels);

            List<Panel> panels_Graph = new List<Panel> { leftGraph_Pnl, centerGraph_Pnl, rightGraph_Pnl};
            MyOtherMethods.CenterAlignPanelsHorizontally(panel2, panels_Graph);

            MyOtherMethods.FitMonthCalendarToPanel(panel3, monthCalendar1);
        }

        private void Dashboard_SizeChanged(object sender, EventArgs e)
        {
            List<Panel> panels = new List<Panel> { panel9, panel21, panel19, panel17, panel15, panel14, panel10, panel12 };
            MyOtherMethods.CenterAlignPanelsHorizontally(panel16, panels);

            List<Panel> panels_Graph = new List<Panel> { leftGraph_Pnl, centerGraph_Pnl, rightGraph_Pnl };
            MyOtherMethods.CenterAlignPanelsHorizontally(panel2, panels_Graph);
        }


        //STATIC FIELDS
        public static int totalAllAssets;
        public static int totalWorkingAssets;
        public static int totalCleaning;
        public static int totalReplaced;
        public static int totalDisposed;
        public static int totalBorrowed;
        public static int totalReserved;
        public static int totalArchived;



        //LOAD ALL DATA
        public void loadAllData()
        {
            // 0. All Assets (with Disposed_Hardwares)
            box0Title_Lbl.Text = "All Assets";
            MyOtherMethods.CenterInPanel(box0Title_Lbl, panel19);
            box0Title_Lbl.Visible = true;
            box0_Lbl.Text = Convert.ToString(totalAllAssets);
            MyOtherMethods.CenterInPanel(box0_Lbl, panel19);
            box0_Lbl.Visible = true;

            // 1. Working Assets (Excluding Archived and Disposed_Hardwares)
            box1Title_Lbl.Text = "Working Assets";
            MyOtherMethods.CenterInPanel(box1Title_Lbl, panel21);
            box1Title_Lbl.Visible = true;
            box1_Lbl.Text = Convert.ToString(totalWorkingAssets);
            MyOtherMethods.CenterInPanel(box1_Lbl, panel21);
            box1_Lbl.Visible = true;

            // 2. Cleaning
            box2Title_Lbl.Text = "Cleaning";
            MyOtherMethods.CenterInPanel(box2Title_Lbl, panel19);
            box2Title_Lbl.Visible = true;
            box2_Lbl.Text = Convert.ToString(totalCleaning);
            MyOtherMethods.CenterInPanel(box2_Lbl, panel19);
            box2_Lbl.Visible = true;

            // 3. Replaced
            box3Title_Lbl.Text = "Replaced";
            MyOtherMethods.CenterInPanel(box3Title_Lbl, panel17);
            box3Title_Lbl.Visible = true;
            box3_Lbl.Text = Convert.ToString(totalReplaced);
            MyOtherMethods.CenterInPanel(box3_Lbl, panel17);
            box3_Lbl.Visible = true;

            // 4. Disposed Hardwares
            box4Title_Lbl.Text = "Disposed";
            MyOtherMethods.CenterInPanel(box4Title_Lbl, panel15);
            box4Title_Lbl.Visible = true;
            box4_Lbl.Text = Convert.ToString(totalDisposed);
            MyOtherMethods.CenterInPanel(box4_Lbl, panel15);
            box4_Lbl.Visible = true;

            // 5. Borrowed
            box5Title_Lbl.Text = "Borrowed";
            MyOtherMethods.CenterInPanel(box5Title_Lbl, panel14);
            box5Title_Lbl.Visible = true;
            box5_Lbl.Text = Convert.ToString(totalBorrowed);
            MyOtherMethods.CenterInPanel(box5_Lbl, panel14);
            box5_Lbl.Visible = true;

            // 6. Reserved Hardwares
            box6Title_Lbl.Text = "Reserved";
            MyOtherMethods.CenterInPanel(box6Title_Lbl, panel10);
            box6Title_Lbl.Visible = true;
            box6_Lbl.Text = Convert.ToString(totalReserved);
            MyOtherMethods.CenterInPanel(box6_Lbl, panel10);
            box6_Lbl.Visible = true;

            // 7. Archived
            box7Title_Lbl.Text = "Archived";
            MyOtherMethods.CenterInPanel(box7Title_Lbl, panel12);
            box7Title_Lbl.Visible = true;
            box7_Lbl.Text = Convert.ToString(totalArchived);
            MyOtherMethods.CenterInPanel(box7_Lbl, panel12);
            box7_Lbl.Visible = true;



            //VALUES FOR CreateBarChart
            List<string> categories = new List<string> { "Category A", "Category B", "Category C", "Category D", "Category E" };
            List<double> values = new List<double> { 25, 60, 45, 80, 55 };
            List<OxyColor> colors = new List<OxyColor>
            {
                OxyColor.FromRgb(255, 128, 0),  // Orange
                OxyColor.FromRgb(0, 204, 102),  // Green
                OxyColor.FromRgb(51, 153, 255), // Blue
                OxyColor.FromRgb(204, 51, 255), // Purple
                OxyColor.FromRgb(255, 51, 51)   // Red
            };
            Graphs.CreateBarChart(leftGraph_Pnl, categories, values, colors);




            Graphs.CreatePieChart(rightGraph_Pnl);
            Graphs.CreateAreaChart(centerGraph_Pnl);

        }


        private void Dashboard_Shown(object sender, EventArgs e)
        {

        }





    }
}
