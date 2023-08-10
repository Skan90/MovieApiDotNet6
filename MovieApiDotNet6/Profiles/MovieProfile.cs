using AutoMapper;
using MovieApiDotNet6.Data.Dtos;
using MovieApiDotNet6.Models;

namespace MovieApiDotNet6.Profiles;

public class MovieProfile : Profile
{
    public MovieProfile()
    {
        CreateMap<CreateMovieDto, Movie>();
        CreateMap<UpdateMovieDto, Movie>();
        CreateMap<Movie, UpdateMovieDto>();
        CreateMap<Movie, ReadMovieDto>();
    }
    
}
