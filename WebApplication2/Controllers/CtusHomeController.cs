using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class CtusHomeController : Controller
    {
        private readonly ILogger<CtusHomeController> _logger;

        public CtusHomeController(ILogger<CtusHomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult CtusIndex()
        {
            return View();
        }

        public IActionResult CtusAbout()
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
