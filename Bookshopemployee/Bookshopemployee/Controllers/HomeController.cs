using Bookshopemployee.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Bookshopemployee.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
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
        public IActionResult storeinsession()
        {
            string v = Request.Query["user"].ToString();
            HttpContext.Session.SetString("username", v);
            return RedirectToAction("getsession");

        }

        public IActionResult getsession()
        {
            string username = HttpContext.Session.GetString("username");
            return Content(username);
        }
    }
}
