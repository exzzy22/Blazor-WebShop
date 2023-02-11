using Blazored.LocalStorage;
using Shared.ConfigurationModels.Configuration;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

//builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddMudServices();

var config = builder.Configuration;

IConfigurationRoot configurationRoot = config.Build();

WebShopConfiguration configuration = new();
configurationRoot.GetSection("WebShopConfiguration")
                 .Bind(configuration);

builder.Services.AddSingleton(configuration);
builder.Services.AddBlazoredLocalStorageAsSingleton();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddHttpClient();
builder.Services.AddSingleton<IApiService, ApiService>();
builder.Services.AddScoped<AuthenticationStateProvider, CMSAuthStateProvider>();
builder.Services.AddSingleton<UserState>();
builder.Services.AddAuthorizationCore();

await builder.Build().RunAsync();
