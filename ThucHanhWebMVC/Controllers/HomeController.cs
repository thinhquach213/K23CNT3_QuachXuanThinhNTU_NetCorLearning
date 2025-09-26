using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using ThucHanhWebMVC.Models;
using X.PagedList;

namespace ThucHanhWebMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly QLBanVaLiContext _db;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, QLBanVaLiContext db)
        {
            _logger = logger;
            _db = db;
        }

        // Trang chủ: danh sách sản phẩm phân trang
        public IActionResult Index(int? page)
        {
            int pageSize = 8;
            int pageNumber = page ?? 1;

            var lstsanpham = _db.TDanhMucSps
                                .AsNoTracking()
                                .OrderBy(x => x.TenSp)
                                .ToPagedList(pageNumber, pageSize);

            return View(lstsanpham);
        }

        // Lọc sản phẩm theo loại
        public IActionResult SanPhamTheoLoai(string maloai, int? page)
        {
            int pageSize = 8;
            int pageNumber = page ?? 1;

            var lstsanpham = _db.TDanhMucSps
                                .AsNoTracking()
                                .Where(x => x.MaLoai == maloai)
                                .OrderBy(x => x.TenSp)
                                .ToPagedList(pageNumber, pageSize);

            // giữ lại mã loại để phân trang không bị mất
            ViewBag.maloai = maloai;

            return View(lstsanpham);
        }

   
        public IActionResult ChiTietSanPham(string maSp)
        {
            var sanPham=_db.TDanhMucSps.SingleOrDefault(x => x.MaSp == maSp);
            var anhSanPham=_db.TAnhSps.Where(x=>x.MaSp == maSp).ToList();
            ViewBag.anhSanPham = anhSanPham;
            return View(sanPham);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
