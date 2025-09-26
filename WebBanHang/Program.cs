using Microsoft.EntityFrameworkCore;
using WebBanHang.Models;
using WebBanHang.Repository;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("DbConnect");

// Đăng ký DbContext
builder.Services.AddDbContext<QlbanHangContext>(x => x.UseSqlServer(connectionString));

// Đăng ký Repository
builder.Services.AddScoped<ILoaiSanPhamRepository, LoaiSpRepository>();

// ✅ Đăng ký Authorization
builder.Services.AddAuthorization();

// Nếu có dùng Controller + View
builder.Services.AddControllersWithViews();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

// Middleware Authorization
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
