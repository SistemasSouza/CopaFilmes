using AutoMapper;
using CopaFilme.Business.Model;
using CopaFilmes.Api.ViewModels;

namespace CopaFilmes.Api.Configuration
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<Movies, MoviesViewModel>().ReverseMap();
        }
    }
}
