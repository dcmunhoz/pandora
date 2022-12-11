using AutoMapper;
using Pandora.Application.Common.Behavior;
using FluentValidation;
using FluentValidation.AspNetCore;
using MediatR;
using System.Reflection;
using Pandora.Application.Common.Notification;

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

            services.AddScoped<INotificationHandler, NotificationHandler>();

            return services;
        }
    }
}
