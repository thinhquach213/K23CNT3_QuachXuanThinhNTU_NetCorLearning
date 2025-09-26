using Microsoft.AspNetCore.Mvc;
using qxtk23cntt_lesson12.Models;
using System.Diagnostics;

namespace qxtk23cntt_lesson12.Controllers
{
    public class QxtHomeController : Controller
    {
        private readonly ILogger<QxtHomeController> _logger;

        public QxtHomeController(ILogger<QxtHomeController> logger)
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
    }
}
