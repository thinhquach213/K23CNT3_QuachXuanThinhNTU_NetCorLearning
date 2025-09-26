using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using WebBanHang.Models;
using WebBanHang.ViewModels;
using X.PagedList;

namespace WebBanHang.Controllers
{
    public class HomeController : Controller
    {
        private readonly QlbanHangContext _db;
        private readonly ILogger<HomeController> _logger;

        
        public HomeController(QlbanHangContext db, ILogger<HomeController> logger)
        {
            _db = db;
            _logger = logger;
        }

        public IActionResult Index(int? page)
        {
            int pageSize = 8;
            int pageNumber = (page == null || page < 1) ? 1 : page.Value;
            var lstsanpham = _db.TDanhMucSps
                                .AsNoTracking()
                                .OrderBy(x => x.TenSp)
                                .ToPagedList(pageNumber, pageSize);

            return View(lstsanpham); 
        }
        public IActionResult SanPhamTheoLoai(string maloai, int? page)
        {
            int pageSize = 8;
            int pageNumber = page == null || page < 1 ? 1 : page.Value;
            var lstsanpham = _db.TDanhMucSps.AsNoTracking()
                                .Where(x => x.MaLoai == maloai)
                                .OrderBy(x => x.TenSp);
            PagedList<TDanhMucSp> lst = new PagedList<TDanhMucSp>(lstsanpham, pageNumber, pageSize);
            ViewBag.maloai=maloai;
            return View(lst);
        }
        public IActionResult ChiTietSanPham(string maSp)
        {
            var sanPham = _db.TDanhMucSps.SingleOrDefault(x => x.MaSp == maSp);
            var anhSanPham = _db.TAnhSps.Where(x => x.MaSp == maSp).ToList();
            ViewBag.anhSanPham = anhSanPham;
            return View(sanPham);
        }
        public IActionResult ProductDetail(string maSp)
        {
            var sanPham =_db.TDanhMucSps.SingleOrDefault(x => x.MaSp == maSp);
            var anhSanPham =_db.TAnhSps.Where(x => x.MaSp == maSp).ToList();
            var homeProductDetailViewModel = new HomeProductDetailViewModel
            {
                danhMucSp = sanPham,
                anhSps = anhSanPham
            };
            return View(homeProductDetailViewModel);
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
