using asp.net_mvc_layeredArch_dapper.BL.Interfaces;
using asp.net_mvc_layeredArch_dapper.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace asp.net_mvc_layeredArch_dapper.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUserBL _userBL;

        public HomeController(ILogger<HomeController> logger, IUserBL userBL)
        {
            _logger = logger;
            _userBL = userBL;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(null);
        }

        [HttpPost]
        public async Task<IActionResult> Index(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                int? userId = await _userBL.Authenticate(model.Email, model.Password);
                if (userId != null)
                {
                    return View(await _userBL.GetUserById(userId.Value));
                }
            }
            return View(null);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
