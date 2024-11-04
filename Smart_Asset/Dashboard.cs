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

            CreateBarChart(panel4);
            //CreateScatterPlot(panel4);
            CreatePieChart(panel5);
            CreateAreaChart(panel7);
            CreateDiagonalLineChart(panel6);

        }


        private void CreateDiagonalLineChart(Panel targetPanel)
        {
            targetPanel.Controls.Clear();

            var plotView = new PlotView { Dock = DockStyle.Fill };

            var plotModel = new PlotModel
            {
                Title = "Diagonal Line Chart",
                TitleFontSize = 18,
                TitleColor = OxyColors.White, // Set title text color to white
                Background = OxyColors.Transparent
            };

            plotModel.Axes.Add(new LinearAxis
            {
                Position = AxisPosition.Bottom,
                Minimum = 0,
                Maximum = 5,
                Title = "Categories",
                AxislineColor = OxyColors.Cyan, // Set axis line color
                AxislineThickness = 2, // Set axis line thickness
                TextColor = OxyColors.White // Set axis text color to white
            });

            plotModel.Axes.Add(new LinearAxis
            {
                Position = AxisPosition.Left,
                Minimum = 0,
                Maximum = 100,
                Title = "Values",
                AxislineColor = OxyColors.Magenta, // Set axis line color
                AxislineThickness = 2, // Set axis line thickness
                TextColor = OxyColors.White // Set axis text color to white
            });

            var lineSeries = new LineSeries
            {
                Title = "Diagonal Line Series",
                Color = OxyColors.Coral,
                StrokeThickness = 2,
                MarkerType = MarkerType.Diamond,
                MarkerSize = 8,
                MarkerStroke = OxyColors.DarkSlateBlue,
                MarkerFill = OxyColors.Coral
            };

            lineSeries.Points.Add(new DataPoint(1, 25));
            lineSeries.Points.Add(new DataPoint(2, 60));
            lineSeries.Points.Add(new DataPoint(3, 45));
            lineSeries.Points.Add(new DataPoint(4, 80));

            plotModel.Series.Add(lineSeries);
            plotView.Model = plotModel;

            targetPanel.Controls.Add(plotView);
        }



        private void CreateBarChart(Panel targetPanel)
        {
            targetPanel.Controls.Clear();

            var plotView = new PlotView { Dock = DockStyle.Fill };

            var plotModel = new PlotModel
            {
                Title = "Colorful Bar Chart",
                TitleFontSize = 18,
                TitleColor = OxyColors.White, // Set title text color to white
                Background = OxyColors.Transparent
            };

            plotModel.Axes.Add(new CategoryAxis
            {
                Position = AxisPosition.Left,
                Key = "Categories",
                ItemsSource = new[] { "Category A", "Category B", "Category C", "Category D" },
                TextColor = OxyColors.White, // Set axis text color to white
                AxislineColor = OxyColors.Cyan, // Set axis line color
                AxislineThickness = 2 // Set axis line thickness
            });

            plotModel.Axes.Add(new LinearAxis
            {
                Position = AxisPosition.Bottom,
                Minimum = 0,
                Maximum = 100,
                Title = "Values",
                AxislineColor = OxyColors.Magenta, // Set axis line color
                AxislineThickness = 2, // Set axis line thickness
                TextColor = OxyColors.White // Set axis text color to white
            });

            var barSeries = new BarSeries
            {
                FillColor = OxyColors.SteelBlue,
                LabelPlacement = LabelPlacement.Inside,
                LabelFormatString = "{0:.0}",
                ItemsSource = new[]
                {
            new BarItem { Value = 25 },
            new BarItem { Value = 60 },
            new BarItem { Value = 45 },
            new BarItem { Value = 80 }
        }
            };

            plotModel.Series.Add(barSeries);
            plotView.Model = plotModel;

            targetPanel.Controls.Add(plotView);
        }


        private void CreateScatterPlot(Panel targetPanel)
        {
            targetPanel.Controls.Clear();

            var plotView = new PlotView { Dock = DockStyle.Fill };

            var plotModel = new PlotModel
            {
                Title = "Scatter Plot Example",
                TitleFontSize = 18,
                TitleColor = OxyColors.White, // Set title text color to white
                Background = OxyColors.Transparent
            };

            plotModel.Axes.Add(new LinearAxis
            {
                Position = AxisPosition.Bottom,
                Title = "X Axis",
                AxislineColor = OxyColors.Cyan, // Set axis line color
                AxislineThickness = 2, // Set axis line thickness
                TextColor = OxyColors.White // Set axis text color to white
            });

            plotModel.Axes.Add(new LinearAxis
            {
                Position = AxisPosition.Left,
                Title = "Y Axis",
                AxislineColor = OxyColors.Magenta, // Set axis line color
                AxislineThickness = 2, // Set axis line thickness
                TextColor = OxyColors.White // Set axis text color to white
            });

            var scatterSeries = new ScatterSeries
            {
                Title = "Data Points",
                MarkerType = MarkerType.Circle,
                MarkerSize = 7,
                MarkerFill = OxyColors.SeaGreen,
                MarkerStroke = OxyColors.DarkGreen,
                MarkerStrokeThickness = 1.5
            };

            scatterSeries.Points.Add(new ScatterPoint(1.0, 1.0));
            scatterSeries.Points.Add(new ScatterPoint(2.0, 3.0));
            scatterSeries.Points.Add(new ScatterPoint(3.0, 2.5));
            scatterSeries.Points.Add(new ScatterPoint(4.0, 5.0));
            scatterSeries.Points.Add(new ScatterPoint(5.0, 4.5));

            plotModel.Series.Add(scatterSeries);
            plotView.Model = plotModel;

            targetPanel.Controls.Add(plotView);
        }



        private void CreateAreaChart(Panel targetPanel)
        {
            targetPanel.Controls.Clear();

            var plotView = new PlotView { Dock = DockStyle.Fill };

            var plotModel = new PlotModel
            {
                Title = "Area Chart Example",
                TitleFontSize = 18,
                TitleColor = OxyColors.White, // Set title text color to white
                Background = OxyColors.Transparent
            };

            plotModel.Axes.Add(new LinearAxis
            {
                Position = AxisPosition.Bottom,
                Title = "X Axis",
                AxislineColor = OxyColors.Cyan, // Set axis line color
                AxislineThickness = 2, // Set axis line thickness
                TextColor = OxyColors.White // Set axis text color to white
            });

            plotModel.Axes.Add(new LinearAxis
            {
                Position = AxisPosition.Left,
                Title = "Y Axis",
                AxislineColor = OxyColors.Magenta, // Set axis line color
                AxislineThickness = 2, // Set axis line thickness
                TextColor = OxyColors.White // Set axis text color to white
            });

            var areaSeries = new AreaSeries
            {
                Title = "Data Series",
                Color = OxyColor.FromAColor(200, OxyColors.LightSeaGreen),
                StrokeThickness = 2,
                MarkerType = MarkerType.Triangle,
                MarkerSize = 6,
                MarkerFill = OxyColors.Teal,
                MarkerStroke = OxyColors.DarkSlateGray
            };

            areaSeries.Points.Add(new DataPoint(0, 0));
            areaSeries.Points.Add(new DataPoint(1, 2));
            areaSeries.Points.Add(new DataPoint(2, 5));
            areaSeries.Points.Add(new DataPoint(3, 3));
            areaSeries.Points.Add(new DataPoint(4, 6));

            plotModel.Series.Add(areaSeries);
            plotView.Model = plotModel;

            targetPanel.Controls.Add(plotView);
        }




        private void CreatePieChart(Panel targetPanel)
        {
            targetPanel.Controls.Clear();

            var plotView = new PlotView { Dock = DockStyle.Fill };

            var plotModel = new PlotModel
            {
                Title = "Colorful Pie Chart",
                TitleFontSize = 18,
                TitleColor = OxyColors.White, // Set title text color to white
                Background = OxyColors.Transparent
            };

            var pieSeries = new PieSeries
            {
                StrokeThickness = 2.0,
                AngleSpan = 360,
                StartAngle = 0
            };

            pieSeries.Slices.Add(new PieSlice("Category A", 40) { IsExploded = true, Fill = OxyColors.Crimson });
            pieSeries.Slices.Add(new PieSlice("Category B", 30) { IsExploded = true, Fill = OxyColors.MediumSeaGreen });
            pieSeries.Slices.Add(new PieSlice("Category C", 20) { IsExploded = false, Fill = OxyColors.DodgerBlue });
            pieSeries.Slices.Add(new PieSlice("Category D", 10) { IsExploded = false, Fill = OxyColors.Goldenrod });

            plotModel.Series.Add(pieSeries);
            plotView.Model = plotModel;

            targetPanel.Controls.Add(plotView);
        }




        private void Dashboard_Shown(object sender, EventArgs e)
        { 

        }
    }
}
