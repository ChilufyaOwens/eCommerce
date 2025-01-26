using System.Reflection;

namespace IdentityService.Web.Configurations
{
    public static class MediatrConfigs
    {
        public static IServiceCollection AddMediatrConfigs(this IServiceCollection services)
        {
            var mediatrAssemblies = new[]
            {
                Assembly.GetAssembly(typeof(Startup)), // Core
                Assembly.GetAssembly(typeof(IdentityService.Web.Startup)), // Application
            };

            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(mediatrAssemblies!))
                .AddScoped(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>))
                .AddScoped<IDomainEventDispatcher, MediatRDomainEventDispatcher>();

            return services;
        }
    }
}
