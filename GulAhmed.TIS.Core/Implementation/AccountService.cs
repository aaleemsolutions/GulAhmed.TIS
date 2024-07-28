using GulAhmed.TIS.Common.DTO;
using GulAhmed.TIS.Common.Model;
using GulAhmed.TIS.Core.Interface;
using GulAhmed.TIS.Repository.Interface;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using static GulAhmed.TIS.Common.Helpers.Constants;

namespace GulAhmed.TIS.Core.Implementation
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository accountRepository;
        private readonly IHttpContextAccessor httpContextAccessor;

        public AccountService(IAccountRepository accountRepository, IHttpContextAccessor httpContextAccessor)
        {
            this.accountRepository = accountRepository;
            this.httpContextAccessor = httpContextAccessor;
        }
        public async Task<JsonModel> ValidateUser(string Name, string Password)
        {
            JsonModel jsonModel = new JsonModel();
            var user = await accountRepository.ValidateUser(Name, Password);

            if (user.SEQID > 0)
            {  // Create the identity for the user
                var identity = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, user.USERNAME),
                    new Claim(ClaimTypes.NameIdentifier, user.USERCODE),
                    new Claim(ClaimTypes.Role, user.ROLEID.ToString()),

                }, CookieAuthenticationDefaults.AuthenticationScheme); ;
                var principal = new ClaimsPrincipal(identity);
                var login = httpContextAccessor.HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
                jsonModel.Success(Messages.LoginSuccess);
                return jsonModel;
            }
            else
            {
                jsonModel.Failed(Messages.LoginFailed);


            }

            return jsonModel;

        }
        public async Task<JsonModel> LogoutUser()
        {
            JsonModel jsonModel = new JsonModel();
            var login = httpContextAccessor.HttpContext.SignOutAsync();
            return jsonModel;
        }


    }
}
