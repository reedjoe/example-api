using Example.Core.Dto;
using Example.Core.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Example.Service.Converters
{
    public interface IUserConverter
    {
        ListUserDto ConvertUserListToDto(List<User> users);
    }
}
