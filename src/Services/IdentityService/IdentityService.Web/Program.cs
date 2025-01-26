using IdentityService.Web.Configurations;

var builder = WebApplication.CreateBuilder(args);
{
    var logger = Log.Logger = new LoggerConfiguration()
        .Enrich.FromLogContext()
        .WriteTo.Console()
        .CreateLogger();

    logger.Information("Starting up Identity Service");

    builder.AddLoggerConfigs();

    var appLogger = new SerilogLoggerFactory(logger)
        .CreateLogger<Program>();

    builder.Services.AddOptionConfigs(builder.Configuration, appLogger, builder);
    builder.Services.AddServiceConfigs(appLogger, builder);

    // Add services to the container.

    builder.Services.AddControllers();
    // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
    builder.Services.AddOpenApi();

    builder.AddServiceDefaults();
}

// Build Identity Service  Web Application.
var app = builder.Build();
{
    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.MapOpenApi();
    }

    app.UseHttpsRedirection();

    // Routing
    app.UseRouting();

    // Auth
    app.UseAuthentication();

    app.UseAuthorization();

    app.MapControllers();

    app.Run();
}


