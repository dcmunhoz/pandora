using Finance.Application.Interfaces.Services;
using Finance.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Finance.Application
{
    public static class DependencyInjector
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddTransient<ITestAppService, TestAppService>();

            return services;
        }
    }
}
