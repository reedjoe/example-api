using Example.Data.Repository;

namespace Example.Data
{
    public interface IRepositoryWrapper
    {
        IUserRepository User { get; }

        void Save();
    }
}
