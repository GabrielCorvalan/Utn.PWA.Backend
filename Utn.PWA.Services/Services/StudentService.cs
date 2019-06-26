using System.Collections.Generic;
using Utn.PWA.DTOs;
using Utn.PWA.Repository.Interfaces;
using Utn.PWA.Services.Interfaces;

namespace Utn.PWA.Services.Services
{
    public class StudentService : IStudentService
    {
        readonly IStudentRepository studentRepo;
        public StudentService(IStudentRepository pRepo)
        {
            studentRepo = pRepo;
        }

        public bool CreateOrUpdate(StudentDTO student)
        {
            return studentRepo.CreateOrUpdate(student);
        }

        public List<StudentDTO> GetAllStudents()
        {
            return studentRepo.GetAllStudents();
        }

        public StudentDTO GetStudentById(int Id)
        {
            return studentRepo.GetStudentById(Id);
        }
        public bool Delete(StudentDTO student)
        {
            return studentRepo.Delete(student);
        }

        public bool ValidateDni(string dni)
        {
            return studentRepo.ValidateDni(dni);
        }

        public bool ValidateCuil(string cuil)
        {
            return studentRepo.ValidateCuil(cuil);
        }
    }
}
