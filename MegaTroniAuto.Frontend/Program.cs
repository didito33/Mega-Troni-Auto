using MegaTroniAuto.Frontend.Components;
using MegaTroniAuto.Frontend.Services;
using MudBlazor.Services;

var builder = WebApplication.CreateBuilder(args);

// Razor Components (.NET 8)
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddMudServices();

builder.Services.AddScoped<IVehicleService, VehicleService>();

builder.Services.AddHttpClient("MegaTroniAPI", client =>
{
    client.BaseAddress = new Uri("https://localhost:7262/");
});

builder.Services.AddScoped(sp =>
    sp.GetRequiredService<IHttpClientFactory>().CreateClient("MegaTroniAPI"));

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAntiforgery();

// ✅ Razor Components endpoint (this replaces _Host)
app.MapRazorComponents<App>()
   .AddInteractiveServerRenderMode();

app.Run();