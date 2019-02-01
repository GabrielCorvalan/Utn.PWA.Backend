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
    public class StudentRepository :  IStudentRepository
    {
        private readonly IMapper _mapper;
        public StudentRepository(IMapper mapper)
        {
            _mapper = mapper;
        }

        public List<StudentDTO> GetAllStudents()
        {
            using (var ctx = new Utn_SysContext())
            {
                return ctx.Students.AsNoTracking()
                                .Include(s => s.Career)
                                    .Select(s =>
                                        _mapper.Map<StudentDTO>(s)
                                    ).ToList();
            }
        }

        public StudentDTO GetStudentById(int Id)
        {
            using (var ctx = new Utn_SysContext())
            {
                return _mapper.Map<StudentDTO>(ctx.Students.AsNoTracking()
                                .Include(d => d.Career)
                                    .Where(s => s.Id.Equals(Id))
                                        .FirstOrDefault());
            }
        }
        public bool Delete(StudentDTO student)
        {
            using (var ctx = new Utn_SysContext())
            {
                ctx.Students.Remove(_mapper.Map<Students>(student));
                ctx.SaveChanges();
                return true;
            }
        }
        public bool CreateOrUpdate(StudentDTO student)
        {
            try
            {
                using (var ctx = new Utn_SysContext())
                {
                    var oStudent = ctx.Students.AsNoTracking()
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

                    ctx.SaveChanges();
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

    }
}
