using System.Collections.Generic;
using Utn.PWA.DTOs;

namespace Utn.PWA.Repository.Interfaces
{
    public interface ITeacherRepository
    {
        List<TeacherDTO> GetAllTeachers();
        TeacherDTO GetTeacherById(int Id);
        List<TeacherDTO> GetTeachersByFilter(string filter);
        bool CreateOrUpdate(TeacherDTO teacher);
        bool Delete(TeacherDTO teacher);
    }
}
