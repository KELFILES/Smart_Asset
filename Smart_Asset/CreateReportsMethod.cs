using MongoDB.Bson;
using OxyPlot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smart_Asset
{
    public static class CreateReportsMethod
    {

        public static void ShowReports(List<BsonDocument> allDocuments, System.Windows.Forms.TextBox tbName)
        {
            if (allDocuments == null || allDocuments.Count == 0)
            {
                tbName.AppendText("No documents found.\n\n");
                return;
            }

            var reportBuilder = new StringBuilder();

            // Define the Philippine Time Zone
            TimeZoneInfo philippineTimeZone = TimeZoneInfo.FindSystemTimeZoneById("Asia/Manila");

            // Convert the current time to Philippine Time
            DateTime philippineTime = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, philippineTimeZone);

            // Add report title and timestamp
            reportBuilder.AppendLine("=== Asset Management Report ===");
            reportBuilder.AppendLine($"Generated On: {philippineTime:dddd, MMMM dd, yyyy hh:mm:ss tt}"); // 12-hour format with AM/PM
            reportBuilder.AppendLine();

            // 1. All Assets (with Disposed_Hardwares)
            int totalAllAssetsCount = allDocuments.Count(doc =>
                doc.GetValue("CurrentLocation", "").AsString != "Archive");
            reportBuilder.AppendLine($"1. Total Assets (Including Disposed_Hardwares): {totalAllAssetsCount}");
            Dashboard.totalAllAssets = totalAllAssetsCount;
            reportBuilder.AppendLine();

            // 2. Total Working Assets Count
            int totalAssetsCount = allDocuments.Count(doc =>
                doc.GetValue("CurrentLocation", "").AsString != "Archive" &&
                doc.GetValue("CurrentLocation", "").AsString != "Disposed_Hardwares" &&
                doc.GetValue("CurrentLocation", "").AsString != "Replacement");
            reportBuilder.AppendLine($"2. Total Working Assets (Excluding Disposed_Hardwares, Archive and Replacement): {totalAssetsCount}");
            Dashboard.totalWorkingAssets = totalAssetsCount;
            reportBuilder.AppendLine();

            // 3. Location-Based Asset Distribution
            reportBuilder.AppendLine("3. Location-Based Asset Distribution:");
            var predefinedLocations = new[] { "Cleaning", "Replacement", "Disposed_Hardwares", "Borrowed", "Reserved_Hardwares", "Archive" };

            foreach (var location in predefinedLocations)
            {
                int locationCount = allDocuments.Count(doc => doc.GetValue("CurrentLocation", "").AsString == location);
                reportBuilder.AppendLine($"   - {location}: {locationCount}");
            }

            var otherLocations = allDocuments
                .Select(doc => doc.GetValue("CurrentLocation", "").AsString)
                .Distinct()
                .Except(predefinedLocations)
                .ToList();

            foreach (var location in otherLocations)
            {
                int locationCount = allDocuments.Count(doc => doc.GetValue("CurrentLocation", "").AsString == location);
                reportBuilder.AppendLine($"   - {location}: {locationCount}");
            }
            reportBuilder.AppendLine();

            // 4.Purchased Assets Count by Year (Excluding Archive)
            reportBuilder.AppendLine("4. Purchased Assets Count by Year (Excluding Archive):");

            // Filter valid PurchaseDates, exclude "Archive", and group by year
            var assetsByYear = allDocuments
                .Where(doc => doc.GetValue("CurrentLocation", "").AsString != "Archive") // Exclude "Archive"
                .Where(doc => DateTime.TryParse(doc.GetValue("PurchaseDate", "").AsString, out _)) // Only valid dates
                .GroupBy(doc => DateTime.Parse(doc.GetValue("PurchaseDate", "").AsString).Year)   // Group by year
                .OrderBy(g => g.Key)
                .ToDictionary(g => g.Key, g => g.Count()); // Year and count in a dictionary

            // Calculate cumulative totals
            int cumulativeTotal = 0;
            foreach (var year in assetsByYear.Keys.OrderBy(y => y)) // Ensure chronological order
            {
                cumulativeTotal += assetsByYear[year];
                reportBuilder.AppendLine($"   - {year}: {cumulativeTotal}");
            }

            reportBuilder.AppendLine();

            // 5. Current Year Monthly Purchases Analysis
            reportBuilder.AppendLine("5. Monthly Asset Purchases (Current Year):");
            int[] monthlyPurchaseCounts = new int[12];
            int currentYear = DateTime.Now.Year;
            int currentMonth = DateTime.Now.Month;

            // Count purchases by month for the current year
            foreach (var doc in allDocuments)
            {
                if (doc.Contains("PurchaseDate") && DateTime.TryParse(doc.GetValue("PurchaseDate", "").AsString, out var purchaseDate))
                {
                    if (purchaseDate.Year == currentYear)
                    {
                        int monthIndex = purchaseDate.Month - 1;
                        if (monthIndex >= 0 && monthIndex < 12)
                        {
                            monthlyPurchaseCounts[monthIndex]++;
                        }
                    }
                }
            }

            // Display monthly purchases
            int yearlyTotal = 0;
            for (int month = 0; month < currentMonth; month++)
            {
                string monthName = new DateTime(currentYear, month + 1, 1).ToString("MMMM");
                reportBuilder.AppendLine($"   - {monthName}: {monthlyPurchaseCounts[month]}");
                yearlyTotal += monthlyPurchaseCounts[month]; // Accumulate total
            }

            // Display the total purchases for the current year
            reportBuilder.AppendLine($"   - Total Purchases in {currentYear}: {yearlyTotal}");
            reportBuilder.AppendLine();




            // 6. Top 10 Brands Used
            reportBuilder.AppendLine("6. Top 10 Brands Used:");
            var topBrands = allDocuments
                .Where(doc => doc.GetValue("CurrentLocation", "").AsString != "Archive")
                .Where(doc => !string.IsNullOrEmpty(doc.GetValue("Brand", "").AsString))
                .GroupBy(doc => doc.GetValue("Brand", "").AsString)
                .OrderByDescending(g => g.Count())
                .Take(10);

            foreach (var brand in topBrands)
            {
                reportBuilder.AppendLine($"   - {brand.Key}: {brand.Count()}");
            }
            reportBuilder.AppendLine();

            // 7. Top 5 Most Expensive Working Assets
            reportBuilder.AppendLine("7. Top 5 Most Expensive Working Assets:");
            var topExpensiveAssets = allDocuments
                .Where(doc => doc.GetValue("CurrentLocation", "").AsString != "Archive" &&
                doc.GetValue("CurrentLocation", "").AsString != "Disposed_Hardwares" &&
                doc.GetValue("CurrentLocation", "").AsString != "Replacement")
                .OrderByDescending(doc => doc.GetValue("Cost", 0).ToDouble())
                .Take(5)
                .Select(doc => new
                {
                    Type = doc.GetValue("Type", "").AsString,
                    Brand = doc.GetValue("Brand", "").AsString,
                    Model = doc.GetValue("Model", "").AsString,
                    Price = doc.GetValue("Cost", 0).ToDouble()
                });

            foreach (var asset in topExpensiveAssets)
            {
                reportBuilder.AppendLine($"   - Type: {asset.Type}, Brand: {asset.Brand}, Model: {asset.Model}, Price: ₱{asset.Price:N2}");
            }
            reportBuilder.AppendLine();







            // 8. Assets Older Than or Equal to 5 Years
            reportBuilder.AppendLine("8. Assets Older Than or Equal to 5 Years:");

            // Initialize counter for assets >= 5 years
            int assetsOverOrEqual5Years = 0;

            foreach (var doc in allDocuments)
            {
                // Validate and parse the PurchaseDate
                if (doc.Contains("PurchaseDate") && DateTime.TryParse(doc.GetValue("PurchaseDate", "").AsString, out var purchaseDate))
                {
                    // Check if the asset is >= 5 years old
                    if ((DateTime.Now - purchaseDate).TotalDays >= 5 * 365.25) // Leap year adjustment
                    {
                        assetsOverOrEqual5Years++;
                    }
                }
            }

            // Append result to the report
            reportBuilder.AppendLine($"   - Total Assets Older Than or Equal to 5 Years: {assetsOverOrEqual5Years}");
            reportBuilder.AppendLine();


            // 9. Age Distribution of Working Assets
            reportBuilder.AppendLine("9. Age Distribution of Working Assets:");
            var ageDistribution = allDocuments
                .Where(doc =>
                    doc.GetValue("CurrentLocation", "").AsString != "Archive" &&
                    doc.GetValue("CurrentLocation", "").AsString != "Disposed_Hardwares" &&
                    doc.GetValue("CurrentLocation", "").AsString != "Replacement" &&
                    DateTime.TryParse(doc.GetValue("PurchaseDate", "").AsString, out _)) // Ensure valid dates
                .Select(doc =>
                {
                    DateTime purchaseDate;
                    if (DateTime.TryParse(doc.GetValue("PurchaseDate", "").AsString, out purchaseDate))
                    {
                        return (DateTime.Now - purchaseDate).TotalDays / 365.25; // Calculate age in years
                    }
                    return -1; // For invalid dates, return a placeholder
                })
                .Where(age => age >= 0) // Exclude invalid entries
                .GroupBy(age =>
                {
                    if (age < 1) return "<1 year";
                    else if (age < 3) return "1-3 years";
                    else if (age < 5) return "3-5 years";
                    else return "5+ years";
                })
                .OrderByDescending(g => g.Key);

            foreach (var ageGroup in ageDistribution)
            {
                reportBuilder.AppendLine($"   - {ageGroup.Key}: {ageGroup.Count()}");
            }
            reportBuilder.AppendLine();





            // 10. Top 10 Types of Working Assets
            reportBuilder.AppendLine("10. Top 10 Types of Working Assets:");
            var mostCommonTypes = allDocuments
                .Where(doc =>
                    doc.GetValue("CurrentLocation", "").AsString != "Archive" &&
                    doc.GetValue("CurrentLocation", "").AsString != "Disposed_Hardwares" &&
                    doc.GetValue("CurrentLocation", "").AsString != "Replacement" &&
                    !string.IsNullOrEmpty(doc.GetValue("Type", "").AsString)) // Ensure valid Type values
                .GroupBy(doc => doc.GetValue("Type", "").AsString) // Group by Type
                .OrderByDescending(g => g.Count()) // Order by descending count
                .Take(10); // Limit to the top 10 types

            foreach (var typeGroup in mostCommonTypes)
            {
                reportBuilder.AppendLine($"   - {typeGroup.Key}: {typeGroup.Count()}");
            }
            reportBuilder.AppendLine();







            










            // Append a footer
            reportBuilder.AppendLine("=== End of Report ===");

            // Display the report in the TextBox
            tbName.Text = reportBuilder.ToString();
        }









    }
}
