using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationCore.Entities;
using ApplicationCore.Contracts.Repository;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class PurchaseRepository : BaseRepository<Purchase>, IPurchaseRepository
    {
        public PurchaseRepository(MovieShopDbContext dbContext) : base(dbContext)
        {
        }
    }
}
