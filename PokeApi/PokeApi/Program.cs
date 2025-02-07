using PokeApi.Client.Pages;

using PokeApi.Components;
using PokeApi.Services;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents();

// AÑADIMOS EL SERVICIO DE POKEMON
// AddTransient = Crea una nueva instancia del servicio cada vez que se solicita (RECOMENDABLE APIS EXTERNAS)
// AddScoped = Crea una instancia por sesión del usuario

builder.Services.AddTransient< PokeApiService>();


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
