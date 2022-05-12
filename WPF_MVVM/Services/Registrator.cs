using Microsoft.Extensions.DependencyInjection;
using WPF_MVVM.Services.Interfaces;

namespace WPF_MVVM.Services
{
    public static class Registrator
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            services.AddSingleton<IDataService, DataService>();
            services.AddTransient<IAsyncDataService, AsyncDataService>();
            services.AddTransient<IWebServerService, HttpListenerWebServer>();

            return services;
        }
    }
}
