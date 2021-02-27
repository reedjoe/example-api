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
        public User ConvertCreateUserDtoToUser(CreateUserDto user)
        {
            return new User()
            {
                FirstName = user.FirstName,
                LastName = user.LastName
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
