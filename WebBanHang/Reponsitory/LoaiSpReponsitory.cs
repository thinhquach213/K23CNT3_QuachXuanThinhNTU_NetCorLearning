using WebBanHang.Models;
 
using WebBanHang.Repository;

namespace WebBanHang.Repository
{
    public class LoaiSpRepository : ILoaiSanPhamRepository
    {
        private readonly QlbanHangContext _context;

        public LoaiSpRepository(QlbanHangContext context)
        {
            _context = context;
        }

        public TLoaiSp Add(TLoaiSp loaiSp)
        {
            _context.TLoaiSps.Add(loaiSp);
            _context.SaveChanges();
            return loaiSp;
        }

        public TLoaiSp Delete(string maloaiSp)
        {
            var loaiSp = _context.TLoaiSps.Find(maloaiSp);
            if (loaiSp != null)
            {
                _context.TLoaiSps.Remove(loaiSp);
                _context.SaveChanges();
            }
            return loaiSp;
        }

        public IEnumerable<TLoaiSp> GetAllLoaiSp()
        {
            return _context.TLoaiSps;
        }

        public TLoaiSp GetLoaiSp(string maloaiSp)
        {
            return _context.TLoaiSps.Find(maloaiSp);
        }

        public TLoaiSp Update(TLoaiSp loaiSp)
        {
            _context.Update(loaiSp);
            _context.SaveChanges();
            return loaiSp;
        }
    }
}
