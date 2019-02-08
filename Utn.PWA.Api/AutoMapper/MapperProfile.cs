using AutoMapper;
using Utn.PWA.DTOs;
using Utn.PWA.Entity.Models;

namespace Utn.PWA.Api.AutoMapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Students, StudentDTO>();
            CreateMap<StudentDTO, Students>();

            CreateMap<Careers, CareerDTO>();
            CreateMap<CareerDTO, Careers>();

            CreateMap<Teachers, TeacherDTO>();
            CreateMap<TeacherDTO, Teachers>();

            CreateMap<Interships, InternshipDTO>();
            CreateMap<InternshipDTO, Interships>();

            CreateMap<Companies, CompanyDTO>();
            CreateMap<CompanyDTO, Companies>();

            CreateMap<Users, UsersDTO>();
            CreateMap<UsersDTO, Users>();

            CreateMap<Rols, RolDTO>();
            CreateMap<RolDTO, Rols>();

            CreateMap<CompanyTutor, CompanyTutorDTO>();
            CreateMap<CompanyTutorDTO, CompanyTutor>();
        }
    }
}
