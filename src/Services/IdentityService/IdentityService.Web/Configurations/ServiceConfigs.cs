using IdentityService.Infrastructure;

namespace IdentityService.Web.Configurations
{
    public static class ServiceConfigs
    {
        public static IServiceCollection AddServiceConfigs(
            this IServiceCollection services, 
            Microsoft.Extensions.Logging.ILogger logger, 
            WebApplicationBuilder builder)
        {
            services.AddInfrastructureServices(builder.Configuration, logger)
                .AddMediatrConfigs();

            if(builder.Environment.IsDevelopment())
            {
                // Configure Email and other services for Development environment
            }
            else
            {
                // Register Email and other Service for other environments

            }

            logger.LogInformation("{Project} services registered", "Mediatr and Email");

            return services;
        }
    }
}
