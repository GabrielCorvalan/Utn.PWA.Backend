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
    public class TeacherRepository : BaseRepository, ITeacherRepository
    {
        private readonly IMapper _mapper;
        public TeacherRepository(IMapper mapper, Utn_SysContext context) : base(context)
        {
            _mapper = mapper;
        }

        public List<TeacherDTO> GetAllTeachers()
        {
            return ctx.Teachers.AsNoTracking()
                                .Select(s =>
                                    _mapper.Map<TeacherDTO>(s)
                                ).ToList();
        }

        public TeacherDTO GetTeacherById(int Id)
        {
            return _mapper.Map<TeacherDTO>(ctx.Teachers.AsNoTracking()
                                .Where(s => s.Id.Equals(Id))
                                    .FirstOrDefault());
        }
        public List<TeacherDTO> GetTeacherByFilter(string filter) 
        {
            return ctx.Teachers.Where(x => x.Names.Contains(filter)
                                        || x.Surnames.Contains(filter)
                                        || x.Email.Contains(filter)
                                        || x.Dni.Contains(filter))
                    .Select(x =>
                        _mapper.Map<TeacherDTO>(x)
                    ).ToList();
        }
        public bool Delete(TeacherDTO teacher)
        {
            ctx.Teachers.Remove(_mapper.Map<Teachers>(teacher));
            ctx.SaveChanges();
            return true;
        }
        public bool CreateOrUpdate(TeacherDTO teacher)
        {
            using (var ctx = new Utn_SysContext())
            {
                var oTeacher = ctx.Teachers.AsNoTracking()
                                .Where(c => c.Id == teacher.Id)
                                    .FirstOrDefault();

                if (oTeacher == null)
                {
                    oTeacher = new Teachers();
                    ctx.Teachers.Add(oTeacher);
                }
                else
                {
                    ctx.Teachers.Attach(oTeacher);
                }
                oTeacher.Names = teacher.Names;
                oTeacher.Surnames = teacher.Surnames;
                oTeacher.Email = teacher.Email;
                oTeacher.Birthdate = teacher.Birthdate;
                oTeacher.Cuil = teacher.Cuil;
                oTeacher.Dni = teacher.Dni;
                oTeacher.Deleted = false;
                oTeacher.Address = teacher.Address;

                ctx.SaveChanges();
                return true;
            }
        }

    }
}