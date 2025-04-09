using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using web_net9_mongodb.Models;
using web_net9_mongodb.Models.Entities;

namespace web_net9_mongodb.Controllers
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
            Demo1Context context = new Demo1Context();
            var q = context.tbl_Khachhangs.ToList();
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
    }
}
