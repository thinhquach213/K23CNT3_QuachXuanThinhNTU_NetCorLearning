using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QxtLesson08.Models;

namespace QxtLesson08.Controllers
{
    public class QxtAccountController : Controller
    {
        private static List<QxtAccount> qxtListAccount = new List<QxtAccount>()
        {
            new QxtAccount
    {
        QxtID = 20100,
        QxtFullName = "Quach Xuan Thinh",
        QxtEmail = "thinhquachj@gmail.com",
        QxtPhone = "0901234567",
        QxtAddress = "123 Nguyễn Trãi, Hà Nội",
        QxtAvatar = "thinhq.jpg",
        QxtBirthday = new DateTime(1995, 5, 10),
        QxtGender = "Nam",
        QxtPassword = "password123",
        QxtFacebook = "https://facebook.com/nguyenvana"
    },
    new QxtAccount
    {
        QxtID = 2,
        QxtFullName = "Trần Thị B",
        QxtEmail = "b.tran@example.com",
        QxtPhone = "0912345678",
        QxtAddress = "456 Lê Lợi, Đà Nẵng",
        QxtAvatar = "https://example.com/images/b.jpg",
        QxtBirthday = new DateTime(1998, 11, 25),
        QxtGender = "Nữ",
        QxtPassword = "abc123456",
        QxtFacebook = "https://facebook.com/tranb"
    },
    new QxtAccount
    {
        QxtID = 3,
        QxtFullName = "Lê Văn C",
        QxtEmail = "c.le@example.com",
        QxtPhone = "0923456789",
        QxtAddress = "789 Trần Hưng Đạo, TP.HCM",
        QxtAvatar = "https://example.com/images/c.jpg",
        QxtBirthday = new DateTime(1990, 3, 15),
        QxtGender = "Nam",
        QxtPassword = "pass456789",
        QxtFacebook = "https://facebook.com/levanc"
    },
    new QxtAccount
    {
        QxtID = 4,
        QxtFullName = "Phạm Thị D",
        QxtEmail = "d.pham@example.com",
        QxtPhone = "0934567890",
        QxtAddress = "101 Hai Bà Trưng, Huế",
        QxtAvatar = "https://example.com/images/d.jpg",
        QxtBirthday = new DateTime(1992, 7, 7),
        QxtGender = "Nữ",
        QxtPassword = "mypassword",
        QxtFacebook = "https://facebook.com/phamd"
    },
    new QxtAccount
    {
        QxtID = 5,
        QxtFullName = "Đỗ Minh E",
        QxtEmail = "e.do@example.com",
        QxtPhone = "0945678901",
        QxtAddress = "202 Lý Thường Kiệt, Cần Thơ",
        QxtAvatar = "https://example.com/images/e.jpg",
        QxtBirthday = new DateTime(1993, 9, 30),
        QxtGender = "Nam",
        QxtPassword = "securepwd",
        QxtFacebook = "https://facebook.com/dominhe"
    } };
        // GET: QxtAccountController
        public ActionResult QxtIndex()
        {
            
            return View(qxtListAccount);
        }

        // GET: QxtAccountController/Details/5
        public ActionResult Details(int id)
        {
            var acc = new QxtAccount(); // lấy theo id
            return View(acc);
        }

        // GET: QxtAccountController/Create
        public ActionResult QxtCreate()
        {
            var qxtModel=new QxtAccount();
            return View();
        }

        // POST: QxtAccountController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(QxtAccount qxtModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    
                    //int nextId = qxtListAccount.Any() ? qxtListAccount.Max(x => x.QxtID) + 1 : 1;
                    //qxtModel.QxtID = nextId;

                    qxtListAccount.Add(qxtModel);
                    return RedirectToAction(nameof(QxtIndex));
                }
                return View(qxtModel);
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", "co loi say ra khi them moi: " + ex.Message);
                return View(qxtModel);
            }
        }

        // GET: QxtAccountController/Edit/5
        public ActionResult Edit(int id)
        {
            var acc = new QxtAccount(); // lấy theo id
            return View(acc);
        }

        // POST: QxtAccountController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(QxtIndex));
            }
            catch
            {
                return View();
            }
        }

        // GET: QxtAccountController/Delete/5
        public ActionResult Delete(int id)
        {
            var acc = new QxtAccount(); // lấy theo id
            return View(acc);
        }

        // POST: QxtAccountController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(QxtIndex));
            }
            catch
            {
                return View();
            }
        }
    }
}
