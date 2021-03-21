using Example.Core.Dto;
using Example.Core.Exceptions;
using Example.Core.Model;
using Example.Data;
using Example.Service.Converters;
using Example.Service.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;

namespace Example.Test.Services
{
    [TestClass]
    public class UserServiceTests
    {
        private Mock<IUserConverter> mockUserConverter;
        private Mock<IRepositoryWrapper> mockRepository;

        private Guid userId = Guid.NewGuid();
        private readonly string firstName = "FirstName";
        private readonly string lastName = "LastName";
        private readonly string fullName = "FirstName LastName";

        [TestInitialize]
        public void Setup()
        {
            this.mockUserConverter = new Mock<IUserConverter>();
            this.mockRepository = new Mock<IRepositoryWrapper>();
        }

        [TestMethod]
        public void UserService_GetUser_ReturnsSuccessfully()
        {
            // Arrange
            User user = new User()
            {
                Id = this.userId,
                FirstName = this.firstName,
                LastName = this.lastName
            };
            UserDto dto = new UserDto()
            {
                Id = this.userId,
                FirstName = this.firstName,
                LastName = this.lastName,
                FullName = this.fullName,
            };

            this.mockRepository
                .Setup(x => x.User.GetUserByIdAsync(user.Id))
                .ReturnsAsync(user);
            this.mockUserConverter
                .Setup(x => x.ConvertUserToUserDto(user))
                .Returns(dto);

            var sut = this.CreateSut();

            // Act
            var res = sut.GetUser(user.Id);

            // Assert
            Assert.IsInstanceOfType(res.Result, typeof(UserDto));
            Assert.AreEqual(res.Result.Id, dto.Id);
            Assert.AreEqual(res.Result.FirstName, dto.FirstName);
            Assert.AreEqual(res.Result.LastName, dto.LastName);
            Assert.AreEqual(res.Result.FullName, dto.FullName);
        }

        [TestMethod]
        public void UserService_GetUser_ThrowsNotFoundException()
        {
            // Arrange
            Guid userId = Guid.NewGuid();
            
            this.mockRepository
                .Setup(x => x.User.GetUserByIdAsync(userId))
                .ReturnsAsync( () => null);

            var sut = this.CreateSut();

            // Act and Assert
            var res = Assert.ThrowsExceptionAsync<EntityNotFoundException>(() => sut.GetUser(userId));
        }

        [TestMethod]
        public void UserService_ListUsers_ReturnsSuccessfully()
        {
            // Arrange
            List<User> userList = new List<User>()
            {
                new User()
                {
                    Id = this.userId,
                    FirstName = this.firstName,
                    LastName = this.lastName
                },
                new User()
                {
                    Id = this.userId,
                    FirstName = this.firstName,
                    LastName = this.lastName
                }
            };
            ListUserDto dtoList = new ListUserDto()
            {
                Users =  new List<UserDto>()
                {
                    new UserDto()
                    {
                        Id = this.userId,
                        FirstName = this.firstName,
                        LastName = this.lastName,
                        FullName = this.fullName
                    },
                    new UserDto()
                    {
                        Id = this.userId,
                        FirstName = this.firstName,
                        LastName = this.lastName,
                        FullName = this.fullName
                    }
                }
            };

            this.mockRepository
                .Setup(x => x.User.FindAllAsync())
                .ReturnsAsync(userList);
            this.mockUserConverter
                .Setup(x => x.ConvertUserListToDto(userList))
                .Returns(dtoList);

            var sut = this.CreateSut();

            // Act
            var res = sut.ListUsers();

            // Assert
            for (int i = 0; i < dtoList.Users.Count; i++)
            {
                Assert.AreEqual(res.Result.Users[i].Id, dtoList.Users[i].Id);
                Assert.AreEqual(res.Result.Users[i].FirstName, dtoList.Users[i].FirstName);
                Assert.AreEqual(res.Result.Users[i].LastName, dtoList.Users[i].LastName);
                Assert.AreEqual(res.Result.Users[i].FullName, dtoList.Users[i].FullName);
            }
        }

        [TestMethod]
        public void UserService_CreateUser_ReturnsSuccessfully()
        {
            // Arrange
            User user = new User()
            {
                Id = this.userId,
                FirstName = this.firstName,
                LastName = this.lastName
            };
            CreateUserDto dto = new CreateUserDto()
            {
                FirstName = this.firstName,
                LastName = this.lastName
            };

            this.mockUserConverter
                .Setup(x => x.ConvertCreateUserDtoToUser(dto))
                .Returns(user);
            this.mockRepository
                .Setup(x => x.User.Create(user));
            this.mockRepository
                .Setup(x => x.SaveAsync());

            var sut = this.CreateSut();

            // Act
            var res = sut.CreateUser(dto);

            // Assert
            Assert.IsInstanceOfType(res.Result, typeof(Guid));
        }

        private UserService CreateSut()
        {
            return new UserService(
                this.mockUserConverter.Object,
                this.mockRepository.Object);
        }
    }
}
