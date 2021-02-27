using Example.Core.Dto;
using Example.Service.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Example.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService userService;

        public UserController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpGet("list")]
        public async Task<ActionResult<ListUserDto>> ListUsers()
        {
            return Ok(await userService.ListUsers());
        }

        [HttpPost("create")]
        public async Task<ActionResult<Guid>> CreateUser([FromBody] CreateUserDto user)
        {
            return Ok(await userService.CreateUser(user));
        }
    }
}
