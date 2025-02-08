using PokeApi.Client.Pages;

using PokeApi.Components;
using PokeApi.Services;

// Añadimos los servicios del proyecto compartido (para utilizar las interfaces)
using PokeApi.Shared.Services;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents();

// AÑADIMOS EL SERVICIO DE POKEMON --------------------------------------------------------------------------------------
// AddTransient = Crea una nueva instancia del servicio cada vez que se solicita (RECOMENDABLE APIS EXTERNAS)
// AddScoped = Crea una instancia por sesión del usuario

// SERVICIO QUE envía 10 números en un vector (para test)
builder.Services.AddScoped<INumbersServicesShared, NumbersServices>();
// SERVICIO QUE envía 100 pokemones
builder.Services.AddScoped<IPokeApiServiceShared, PokeApiService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(PokeApi.Client._Imports).Assembly);

app.Run();
