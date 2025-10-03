using WebBanHang.Models;
using Microsoft.AspNetCore.Mvc;
using WebBanHang.Repository;
namespace WebBanHang.ViewComponents
{
        public class LoaiSpMenuViewComponent : ViewComponent
        {
            private readonly ILoaiSanPhamRepository _loaiSp;

            public LoaiSpMenuViewComponent(ILoaiSanPhamRepository loaiSpRepository)
            {
                _loaiSp = loaiSpRepository;
            }

            public IViewComponentResult Invoke()
            {
                var loaisp = _loaiSp.GetAllLoaiSp().OrderBy(x => x.Loai);
                return View(loaisp);
            }
        }
    

}
