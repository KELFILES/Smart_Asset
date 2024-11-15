using OxyPlot.Axes;
using OxyPlot.Series;
using OxyPlot.WindowsForms;
using OxyPlot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smart_Asset
{
    public static class Graphs
    {
        public static void CreateDiagonalLineChart(Panel targetPanel)
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

        public static void CreateBarChart(Panel targetPanel, List<string> categories, List<double> values, List<OxyColor> colors = null)
        {
            targetPanel.Controls.Clear();

            var plotView = new PlotView { Dock = DockStyle.Fill };

            var plotModel = new PlotModel
            {
                Title = "Dynamic Colorful Bar Chart",
                TitleFontSize = 20,
                TitleColor = OxyColors.White,
                Background = OxyColors.Black
            };

            // Ensure the number of categories and values match
            if (categories.Count != values.Count)
            {
                MessageBox.Show("The number of categories must match the number of values.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Category Axis (Y Axis)
            plotModel.Axes.Add(new CategoryAxis
            {
                Position = AxisPosition.Left,
                Key = "Categories",
                ItemsSource = categories,
                TextColor = OxyColors.White,
                AxislineColor = OxyColors.Cyan,
                AxislineThickness = 2,
                MajorTickSize = 0,
                MinorTickSize = 0
            });

            // Value Axis (X Axis)
            plotModel.Axes.Add(new LinearAxis
            {
                Position = AxisPosition.Bottom,
                Minimum = 0,
                Maximum = values.Max() + 10, // Set maximum based on the highest value
                Title = "Values",
                AxislineColor = OxyColors.Magenta,
                AxislineThickness = 2,
                TextColor = OxyColors.White,
                MajorGridlineColor = OxyColor.FromAColor(60, OxyColors.White),
                MinorGridlineColor = OxyColor.FromAColor(30, OxyColors.White),
                MajorGridlineStyle = LineStyle.Solid,
                MinorGridlineStyle = LineStyle.Dot
            });

            // Bar Series with dynamic colors
            var barSeries = new BarSeries
            {
                LabelPlacement = LabelPlacement.Inside,
                LabelFormatString = "{0:.0}",
                StrokeColor = OxyColors.White,
                StrokeThickness = 1
            };

            // Default colors if none are provided
            if (colors == null || colors.Count < values.Count)
            {
                colors = Enumerable.Repeat(OxyColors.SteelBlue, values.Count).ToList();
            }

            // Add bars to the series
            for (int i = 0; i < values.Count; i++)
            {
                var barColor = i < colors.Count ? colors[i] : OxyColors.SteelBlue;
                barSeries.Items.Add(new BarItem { Value = values[i], Color = barColor });
            }

            plotModel.Series.Add(barSeries);
            plotView.Model = plotModel;

            // Add the plot view to the target panel
            targetPanel.Controls.Add(plotView);
        }


        public static void CreateScatterPlot(Panel targetPanel)
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



        public static void CreateAreaChart(Panel targetPanel)
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




        public static void CreatePieChart(Panel targetPanel)
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
    }
}
