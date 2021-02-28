using Example.Core.Model;
using System;
using System.Linq;

namespace Example.Data.Repository
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(ExampleDbContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public User GetUserById(Guid userId)
        {
            return FindByCondition(user => user.Id.Equals(userId))
                .FirstOrDefault();
        }
    }
}
