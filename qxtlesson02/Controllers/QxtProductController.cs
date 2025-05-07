using Microsoft.AspNetCore.Mvc;

namespace qxtlesson02.Controllers
{
    public class QxtProductController : Controller
    {
        public IActionResult QxtIndex()
        {
            ViewData["messageData"] = "Du lieu tu viewData";
            ViewBag.messageData = "Du lieu tu viewBag";
            TempData["messageData"] = "Du lieu tu TempData";
            return View();
        }
    }
}

