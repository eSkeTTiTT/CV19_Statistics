using Microsoft.Extensions.DependencyInjection;

namespace WPF_MVVM.ViewModels
{
    public static class Registrator
    {
        public static IServiceCollection RegisterViewModels(this IServiceCollection services)
        {
            services.AddSingleton<MainWindowViewModel>();
            services.AddSingleton<CountriesStatisticViewModel>();
            services.AddSingleton<WebServerViewModel>();

            services.AddTransient<StudentsManagementViewModel>();

            return services;
        }
    }
}
