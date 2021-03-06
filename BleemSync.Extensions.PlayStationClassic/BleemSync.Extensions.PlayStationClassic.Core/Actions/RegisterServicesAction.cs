﻿using BleemSync.Data;
using BleemSync.Extensions.PlayStationClassic.Core.Services;
using BleemSync.Services.Abstractions;
using ExtCore.Infrastructure.Actions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace BleemSync.Extensions.PlayStationClassic.Core.Actions
{
    public class RegisterServicesAction : IConfigureServicesAction
    {
        public int Priority => 1000;

        public void Execute(IServiceCollection services, IServiceProvider serviceProvider)
        {
            var configuration = serviceProvider.GetService<IConfiguration>();

            services.AddScoped(typeof(IGameManagerService), typeof(GameManagerService));
            services.AddDbContext<MenuDatabaseContext>(options =>
                options.UseSqlite(configuration["PlayStationClassic:ConnectionStrings:MenuDatabaseContext"])
            );
        }
    }
}
