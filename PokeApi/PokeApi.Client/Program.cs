using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

// Añadimos el servicio de del client
using PokeApi.Client.Services;


var builder = WebAssemblyHostBuilder.CreateDefault(args);

// Registrar el servicio de la API
builder.Services.AddScoped<PokeApiClientService>();


await builder.Build().RunAsync();
