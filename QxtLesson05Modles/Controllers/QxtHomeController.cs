using Microsoft.AspNetCore.Mvc;
using QxtLesson05Modles.Models;
using QxtLesson05Modles.Models.DataModels;
using System.Diagnostics;

namespace QxtLesson05Modles.Controllers
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
            QxtMember qxtMember = new QxtMember();
            qxtMember.QxtMemberID = Guid.NewGuid(). ToString();
            qxtMember.QxtUserName = "Quach Thinh ";
            qxtMember.QxtPassword = "123456a@";
            qxtMember.QxtFullName = "Quach Xuan THinh "
            qxtMember.QxtEmail = "Quachxuanthinhj@gmail.com";
            return View(qxtMember);
            
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
