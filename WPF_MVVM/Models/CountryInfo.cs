using System.Collections.Generic;

namespace WPF_MVVM.Models
{
    public class CountryInfo : PlaceInfo
    {
        public IEnumerable<ProvinceInfo> ProvinceCounts { get; set; }
    }
}
