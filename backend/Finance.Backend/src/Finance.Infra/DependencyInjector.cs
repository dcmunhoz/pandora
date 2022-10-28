using Finance.Domain.Interfaces.Repository;
using Finance.Infra.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace Finance.Infra
{
    public static class DependencyInjector
    {
        public static IServiceCollection AddInfra(this IServiceCollection services )
        {
            services.AddScoped<ITestRepository, TestRepository>();

            return services;
        }
    }
}
