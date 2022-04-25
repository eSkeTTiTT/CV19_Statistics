using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace WPF_MVVM.Models
{
    public class CountryInfo : PlaceInfo
    {
        private Point? _location;
        public override Point Location
        {
            get
            {
                if (_location.HasValue)
                    return _location.Value;

                if (ProvinceCounts is null)
                    return default;

                var average_x = ProvinceCounts.Average(p => p.Location.X);
                var average_y = ProvinceCounts.Average(p => p.Location.Y);

                return (_location = new Point(average_x, average_y)).Value;
            }
            set => _location = value;
        }

        public IEnumerable<PlaceInfo> ProvinceCounts { get; set; }
    }
}
