using Finance.Domain.Interfaces.Services;
using Finance.Domain.Test.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Finance.Domain
{
    public static class DependencyInjector
    {
        public static IServiceCollection AddDomain(this IServiceCollection services)
        {

            services.AddTransient<ITestService, TestService>();

            return services;
        }
    }
}
