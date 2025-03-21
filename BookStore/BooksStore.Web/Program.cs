using BooksStore.Web.Context;
using BooksStore.Web.Repository;
using BooksStore.Web.Repository.Abstract;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<InventoryContext>(context =>
    context.UseNpgsql(builder.Configuration.GetConnectionString("BookStoreDb")));
builder.Services.AddTransient<IInventoryRepository, InventoryRepository>();

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
