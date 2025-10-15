using Microsoft.EntityFrameworkCore;
using TapHoaTDA.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<TapHoaTDAContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DbConnect")));

builder.Services.AddControllersWithViews();

var app = builder.Build();

app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "areas",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
