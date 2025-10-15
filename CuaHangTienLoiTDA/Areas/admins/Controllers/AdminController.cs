using CuaHangTienLoiTDA.Models;
using Microsoft.AspNetCore.Mvc;

namespace CuaHangTienLoiTDA.Areas.admins.Controllers
{
    [Area("admins")]
    public class AdminController : Controller
    {
        private readonly CuaHangTienLoiTDAContext _context;

        public AdminController(CuaHangTienLoiTDAContext context)
        {
            _context = context;
        }

        // GET: admins/Admin
        public IActionResult Index()
        {
            var list = _context.Admins.ToList();
            return View(list);
        }

        // GET: admins/Admin/Details/5
        public IActionResult Details(int id)
        {
            var admin = _context.Admins.FirstOrDefault(a => a.MaNV == id);
            if (admin == null) return NotFound();
            return View(admin);
        }

        // GET: admins/Admin/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: admins/Admin/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [HttpPost]
      
        public IActionResult Create(Admin admin)
        {
            if (ModelState.IsValid)
            {
                // Kiểm tra xem email đã tồn tại chưa
                bool emailExists = _context.Admins.Any(a => a.Email == admin.Email);
                if (emailExists)
                {
                    ModelState.AddModelError("Email", "Email này đã được sử dụng. Vui lòng chọn email khác.");
                    return View(admin);
                }

                _context.Admins.Add(admin);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(admin);
        }

        // GET: admins/Admin/Edit/5
        public IActionResult Edit(int id)
        {
            var admin = _context.Admins.Find(id);
            if (admin == null) return NotFound();
            return View(admin);
        }

        // POST: admins/Admin/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Admin admin)
        {
            if (ModelState.IsValid)
            {
                _context.Admins.Update(admin);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(admin);
        }

        // GET: admins/Admin/Delete/5
        public IActionResult Delete(int id)
        {
            var admin = _context.Admins.Find(id);
            if (admin == null) return NotFound();
            return View(admin);
        }

        // POST: admins/Admin/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var admin = _context.Admins.Find(id);
            if (admin != null)
            {
                _context.Admins.Remove(admin);
                _context.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
