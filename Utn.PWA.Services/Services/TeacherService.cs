using System.Collections.Generic;
using Utn.PWA.DTOs;
using Utn.PWA.Repository.Interfaces;
using Utn.PWA.Services.Interfaces;

namespace Utn.PWA.Services.Services
{
    public class TeacherService : ITeacherService
    {
        readonly ITeacherRepository teacherRepo;
        public TeacherService(ITeacherRepository pRepo)
        {
            teacherRepo = pRepo;
        }

        public bool CreateOrUpdate(TeacherDTO teacher)
        {
            return teacherRepo.CreateOrUpdate(teacher);
        }

        public List<TeacherDTO> GetAllTeachers()
        {
            return teacherRepo.GetAllTeachers();
        }

        public List<TeacherDTO> GetTeachersByFilter(string filter)
        {
            return teacherRepo.GetTeachersByFilter(filter);
        }

        public TeacherDTO GetTeacherById(int Id)
        {
            return teacherRepo.GetTeacherById(Id);
        }
        public bool Delete(TeacherDTO teacher)
        {
            return teacherRepo.Delete(teacher);
        }
    }
}
