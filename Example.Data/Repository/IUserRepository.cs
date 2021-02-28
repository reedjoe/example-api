using Example.Core.Model;
using System;

namespace Example.Data.Repository
{
    public interface IUserRepository : IRepositoryBase<User>
    {
        User GetUserById(Guid userId);
    }
}
