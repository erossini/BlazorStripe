using Blazored.SessionStorage;
using BlazorStripeConnect.Client;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Stripe;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddBlazoredSessionStorage();

#region Read configuration

var configuration = builder.Configuration;
var env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

configuration
    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
    .AddJsonFile($"appsettings.{env}.json", true, true);

#endregion Read configuration

string? stripeKey = builder.Configuration["Stripe:ApiKey"];
string? stripeClientId = builder.Configuration["Stripe:ClientId"];
StripeConfiguration.ApiKey = stripeKey;
StripeConfiguration.ClientId = stripeClientId;

await builder.Build().RunAsync();