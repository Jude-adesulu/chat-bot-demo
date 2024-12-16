using chat_bot_demo.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace chat_bot_demo.Controllers
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

    }
}
