using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CuaHangTienLoiTDA.Models;
using System;
using System.Linq;

namespace CuaHangTienLoiTDA.Areas.admins.Controllers
{
    [Area("admins")]
    public class DonHangController : Controller
    {
        private readonly CuaHangTienLoiTDAContext _context;

        public DonHangController(CuaHangTienLoiTDAContext context)
        {
            _context = context;
        }

        // Helper: luôn tạo SelectList an toàn (dùng text fallback nếu tên null)
        private void PopulateDropdowns(object selectedKH = null, object selectedNV = null)
        {
            // Danh sách khách hàng
            var khList = _context.KhachHangs
                .Select(k => new
                {
                    MaKH = k.MaKH,
                    TenKH = k.TenKH ?? k.MaKH.ToString()
                })
                .ToList();
            ViewBag.MaKH = new SelectList(khList, "MaKH", "TenKh", selectedKH);

            // Danh sách nhân viên (Admin)
            var nvList = _context.Admins
                .Select(a => new
                {
                    MaNV = a.MaNV,
                    TenDangNhap = a.TenDangNhap ?? a.MaNV.ToString()
                })
                .ToList();
            ViewBag.MaNV = new SelectList(nvList, "MaNV", "TenDangNhap", selectedNV);
        }

        // GET: admins/DonHang
        public IActionResult Index()
        {
            var donHangs = _context.DonHangs
                .Include(d => d.MaKHNavigation)
                .Include(d => d.MaNVNavigation)
                .ToList();
            return View(donHangs);
        }

        // GET: admins/DonHang/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null) return NotFound();

            var donHang = _context.DonHangs
                .Include(d => d.MaKHNavigation)
                .Include(d => d.MaNVNavigation)
                .Include(d => d.ChiTietDonHangs)
                .FirstOrDefault(m => m.MaDH == id);

            if (donHang == null) return NotFound();
            return View(donHang);
        }

        // GET: admins/DonHang/Create
        public IActionResult Create()
        {
            PopulateDropdowns();
            return View();
        }

        // POST: admins/DonHang/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(DonHang donHang)
        {
            // nếu muốn kiểm tra tồn tại MaKH có thể thêm:
            var kh = _context.KhachHangs.Find(donHang.MaKH);
            if (kh == null)
            {
                ModelState.AddModelError(nameof(donHang.MaKH), "Mã khách hàng không tồn tại.");
            }

            if (!ModelState.IsValid)
            {
                PopulateDropdowns(donHang.MaKH, donHang.MaNV);
                return View(donHang);
            }

            donHang.NgayDat = DateTime.Now;
            donHang.TrangThai = donHang.TrangThai ?? "Mới";

            _context.Add(donHang);
            _context.SaveChanges();
            TempData["Success"] = "Đã lưu đơn hàng.";
            return RedirectToAction(nameof(Index));
        }

        // GET: admins/DonHang/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null) return NotFound();

            var donHang = _context.DonHangs.Find(id);
            if (donHang == null) return NotFound();

            PopulateDropdowns(donHang.MaKH, donHang.MaNV);
            return View(donHang);
        }

        // POST: admins/DonHang/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, DonHang donHang)
        {
            if (id != donHang.MaDH) return NotFound();

            var kh = _context.KhachHangs.Find(donHang.MaKH);
            if (kh == null)
                ModelState.AddModelError(nameof(donHang.MaKH), "Mã khách hàng không tồn tại.");

            if (!ModelState.IsValid)
            {
                PopulateDropdowns(donHang.MaKH, donHang.MaNV);
                return View(donHang);
            }

            try
            {
                _context.Update(donHang);
                _context.SaveChanges();
                TempData["Success"] = "Đã cập nhật đơn hàng.";
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.DonHangs.Any(e => e.MaDH == donHang.MaDH))
                    return NotFound();
                else
                    throw;
            }

            return RedirectToAction(nameof(Index));
        }

        // GET: admins/DonHang/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null) return NotFound();

            var donHang = _context.DonHangs
                .Include(d => d.MaKHNavigation)
                .Include(d => d.MaNVNavigation)
                .FirstOrDefault(m => m.MaDH == id);

            if (donHang == null) return NotFound();
            return View(donHang);
        }

        // POST: admins/DonHang/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var donHang = _context.DonHangs.Find(id);
            if (donHang != null)
            {
                _context.DonHangs.Remove(donHang);
                _context.SaveChanges();
                TempData["Success"] = "Đã xóa đơn hàng.";
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
