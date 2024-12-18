﻿using OxyPlot.Axes;
using OxyPlot.Series;
using OxyPlot.WindowsForms;
using OxyPlot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OxyPlot.Legends;

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
                TitleColor = OxyColors.Black, // Set title text color to white
                Background = OxyColors.Transparent,
                TextColor = OxyColors.Black,
                
            };

            plotModel.Axes.Add(new LinearAxis
            {
                Position = AxisPosition.Bottom,
                Minimum = 0,
                Maximum = 5,
                Title = "Categories",
                AxislineColor = OxyColors.Cyan, // Set axis line color
                AxislineThickness = 2, // Set axis line thickness
                TextColor = OxyColors.Black // Set axis text color to white
            });

            plotModel.Axes.Add(new LinearAxis
            {
                Position = AxisPosition.Left,
                Minimum = 0,
                Maximum = 100,
                Title = "Values",
                AxislineColor = OxyColors.Magenta, // Set axis line color
                AxislineThickness = 2, // Set axis line thickness
                TextColor = OxyColors.Black // Set axis text color to white
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
                Title = "Top Expensive Working Assets",
                TitleFontSize = 20,
                TitleColor = OxyColors.Black,
                Background = OxyColors.White,
                TitlePadding = 40 // Adjust this value to manually center the title
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
                TextColor = OxyColors.Black,
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
                Maximum = values.Max() + 10,
                Title = "Price (₱)",
                AxislineColor = OxyColors.Magenta,
                AxislineThickness = 2,
                TextColor = OxyColors.Black,
                MajorGridlineColor = OxyColor.FromAColor(60, OxyColors.Black),
                MinorGridlineColor = OxyColor.FromAColor(30, OxyColors.Black),
                MajorGridlineStyle = LineStyle.Solid,
                MinorGridlineStyle = LineStyle.Dot
            });

            // Bar Series with dynamic colors
            var barSeries = new BarSeries
            {
                LabelPlacement = LabelPlacement.Inside,
                LabelFormatString = "₱{0:N2}", // Use Peso sign with two decimal places
                StrokeColor = OxyColors.Black,
                StrokeThickness = 1
            };

            // Use the provided colors or default to a repeating color pattern
            if (colors == null || colors.Count < values.Count)
            {
                colors = Enumerable.Repeat(OxyColors.SteelBlue, values.Count).ToList();
            }
            else
            {
                colors = colors.Take(values.Count).ToList();
            }

            // Add bars to the series
            for (int i = 0; i < values.Count; i++)
            {
                var barColor = colors[i];
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

            var plotView = new PlotView
            {
                Dock = DockStyle.Fill,
                Margin = new Padding(5) // Optional margin
            };

            var plotModel = new PlotModel
            {
                Title = "Scatter Plot Example",
                TitleFontSize = 18,
                TitleColor = OxyColors.Black, // Title color
                Background = OxyColors.Transparent
            };

            // Configure X-axis
            var xAxis = new LinearAxis
            {
                Position = AxisPosition.Bottom,
                Title = "X Axis",
                AxislineColor = OxyColors.Cyan,
                AxislineThickness = 2,
                TextColor = OxyColors.Black,
                Minimum = 0, // Leave extra space on the left
                Maximum = 6.5, // Extra space on the right
                AbsoluteMinimum = 0,
                AbsoluteMaximum = 6.5,
                MinimumPadding = 0,
                MaximumPadding = 0
            };

            // Configure Y-axis
            var yAxis = new LinearAxis
            {
                Position = AxisPosition.Left,
                Title = "Y Axis",
                AxislineColor = OxyColors.Magenta,
                AxislineThickness = 2,
                TextColor = OxyColors.Black,
                Minimum = 0, // Extra space at the bottom
                Maximum = 6.5, // Extra space at the top
                AbsoluteMinimum = 0,
                AbsoluteMaximum = 6.5,
                MinimumPadding = 0,
                MaximumPadding = 0
            };

            plotModel.Axes.Add(xAxis);
            plotModel.Axes.Add(yAxis);

            // Scatter series
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

            // Add plotView to the panel
            targetPanel.Controls.Add(plotView);
            targetPanel.Refresh();
        }



        public static void CreateAreaChart(Panel targetPanel, int[] monthlyPurchaseCounts, int currentMonth)
        {
            targetPanel.Controls.Clear();

            var plotView = new PlotView { Dock = DockStyle.Fill };

            var plotModel = new PlotModel
            {
                Title = $"Monthly Asset Purchases for {DateTime.Now.Year}",
                TitleFontSize = 18,
                TitleColor = OxyColors.Black,
                Background = OxyColors.Transparent
            };

            // Define the list of abbreviated month names (Jan, Feb, etc.)
            var monthNames = new[] { "Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec" };

            // X Axis (Category Axis for Months)
            plotModel.Axes.Add(new CategoryAxis
            {
                Position = AxisPosition.Bottom,
                Title = "Month",
                AxislineColor = OxyColors.Cyan,
                AxislineThickness = 2,
                TextColor = OxyColors.Black,
                ItemsSource = monthNames.Take(currentMonth).ToList(),
                Minimum = -0.5, // Add extra space before the first month
                Maximum = currentMonth - 0.5, // Add extra space after the last month
                IsPanEnabled = false, // Disable panning
                IsZoomEnabled = false // Disable zooming
            });

            // Y Axis (Linear Axis for Purchase Counts)
            plotModel.Axes.Add(new LinearAxis
            {
                Position = AxisPosition.Left,
                Title = "Purchases",
                AxislineColor = OxyColors.Magenta,
                AxislineThickness = 2,
                TextColor = OxyColors.Black,
                Minimum = 0,
                Maximum = monthlyPurchaseCounts.Max() + 10, // Add extra space above the maximum value
                MinimumPadding = 0.1,
                MaximumPadding = 0.1
            });

            // Area Series for Monthly Purchases Data
            var areaSeries = new AreaSeries
            {
                Title = "Monthly Purchases",
                Color = OxyColor.FromAColor(200, OxyColors.LightSeaGreen),
                StrokeThickness = 2,
                MarkerType = MarkerType.Circle,
                MarkerSize = 6,
                MarkerFill = OxyColors.Teal,
                MarkerStroke = OxyColors.DarkSlateGray
            };

            // Add data points to the area series
            for (int month = 0; month < currentMonth; month++)
            {
                areaSeries.Points.Add(new DataPoint(month, monthlyPurchaseCounts[month]));
            }

            // Add the area series to the plot model
            plotModel.Series.Add(areaSeries);
            plotView.Model = plotModel;

            // Add the plot view to the target panel
            targetPanel.Controls.Add(plotView);
        }


        public static void CreatePieChart(Panel targetPanel, Dictionary<string, int> assetCounts)
        {
            targetPanel.Controls.Clear();

            var plotView = new PlotView { Dock = DockStyle.Fill };

            // Sort and take only the top 10 asset types
            var sortedAssetCounts = assetCounts
                .OrderByDescending(kv => kv.Value)
                .Take(10)
                .ToList();

            int sliceCount = sortedAssetCounts.Count;
            string title = $"Top Types of Working Assets";

            var plotModel = new PlotModel
            {
                Title = title,
                TitleFontSize = 18,
                TitleColor = OxyColors.Black,
                TextColor = OxyColors.Black,
                Background = OxyColors.Transparent
            };

            var pieSeries = new PieSeries
            {
                StrokeThickness = 2.0,
                AngleSpan = 360,
                StartAngle = 0,
                FontSize = 14,
                ExplodedDistance = 0.05, // Slightly explode slices for better separation
                TextColor = OxyColors.Black,
                InsideLabelFormat = null, // Completely remove inside labels
                OutsideLabelFormat = "{0}: {1}", // Only show outside labels
            };

            // Define colors for the slices
            List<OxyColor> colors = new List<OxyColor>
    {
        OxyColors.Crimson,
        OxyColors.MediumSeaGreen,
        OxyColors.DodgerBlue,
        OxyColors.Goldenrod,
        OxyColors.Purple,
        OxyColors.OrangeRed,
        OxyColors.Teal,
        OxyColors.Violet,
        OxyColors.SkyBlue,
        OxyColors.DarkCyan
    };

            // Add slices for each asset type
            for (int i = 0; i < sliceCount; i++)
            {
                var assetType = sortedAssetCounts[i].Key;
                var count = sortedAssetCounts[i].Value;

                pieSeries.Slices.Add(new PieSlice(assetType, count)
                {
                    IsExploded = false,
                    Fill = colors[i % colors.Count]
                });
            }

            plotModel.Legends.Add(new Legend
            {
                LegendPosition = LegendPosition.RightTop,
                LegendTextColor = OxyColors.Black,
                LegendFontSize = 14
            });

            plotModel.Series.Add(pieSeries);
            plotView.Model = plotModel;

            targetPanel.Controls.Add(plotView);
        }


    }
}
