using Example.Core.Model;
using Microsoft.EntityFrameworkCore;

namespace Example.Data
{
    public class ExampleDbContext : DbContext
    {
        public ExampleDbContext(DbContextOptions<ExampleDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
    }
}
