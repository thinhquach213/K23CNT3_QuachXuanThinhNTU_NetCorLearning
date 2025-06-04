using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QxtLesson07.Models;

namespace QxtLesson07.Controllers
{
    public class QxtEmployeeController : Controller
    {
        private static List<QxtEmployee> QxtListEmployee = new List<QxtEmployee>()
        {
            new QxtEmployee { QxtID = 1, QxtName = "Quach Xuan Thinh", QxtBirthDay = new DateTime(1995, 5, 10), QxtEmail = "a@example.com", QxtPhone = "2310900100", QxtSalary = 12000000, QxtStatus = true },
            new QxtEmployee { QxtID = 2, QxtName = "Tran Thi B",    QxtBirthDay = new DateTime(1998, 8, 21), QxtEmail = "b@example.com", QxtPhone = "0909876543", QxtSalary = 10000000, QxtStatus = false },
            new QxtEmployee { QxtID = 3, QxtName = "Le Van C",       QxtBirthDay = new DateTime(1990, 1, 3),  QxtEmail = "c@example.com", QxtPhone = "0912345678", QxtSalary = 15000000, QxtStatus = true },
            new QxtEmployee { QxtID = 4, QxtName = "Pham Thi D",     QxtBirthDay = new DateTime(1992, 12, 15),QxtEmail = "d@example.com", QxtPhone = "0923456789", QxtSalary = 9500000,  QxtStatus = true },
            new QxtEmployee { QxtID = 5, QxtName = "Hoang Van E",    QxtBirthDay = new DateTime(1988, 3, 27), QxtEmail = "e@example.com", QxtPhone = "0934567890", QxtSalary = 11000000, QxtStatus = false },
            new QxtEmployee { QxtID = 6, QxtName = "Do Thi F",       QxtBirthDay = new DateTime(1997, 7, 5),  QxtEmail = "f@example.com", QxtPhone = "0945678901", QxtSalary = 12500000, QxtStatus = true }
        };
        public ActionResult QxtIndex()
        {
            return View(QxtListEmployee);
        }

        // GET: QxtEmployeeController/Details/5
        public ActionResult QxtDetails(int id)
        {
            var emp = QxtListEmployee.FirstOrDefault(x => x.QxtID == id);
            return View(emp);
        }

        // GET: QxtEmployeeController/Create
        public ActionResult QxtCreate()
        {
            var qxtEmployee = new QxtEmployee();
            return View();
        }

        // POST: QxtEmployeeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult QxtCreate(QxtEmployee qxtmodel)
        {
            try
            {
                // them moi nhan vien
                qxtmodel.QxtID = QxtListEmployee. Max(x=>x.QxtID) + 1;
                QxtListEmployee.Add(qxtmodel);
                return RedirectToAction(nameof(QxtIndex));
            }
            catch
            {
                return View();
            }
        }

        // GET: QxtEmployeeController/Edit/5
        public ActionResult QxtEdit(int id)
        {
            var emp = QxtListEmployee.FirstOrDefault(x => x.QxtID == id);
            return View(emp);

        }

        // POST: QxtEmployeeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [HttpPost]
                public ActionResult QxtEdit(int id, QxtEmployee qxtmodel)
        {
            try
            {
                for (int i = 0; i < QxtListEmployee.Count; i++)
                {
                    if (QxtListEmployee[i].QxtID == id)
                    {
                        QxtListEmployee[i] = qxtmodel;
                        break;
                    }
                }
                return RedirectToAction(nameof(QxtIndex));
            }
            catch
            {
                return View(qxtmodel); // thêm qxtmodel để tránh NullReference
            }
        }


        // GET: QxtEmployeeController/Delete/5
        public ActionResult QxtDelete(int id)
        {
            var emp = QxtListEmployee.FirstOrDefault(x => x.QxtID == id);
            return View(emp);
        }

        // POST: QxtEmployeeController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
