using Example.Data.Repository;
using System.Threading.Tasks;

namespace Example.Data
{
    public interface IRepositoryWrapper
    {
        IUserRepository User { get; }

        Task SaveAsync();
    }
}
