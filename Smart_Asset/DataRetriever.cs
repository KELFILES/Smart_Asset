using MongoDB.Bson;
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
                Console.WriteLine("No documents found.");
                return;
            }

            var currentDate = DateTime.Now;
            int currentYear = currentDate.Year;
            int currentMonth = currentDate.Month;


            // 0. All Assets (with Disposed_Hardwares)
            int totalAllAssetsCount = allDocuments.Count(doc =>
                doc.GetValue("CurrentLocation", "").AsString != "Archive");
            Console.WriteLine($"All Assets (with Disposed_Hardwares): {totalAllAssetsCount}");
            Console.WriteLine(new string('-', 50));

            // SET DASHBOARD TOTAL ASSETS
            Dashboard.totalAllAssets = totalAllAssetsCount;


            // 1. Total Assets Count (Excluding "Archived" and "Disposed_Hardwares")
            int totalAssetsCount = allDocuments.Count(doc =>
                doc.GetValue("CurrentLocation", "").AsString != "Archive" &&
                doc.GetValue("CurrentLocation", "").AsString != "Disposed_Hardwares" &&
                doc.GetValue("CurrentLocation", "").AsString != "Replacement");
            Console.WriteLine($"Total Assets Count (Excluding Archived and Disposed_Hardwares): {totalAssetsCount}");
            Console.WriteLine(new string('-', 50));

            // SET DASHBOARD TOTAL ASSETS
            Dashboard.totalWorkingAssets = totalAssetsCount;

            // 2. Count of Assets by CurrentLocation
            var locations = new[] { "Cleaning", "Replacement", "Disposed_Hardwares", "Borrowed", "Reserved_Hardwares", "Archive" };
            Console.WriteLine("Count of Assets by CurrentLocation:");
            foreach (var location in locations)
            {
                int locationCount = allDocuments.Count(doc => doc.GetValue("CurrentLocation", "").AsString == location);
                Console.WriteLine($"{location}: {locationCount}");

                if (location.Equals("Cleaning"))
                {
                    Dashboard.totalCleaning = locationCount;
                }

                //This is Replaced 
                if (location.Equals("Replacement"))
                {
                    Dashboard.totalReplaced = locationCount;
                }

                if (location.Equals("Disposed_Hardwares"))
                {
                    Dashboard.totalDisposed = locationCount;
                }

                if(location.Equals("Borrowed"))
                {
                    Dashboard.totalBorrowed = locationCount;
                }

                if (location.Equals("Reserved_Hardwares"))
                {
                    Dashboard.totalReserved = locationCount;
                }

                if (location.Equals("Archive"))
                {
                    Dashboard.totalArchive = locationCount;
                }

            }
            Console.WriteLine(new string('-', 50));



            // 3. Total Assets by Year
            var assetsByYear = allDocuments
                .Where(doc => doc.GetValue("CurrentLocation", "").AsString != "Archived")
                .Where(doc => DateTime.TryParse(doc.GetValue("PurchaseDate", "").AsString, out _))
                .GroupBy(doc => DateTime.Parse(doc.GetValue("PurchaseDate", "").AsString).Year)
                .OrderBy(g => g.Key);

            Console.WriteLine("Total Assets by Year:");
            foreach (var yearGroup in assetsByYear)
            {
                Console.WriteLine($"Total Assets of {yearGroup.Key}: {yearGroup.Count()}");
            }
            Console.WriteLine(new string('-', 50));

            // 4. Monthly Purchases Analysis
            Console.WriteLine("Monthly Purchases Analysis:");
            for (int month = 1; month <= currentMonth; month++)
            {
                int monthlyPurchases = allDocuments.Count(doc =>
                    doc.GetValue("CurrentLocation", "").AsString != "Archived" &&
                    DateTime.TryParse(doc.GetValue("PurchaseDate", "").AsString, out var date) &&
                    date.Year == currentYear && date.Month == month);

                string monthName = new DateTime(currentYear, month, 1).ToString("MMMM");
                Console.WriteLine($"{monthName} Purchases: {monthlyPurchases}");
            }
            Console.WriteLine(new string('-', 50));

            // 5. Top 3 Brands Used
            var topBrands = allDocuments
                .Where(doc => doc.GetValue("CurrentLocation", "").AsString != "Archived")
                .Where(doc => !string.IsNullOrEmpty(doc.GetValue("Brand", "").AsString))
                .GroupBy(doc => doc.GetValue("Brand", "").AsString)
                .OrderByDescending(g => g.Count())
                .Take(3);

            Console.WriteLine("Top 3 Brands Used:");
            foreach (var brand in topBrands)
            {
                Console.WriteLine($"{brand.Key}: {brand.Count()}");
            }
            Console.WriteLine(new string('-', 50));

            // 6. Most Common Asset Types
            var assetTypes = allDocuments
                .Where(doc => doc.GetValue("CurrentLocation", "").AsString != "Archived")
                .GroupBy(doc => doc.GetValue("Type", "").AsString)
                .OrderByDescending(g => g.Count())
                .Take(3);

            Console.WriteLine("Most Common Asset Types:");
            foreach (var type in assetTypes)
            {
                Console.WriteLine($"{type.Key}: {type.Count()}");
            }
            Console.WriteLine(new string('-', 50));

            // 7. Asset Counts by Type
            var assetsByType = allDocuments
                .Where(doc => doc.GetValue("CurrentLocation", "").AsString != "Archived")
                .GroupBy(doc => doc.GetValue("Type", "").AsString);

            Console.WriteLine("Asset Counts by Type:");
            foreach (var type in assetsByType)
            {
                Console.WriteLine($"{type.Key}: {type.Count()}");
            }
            Console.WriteLine(new string('-', 50));

            // 8. Asset Counts per Supplier
            var assetsPerSupplier = allDocuments
                .Where(doc => doc.GetValue("CurrentLocation", "").AsString != "Archived")
                .GroupBy(doc => doc.GetValue("Supplier", "").AsString);

            Console.WriteLine("Assets Counts per Supplier:");
            foreach (var supplier in assetsPerSupplier)
            {
                Console.WriteLine($"{supplier.Key}: {supplier.Count()}");
            }
            Console.WriteLine(new string('-', 50));

            // 9. Top 5 Most Expensive Assets (Include Price)
            var top5ExpensiveAssets = allDocuments
                .Where(doc => doc.GetValue("CurrentLocation", "").AsString != "Archived")
                .OrderByDescending(doc => doc.GetValue("Cost", 0).ToDouble())
                .Take(5)
                .Select(doc => new
                {
                    Type = doc.GetValue("Type", "").AsString,
                    Brand = doc.GetValue("Brand", "").AsString,
                    Model = doc.GetValue("Model", "").AsString,
                    Price = doc.GetValue("Cost", 0).ToDouble()
                });

            Console.WriteLine("Top 5 Most Expensive Assets (Type, Brand, Model, Price):");
            foreach (var asset in top5ExpensiveAssets)
            {
                Console.WriteLine($"Type: {asset.Type}, Brand: {asset.Brand}, Model: {asset.Model}, Price: {asset.Price:F2}");
            }
            Console.WriteLine(new string('-', 50));

            // 10. Total Spend per Brand (Top 5)
            var topSpendByBrand = allDocuments
                .Where(doc => doc.GetValue("CurrentLocation", "").AsString != "Archived")
                .GroupBy(doc => doc.GetValue("Brand", "").AsString)
                .Select(g => new { Brand = g.Key, TotalSpend = g.Sum(doc => doc.GetValue("Cost", 0).ToDouble()) })
                .OrderByDescending(g => g.TotalSpend)
                .Take(5);

            Console.WriteLine("Total Spend per Brand (Top 5):");
            foreach (var spend in topSpendByBrand)
            {
                Console.WriteLine($"{spend.Brand}: {spend.TotalSpend:F2}");
            }
            Console.WriteLine(new string('-', 50));

            // 11. Assets Greater than or Equal to 5 Years Old
            int assetsOverOrEqual5Years = allDocuments.Count(doc =>
                doc.GetValue("CurrentLocation", "").AsString != "Archived" &&
                DateTime.TryParse(doc.GetValue("PurchaseDate", "").AsString, out var purchaseDate) &&
                (currentDate - purchaseDate).TotalDays >= 5 * 365);

            Console.WriteLine($"Assets Greater than or Equal to 5 Years Old: {assetsOverOrEqual5Years}");
            Console.WriteLine(new string('-', 50));
        }








    }
}
