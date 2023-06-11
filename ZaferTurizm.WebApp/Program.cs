using System.Diagnostics;
using ZaferTurizm.Business.Services;
using ZaferTurizm.DataAccess;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

Trace.Listeners.Add(new TextWriterTraceListener("error-logs.tx"));
Trace.AutoFlush = true;

var services = builder.Services;
services.AddTransient<IVehicleMakeService,VehicleMakeService >();
services.AddTransient<IVehicleModelService,VehicleModelService >();
services.AddTransient<IVehicleDefinitionService,VehicleDefinitionService >();
services.AddDbContext<TourDbContext>();

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
