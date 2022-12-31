using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.JSInterop;
using System.Globalization;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

var config = builder.Configuration;

IConfigurationRoot configurationRoot = config.Build();

WebShopConfiguration configuration = new();
configurationRoot.GetSection("WebShopConfiguration")
                 .Bind(configuration);

builder.Services.AddSingleton(configuration);
builder.Services.AddBlazoredLocalStorageAsSingleton();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddHttpClient();
builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthStateProvider>();
builder.Services.AddSingleton<IApiService, ApiService>();
builder.Services.AddSingleton<UserState>();

var host = builder.Build();

IJSRuntime jsRuntime = host.Services.GetRequiredService<IJSRuntime>();

string language = await jsRuntime.InvokeAsync<string>("getLanguage");

Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo(language);

await host.RunAsync();
