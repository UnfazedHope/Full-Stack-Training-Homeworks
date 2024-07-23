using ApplicationCore.Entities;
using ApplicationCore.Models;
using ApplicationCore.Contracts.Repository;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(MovieShopDbContext dbContext) : base(dbContext)
        {

        }

        
    }

}
