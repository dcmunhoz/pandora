using AutoMapper;
using FluentValidation.AspNetCore;
using MediatR;
using System.Reflection;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class DependencyInjector
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            var serviceProvider = services.BuildServiceProvider();
            MapperExtension.Configure(serviceProvider.GetService<IMapper>());

            return services;
        }
    }
}
