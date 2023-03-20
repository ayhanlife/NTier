﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using TodoAppNTier.Busniess.Interfaces;
using TodoAppNTier.Busniess.Services;
using TodoAppNTier.DataAccess.Context;
using TodoAppNTier.DataAccess.UnitOfWork;

namespace TodoAppNTier.Busniess.DependencyResolvers.Microsoft
{
    public static class DependencyExtension
    {
        public static void AddDependencies(this IServiceCollection services)
        {
            services.AddDbContext<TodoContext>(opt =>
            {
                opt.UseSqlServer("Data Source=AYHAN\\AYHAN;Password=sifre123@;User ID=sa;Initial Catalog=TodoAppDb;TrustServerCertificate=True;");

                opt.LogTo(Console.WriteLine, LogLevel.Information);
            });

            services.AddScoped<IUow, Uow>();
            services.AddScoped<IWorkServices, WorkService>();

        }
    }
}
