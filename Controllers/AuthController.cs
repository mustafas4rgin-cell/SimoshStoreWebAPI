using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using SimoshStore;
using SimoshStoreAPI;

namespace MyApp.Namespace
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly JwtService _jwtService;
        private readonly IUserService _userService;

        public AuthController(IUserService userService, JwtService jwtService)
        {
            _userService = userService;
            _jwtService = jwtService;
        }

        [HttpPost("/api/login")]
        public async Task<IActionResult> Login([FromBody] LoginModel login)
        {
            var users = await _userService.GetUsersAsync();
            if(!await _userService.ValidateUserAsync(login.username, login.password))
            {
               return NotFound();
            }
            var user = await _userService.GetUserByEmailAsync(login.username);
            await _userService.ValidateUserRoleAsync(user);
            var token = _jwtService.GenerateToken(user);
            return Ok(new { token });
        }
    }
}
