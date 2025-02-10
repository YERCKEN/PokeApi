using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;


// Añadimos el servicio de del client
using PokeApi.Client.Services;


var builder = WebAssemblyHostBuilder.CreateDefault(args);

// Registra los servicios de MudBlazor
builder.Services.AddMudServices();

// Registrar el servicio de la API
builder.Services.AddScoped<PokeApiClientService>();


await builder.Build().RunAsync();
