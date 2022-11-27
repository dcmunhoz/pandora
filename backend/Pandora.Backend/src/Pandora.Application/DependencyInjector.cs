using AutoMapper;
using Pandora.Application.Business.Example.Command.New;
using Pandora.Application.Common.Behavior;
using FluentValidation;
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
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationsBehavior<,>));

            var serviceProvider = services.BuildServiceProvider();
            MapperExtension.Configure(serviceProvider.GetService<IMapper>());

            return services;
        }
    }
}
