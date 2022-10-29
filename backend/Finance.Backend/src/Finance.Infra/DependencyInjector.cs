using Finance.Application.Common.Interfaces.Repository;
using Finance.Infra.Persistence.Repository;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class DependencyInjector
    {
        public static IServiceCollection AddInfra(this IServiceCollection services )
        {
            // Repositories
            services.AddTransient<ITestRepository, TestRepository>();

            return services;
        }
    }
}
