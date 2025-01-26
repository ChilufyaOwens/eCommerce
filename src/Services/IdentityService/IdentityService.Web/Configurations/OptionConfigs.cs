
namespace IdentityService.Web.Configurations
{
    public static class OptionConfigs
    {
        public static IServiceCollection AddOptionConfigs(this IServiceCollection services,
            IConfiguration configuration,
            Microsoft.Extensions.Logging.ILogger logger,
            WebApplicationBuilder builder)
        {
            if (builder.Environment.IsDevelopment())
            {
                services.Configure<ServiceConfig>(config =>
                {
                    config.Services = new List<ServiceDescriptor>(builder.Services);

                    config.Path = "/_startup/services";
                });
            }
            return services;
        }
    }
}
