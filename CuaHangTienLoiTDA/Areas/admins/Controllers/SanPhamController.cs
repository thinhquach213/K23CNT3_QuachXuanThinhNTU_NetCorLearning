using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using CuaHangTienLoiTDA.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace CuaHangTienLoiTDA.Areas.admins.Controllers
{
    [Area("admins")]
    public class SanPhamController : Controller
    {
        private readonly CuaHangTienLoiTDAContext _context;
        private readonly IWebHostEnvironment _env;

        public SanPhamController(CuaHangTienLoiTDAContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        // GET: admins/SanPham
        public async Task<IActionResult> Index()
        {
            var sanPhams = await _context.SanPhams
                .Include(sp => sp.MaDMNavigation)
                .ToListAsync();
            return View(sanPhams);
        }

        // GET: admins/SanPham/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var sp = await _context.SanPhams
                .Include(s => s.MaDMNavigation)
                .FirstOrDefaultAsync(m => m.MaSP == id);

            if (sp == null) return NotFound();

            return View(sp);
        }

        // GET: admins/SanPham/Create
        public IActionResult Create()
        {
            ViewData["MaDM"] = new SelectList(_context.DanhMucSanPhams, "MaDM", "TenDM");
            return View();
        }

        // POST: admins/SanPham/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SanPham sp, IFormFile? ImageFile)
        {
            if (ModelState.IsValid)
            {
                // Xử lý upload hình ảnh
                if (ImageFile != null && ImageFile.Length > 0)
                {
                    string fileName = Path.GetFileNameWithoutExtension(ImageFile.FileName);
                    string extension = Path.GetExtension(ImageFile.FileName);
                    string newFileName = $"{fileName}_{DateTime.Now:yyyyMMddHHmmss}{extension}";
                    string uploadPath = Path.Combine(_env.WebRootPath, "images", "sanpham");

                    if (!Directory.Exists(uploadPath))
                        Directory.CreateDirectory(uploadPath);

                    string filePath = Path.Combine(uploadPath, newFileName);

                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await ImageFile.CopyToAsync(stream);
                    }

                    sp.HinhAnh = "/images/sanpham/" + newFileName;
                }

                _context.Add(sp);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewData["MaDM"] = new SelectList(_context.DanhMucSanPhams, "MaDM", "TenDM", sp.MaDM);
            return View(sp);
        }

        // GET: admins/SanPham/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var sp = await _context.SanPhams.FindAsync(id);
            if (sp == null) return NotFound();

            ViewData["MaDM"] = new SelectList(_context.DanhMucSanPhams, "MaDM", "TenDM", sp.MaDM);
            return View(sp);
        }

        // POST: admins/SanPham/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, SanPham sp, IFormFile? ImageFile)
        {
            if (id != sp.MaSP) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    // Xử lý hình ảnh nếu có upload mới
                    if (ImageFile != null && ImageFile.Length > 0)
                    {
                        string fileName = Path.GetFileNameWithoutExtension(ImageFile.FileName);
                        string extension = Path.GetExtension(ImageFile.FileName);
                        string newFileName = $"{fileName}_{DateTime.Now:yyyyMMddHHmmss}{extension}";
                        string uploadPath = Path.Combine(_env.WebRootPath, "images", "sanpham");

                        if (!Directory.Exists(uploadPath))
                            Directory.CreateDirectory(uploadPath);

                        string filePath = Path.Combine(uploadPath, newFileName);

                        using (var stream = new FileStream(filePath, FileMode.Create))
                        {
                            await ImageFile.CopyToAsync(stream);
                        }

                        sp.HinhAnh = "/images/sanpham/" + newFileName;
                    }

                    _context.Update(sp);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.SanPhams.Any(e => e.MaSP == sp.MaSP))
                        return NotFound();
                    else
                        throw;
                }
                return RedirectToAction(nameof(Index));
            }

            ViewData["MaDM"] = new SelectList(_context.DanhMucSanPhams, "MaDM", "TenDM", sp.MaDM);
            return View(sp);
        }

        // GET: admins/SanPham/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var sp = await _context.SanPhams
                .Include(s => s.MaDMNavigation)
                .FirstOrDefaultAsync(m => m.MaSP == id);
            if (sp == null) return NotFound();

            return View(sp);
        }

        // POST: admins/SanPham/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sp = await _context.SanPhams.FindAsync(id);
            if (sp != null)
            {
                // Xóa ảnh khỏi thư mục nếu có
                if (!string.IsNullOrEmpty(sp.HinhAnh))
                {
                    var filePath = Path.Combine(_env.WebRootPath, sp.HinhAnh.TrimStart('/'));
                    if (System.IO.File.Exists(filePath))
                        System.IO.File.Delete(filePath);
                }

                _context.SanPhams.Remove(sp);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
