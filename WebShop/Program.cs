using Microsoft.AspNetCore.Components.Authorization;

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

await builder.Build().RunAsync();
