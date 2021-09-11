using App.API.Data;
using App.API.Data.Context;
using App.API.Services;
using App.Data.Repository;
using App.Domain.Interfaces;
using App.Domain.Interfaces.Repository;
using App.Domain.Notifications;
using App.Service.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.API.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddScoped<SampleAppContext>();
            services.AddScoped<INotifier, Notifier>();


            services.AddScoped<IOfficeRepository, OfficeRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserRoleRepository, UserRoleRepository>();

            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IOfficeService, OfficeService>();

            return services;
        }
    }
}
