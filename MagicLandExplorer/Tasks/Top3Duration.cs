using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicLandExplorer.Tasks
{
    public class Top3Duration
    {
        public static string[] GetTop3Durations(Category[] categories)
        {
            var top3 = (from category in categories
                        from destination in category.Destinations
                        orderby destination.durationTime descending
                        select $"{destination.Name} - {destination.Duration}").Take(3);

            return top3.ToArray();
        }
    }
}
