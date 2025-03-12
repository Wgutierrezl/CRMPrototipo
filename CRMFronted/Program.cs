using Blazored.SessionStorage;
using CRMFronted;
using CRMFronted.Extensiones;
using CRMFronted.Servicios;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using System.Net.Http.Headers;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7053/") });
builder.Services.AddScoped(async sp =>
{
    var sessionStorage = sp.GetRequiredService<ISessionStorageService>();
    var httpClient = new HttpClient { BaseAddress = new Uri("https://localhost:7053/") };

    var token = await sessionStorage.GetItemAsync<string>("Token");
    if (!string.IsNullOrEmpty(token))
    {
        httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
    }

    return httpClient;
});
builder.Services.AddScoped<AuthenticationStateProvider, AutenticacionExtension>();
builder.Services.AddScoped<AuthService>();
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
