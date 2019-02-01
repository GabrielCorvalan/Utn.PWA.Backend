using System.Collections.Generic;
using Utn.PWA.DTOs;

namespace Utn.PWA.Services.Interfaces
{
    public interface IStudentService
    {
        List<StudentDTO> GetAllStudents();
        StudentDTO GetStudentById(int Id);
        bool CreateOrUpdate(StudentDTO student);
        bool Delete(StudentDTO student);
    }
}
