using Example.Core.Model;

namespace Example.Data.Repository
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(ExampleDbContext repositoryContext)
            : base(repositoryContext)
        {
        }
    }
}
