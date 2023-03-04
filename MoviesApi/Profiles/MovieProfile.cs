﻿using AutoMapper;
using MoviesApi.Data.Dtos.Movie;
using MoviesApi.Models;

namespace MoviesApi.Profiles;

public class MovieProfile : Profile
{
    public MovieProfile()
    {
        CreateMap<CreateMovieDto, Movie>();
        CreateMap<UpdateMovieDto, Movie>();
        CreateMap<Movie, UpdateMovieDto>();
        CreateMap<Movie, GetMovieDto>();
    }
}