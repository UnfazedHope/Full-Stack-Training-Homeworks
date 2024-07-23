﻿using ApplicationCore.Entities;
using ApplicationCore.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Contracts.Repository
{
    public interface IGenreRepository : IAsyncRepository<Genre>
    {
        Task<IEnumerable<GenreModel>> GetAllGenres();
    }
}
