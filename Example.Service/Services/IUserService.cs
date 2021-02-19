using Example.Core.Dto;
using System.Threading.Tasks;

namespace Example.Service.Services
{
    public interface IUserService
    {
        Task<ListUserDto> ListUsersAsync();
    }
}
