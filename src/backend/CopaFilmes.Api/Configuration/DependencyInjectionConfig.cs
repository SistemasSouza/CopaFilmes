using AutoMapper;
using CopaFilme.Business.Interfaces;
using CopaFilme.Business.Services;
using CopaFilmes.Data.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace CopaFilmes.Api.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(Startup));
            services.AddScoped<IMoviesRepository, MoviesRepository>();
            services.AddScoped<IMoviesService, MoviesService>();

            return services;
        }
    }
}
