using GulAhmed.TIS.Repository.Implementation;
using GulAhmed.TIS.Repository.Interface;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GulAhmed.Repository
{
    public static class ConfigureRepositoryContainer
    {
        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddSingleton<IUserRepository, UserRepository>();
            services.AddSingleton<IAccountRepository, AccountRepository>();
        }
    }
}
