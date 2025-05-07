using Microsoft.AspNetCore.Mvc;
using qxtlesson02.Models;
using System.Diagnostics;

namespace qxtlesson02.Controllers
{
    public class QxtHomeController : Controller
    {
        private readonly ILogger<QxtHomeController> _logger;

        public QxtHomeController(ILogger<QxtHomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult QxtIndex()
        {
            return View();
        }

        public IActionResult QxtAbout()
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
