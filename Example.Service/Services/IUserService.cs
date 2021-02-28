using Example.Core.Dto;
using Example.Core.Model;
using System;
using System.Threading.Tasks;

namespace Example.Service.Services
{
    public interface IUserService
    {
        Task<UserDto> GetUser(Guid userId);

        Task<ListUserDto> ListUsers();

        Task<Guid> CreateUser(CreateUserDto user);
    }
}
