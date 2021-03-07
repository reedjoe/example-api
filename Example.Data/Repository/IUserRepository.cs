using Example.Core.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Example.Data.Repository
{
    public interface IUserRepository : IRepositoryBase<User>
    {
        Task<User> GetUserByIdAsync(Guid userId);

        Task<List<User>> FindAllAsync();
    }
}
