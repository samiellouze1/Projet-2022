using Microsoft.EntityFrameworkCore;
using Projet_2022.Data;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddMvc().AddRazorRuntimeCompilation();
builder.Services.AddDbContext<AppDbContext>(option => option.UseLazyLoadingProxies().UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseSession();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Product}/{action=AllProducts}/{id?}");
AppDbInitializer.SeedUsersAndRolesAsync(app).Wait();

app.Run();
