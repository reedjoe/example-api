using Example.Core.Dto;
using System;
using System.Threading.Tasks;

namespace Example.Service.Services
{
    public interface IUserService
    {
        Task<ListUserDto> ListUsers();

        Task<Guid> CreateUser(CreateUserDto user);
    }
}
