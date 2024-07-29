using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicLandExplorer.Tasks
{
    internal class FilterDestinations
    {
        //public static IEnumerable<string> GetFilteredDestinations(List<Category> categories)
        //{
        //    return categories
        //        .SelectMany(c => c.Destinations)
        //        .Where(d => int.TryParse(d.Duration.Split(' ')[0], out int duration) && duration < 100)
        //        .Select(d => d.Name);
        //}
        public static string[] GetFilteredDestinations(Category[] categories)
        {
            var filtered = from category in categories
                           from destination in category.Destinations
                           where destination.durationTime < 100
                           select destination.Name;

            return filtered.ToArray();
        }

    }
}
