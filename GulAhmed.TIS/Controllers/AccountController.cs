using GulAhmed.TIS.Core.Interface;
using Microsoft.AspNetCore.Mvc;
using static GulAhmed.TIS.Common.Helpers.Constants;

namespace GulAhmed.TIS.WEB.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountService accountService;

        public AccountController(IAccountService accountService)
        {
            this.accountService = accountService;
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(string UserName, string password)
        {
            var model  = await this.accountService.ValidateUser(UserName, password);
            if (model.status == ResponseStatusCode.Succcess)
            {
                return RedirectToAction("role","setup");
            }
            return View(model);
        }
        public async  Task<IActionResult> Logout()
        {
            var model = await this.accountService.LogoutUser();
            return RedirectToAction("Login");
        }
    }
}
