using Microsoft.AspNetCore.Mvc;
using SmartEvent.Services;
using SmartEvent.Core.DTO;

namespace SmartEvent.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly AuthService _authService;

        public AuthController(AuthService authService)
        {
            _authService = authService;
        }


        [HttpPost("register/user")]
        public async Task<IActionResult> UserRegisterAsync([FromBody] UserRegisterModel userRegisterModel)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _authService.UserRegisterAsync(userRegisterModel);

            if (result.IsAuthenticated == false)
                return BadRequest(result.Message);

            return Ok(result);
        }

        [HttpPost("register/organisation")]
        public async Task<IActionResult> OrganisationRegisterAsync([FromBody] OrganisationRegisterModel organisationRegisterModel)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _authService.OrganisationRegisterAsync(organisationRegisterModel);

            if (result.IsAuthenticated == false)
                return BadRequest(result.Message);

            return Ok(result);
        }



        [HttpPost("login")]
        public async Task<IActionResult> GetTokenAsync([FromBody] TokenRequestModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _authService.GetTokenAsync(model);

            if (!result.IsAuthenticated)
                return BadRequest(result.Message);

            return Ok(result);
        }
    }
}