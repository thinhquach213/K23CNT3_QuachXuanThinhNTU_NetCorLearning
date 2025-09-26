using WebBanHang.Models;
using Microsoft.AspNetCore.Mvc;
using WebBanHang.Repository;
namespace WebBanHang.ViewComponents
{
        public class LoaiSpMenuViewComponent : ViewComponent
        {
            private readonly ILoaiSanPhamRepository _loaiSpRepository;

            public LoaiSpMenuViewComponent(ILoaiSanPhamRepository loaiSpRepository)
            {
                _loaiSpRepository = loaiSpRepository;
            }

            public IViewComponentResult Invoke()
            {
                var loaisp = _loaiSpRepository.GetAllLoaiSp().OrderBy(x => x.Loai);
                return View(loaisp);
            }
        }
    

}
