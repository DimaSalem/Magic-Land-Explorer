using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicLandExplorer
{
    public class Destination
    {
        private string _duration;
        public string Name { get; set; }
        public string Type { get; set; }
        public string Location { get; set; }
        public string Duration
        {
            get => _duration;
            set
            {
                _duration = value;
                durationTime = !string.IsNullOrEmpty(_duration) ? int.Parse(_duration.Split(' ')[0]) : default;
            }
        }
        public int durationTime { get; private set; }
        public string Description { get; set; }
    }
}
