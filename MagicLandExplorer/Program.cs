using System;
using System.IO;
using Newtonsoft.Json;
using MagicLandExplorer.Tasks;

namespace MagicLandExplorer
{
    class Program
    {
        static Category[] categories;

        static void Main(string[] args)
        {
            string jsonFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "data", "data.json");

            if (!File.Exists(jsonFilePath))
            {
                Console.WriteLine("The data file is missing. Please ensure MagicLandData.json is in the 'data' directory.");
                return;
            }

            string json = File.ReadAllText(jsonFilePath);
            categories = JsonConvert.DeserializeObject<Category[]>(json);

            ShowMenu();
        }

        static void ShowMenu()
        {
            bool exit = false;
            while (!exit)
            {
                Console.Clear();
                Console.WriteLine("Select an option:");
                Console.WriteLine("1. Show filtered destinations");
                Console.WriteLine("2. Show destination with longest duration");
                Console.WriteLine("3. Sort destinations by name");
                Console.WriteLine("4. Show top 3 destinations by duration");
                Console.WriteLine("5. Exit");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        DisplayFilteredDestinations();
                        break;
                    case "2":
                        DisplayLongestDuration();
                        break;
                    case "3":
                        DisplaySortedDestinations();
                        break;
                    case "4":
                        DisplayTop3Durations();
                        break;
                    case "5":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
                Console.ReadKey();
                Console.WriteLine("press any key...");

            }
        }

        static void DisplayFilteredDestinations()
        {
            var filteredDestinations = FilterDestinations.GetFilteredDestinations(categories);
            Console.WriteLine("Destinations with duration less than 100 minutes:");
            foreach (var name in filteredDestinations)
            {
                Console.WriteLine(name);
            }
        }

        static void DisplayLongestDuration()
        {
            var longestDurationDestination = LongestDuration.GetLongestDurationDestination(categories);
            if (longestDurationDestination != null)
            {
                Console.WriteLine($"Destination with longest duration: {longestDurationDestination}");
            }
        }

        static void DisplaySortedDestinations()
        {
            var sortedDestinations = SortByName.GetSortedDestinationsByName(categories);
            Console.WriteLine("Destinations sorted by name:");
            foreach (var name in sortedDestinations)
            {
                Console.WriteLine(name);
            }
        }

        static void DisplayTop3Durations()
        {
            var top3Durations = Top3Duration.GetTop3Durations(categories);
            Console.WriteLine("Top 3 destinations by duration:");
            foreach (var info in top3Durations)
            {
                Console.WriteLine(info);
            }
        }
    }
}
