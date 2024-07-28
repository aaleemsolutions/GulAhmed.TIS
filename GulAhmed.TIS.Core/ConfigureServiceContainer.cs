using GulAhmed.TIS.Core.Implementation;
using GulAhmed.TIS.Core.Interface;
using GulAhmed.TIS.Repository.Implementation;
using GulAhmed.TIS.Repository.Interface;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GulAhmed.TIS.Core
{
    public static class ConfigureServiceContainer
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddHttpContextAccessor();
            services.AddSingleton<IUserService, UserService>();
            services.AddSingleton<IAccountService, AccountService>();

        }
    }
}
