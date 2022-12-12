using Pandora.Application.Common.Interfaces.Repository;
using Pandora.Application.Common.Interfaces.Token;
using Pandora.Infra.JwtProvider;
using Pandora.Infra.Persistence.Repository;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class DependencyInjector
    {
        public static IServiceCollection AddInfra(this IServiceCollection services )
        {
            // Repositories
            services.AddTransient<IUserRepository, UserRepository>();

            // Providers
            services.AddTransient<ITokenService, JwtProvider>();

            return services;
        }
    }
}
