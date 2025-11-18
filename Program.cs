using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WebApp.DAL;
using WebApp.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//DIP
builder.Services.AddDbContext<HospitalDB>(options =>
         options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

//builder.Services.AddDefaultIdentity<Member>(options => options.SignIn.RequireConfirmedAccount = true)
//    .AddEntityFrameworkStores<HospitalDB>();


//builder.Services.AddDefaultIdentity<Member>(options => options.SignIn.RequireConfirmedAccount = true)
//    .AddEntityFrameworkStores<KutuphaneDB>();

//Varsay�lan Identity ayarlar� i�in kullan�l�r
//builder.Services.AddDefaultIdentity<IdentityUser>().AddEntityFrameworkStores<KutuphaneDB>();

builder.Services.AddIdentity<Member, Role>().AddEntityFrameworkStores<HospitalDB>();


builder.Services.AddMvc();

var app = builder.Build();

// Seed roles
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    await SeedRolesAsync(services);
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
      name: "Admin",
      pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
    );
});

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
      name: "Member",
      pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
    );
});

app.Use(async (context, next) =>
{
    await next.Invoke();
    if (context.Response.StatusCode == StatusCodes.Status404NotFound)
    {
        context.Response.Redirect("/Identity/Account/Login");
    }
});

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();
app.Run();



async Task SeedRolesAsync(IServiceProvider serviceProvider)
{
    var roleManager = serviceProvider.GetRequiredService<RoleManager<Role>>();
    string[] roleNames = { "Member", "Admin" };

    foreach (var roleName in roleNames)
    {
        if (!await roleManager.RoleExistsAsync(roleName))
        {
            await roleManager.CreateAsync(new Role { Name = roleName });
        }
    }
}
