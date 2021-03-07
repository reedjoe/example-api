using Example.Core.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Example.Data.Repository
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(ExampleDbContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public async Task<User> GetUserByIdAsync(Guid userId)
        {
            return await FindByCondition(user => user.Id.Equals(userId))
                .FirstOrDefaultAsync();
        }

        public async Task<List<User>> FindAllAsync()
        {
            return await FindAll()
                .ToListAsync();
        }
    }
}
