using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.DependencyInjection;
using Pandora.Application.Common.Interfaces.Repository;
using Pandora.Application.Common.Notification;
using Pandora.Infra.Persistence.Repository;
using Pandora.Infra.Repository.Context;
using System;
using System.Reflection;

namespace Pandora.Unit.Test.Application
{
    public static class ServiceCollectionProvider
    {
        public static ServiceProvider BuildProvider()
        {
            var services = new ServiceCollection();

            // Application
            services.AddScoped<INotificationHandler, NotificationHandler>();
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies().SingleOrDefault(w => w.GetName().Name == "Pandora.Application"));

            // Domain

            // Infra
            services.AddTransient<IDatabaseContext, SqlLiteDbContext>();
            services.AddDbContext<DatabaseContext>(option =>  option
                .UseInMemoryDatabase("Pandora")
                .ConfigureWarnings(x => x.Ignore(InMemoryEventId.TransactionIgnoredWarning)));

            // Repositories
            services.AddTransient<IUserRepository, UserRepository>();

            var provider = services.BuildServiceProvider();

            MapperExtension.Configure(provider.GetService<IMapper>());

            return provider;
        }
    }
}
