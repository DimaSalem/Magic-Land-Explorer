using System;
using System.Linq;

namespace MagicLandExplorer.Tasks
{
    public static class LongestDuration
    {
        public static string GetLongestDurationDestination(Category[] categories)
        {
            var longest = (from category in categories
                           from destination in category.Destinations
                           orderby destination.durationTime descending
                           select destination.Name).FirstOrDefault();

            return longest;
        }

    
    }
}
