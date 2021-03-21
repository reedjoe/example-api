using Example.Core.Dto;
using Example.Core.Exceptions;
using Example.Core.Model;
using Example.Data;
using Example.Service.Converters;
using System;
using System.Threading.Tasks;

namespace Example.Service.Services
{
    public class UserService : IUserService
    {
        private readonly IUserConverter userConverter;
        private readonly IRepositoryWrapper repository;

        public UserService(
            IUserConverter userConverter,
            IRepositoryWrapper repository)
        {
            this.userConverter = userConverter;
            this.repository = repository;
        }

        public async Task<UserDto> GetUser(Guid userId)
        {
            User user = await repository.User.GetUserByIdAsync(userId);

            if (user == null)
            {
                throw new EntityNotFoundException(nameof(user), userId);
            }

            return this.userConverter.ConvertUserToUserDto(user);
        }

        public async Task<ListUserDto> ListUsers()
        {
            var users = await repository.User.FindAllAsync();

            return this.userConverter.ConvertUserListToDto(users);
        }

        public async Task<Guid> CreateUser(CreateUserDto user)
        {
            User userEntity = this.userConverter.ConvertCreateUserDtoToUser(user);
            repository.User.Create(userEntity);
            await repository.SaveAsync();

            return userEntity.Id;
        }
    }
}
