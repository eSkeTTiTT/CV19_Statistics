using System.Collections.Generic;
using WPF_MVVM.Models;

namespace WPF_MVVM.Services.Interfaces
{
    public interface IDataService
    {
        public IEnumerable<CountryInfo> GetData();
    }
}
