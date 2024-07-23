using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Contracts.Repository
{
    public interface ICastRepository : IAsyncRepository<Cast>
    {
        Task<List<Cast>> GetCastDetails();
    }
}
