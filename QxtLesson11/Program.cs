using Microsoft.EntityFrameworkCore;
using QxtLesson11.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// ✅ Cấu hình DbContext TRƯỚC KHI gọi builder.Build()
builder.Services.AddDbContext<QuachXuanThinh2210900088Context>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Configure the HTTP request pipeline.
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
    pattern: "{controller=QxtHome}/{action=QxtIndex}/{id?}");

app.Run();
