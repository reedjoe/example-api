using Example.Core.Dto;
using Example.Core.Exceptions;
using Example.Core.Model;
using Example.Data;
using Example.Service.Converters;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Example.Service.Services
{
    public class UserService : IUserService
    {
        private readonly IRepositoryWrapper repository;
        private readonly IUserConverter userConverter;

        public UserService(
            IUserConverter userConverter,
            IRepositoryWrapper repository)
        {
            this.userConverter = userConverter;
            this.repository = repository;
        }

        public Task<UserDto> GetUser(Guid userId)
        {
            User user = repository.User.GetUserById(userId);

            if (user == null)
            {
                throw new EntityNotFoundException(nameof(user), userId);
            }

            return Task.FromResult(this.userConverter.ConvertUserToUserDto(user));
        }

        public Task<ListUserDto> ListUsers()
        {
            var users = repository.User.FindAll().ToList();

            return Task.FromResult(this.userConverter.ConvertUserListToDto(users));
        }

        public Task<Guid> CreateUser(CreateUserDto user)
        {
            User userEntity = this.userConverter.ConvertCreateUserDtoToUser(user);
            repository.User.Create(userEntity);
            repository.Save();

            return Task.FromResult(userEntity.Id);
        }
    }
}
