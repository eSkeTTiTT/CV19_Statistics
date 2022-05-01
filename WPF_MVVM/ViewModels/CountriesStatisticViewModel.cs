using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Input;
using WPF_MVVM.Infrastructure.Commands;
using WPF_MVVM.Models;
using WPF_MVVM.Services;
using WPF_MVVM.ViewModels.Base;

namespace WPF_MVVM.ViewModels
{
    public class CountriesStatisticViewModel : ViewModel
    {
        private DataService _dataService;
        public MainWindowViewModel MainViewModel { get; internal set; }

        private IEnumerable<CountryInfo> _countries;
        public IEnumerable<CountryInfo> Countries
        {
            get => _countries;
            private set => Set(ref _countries, value);
        }

        private CountryInfo _selectedCounrty;
        public CountryInfo SelectedCountry
        {
            get => _selectedCounrty;
            set => Set(ref _selectedCounrty, value);
        }

        public CountriesStatisticViewModel(DataService dataService)
        {
            _dataService = dataService;

            #region Commands

            RefreshDataCommand = new LambdaCommand(OnRefreshDataCommandExecuted);

            #endregion
        }

        /// <summary>
        /// Отладочный конструктор
        /// </summary>
        /*public CountriesStatisticViewModel() : this(null)
        {
            Countries = Enumerable.Range(1, 10)
                .Select(p => new CountryInfo
                {
                    Name = $"Country {p}",
                    ProvinceCounts = Enumerable.Range(1, 10).Select(i => new PlaceInfo
                    {
                        Name = $"Province {i}",
                        Location = new Point(p, i),
                        Counts = Enumerable.Range(1, 10).Select(k => new ConfirmedCount { Date = DateTime.Now, Count = k}).ToArray()
                    }).ToArray()
                }).ToArray();
        }*/

        #region Commands

        public ICommand RefreshDataCommand { get; }

        private void OnRefreshDataCommandExecuted(object p)
        {
            Countries = _dataService.GetData();
        }

        #endregion
    }
}
