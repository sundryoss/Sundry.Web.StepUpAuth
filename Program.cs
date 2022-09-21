using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Sundry.Web.StepUpAuth;
using Sundry.Web.StepUpAuth.Extension;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

//builder.Services.AddAuth0OidcAuthentication(options =>
//{
//    var authority = builder.Configuration["Auth0:Authority"];
//    var clientId = builder.Configuration["Auth0:ClientId"];
//    options.ProviderOptions.ResponseType = "code";
//    options.ProviderOptions.MetadataSeed.EndSessionEndpoint = $"{authority}/v2/logout?client_id={clientId}&returnTo={builder.HostEnvironment.BaseAddress}";
//});

builder.Services.AddOidcAuthentication(options =>
{
    builder.Configuration.Bind("Auth0", options.ProviderOptions);
    options.ProviderOptions.ResponseType = "code";
});

await builder.Build().RunAsync();
