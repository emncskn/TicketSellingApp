using System.Diagnostics;
using ZaferTurizm.Business.Services;
using ZaferTurizm.Business.Services.BusScedhuleManagers;
using ZaferTurizm.Business.Services.LocationManager;
using ZaferTurizm.Business.Services.PassengerManager;
using ZaferTurizm.Business.Services.RouteManager;
using ZaferTurizm.Business.Services.TicketManager;
using ZaferTurizm.Business.Services.VehicleDefinitionManagers;
using ZaferTurizm.Business.Services.VehicleMakeManagers;
using ZaferTurizm.Business.Services.VehicleManagers;
using ZaferTurizm.Business.Services.VehicleModelManagers;
using ZaferTurizm.Business.Validator;
using ZaferTurizm.DataAccess;

var builder = WebApplication.CreateBuilder(args);

Trace.Listeners.Add(new TextWriterTraceListener("error-logs.txt"));
Trace.AutoFlush = true;

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IVehicleMakeService, VehicleMakeService>();
builder.Services.AddTransient<IVehicleModelService, VehicleModelService>();

builder.Services.AddTransient<IPassengerService, PassengerService>();
builder.Services.AddTransient<ILocationService, LocationService>();
builder.Services.AddTransient<IVehicleDefinitionService,VehicleDefinitionService>();
builder.Services.AddTransient<IBusScedhuleService,BusScedhuleService>();
builder.Services.AddTransient<IRouteService,RouteService>();
builder.Services.AddTransient<IVehicleService,VehicleService>();
builder.Services.AddTransient<ITicketService,TicketService>();
builder.Services.AddTransient<BusScedhuleValidator>();
builder.Services.AddTransient<TicketValidator>();
builder.Services.AddTransient(typeof(GenericValidator<>));
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
