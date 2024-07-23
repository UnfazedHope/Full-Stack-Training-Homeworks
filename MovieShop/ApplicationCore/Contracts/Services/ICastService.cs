using ApplicationCore.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Contracts.Services
{
    public interface ICastService
    {
        Task<CastResponseModel> GetMovieByCast(int id);

        Task<CastResponseModel> GetCastById(int id);
    }
}
