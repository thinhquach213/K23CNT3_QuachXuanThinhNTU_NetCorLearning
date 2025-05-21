using Microsoft.AspNetCore.Mvc;
using QxtLesson05Modles.Models.DataModels;

namespace QxtLesson05Modles.Controllers
{
    public class QxtMemberController : Controller
    {
        private static List<QxtMember> qxtlistMember = new List<QxtMember>()
        {
            new QxtMember
    {
        QxtMemberID = "2310900100",
        QxtUserName = "Quách Thịnh",
        QxtPassword = "pass123",
        QxtFullName = "QuáchXuânThịnh",
        QxtEmail = "quachxuanthinh20092005@.com"
    },
    new QxtMember
    {
        QxtMemberID = "M002",
        QxtUserName = "jane_smith",
        QxtPassword = "secure456",
        QxtFullName = "Jane Smith",
        QxtEmail = "jane.smith@example.com"
    },
    new QxtMember
    {
        QxtMemberID = "M003",
        QxtUserName = "alice_wu",
        QxtPassword = "alicepwd789",
        QxtFullName = "Alice Wu",
        QxtEmail = "alice.wu@example.com"
    },
    new QxtMember
    {
        QxtMemberID = "M004",
        QxtUserName = "bob_nguyen",
        QxtPassword = "bobng123",
        QxtFullName = "Bob Nguyen",
        QxtEmail = "bob.nguyen@example.com"
    },
    new QxtMember
    {
        QxtMemberID = "M005",
        QxtUserName = "sara_lee",
        QxtPassword = "sarapass321",
        QxtFullName = "Sara Lee",
        QxtEmail = "sara.lee@example.com"
    }
        };
        public IActionResult QxtIndex() // list member
        {
            return View(qxtlistMember);
        }
    }
}
