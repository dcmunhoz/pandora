using Microsoft.OpenApi.Models;
using Pandora.Api.Filters;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class DependencyInjector
    {
        public static IServiceCollection AddApi(this IServiceCollection services)
        {
            // Add services to the container.

            services.AddControllers(op =>
            {
                op.Filters.Add<ExceptionFilter>();
                op.Filters.Add<NotificationFilter>();
            });

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(option =>
            {
                option.SwaggerDoc("v1", new OpenApiInfo()
                {
                    Version = "v1",
                    Title = "Pandora API",
                    Description = "BFF Pandora Api"
                });
            });

            return services;
        }
    }
}
