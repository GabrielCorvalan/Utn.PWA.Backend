using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Utn.PWA.DTOs;
using Utn.PWA.Entity.Models;
using Utn.PWA.Repository.Interfaces;

namespace Utn.PWA.Repository.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IMapper _mapper;
        public UserRepository(IMapper mapper)
        {
            _mapper = mapper;
        }
        public UsersDTO Authenticate(UserLoginDTO user)
        {
            using (var ctx = new Utn_SysContext())
            {
                return _mapper.Map<UsersDTO>(
                            ctx.Users.Where(u => u.Dni == user.Dni && u.Password == user.Password)
                                        .Include(u => u.Rol)
                                            .FirstOrDefault()
                        );
            }
        }
    }
}
