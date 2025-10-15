using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using PhuKienTDAStore.Models;
using PhuKienTDAStore.Helpers;
using System.Collections.Generic;

namespace PhuKienTDAStore.Controllers
{
    [Authorize]
    public class CartController : Controller
    {
        private readonly PhuKienTdastoreContext _context;
        private const string CARTKEY = "GioHang";

        public CartController(PhuKienTdastoreContext context)
        {
            _context = context;
        }

        [AllowAnonymous]
        public IActionResult Index()
        {
            var cart = HttpContext.Session.GetObject<List<CartItem>>(CARTKEY) ?? new List<CartItem>();
            return View(cart);
        }

        public async Task<IActionResult> AddToCart(int maSp, int soLuong = 1)
        {
            var sp = await _context.SanPhams.FindAsync(maSp);
            if (sp == null) return NotFound();

            var cart = HttpContext.Session.GetObject<List<CartItem>>(CARTKEY) ?? new List<CartItem>();
            var item = cart.FirstOrDefault(c => c.MaSp == maSp);

            if (item != null)
                item.SoLuong += soLuong;
            else
                cart.Add(new CartItem
                {
                    MaSp = sp.MaSp,
                    TenSp = sp.TenSp,
                    Gia = sp.Gia,
                    SoLuong = soLuong
                });

            HttpContext.Session.SetObject(CARTKEY, cart);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Remove(int maSp)
        {
            var cart = HttpContext.Session.GetObject<List<CartItem>>(CARTKEY) ?? new List<CartItem>();
            cart.RemoveAll(c => c.MaSp == maSp);
            HttpContext.Session.SetObject(CARTKEY, cart);
            return RedirectToAction(nameof(Index));
        }

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

            var email = HttpContext.Session.GetString("UserEmail");
            if (string.IsNullOrEmpty(email))
                return RedirectToAction("DangNhap", "Auth", new { returnUrl = Url.Action(nameof(Index), "Cart") });

            var kh = await _context.KhachHangs.AsNoTracking().FirstOrDefaultAsync(k => k.Email == email);
            if (kh == null)
            {
                TempData["Err"] = "Tài khoản khách hàng không hợp lệ.";
                return RedirectToAction(nameof(Index));
            }

            await using var tx = await _context.Database.BeginTransactionAsync();
            try
            {
                var donHang = new DonHang
                {
                    MaKh = kh.MaKh,
                    NgayDat = DateTime.Now,
                    TrangThai = "Chờ xử lý",
                    TongTien = 0
                };

                _context.DonHangs.Add(donHang);
                await _context.SaveChangesAsync();

                decimal tong = 0;
                foreach (var item in cart)
                {
                    var sp = await _context.SanPhams.AsNoTracking().FirstOrDefaultAsync(s => s.MaSp == item.MaSp);
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
                        MaDh = donHang.MaDh,
                        MaSp = item.MaSp,
                        SoLuong = item.SoLuong,
                        Gia = giaBan
                    });
                }

                donHang.TongTien = tong;
                await _context.SaveChangesAsync();
                await tx.CommitAsync();

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
