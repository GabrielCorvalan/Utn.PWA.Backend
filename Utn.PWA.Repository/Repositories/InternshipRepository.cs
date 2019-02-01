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
    public class InternshipRepository : IInternshipRepository
    {
        private readonly IMapper _mapper;
        public InternshipRepository(IMapper mapper)
        {
            _mapper = mapper;
        }

        public List<InternshipDTO> GetAllInternships()
        {
            using (var ctx = new Utn_SysContext())
            {
                return ctx.Interships.AsNoTracking()
                                    .Select(s =>
                                        _mapper.Map<InternshipDTO>(s)
                                    ).ToList();
            }
        }

        public InternshipDTO GetInternshipById(int Id)
        {
            using (var ctx = new Utn_SysContext())
            {
                return _mapper.Map<InternshipDTO>(ctx.Interships.AsNoTracking()
                                    .Where(s => s.Id.Equals(Id))
                                        .FirstOrDefault());
            }
        }
        public bool Delete(InternshipDTO internship)
        {
            using (var ctx = new Utn_SysContext())
            {
                ctx.Interships.Remove(_mapper.Map<Interships>(internship));
                ctx.SaveChanges();
                return true;
            }
        }
        public bool CreateOrUpdate(InternshipDTO internship)
        {
            try
            {
                using (var ctx = new Utn_SysContext())
                {
                    var oInternship = ctx.Interships.AsNoTracking()
                                    .Where(c => c.Id == internship.Id)
                                        .FirstOrDefault();

                    if (oInternship == null)
                    {
                        oInternship = new Interships();
                        ctx.Interships.Add(oInternship);
                    }
                    else
                    {
                        ctx.Interships.Attach(oInternship);
                    }
                    oInternship.SalaryWorkAssignment = internship.SalaryWorkAssignment;
                    oInternship.StartDate = internship.StartDate;
                    oInternship.EndDate = internship.EndDate;
                    oInternship.StudentId = internship.StudentId;
                    oInternship.TaskDescription = internship.TaskDescription;
                    oInternship.CompanyId = internship.CompanyId;
                    oInternship.Deleted = false;

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
