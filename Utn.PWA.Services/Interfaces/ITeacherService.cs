using System.Collections.Generic;
using Utn.PWA.DTOs;

namespace Utn.PWA.Services.Interfaces
{
    public interface ITeacherService
    {
        List<TeacherDTO> GetAllTeachers();
        TeacherDTO GetTeacherById(int Id);
        List<TeacherDTO> GetTeachersByFilter(string filter);
        bool CreateOrUpdate(TeacherDTO teacher);
        bool Delete(TeacherDTO teacher);
    }
}
