using Ardalis.ListStartupServices;

namespace IdentityService.Web.Configurations
{
    public static class MiddlewareConfigs
    {
        public static async Task<IApplicationBuilder> UseAppMiddlewareAndSeedData(this WebApplication app)
        {
            if(app.Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseShowAllServicesMiddleware();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            return app;
        }
    }
}
