using Microsoft.EntityFrameworkCore;
using WebServerFinalProject.Data;  // Make sure to import the namespace for ApplicationDbContext
using WebServerFinalProject.Service;
using WebServerFinalProject.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Add DbContext configuration for Entity Framework Core with SQL Server
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);

// builder.Services.AddAuthentication(options => { /* Authentication configuration */ });
// builder.Services.AddLogging();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

// Enable authorization if you're using authentication/authorization
app.UseAuthorization();

// Map static assets
app.MapStaticAssets();

// Enable static files (for serving CSS, JS, images, etc.)
app.UseStaticFiles();

// Map the default controller route
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

app.Run();
