using Example.Data.Repository;

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

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
