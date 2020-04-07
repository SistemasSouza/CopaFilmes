using Microsoft.Extensions.DependencyInjection;

namespace CopaFilmes.Api.Configuration
{
    public static class ApiConfig
    {
        public static IServiceCollection WebApiConfig(this IServiceCollection services)
        {
            services.AddMvc(option => option.EnableEndpointRouting = false);
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "frontend/build";
            });


            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", builder => builder
                    .AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader());
            });
            return services;
        }
    }
}
