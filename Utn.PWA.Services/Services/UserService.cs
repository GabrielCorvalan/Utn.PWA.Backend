using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Utn.PWA.DTOs;
using Utn.PWA.Helpers;
using Utn.PWA.Repository.Interfaces;
using Utn.PWA.Services.Interfaces;

namespace Utn.PWA.Services.Services
{
    public class UserService : IUserService
    {
        private readonly AppSettings _appSettings;
        private readonly IUserRepository userRepository;

        public UserService(IOptions<AppSettings> appSettings, IUserRepository repository)
        {
            _appSettings = appSettings.Value;
            userRepository = repository;
        }

        public string Authenticate(UserLoginDTO userLogin)
        {
            var user = userRepository.Authenticate(userLogin);

            if (user == null)
                return null;
            
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Dni),
                    new Claim(ClaimTypes.Role, user.Rol.Name),
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(14),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);

            user.Password = null;

            return tokenHandler.WriteToken(token);
        }

    }
}
