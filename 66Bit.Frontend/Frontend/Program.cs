using Frontend.Api;
using Frontend.Components;
using Frontend.Options;
using HttpClient = Frontend.Core.HttpClient;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddOptions<ApiConnectionOptions>()
    .BindConfiguration(ApiConnectionOptions.SECTION_NAME);

builder.Services.AddHttpClient(HttpClient.Api.ToString(), client =>
{
    var apiConnectionOptions = builder.Configuration
                                   .GetSection(ApiConnectionOptions.SECTION_NAME).Get<ApiConnectionOptions>() ??
                               throw new InvalidOperationException();

    client.BaseAddress = new Uri(apiConnectionOptions.ApiConnectionString);
});
builder.Services.AddScoped<TeamsApi>();
builder.Services.AddScoped<FootballersApi>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
}

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();
app.Run();