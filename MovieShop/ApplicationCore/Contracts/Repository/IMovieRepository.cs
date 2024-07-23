﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ApplicationCore.Entities;
using ApplicationCore.Models;

namespace ApplicationCore.Contracts.Repository
{
    public interface IMovieRepository : IAsyncRepository<Movie>
    {
        Task<List<Movie>> GetHighestGrossingMovies();
        Task<IEnumerable<Movie>> GetTopRatedMovies();
        Task<List<Movie>> GetMoviesByGenre(int id);
        Task<Movie> GetMovieReviews(int id);
        Task<List<Movie>> GetMoviesCast();
        

    }
}