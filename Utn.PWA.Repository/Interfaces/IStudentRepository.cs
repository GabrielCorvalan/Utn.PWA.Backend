using System.Collections.Generic;
using Utn.PWA.DTOs;

namespace Utn.PWA.Repository.Interfaces
{
    public interface IStudentRepository
    {
        List<StudentDTO> GetAllStudents();
        StudentDTO GetStudentById(int Id);
        bool CreateOrUpdate(StudentDTO student);
        bool Delete(StudentDTO student);
    }
}
