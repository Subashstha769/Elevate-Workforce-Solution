using Microsoft.AspNetCore.Authentication.Cookies;
using WebLab2024;
using WebLab2024.Interfaces;
using WebLab2024.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<AppDbContext>();

builder.Services.AddScoped<IUserRepository,UserRepository>();

builder.Services.AddScoped<IJobRepository,JobRepository>();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie
(options =>
{

options.Cookie.Name = "auth";
options.ExpireTimeSpan = TimeSpan.FromMinutes(30);
options.LoginPath = "/User/Login";
options.AccessDeniedPath = "/Home/Error";

}

);






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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
