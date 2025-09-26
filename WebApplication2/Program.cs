using Microsoft.EntityFrameworkCore;
using WebApplication2.Models;


var builder = WebApplication.CreateBuilder(args);

// ✅ Thêm cấu hình kết nối DbContext
builder.Services.AddDbContext<NctusContext>(options =>
    options.UseSqlServer("Server=LAPTOP-AGRHRR3H\\MSSQLSERVER01;Database=Nctus;Trusted_Connection=True;MultipleActiveResultSets=True;TrustServerCertificate=True"));

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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=CtusHome}/{action=CtusIndex}/{Ctusid?}");

app.Run();
