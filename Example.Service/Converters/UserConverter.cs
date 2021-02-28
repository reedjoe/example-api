using Example.Core.Dto;
using Example.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Example.Service.Converters
{
    public class UserConverter : IUserConverter
    {
        public User ConvertCreateUserDtoToUser(CreateUserDto dto)
        {
            return new User()
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName
            };
        }

        public UserDto ConvertUserToUserDto(User user)
        {
            return new UserDto()
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                FullName = user.FirstName + ' ' + user.LastName
            };
        }

        public ListUserDto ConvertUserListToDto(List<User> users)
        {
            return new ListUserDto()
            {
                Users = users
                    .Select(x => new UserDto() 
                    { 
                        Id = x.Id,
                        FirstName = x.FirstName,
                        LastName= x.LastName,
                        FullName = x.FirstName + ' ' + x.LastName
                    })
                    .ToList()
            };
        }
    }
}
