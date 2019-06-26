using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using Utn.PWA.DTOs;
using Utn.PWA.Entity.Models;
using Utn.PWA.Helpers;
using Utn.PWA.Repository.Interfaces;

namespace Utn.PWA.Repository.Repositories
{
    public class InternshipRepository : BaseRepository, IInternshipRepository
    {
        private readonly IMapper _mapper;
        public InternshipRepository(IMapper mapper, Utn_SysContext context) : base(context)
        {
            _mapper = mapper;
        }

        public List<InternshipDTO> GetAllInternships()
        {
                return ctx.Interships.AsNoTracking().Include(s => s.Student)
                                        .Include(s => s.Company).Include(s => s.CompanyTutor)
                                            .Select(s =>
                                                _mapper.Map<InternshipDTO>(s)
                                            ).ToList();
        }

        public List<InternshipDTO> FilterGetAllInternship(InternshipFilterDTO filter) 
        {
            var internships = ctx.Interships.Where(i => !i.Deleted)
                .AddFilterIfValue(filter.careerId, i => i.Student.CareerId.Equals(filter.careerId))
                    .AddFilterIfValue(filter.companyId, i => i.CompanyId.Equals(filter.companyId))
                        .AddFilterIfValue(filter.genre, i => i.Student.Sex.Equals(filter.genre))
                            .AddFilterIfValue(filter.state, i => i.State.Equals(filter.state))
                            .WhereIf(filter.dateStart != null, i => i.StartDate >= filter.dateStart)
                            .WhereIf(filter.dateEnd != null, i => i.StartDate >= filter.dateEnd)
                                .Include(s => s.Student)
                                .   Include(s => s.Company).Include(s => s.CompanyTutor)
                                    .Select(s =>
                                        _mapper.Map<InternshipDTO>(s)
                                    ).ToList();
            
            return internships;
        }

        public InternshipDTO GetInternshipById(int Id)
        {
                return _mapper.Map<InternshipDTO>(ctx.Interships.AsNoTracking()
                                    .Where(s => s.Id.Equals(Id))
                                        .FirstOrDefault());
        }
        public bool Delete(InternshipDTO internship)
        {
                ctx.Interships.Remove(_mapper.Map<Interships>(internship));
                ctx.SaveChanges();
                return true;
        }
        public bool CreateOrUpdate(InternshipDTO internship, int userId)
        {
            var oInternship = ctx.Interships.AsNoTracking()
                            .Where(c => c.Id == internship.Id)
                                .FirstOrDefault();

            if (oInternship == null)
            {
                oInternship = new Interships();
                ctx.Interships.Add(oInternship);
                oInternship.CreatedDate = DateTime.Now;
                oInternship.State = "Nueva";
                oInternship.UserCreatedId = userId;
            }
            else
            {
                ctx.Interships.Attach(oInternship);
                oInternship.LastModified = DateTime.Now;
                oInternship.UserLasModifiedId = userId;
            }
            oInternship.DailyHours = internship.DailyHours;
            oInternship.WorkAgreement = internship.WorkAgreement;
            oInternship.CompanyTutorId = internship.CompanyMentorId;
            oInternship.CompanySignatory = internship.CompanySignatory;
            oInternship.SalaryWorkAssignment = internship.SalaryWorkAssignment;
            oInternship.StartDate = internship.StartDate;
            oInternship.EndDate = internship.EndDate;
            oInternship.StudentId = internship.StudentId;
            oInternship.TaskDescription = internship.TaskDescription;
            oInternship.CompanyId = internship.CompanyId;
            oInternship.Observations = internship.Observations;

            ctx.SaveChanges();
            return true;
        }

        public bool CancelInternship(string cancelationDescription, int internshipId, int userId, DateTime? cancelationDate)
        {
            var oInternship = ctx.Interships.Where(i => i.Id.Equals(internshipId)).FirstOrDefault();

            if(oInternship.Equals(null))
            {
                return false;
            }

            ctx.Interships.Attach(oInternship);
            oInternship.State = "Cancelada";
            oInternship.CancellationDescription = cancelationDescription;
            oInternship.CancellationDate = cancelationDate ?? DateTime.Now;
            oInternship.UserCancelattionId = userId;

            ctx.SaveChanges();
            return true;
        }

        public bool RenoveInternship(int userId, int internshipId, DateTime? renovationDate)
        {
            var oInternship = ctx.Interships.Where(i => i.Id.Equals(internshipId)).FirstOrDefault();

            if (oInternship.Equals(null))
            {
                return false;
            }

            ctx.Interships.Attach(oInternship);
            oInternship.State = "Renovada";
            oInternship.UserRenovationId = userId;
            oInternship.RenovationDate = renovationDate ?? DateTime.Now;
            ctx.SaveChanges();
            return true;
        }

        public List<InternshipDTO> GetInternshipsByCareer(int careerId)
        {
            return ctx.Interships.Where(i => i.Student.CareerId == careerId).
                                        AsNoTracking().Include(s => s.Student)
                                            .Include(s => s.Company).Include(s => s.CompanyTutor)
                                                .Select(s =>
                                                    _mapper.Map<InternshipDTO>(s)
                                                ).ToList();
        }

    }
}
