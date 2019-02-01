using AutoMapper;
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
            return new UsersDTO()
            {
                Id = 1000,
                Address = "Brasil 2693",
                Birthdate = new System.DateTime(),
                Cuil = "404753046",
                Deleted = false,
                Dni = "40475304",
                Email = "Gabrielcn6@gmail.com",
                Names = "Gabriel Gonzalo",
                Password = "xxxxxxxxx",
                Rol = new RolDTO { Deleted = false, Id = 1000, Name = "Admin" },
                RolId = 1000,
                Sex = "Masculino",
                Surnames = "Corvalan",
                UniversityPosition = "Estudiante",
                Token = null
            };
            //using (var ctx = new Utn_SysContext())
            //{
            //    return _mapper.Map<UsersDTO>(
            //                ctx.Users.SingleOrDefault(x => x.Dni == user.Dni && x.Password == user.Password)
            //            );
            //}
        }
    }
}
