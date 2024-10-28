using Core.Security;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using LMS.Repository.Ioc;
using LMS.Service.Interfaces;
using LMS.Service.Services;

namespace LMS.Service.Ioc
{
    public static class IocService
    {
        public static void RegisterServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.RegisterRepositories(configuration);

            #region Services

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddTransient<ITokenBuilder, TokenBuilder>();
            services.AddTransient<IUserProviderService, UserProviderService>();
            //services.AddTransient<IRoleService, RoleService>();
            services.AddTransient<IUserService, UserService>();
            //services.AddTransient<IUserLoginService, UserLoginService>();
            services.AddTransient<IUserProviderService, UserProviderService>();
            services.AddTransient<IBookService, BookService>();
            services.AddTransient<ITransactionService, TransactionService>();
            #endregion
        }
    }
}
