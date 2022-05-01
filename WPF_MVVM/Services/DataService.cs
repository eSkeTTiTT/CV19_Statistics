using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using WPF_MVVM.Models;
using WPF_MVVM.Services.Interfaces;

namespace WPF_MVVM.Services
{
    public class DataService : IDataService
    {
        private const string DataSourceAdress = @"https://raw.githubusercontent.com/CSSEGISandData/COVID-19/master/csse_covid_19_data/csse_covid_19_time_series/time_series_covid19_confirmed_global.csv";

        private static async Task<Stream> GetDataStream()
        {
            var client = new HttpClient();
            var response = await client.GetAsync(DataSourceAdress, HttpCompletionOption.ResponseHeadersRead);

            return await response.Content.ReadAsStreamAsync();
        }

        private static IEnumerable<string> GetDataLines()
        {
            using var data_stream = (SynchronizationContext.Current is null ? GetDataStream() : Task.Run(GetDataStream)).Result;
            using var data_reader = new StreamReader(data_stream);

            while (!data_reader.EndOfStream)
            {
                var line = data_reader.ReadLine();

                if (string.IsNullOrWhiteSpace(line)) continue;

                if (line.Contains('"'))
                    line = line.Insert(line.IndexOf(',', line.IndexOf('"')) + 1, " -").Remove(line.IndexOf(',', line.IndexOf('"')), 1);

                yield return line;
            }
        }

        private static DateTime[] GetDates() => GetDataLines()
            .First()
            .Split(',')
            .Skip(4)
            .Select(s => DateTime.Parse(s, CultureInfo.InvariantCulture))
            .ToArray();

        private static IEnumerable<(string Province, string Country, (double lat, double lon) Place, int[] Counts)> GetCountriesData()
        {
            var lines = GetDataLines()
                .Skip(1) // пропускаем заголовок
                .Select(line => line.Split(','));

            foreach (var row in lines)
            {
                var province = row[0].Trim();
                var country_name = row[1].Trim(' ', '"');
                var latitude = row[2] == string.Empty ? default : double.Parse(row[2], CultureInfo.InvariantCulture);
                var longitude = row[3] == string.Empty ? default : double.Parse(row[3], CultureInfo.InvariantCulture);
                var counts = row.Skip(4).Select(int.Parse).ToArray(); // пропускаем широту и долготу

                yield return (province, country_name, (latitude, longitude), counts);
            }
        }

        public IEnumerable<CountryInfo> GetData()
        {
            var dates = GetDates();

            var data = GetCountriesData().GroupBy(d => d.Country);

            foreach (var c_info in data)
            {
                var country = new CountryInfo
                {
                    Name = c_info.Key,
                    ProvinceCounts = c_info.Select(c => new PlaceInfo
                    {
                        Name = c.Province,
                        Location = new Point(c.Place.lat, c.Place.lon),
                        Counts = dates.Zip(c.Counts, (date, count) => new ConfirmedCount { Date = date, Count = count})
                    })
                };

                yield return country;
            }
        }
    }
}
