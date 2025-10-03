using WebBanHang.Models;

namespace WebBanHang.Repository
{
    public interface ILoaiSanPhamRepository
    {
        TLoaiSp Add(TLoaiSp loaiSp);
        TLoaiSp Update(TLoaiSp loaiSp);
        TLoaiSp? Delete(string maLoaiSp);   
        TLoaiSp? GetLoaiSp(string maLoaiSp);
        IEnumerable<TLoaiSp> GetAllLoaiSp();
    }
}
