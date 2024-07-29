using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicLandExplorer.Tasks
{
    public class SortByName
    {
        public static string[] GetSortedDestinationsByName(Category[] categories)
        {
            var sorted = from category in categories
                         from destination in category.Destinations
                         orderby destination.Name
                         select destination.Name;

            return sorted.ToArray();
        }
    }
}
