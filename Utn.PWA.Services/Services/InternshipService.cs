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

        public bool CreateOrUpdate(InternshipDTO internship)
        {
            return internshipRepo.CreateOrUpdate(internship);
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
    }
}
