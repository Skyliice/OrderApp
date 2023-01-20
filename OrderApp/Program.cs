using Microsoft.EntityFrameworkCore;
using OrderApp;
using OrderApp.Interfaces;
using OrderApp.Models;
using OrderApp.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<OrderDb>(options => options.UseSqlite("Filename=OrderDb.db"));
builder.Services.AddTransient<IOrderConnection,OrderSQLiteRepository>();

var app = builder.Build();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/");

app.Run();