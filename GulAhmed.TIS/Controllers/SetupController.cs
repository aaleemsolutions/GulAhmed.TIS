using GulAhmed.TIS.Common.Model;
using GulAhmed.TIS.Controllers;
using GulAhmed.TIS.Core.Implementation;
using GulAhmed.TIS.Core.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GulAhmed.TIS.WEB.Controllers
{
    [Authorize]
    public class SetupController : Controller
    {
        private readonly ILogger<SetupController> _logger;
        private readonly IUserService userService;
        public SetupController(ILogger<SetupController> logger, IUserService userService)
        {
            _logger = logger;
            this.userService = userService;
        }
        public IActionResult Role()
        {
            
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> GetEmployeeDataTable(DTParameters dtparam)
        {
            var test = await userService.GetEmployeeDataTable(dtparam);
            return Json(test);
        }
        public IActionResult Customer()
        {
            return View();
        }

        public IActionResult Location()
        {
            return View();
        }
        public IActionResult Shift()
        {
            return View();
        }
 
    }
}
