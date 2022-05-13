using Microsoft.Extensions.DependencyInjection;
using WPF_MVVM.Services.Interfaces;
using WPF_MVVM.Services.Students;

namespace WPF_MVVM.Services
{
    public static class Registrator
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            services.AddSingleton<IDataService, DataService>();
            services.AddTransient<IAsyncDataService, AsyncDataService>();
            services.AddTransient<IWebServerService, HttpListenerWebServer>();
            services.AddSingleton<StudentsRepository>();
            services.AddSingleton<GroupRepository>();
            services.AddSingleton<StudentManager>();

            return services;
        }
    }
}
