using Example.Core.Dto;
using Example.Core.Exceptions;
using Example.Core.Model;
using Example.Service.Converters;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Example.Service.Services
{
    public class UserService : IUserService
    {
        private readonly IUserConverter userConverter;

        public UserService(IUserConverter userConverter)
        {
            this.userConverter = userConverter;
        }
        
        public Task<ListUserDto> ListUsersAsync()
        {
            List<User> users = new List<User>()
            {
                new User()
                {
                    Id = Guid.NewGuid(),
                    FirstName = "John",
                    LastName = "Smith"
                }
            };
            return Task.FromResult(this.userConverter.ConvertUserListToDto(users));
        }
    }
}
