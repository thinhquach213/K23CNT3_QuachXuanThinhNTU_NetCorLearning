using Microsoft.AspNetCore.Mvc;
using CuaHangTienLoiTDA.Models;
using System.Linq;

namespace CuaHangTienLoiTDA.Areas.admins.Controllers
{
    [Area("admins")]
    public class KhachHangController : Controller
    {
        private readonly CuaHangTienLoiTDAContext _context;

        public KhachHangController(CuaHangTienLoiTDAContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var list = _context.KhachHangs.ToList();
            return View(list);
        }

        public IActionResult Details(int id)
        {
            var kh = _context.KhachHangs.FirstOrDefault(k => k.MaKH == id);
            if (kh == null) return NotFound();
            return View(kh);
        }


        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(KhachHang kh)
        {
            if (ModelState.IsValid)
            {
                _context.KhachHangs.Add(kh);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(kh);
        }

        public IActionResult Edit(int id)
        {
            var kh = _context.KhachHangs.Find(id);
            if (kh == null) return NotFound();
            return View(kh);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(KhachHang kh)
        {
            if (ModelState.IsValid)
            {
                _context.KhachHangs.Update(kh);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(kh);
        }

        public IActionResult Delete(int id)
        {
            var kh = _context.KhachHangs.Find(id);
            if (kh == null) return NotFound();
            return View(kh);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var kh = _context.KhachHangs.Find(id);
            if (kh != null)
            {
                _context.KhachHangs.Remove(kh);
                _context.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
