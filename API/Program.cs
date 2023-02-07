using Serilog;
using Serilog.Events;

var builder = WebApplication.CreateBuilder(args);

// Configure SeriLog
Log.Logger = new LoggerConfiguration()
				.MinimumLevel.Information()
				.MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
				.MinimumLevel.Override("System", LogEventLevel.Warning)
				.WriteTo.File("wwwroot/logs/log-.log", rollingInterval: RollingInterval.Day)
				.CreateLogger();

builder.Logging.AddSerilog(Log.Logger);
builder.Services.ConfigureSqlContext(builder.Configuration);
builder.Services.Configure<Configuration>(builder.Configuration.GetSection("Configuration"));

// Add services to the container.
builder.Services.AddSingleton<ILoggerManager, LoggerManager>();
builder.Services.AddScoped<IRepositoryManager, RepositoryManager>();
builder.Services.AddScoped<IServiceManager, ServiceManager>();

builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.SuppressModelStateInvalidFilter = true;
});

builder.Services.AddScoped<ValidationFilterAttribute>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddAuthentication();
builder.Services.ConfigureIdentity();
builder.Services.ConfigureJWT(builder.Configuration);
builder.Services.AddJwtConfiguration(builder.Configuration);

builder.Services.AddSwaggerGen();
builder.Services.ConfigureSwagger();

builder.Services.AddHttpContextAccessor();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddCors(options =>
{
	options.AddPolicy("SpecificOrgin",
	policy =>
	{
		policy.WithOrigins(builder.Configuration.GetSection("Configuration").Get<Configuration>().Origins.ToArray())
							.AllowAnyHeader()
							.AllowAnyMethod();
	});
});


var app = builder.Build();

var logger = app.Services.GetRequiredService<ILoggerManager>();
app.ConfigureExceptionHandler(logger);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("SpecificOrgin");

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers().RequireAuthorization();

app.Run();
