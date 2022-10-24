using Microsoft.Extensions.DependencyInjection;

namespace Finance.Infra
{
    public static class DependencyInjector
    {
        public static IServiceCollection AddInfra(this IServiceCollection services)
        {
            return services;
        }
    }
}
