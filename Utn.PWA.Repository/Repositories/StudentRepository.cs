using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using Utn.PWA.DTOs;
using Utn.PWA.Entity.Models;
using Utn.PWA.Repository.Interfaces;

namespace Utn.PWA.Repository.Repositories
{
    public class StudentRepository : BaseRepository, IStudentRepository
    {
        private readonly IMapper _mapper;
        public StudentRepository(IMapper mapper, Utn_SysContext context) : base(context)
        {
            _mapper = mapper;
        }

        public List<StudentDTO> GetAllStudents()
        {
            return ctx.Students.AsNoTracking()
                            .Include(s => s.Career)
                                .Select(s =>
                                    _mapper.Map<StudentDTO>(s)
                                ).ToList();
        }

        public StudentDTO GetStudentById(int Id)
        {
            
            return _mapper.Map<StudentDTO>(ctx.Students.AsNoTracking()
                            .Include(d => d.Career)
                                .Where(s => s.Id.Equals(Id))
                                    .FirstOrDefault());
        }
        public bool Delete(StudentDTO student)
        {
            ctx.Students.Remove(_mapper.Map<Students>(student));
            ctx.SaveChanges();
            return true;
        }
        public bool CreateOrUpdate(StudentDTO student)
        {
            var oStudent = ctx.Students
                            .Where(c => c.Id == student.Id)
                                .FirstOrDefault();

            if (oStudent == null)
            {
                oStudent = new Students();
                ctx.Students.Add(oStudent);
            }
            else
            {
                ctx.Students.Attach(oStudent);
            }
            oStudent.Names = student.Names;
            oStudent.Surnames = student.Surnames;
            oStudent.Email = student.Email;
            oStudent.Birthdate = student.Birthdate;
            oStudent.Cuil = student.Cuil;
            oStudent.Dni = student.Dni;
            oStudent.Deleted = false;
            oStudent.Address = student.Address;
            oStudent.TeacherGuideId = student.TeacherGuideId;
            oStudent.CareerId = student.CareerId;
            oStudent.Sex = student.Sex;
            oStudent.File = student.Dni + student.Cuil;


            ctx.SaveChanges();
            return true;
        }

        public bool ValidateCuil(string cuil)
        {
            var oStudent = ctx.Students.Where(s => s.Cuil == cuil).FirstOrDefault();

            if (oStudent == null)
            {
                return false;
            }

            return true;
        }

        public bool ValidateDni(string dni)
        {
            var oStudent = ctx.Students.Where(s => s.Dni == dni).FirstOrDefault();

            if (oStudent == null)
            {
                return false;
            }

            return true;
        }

    }
}
