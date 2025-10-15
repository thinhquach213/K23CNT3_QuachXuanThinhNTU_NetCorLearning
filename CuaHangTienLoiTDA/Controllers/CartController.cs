using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using CuaHangTienLoiTDA.Models;
using CuaHangTienLoiTDA.Helpers; // SessionExtensions

namespace CuaHangTienLoiTDADKT.Controllers
{
    [Authorize] // Yêu cầu đăng nhập cho mọi action trừ những action có [AllowAnonymous]
    public class CartController : Controller
    {
        private readonly CuaHangTienLoiTDAContext _context;
        private const string CARTKEY = "GioHang";

        public CartController(CuaHangTienLoiTDAContext context)
        {
            _context = context;
        }

        // =========================
        // Xem giỏ hàng
        // =========================
        [AllowAnonymous]
        public IActionResult Index()
        {
            var cart = HttpContext.Session.GetObject<List<CartItem>>(CARTKEY) ?? new List<CartItem>();
            return View(cart);
        }

        // =========================
        // Thêm sản phẩm vào giỏ
        // =========================
        public async Task<IActionResult> AddToCart(int maSp, int soLuong = 1)
        {
            var sp = await _context.SanPhams.FindAsync(maSp);
            if (sp == null) return NotFound();

            var cart = HttpContext.Session.GetObject<List<CartItem>>(CARTKEY) ?? new List<CartItem>();
            var item = cart.FirstOrDefault(c => c.MaSp == maSp);

            if (item != null)
            {
                item.SoLuong += soLuong;
            }
            else
            {
                cart.Add(new CartItem
                {
                    MaSp = sp.MaSP,
                    TenSp = sp.TenSP,
                    Gia = sp.Gia,
                    SoLuong = soLuong
                });
            }

            HttpContext.Session.SetObject(CARTKEY, cart);
            return RedirectToAction(nameof(Index));
        }

        // =========================
        // Xóa sản phẩm khỏi giỏ
        // =========================
        public IActionResult Remove(int maSp)
        {
            var cart = HttpContext.Session.GetObject<List<CartItem>>(CARTKEY) ?? new List<CartItem>();
            cart.RemoveAll(c => c.MaSp == maSp);
            HttpContext.Session.SetObject(CARTKEY, cart);
            return RedirectToAction(nameof(Index));
        }

        // =========================
        // Đặt hàng
        // =========================
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DatHang()
        {
            var cart = HttpContext.Session.GetObject<List<CartItem>>(CARTKEY);
            if (cart == null || cart.Count == 0)
            {
                TempData["Err"] = "Giỏ hàng trống!";
                return RedirectToAction(nameof(Index));
            }

            // Lấy email từ session
            var email = HttpContext.Session.GetString("UserEmail");
            if (string.IsNullOrEmpty(email))
            {
                // Chưa login -> về trang đăng nhập
                return RedirectToAction("DangNhap", "Auth", new { returnUrl = Url.Action(nameof(Index), "Cart") });
            }

            // Tìm khách hàng theo email
            var kh = await _context.KhachHangs.AsNoTracking().FirstOrDefaultAsync(k => k.Email == email);
            if (kh == null)
            {
                TempData["Err"] = "Tài khoản khách hàng không hợp lệ.";
                return RedirectToAction(nameof(Index));
            }

            await using var tx = await _context.Database.BeginTransactionAsync();
            try
            {
                // Tạo đơn hàng
                var donHang = new DonHang
                {
                    MaKH = kh.MaKH,
                    NgayDat = DateTime.Now,
                    TrangThai = "Chờ xử lý",
                    TongTien = 0
                };

                _context.DonHangs.Add(donHang);
                await _context.SaveChangesAsync(); // có MaDH

                decimal tong = 0;

                foreach (var item in cart)
                {
                    // Lấy giá từ DB để chống sửa giá
                    var sp = await _context.SanPhams.AsNoTracking().FirstOrDefaultAsync(s => s.MaSP == item.MaSp);
                    if (sp == null)
                    {
                        await tx.RollbackAsync();
                        TempData["Err"] = $"Sản phẩm {item.MaSp} không tồn tại.";
                        return RedirectToAction(nameof(Index));
                    }

                    var giaBan = sp.Gia;
                    tong += giaBan * item.SoLuong;

                    _context.ChiTietDonHangs.Add(new ChiTietDonHang
                    {
                        MaDH = donHang.MaDH,  // ⚡ CHÚ Ý: đúng tên property EF scaffold
                        MaSP = item.MaSp,
                        SoLuong = item.SoLuong,
                        Gia = giaBan
                    });
                }

                donHang.TongTien = tong;
                await _context.SaveChangesAsync();
                await tx.CommitAsync();

                // Xóa giỏ
                HttpContext.Session.Remove(CARTKEY);

                TempData["Ok"] = "Đặt hàng thành công!";
                return RedirectToAction(nameof(ThongBaoDatHangThanhCong));
            }
            catch
            {
                await tx.RollbackAsync();
                throw;
            }
        }

        public IActionResult ThongBaoDatHangThanhCong() => View();
    }
}
