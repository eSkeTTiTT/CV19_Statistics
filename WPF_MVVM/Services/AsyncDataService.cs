using System;
using System.Threading;
using WPF_MVVM.Services.Interfaces;

namespace WPF_MVVM.Services
{
    public class AsyncDataService : IAsyncDataService
    {
        private const int _sleepTime = 5000;

        public string GetResult(DateTime time)
        {
            Thread.Sleep(_sleepTime);

            return $"Result value {time}";
        }
    }
}
