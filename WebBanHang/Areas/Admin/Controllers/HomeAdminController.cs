using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebBanHang.Models;
using X.PagedList;

namespace WebBanHang.Controllers
{
    [Area("admin")]
    [Route("admin")]
    [Route("admin/homeadmin")]
    public class HomeAdminController : Controller
    {
        private readonly QlbanHangContext _db;

        public HomeAdminController(QlbanHangContext db)
        {
            _db = db;
        }
        [Route("")]
        [Route("index")]
        public IActionResult Index()
        {
            return View();
        }
        [Route("danhmucsanpham")]
        public IActionResult DanhMucSanPham(int? page)
        {
            int pageSize = 12;
            int pageNumber = page ?? 1; // Nếu page là null thì gán bằng 1
            var lstsanpham =_db.TDanhMucSps.AsNoTracking().OrderBy(x => x.TenSp);
            // Sử dụng ToPagedList từ X.PagedList
            IPagedList<TDanhMucSp> lst = lstsanpham.ToPagedList(pageNumber, pageSize);
            return View(lst);
        }
    }
}
