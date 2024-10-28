using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LMS.Repository.Contexts;
using LMS.Repository.Interfaces;
using LMS.Repository.Repositories;

namespace LMS.Repository.Ioc
{
    public static class IocRepository
    {
        public static void RegisterRepositories(this IServiceCollection services, IConfiguration configuration)
        {
            string connectionString = configuration.GetConnectionString("DefaultConnection");
            services.AddEntityFrameworkSqlServer()
                    .AddDbContext<LMSDbContext>(options => options.UseSqlServer(connectionString, sqlServerOptionsAction: sqlOptions =>
                    {
                        sqlOptions.EnableRetryOnFailure(maxRetryCount: 15, maxRetryDelay: TimeSpan.FromSeconds(30), errorNumbersToAdd: null);
                    }),
            ServiceLifetime.Scoped//Showing explicitly that the DbContext is shared across the HTTP request scope (graph of objects started in the HTTP request)
            );

            #region Repositories
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IBookRepository, BookRepository>();
            services.AddTransient<ITransactionRepository, TransactionRepository>();
            #endregion
        }
    }
}
