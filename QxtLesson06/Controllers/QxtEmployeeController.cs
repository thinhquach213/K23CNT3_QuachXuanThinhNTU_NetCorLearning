using Microsoft.AspNetCore.Mvc;
using QxtLesson06.Models;

namespace QxtLesson06.Controllers
{
    public class QxtEmployeeController : Controller 
    {

        private static List<QxtEmployee> qxtListEmployee = new List<QxtEmployee>()
        {
    new QxtEmployee { QxtID = 1, QxtName = "Quách Xuân Thinh", QxtBirthDay = new DateTime(2005, 5, 10), QxtEmail = "a@example.com", QxtPhone = "090124567", QxtSalary = 1200000, QxtStatus = true },
    new QxtEmployee { QxtID = 2, QxtName = "Tran Thi B",    QxtBirthDay = new DateTime(1998, 8, 21), QxtEmail = "b@example.com", QxtPhone = "0909876543", QxtSalary = 10000000, QxtStatus = false },
    new QxtEmployee { QxtID = 3, QxtName = "Le Van C",       QxtBirthDay = new DateTime(1990, 1, 3),  QxtEmail = "c@example.com", QxtPhone = "0912345678", QxtSalary = 15000000, QxtStatus = true },
    new QxtEmployee { QxtID = 4, QxtName = "Pham Thi D",     QxtBirthDay = new DateTime(1992, 12, 15),QxtEmail = "d@example.com", QxtPhone = "0923456789", QxtSalary = 9500000,  QxtStatus = true },
    new QxtEmployee { QxtID = 5, QxtName = "Hoang Van E",    QxtBirthDay = new DateTime(1988, 3, 27), QxtEmail = "e@example.com", QxtPhone = "0934567890", QxtSalary = 11000000, QxtStatus = false },
    new QxtEmployee { QxtID = 6, QxtName = "Do Thi F",       QxtBirthDay = new DateTime(1997, 7, 5),  QxtEmail = "f@example.com", QxtPhone = "0945678901", QxtSalary = 12500000, QxtStatus = true }
        };
        public IActionResult QxtIndex()
        {
            return View(qxtListEmployee);
        }
        // GET: QxtHome/QxtCreate
        public ActionResult QxtCreate()
        {
            return View();
        }
        
        [HttpPost]
        [HttpPost]
        public IActionResult QxtCreate(QxtEmployee employee)
        {
            if (ModelState.IsValid)
            {
                int newId = qxtListEmployee.Any() ? qxtListEmployee.Max(x => x.QxtID) + 1 : 1;
                employee.QxtID = newId;   // Gán ID cho employee
                qxtListEmployee.Add(employee);
                return RedirectToAction("QxtIndex");
            }
            // Nếu dữ liệu không hợp lệ, trả lại form với dữ liệu đã nhập
            return View(employee);
        }


    }
}
