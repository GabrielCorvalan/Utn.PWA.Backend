using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Utn.PWA.DTOs;
using Utn.PWA.Repository.Interfaces;
using Utn.PWA.Services.Interfaces;

namespace Utn.PWA.Api.Controllers
{
    [EnableCors("AllowMyOrigin")]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository userRepository;

        public UserController(IUserRepository service)
        {
            userRepository = service;
        }

        [AllowAnonymous]
        [HttpPost("Auth")]
        public IActionResult Authenticate([FromBody]UserLoginDTO userParam)
        {
            var token = userRepository.Authenticate(userParam);

            if (token == null)
                return  Unauthorized();

            return Ok(token);
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Hello");
        }
    }
}