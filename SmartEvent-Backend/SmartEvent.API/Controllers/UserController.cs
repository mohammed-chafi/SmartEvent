using Microsoft.AspNetCore.Mvc;
using SmartEvent.Services;
using SmartEvent.Core.DTO;
using Microsoft.AspNetCore.Authorization;
using SmartEvent.Core.Models;

namespace SmartEvent.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;

        public UserController(UserService userService)
        {
            _userService = userService;
        }

    }
}