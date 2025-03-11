using Blazored.SessionStorage;
using CRMFronted;
using CRMFronted.Extensiones;
using CRMFronted.Servicios;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7053/") });
builder.Services.AddScoped<AuthenticationStateProvider, AutenticacionExtension>();
builder.Services.AddBlazoredSessionStorage();
builder.Services.AddAuthorizationCore();
builder.Services.AddScoped<IServiciosClientes, ServiciosClientes>();
builder.Services.AddScoped<IServiciosCategorias, ServiciosCategorias>();
builder.Services.AddScoped<IServiciosContactos, ServiciosContactos>();
builder.Services.AddScoped<IServiciosDetalleVenta, ServiciosDetalleVentas>();
builder.Services.AddScoped<IServiciosOportunidadVenta, ServiciosOportunidadVenta>();
builder.Services.AddScoped<IServiciosProductos, ServiciosProductos>();
builder.Services.AddScoped<IServiciosUsuarios, ServiciosUsuarios>();

await builder.Build().RunAsync();
