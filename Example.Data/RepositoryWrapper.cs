using Example.Data.Repository;
using System.Threading.Tasks;

namespace Example.Data
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private ExampleDbContext _context;
        private IUserRepository _user;

        public IUserRepository User
        {
            get
            {
                if (_user == null)
                {
                    _user = new UserRepository(_context);
                }
                return _user;
            }
        }

        public RepositoryWrapper(ExampleDbContext context)
        {
            _context = context;
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
