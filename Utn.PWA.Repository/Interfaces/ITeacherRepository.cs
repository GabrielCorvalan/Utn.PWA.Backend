using System.Collections.Generic;
using Utn.PWA.DTOs;

namespace Utn.PWA.Repository.Interfaces
{
    public interface ITeacherRepository
    {
        List<TeacherDTO> GetAllTeachers();
        TeacherDTO GetTeacherById(int Id);
        bool CreateOrUpdate(TeacherDTO teacher);
        bool Delete(TeacherDTO teacher);
        List<TeacherDTO> GetTeacherByFilter(string filter);
    }
}
