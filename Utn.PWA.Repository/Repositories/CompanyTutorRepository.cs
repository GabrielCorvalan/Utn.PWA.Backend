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
    public class CompanyTutorRepository : BaseRepository, ICompanyTutorRepository
    {
        private readonly IMapper _mapper;
        public CompanyTutorRepository(IMapper mapper, Utn_SysContext context) : base(context)
        {
            _mapper = mapper;
        }

        public List<CompanyTutorDTO> GetAllCompanyTutors()
        {
            return ctx.CompanyTutor.AsNoTracking()
                                .Select(s =>
                                    _mapper.Map<CompanyTutorDTO>(s)
                                ).ToList();
        }

        public CompanyTutorDTO GetCompanyTutorById(int Id)
        {
            return _mapper.Map<CompanyTutorDTO>(ctx.CompanyTutor
                                .AsNoTracking()
                                    .Where(s => s.Id.Equals(Id))
                                        .FirstOrDefault());
        }
        public bool Delete(CompanyTutorDTO companyTutor)
        {
            ctx.CompanyTutor.Remove(_mapper.Map<CompanyTutor>(companyTutor));
            ctx.SaveChanges();
            return true;
        }
        public bool CreateOrUpdate(CompanyTutorDTO companyTutor)
        {
            var oCompanyTutor = ctx.CompanyTutor.AsNoTracking()
                            .Where(c => c.Id == companyTutor.Id)
                                .FirstOrDefault();

            if (oCompanyTutor == null)
            {
                oCompanyTutor = new CompanyTutor();
                ctx.CompanyTutor.Add(oCompanyTutor);
            }
            else
            {
                ctx.CompanyTutor.Attach(oCompanyTutor);
            }
            oCompanyTutor.Birthdate = companyTutor.Birthdate;
            oCompanyTutor.CompanyId = companyTutor.CompanyId;
            oCompanyTutor.Cuil = companyTutor.Cuil;
            oCompanyTutor.Dni = companyTutor.Dni;
            oCompanyTutor.Email = companyTutor.Email;
            oCompanyTutor.Names = companyTutor.Names;
            oCompanyTutor.Surnames = companyTutor.Surnames;
            oCompanyTutor.Sex = companyTutor.Sex;

            ctx.SaveChanges();
            return true;
        }
    }
}