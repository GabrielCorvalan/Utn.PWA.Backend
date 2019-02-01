using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Utn.PWA.DTOs;
using Utn.PWA.Services.Interfaces;

namespace Utn.PWA.Api.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("AllowMyOrigin")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService userService;

        public UserController(IUserService service)
        {
            userService = service;
        }

        [AllowAnonymous]
        [HttpPost("Auth")]
        public IActionResult Authenticate([FromBody]UserLoginDTO userParam)
        {
            var user = userService.Authenticate(userParam);

            if (user == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            return Ok(user);
        }

        [HttpGet, Authorize(Roles = "Administrador")]
        public IActionResult Get()
        {
            return Ok("Hello");
        }
    }
}