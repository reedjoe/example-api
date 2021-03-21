using Example.Core.Dto;
using Example.Core.Model;
using Example.Service.Converters;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Example.Test.Converters
{
    [TestClass]
    public class UserConverterTests
    {
        [TestMethod]
        public void UserConverter_ConvertCreateUserDtoToUser_ConvertsSuccessfully()
        {
            // Arrange
            CreateUserDto dto = new CreateUserDto()
            {
                FirstName = "FirstName",
                LastName = "LastName"
            };
            var sut = this.CreateSut();

            // Act
            var res = sut.ConvertCreateUserDtoToUser(dto);

            // Assert
            Assert.IsInstanceOfType(res, typeof(User));
            Assert.AreEqual(res.FirstName, dto.FirstName);
            Assert.AreEqual(res.LastName, dto.LastName);
        }

        [TestMethod]
        public void UserConverter_ConvertUserToUserDto_ConvertsSuccessfully()
        {
            // Arrange
            User user = new User()
            {
                Id = Guid.NewGuid(),
                FirstName = "FirstName",
                LastName = "LastName"
            };
            var sut = this.CreateSut();

            // Act
            var res = sut.ConvertUserToUserDto(user);

            // Assert
            Assert.IsInstanceOfType(res, typeof(UserDto));
            Assert.AreEqual(res.Id, user.Id);
            Assert.AreEqual(res.FirstName, user.FirstName);
            Assert.AreEqual(res.LastName, user.LastName);
            Assert.AreEqual(res.FullName, $"{user.FirstName} { user.LastName}");
        }

        [TestMethod]
        public void UserConverter_ConvertUserListToDto_ConvertsSuccessfully()
        {
            // Arrange
            List<User> users = new List<User>()
            {
                new User()
                {
                    Id = Guid.NewGuid(),
                    FirstName = "FirstName1",
                    LastName = "LastName1"
                },
                new User()
                {
                    Id = Guid.NewGuid(),
                    FirstName = "FirstName2",
                    LastName = "LastName2"
                }
            };
            var sut = this.CreateSut();

            // Act
            var res = sut.ConvertUserListToDto(users);

            // Assert
            Assert.IsInstanceOfType(res, typeof(ListUserDto));
            for (int i = 0; i < users.Count; i++)
            {
                Assert.AreEqual(res.Users[i].Id, users[i].Id);
                Assert.AreEqual(res.Users[i].FirstName, users[i].FirstName);
                Assert.AreEqual(res.Users[i].LastName, users[i].LastName);
                Assert.AreEqual(res.Users[i].FullName, $"{users[i].FirstName} { users[i].LastName}");
            }
        }

        private UserConverter CreateSut()
        {
            return new UserConverter();
        }
    }
}
