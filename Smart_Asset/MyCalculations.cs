using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDB.Bson;

namespace Smart_Asset
{
    public class MyCalculations
    {

        public static string CalculateUsage(DateTime purchaseDate)
        {
            DateTime currentDate = DateTime.Now;

            // Calculate the difference in years, months, and days
            int years = currentDate.Year - purchaseDate.Year;
            int months = currentDate.Month - purchaseDate.Month;
            int days = currentDate.Day - purchaseDate.Day;

            // Check if usage is less than 1 day
            if (currentDate.Date == purchaseDate.Date)
            {
                return "Less than 1 day";
            }

            // Adjust if the current month/day is less than the purchase month/day
            if (days < 0)
            {
                months--;
                days += DateTime.DaysInMonth(currentDate.Year, currentDate.Month - 1);
            }

            if (months < 0)
            {
                years--;
                months += 12;
            }

            // Build the usage string
            string usage = "";
            if (years > 0)
            {
                usage += $"{years} year{(years > 1 ? "s" : "")} ";
            }
            if (months > 0)
            {
                usage += $"{months} month{(months > 1 ? "s" : "")} ";
            }
            if (days > 0)
            {
                usage += $"{days} day{(days > 1 ? "s" : "")}";
            }

            // Trim any trailing whitespace and return the result
            return usage.Trim();
        }



        public static bool IsWarrantyValid(DateTime purchaseDate, string warrantyString)
        {
            // Parse the warranty string to extract years, months, and days
            int years = 0, months = 0, days = 0;
            var warrantyParts = warrantyString.Split(' ');

            foreach (var part in warrantyParts)
            {
                if (part.StartsWith("years"))
                {
                    years = int.Parse(part.Split(':')[1]);
                }
                else if (part.StartsWith("months"))
                {
                    months = int.Parse(part.Split(':')[1]);
                }
                else if (part.StartsWith("days"))
                {
                    days = int.Parse(part.Split(':')[1]);
                }
            }

            // Calculate the warranty end date
            DateTime warrantyEndDate = purchaseDate.AddYears(years).AddMonths(months).AddDays(days);

            // Compare the current date with the warranty end date
            return DateTime.Now <= warrantyEndDate;
        }




    }
}
