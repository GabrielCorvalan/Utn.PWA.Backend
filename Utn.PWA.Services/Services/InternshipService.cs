using System;
using System.Collections.Generic;
using Utn.PWA.DTOs;
using Utn.PWA.Repository.Interfaces;
using Utn.PWA.Services.Interfaces;

namespace Utn.PWA.Services.Services
{
    public class InternshipService : IInternshipService
    {
        readonly IInternshipRepository internshipRepo;
        public InternshipService(IInternshipRepository pRepo)
        {
            internshipRepo = pRepo;
        }

        public bool CreateOrUpdate(InternshipDTO internship, string userId)
        {
            return internshipRepo.CreateOrUpdate(internship, int.Parse(userId));
        }

        public List<InternshipDTO> FilterGetAllInternship(InternshipFilterDTO filter)
        {
            return internshipRepo.FilterGetAllInternship(filter);
        }

        public List<InternshipDTO> GetAllInternships()
        {
            return internshipRepo.GetAllInternships();
        }

        public InternshipDTO GetInternshipById(int Id)
        {
            return internshipRepo.GetInternshipById(Id);
        }
        public bool Delete(InternshipDTO internship)
        {
            return internshipRepo.Delete(internship);
        }

        public bool CancelInternship(string cancelationDescription, int internshipId, int userId, DateTime? cancelationDate)
        {
            return internshipRepo.CancelInternship(cancelationDescription, internshipId, userId, cancelationDate);
        }
        public bool RenoveInternship(int internshipId, int userId, DateTime? renovationDate)
        {
            return internshipRepo.RenoveInternship(internshipId, userId, renovationDate);
        }
    }
}
