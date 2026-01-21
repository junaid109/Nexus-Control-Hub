using Microsoft.EntityFrameworkCore;
using NexusControl.Infrastructure.Data;
using NexusControl.Web.Hubs;
using Microsoft.Extensions.Hosting; // Ensure namespace is available just in case

var builder = WebApplication.CreateBuilder(args);
builder.AddServiceDefaults(); // Add ServiceDefaults

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddSignalR(); 

// Register Infrastructure Services
builder.Services.AddScoped<NexusControl.Core.Interfaces.IBlobStorageService>(provider => 
{
    var env = provider.GetRequiredService<IWebHostEnvironment>();
    return new NexusControl.Infrastructure.Services.LocalBlobStorageService(env.WebRootPath);
});

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

app.MapDefaultEndpoints(); // Map Default Endpoints

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();
app.MapHub<DashboardHub>("/dashboardHub");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

app.Run();

