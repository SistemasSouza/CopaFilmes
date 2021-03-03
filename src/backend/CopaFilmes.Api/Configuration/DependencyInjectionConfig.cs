using CopaFilmes.Api.Data.Repositories;
using Microsoft.Extensions.DependencyInjection;
using CopaFilmes.Api.Services;

namespace CopaFilmes.Api.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddScoped<IMoviesRepository, MoviesRepository>();
            services.AddScoped<IMoviesService, MoviesService>();

            services.AddScoped<GlobalExceptionHandlingFilter>();

            return services;
        }
    }
}
