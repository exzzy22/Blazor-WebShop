var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

Console.WriteLine(builder.HostEnvironment.Environment);

var config = builder.Configuration;

IConfigurationRoot configurationRoot = config.Build();

WebShopConfiguration configuration = new();
configurationRoot.GetSection("WebShopConfiguration")
                 .Bind(configuration);

builder.Services.AddSingleton(configuration);

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddHttpClient();
builder.Services.AddScoped<IApiService, ApiService>();

await builder.Build().RunAsync();
