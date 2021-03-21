using Example.API.Controllers;
using Example.Core.Dto;
using Example.Service.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Threading.Tasks;

namespace Example.Test.Controllers
{
    [TestClass]
    public class UserControllerTests
    {
        Mock<IUserService> mockUserService;

        [TestInitialize]
        public void Setup()
        {
            this.mockUserService = new Mock<IUserService>();
        }

        [TestMethod]
        public async Task UserController_GetUser_ReturnsSuccess()
        {
            // Arrange
            Guid userId = Guid.NewGuid();
            UserDto user = new UserDto();
            this.mockUserService
                .Setup(service => service.GetUser(userId))
                .ReturnsAsync(user);
            var sut = this.CreateSut();

            // Act
            var res = await sut.GetUser(userId);

            // Assert
            var result = res.Result as OkObjectResult;
            Assert.AreEqual(result.Value, user);
        }

        [TestMethod]
        public async Task UserController_ListUsers_ReturnsSuccess()
        {
            // Arrange
            ListUserDto userList = new ListUserDto();
            this.mockUserService
                .Setup(service => service.ListUsers())
                .ReturnsAsync(userList);
            var sut = this.CreateSut();

            // Act
            var res = await sut.ListUsers();

            // Assert
            var result = res.Result as OkObjectResult;
            Assert.AreEqual(result.Value, userList);
        }

        [TestMethod]
        public async Task UserController_CreateUser_ReturnsSuccess()
        {
            // Arrange
            Guid userId = Guid.NewGuid();
            CreateUserDto user = new CreateUserDto();
            this.mockUserService
                .Setup(service => service.CreateUser(user))
                .ReturnsAsync(userId);
            var sut = this.CreateSut();

            // Act
            var res = await sut.CreateUser(user);

            // Assert
            var result = res.Result as OkObjectResult;
            Assert.AreEqual(result.Value, userId);
        }

        private UserController CreateSut()
        {
            return new UserController(this.mockUserService.Object);
        }
    }
}
