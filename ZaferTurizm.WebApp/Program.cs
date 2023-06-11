using System.Diagnostics;
using ZaferTurizm.Business.Services;
using ZaferTurizm.Business.Services.VehicleDefinitionManagers;
using ZaferTurizm.Business.Services.VehicleMakeManagers;
using ZaferTurizm.Business.Services.VehicleModelManagers;
using ZaferTurizm.DataAccess;

var builder = WebApplication.CreateBuilder(args);

Trace.Listeners.Add(new TextWriterTraceListener("error-logs.txt"));
Trace.AutoFlush = true;

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IVehicleMakeService, VehicleMakeService>();
builder.Services.AddTransient<IVehicleModelService, VehicleModelService>();
builder.Services.AddTransient<IVehicleDefinitonService,VehicleDefinitionService>();
builder.Services.AddDbContext<TourDbContext>();
    
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
