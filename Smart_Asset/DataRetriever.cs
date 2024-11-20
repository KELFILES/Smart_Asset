using MongoDB.Bson;
using OxyPlot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smart_Asset
{
    public static class DataRetriever
    {

        public static void SummarizeData(List<BsonDocument> allDocuments)
        {
            if (allDocuments == null || allDocuments.Count == 0)
            {
                //Console.WriteLine("No documents found.");
                return;
            }

            var currentDate = DateTime.Now;
            int currentYear = currentDate.Year;
            int currentMonth = currentDate.Month;




            // 1. Top 10 Working Asset Counts by Type (Excluding "Archive", "Disposed_Hardwares", and "Replacement")
            var filteredDocuments = allDocuments
                .Where(doc => doc.GetValue("CurrentLocation", "").AsString != "Archive" &&
                              doc.GetValue("CurrentLocation", "").AsString != "Disposed_Hardwares" &&
                              doc.GetValue("CurrentLocation", "").AsString != "Replacement");

            // Group by "Type" and count the occurrences
            var assetCounts = filteredDocuments
                .GroupBy(doc => doc.GetValue("Type", "").AsString)
                .Where(g => g.Count() > 0) // Exclude groups with zero count (safety check)
                .OrderByDescending(g => g.Count())
                .Take(10) // Limit to top 10 types
                .ToDictionary(g => g.Key, g => g.Count());

            // Display the counts in the console
            //Console.WriteLine("Top Working Asset Counts by Type (Excluding Archive, Disposed_Hardwares, and Replacement):");
            
            /*
            foreach (var type in assetCounts)
            {
                Console.WriteLine($"{type.Key}: {type.Value}");
            }
            */

            //Console.WriteLine(new string('-', 50));

            // Create the pie chart with the retrieved asset counts
            Graphs.CreatePieChart(Dashboard.staticRightGraphPanel, assetCounts);






            // 2. Top 5 Most Expensive Working Assets
            var topExpensiveAssets = allDocuments
                .Where(doc => doc.GetValue("CurrentLocation", "").AsString != "Archive" &&
                doc.GetValue("CurrentLocation", "").AsString != "Disposed_Hardwares" &&
                doc.GetValue("CurrentLocation", "").AsString != "Replacement")
                .OrderByDescending(doc => doc.GetValue("Cost", 0).ToDouble())
                .Take(5) // Limit to a maximum of 5 assets
                .Select(doc => new
                {
                    Type = doc.GetValue("Type", "").AsString,
                    Brand = doc.GetValue("Brand", "").AsString,
                    Model = doc.GetValue("Model", "").AsString,
                    Price = doc.GetValue("Cost", 0).ToDouble()
                })
                .ToList();

            // Set the console output encoding to UTF-8
            //Console.OutputEncoding = System.Text.Encoding.UTF8;

            // Console Output
            if (topExpensiveAssets.Count == 0)
            {
                //Console.WriteLine("No assets found.");
            }
            else
            {
                //Console.WriteLine("Top Most Expensive Assets (Type, Brand, Model, Price):");

                /*
                foreach (var asset in topExpensiveAssets)
                {
                    // Using the Peso sign (₱) for price formatting
                    Console.WriteLine($"Type: {asset.Type}, Brand: {asset.Brand}, Model: {asset.Model}, Price: \u20B1{asset.Price:N2}");
                }
                */

                //Console.WriteLine(new string('-', 50));
            }

            // Prepare the lists for categories and values
            List<string> categories = topExpensiveAssets
                .Select(asset => $"{asset.Type} - {asset.Brand} - {asset.Model}")
                .ToList();

            List<double> values = topExpensiveAssets
                .Select(asset => asset.Price)
                .ToList();

            // Reverse the order to make the top 1 appear at the top of the chart
            categories.Reverse();
            values.Reverse();

            // Define custom colors (flexible handling for fewer assets)
            List<OxyColor> colors = new List<OxyColor>
            {
                OxyColor.FromRgb(255, 128, 0),  // Orange
                OxyColor.FromRgb(0, 204, 102),  // Green
                OxyColor.FromRgb(51, 153, 255), // Blue
                OxyColor.FromRgb(204, 51, 255), // Purple
                OxyColor.FromRgb(255, 51, 51)   // Red
            };

            // Adjust the color list to match the number of assets
            colors = colors.Take(topExpensiveAssets.Count).ToList();
            colors.Reverse(); // Reverse colors to match the reversed data

            // Call the method to create the bar chart
            Graphs.CreateBarChart(Dashboard.staticLeftGraphPanel, categories, values, colors);




            // 3. Current Year Monthly Purchases Analysis (This year only up to the current month)
            //Console.WriteLine($"Monthly Asset Purchases Analysis for {currentYear}:");
            int[] monthlyPurchaseCounts = new int[12];

            // Iterate through all documents to count purchases for the current year
            foreach (var doc in allDocuments)
            {
                // Check if the document has a valid "PurchaseDate" and belongs to the current year
                if (doc.Contains("PurchaseDate") && DateTime.TryParse(doc.GetValue("PurchaseDate", "").AsString, out var purchaseDate))
                {
                    // Only count purchases from the current year
                    if (purchaseDate.Year == currentYear)
                    {
                        // Increment the count for the corresponding month (0-based index)
                        int monthIndex = purchaseDate.Month - 1;
                        if (monthIndex >= 0 && monthIndex < 12)
                        {
                            monthlyPurchaseCounts[monthIndex]++;
                        }
                    }
                }
            }

            /*
            // Display the monthly purchase counts for the current year (up to the current month)
            for (int month = 0; month < currentMonth; month++)
            {
                string monthName = new DateTime(currentYear, month + 1, 1).ToString("MMM");
                Console.WriteLine($"{monthName} Purchases: {monthlyPurchaseCounts[month]}");
            }
            Console.WriteLine(new string('-', 50));
            */


            // Call the method to create the area chart with the retrieved data
            Graphs.CreateAreaChart(Dashboard.staticCenterGraphPanel, monthlyPurchaseCounts, currentMonth);











            //FOR SHOWING ALL ASSETS
            //All Assets (with Disposed_Hardwares)
            int totalAllAssetsCount = allDocuments.Count(doc =>
                doc.GetValue("CurrentLocation", "").AsString != "Archive");
            //Console.WriteLine($"All Assets (Including Disposed_Hardwares): {totalAllAssetsCount}");
            //Console.WriteLine(new string('-', 50));
            // SET DASHBOARD TOTAL ASSETS
            Dashboard.totalAllAssets = totalAllAssetsCount;





            //FOR SHOWING WORKING ASSETS
            //Total Working Assets Count (Excluding "Archived", "Disposed_Hardwares" and "Replacement")
            int totalWorkingAssetsCount = allDocuments.Count(doc =>
                doc.GetValue("CurrentLocation", "").AsString != "Archive" &&
                doc.GetValue("CurrentLocation", "").AsString != "Disposed_Hardwares" &&
                doc.GetValue("CurrentLocation", "").AsString != "Replacement");
            //Console.WriteLine($"Total Working Assets Count (Excluding Archive and Disposed_Hardwares): {totalWorkingAssetsCount}");
            //Console.WriteLine(new string('-', 50));
            Dashboard.totalWorkingAssets = totalWorkingAssetsCount;





            //FOR SHOWING OTHER ASSETS
            //Count of Assets by CurrentLocation
            var predefinedLocations = new[] { "Cleaning", "Replacement", "Disposed_Hardwares", "Borrowed", "Reserved_Hardwares", "Archive" };
            //Console.WriteLine("Count of Assets by CurrentLocation:");

            // First, display counts for predefined locations
            foreach (var location in predefinedLocations)
            {
                int locationCount = allDocuments.Count(doc => doc.GetValue("CurrentLocation", "").AsString == location);
                //Console.WriteLine($"{location}: {locationCount}");

                // Update dashboard values for predefined locations
                switch (location)
                {
                    case "Cleaning":
                        Dashboard.totalCleaning = locationCount;
                        break;
                    case "Replacement":
                        Dashboard.totalReplaced = locationCount;
                        break;
                    case "Disposed_Hardwares":
                        Dashboard.totalDisposed = locationCount;
                        break;
                    case "Borrowed":
                        Dashboard.totalBorrowed = locationCount;
                        break;
                    case "Reserved_Hardwares":
                        Dashboard.totalReserved = locationCount;
                        break;
                    case "Archive":
                        Dashboard.totalArchive = locationCount;
                        break;
                }
            }

            // Get all unique CurrentLocation values excluding predefined locations
            var otherLocations = allDocuments
                .Select(doc => doc.GetValue("CurrentLocation", "").AsString)
                .Distinct()
                .Except(predefinedLocations)
                .ToList();

            // Display counts for other locations

            /*
            foreach (var location in otherLocations)
            {
                int locationCount = allDocuments.Count(doc => doc.GetValue("CurrentLocation", "").AsString == location);
                Console.WriteLine($"{location}: {locationCount}");
            }
            */

            //Console.WriteLine(new string('-', 50));
        }



    }
}
