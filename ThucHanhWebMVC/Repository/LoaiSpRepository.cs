using ThucHanhWebMVC.Models;

namespace ThucHanhWebMVC.Repository
{
    public class LoaiSpRepository : ILoaiSpRepository
    {
        private readonly QLBanVaLiContext _context;

        public LoaiSpRepository(QLBanVaLiContext context) // sửa private -> public constructor
        {
            _context = context;
        }

        public TLoaiSp Add(TLoaiSp entity)
        {
            _context.TLoaiSps.Add(entity);
            _context.SaveChanges();
            return entity;
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
            return _context.TLoaiSps.ToList();
        }

        public TLoaiSp GetLoaiSp(string maloaiSp)
        {
            return _context.TLoaiSps.Find(maloaiSp);
        }

        public TLoaiSp Update(TLoaiSp loaiSp)
        {
            _context.TLoaiSps.Update(loaiSp);
            _context.SaveChanges();
            return loaiSp;
        }
    }
}
