using ThucHanhWebMVC.Models;

namespace ThucHanhWebMVC.Repository
{
    public interface ILoaiSpRepository
    {
        TLoaiSp Add(TLoaiSp loaiSp);
        TLoaiSp Update(TLoaiSp loaiSp);
        TLoaiSp Delete(string maloaiSp);   
        TLoaiSp GetLoaiSp(string maloaiSp); // sửa lại để truyền mã loại
        IEnumerable<TLoaiSp> GetAllLoaiSp();
    }
}
