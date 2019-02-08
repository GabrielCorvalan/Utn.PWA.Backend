using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Utn.PWA.DTOs;
using Utn.PWA.Services.Interfaces;

namespace Utn.PWA.Api.Controllers
{
    [EnableCors("AllowMyOrigin")]
    [Route("api/[controller]")]
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
            var token = userService.Authenticate(userParam);

            if (token == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            return Ok(token);
        }

        [HttpGet, Authorize(Roles = "Administrador")]
        public IActionResult Get()
        {
            return Ok("Hello");
        }
    }
}