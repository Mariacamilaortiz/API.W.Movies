using API.W.Movies.DAL.Models;
using API.W.Movies.DAL.Models.Dtos;
using AutoMapper;

namespace API.W.Movies.MoviesMapper
{
    public class MovieMapper : Profile
    {
        public MovieMapper()
        {
            CreateMap<Movie, MovieDto>().ReverseMap();
            CreateMap<Movie, MovieCreateUpdateDto>().ReverseMap();
        }
    }
}
