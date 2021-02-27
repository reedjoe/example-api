using Example.Core.Dto;
using Example.Core.Exceptions;
using Example.Core.Model;
using Example.Data;
using Example.Service.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Example.Service.Services
{
    public class UserService : IUserService
    {
        private IRepositoryWrapper repository;
        private readonly IUserConverter userConverter;

        public UserService(
            IUserConverter userConverter,
            IRepositoryWrapper repository)
        {
            this.userConverter = userConverter;
            this.repository = repository;
        }
        
        public Task<ListUserDto> ListUsersAsync()
        {
            var users = repository.User.FindAll().ToList();

            return Task.FromResult(this.userConverter.ConvertUserListToDto(users));
        }
    }
}
