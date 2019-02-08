using System.Collections.Generic;
using Utn.PWA.DTOs;
using Utn.PWA.Repository.Interfaces;
using Utn.PWA.Services.Interfaces;

namespace Utn.PWA.Services.Services
{
    public class CompanyTutorService : ICompanyTutorService
    {
        readonly ICompanyTutorRepository companyTutorRepo;
        public CompanyTutorService(ICompanyTutorRepository pRepo)
        {
            companyTutorRepo = pRepo;
        }

        public bool CreateOrUpdate(CompanyTutorDTO companyTutor)
        {
            return companyTutorRepo.CreateOrUpdate(companyTutor);
        }

        public List<CompanyTutorDTO> GetAllCompanyTutors()
        {
            return companyTutorRepo.GetAllCompanyTutors();
        }

        public CompanyTutorDTO GetCompanyTutorById(int Id)
        {
            return companyTutorRepo.GetCompanyTutorById(Id);
        }
        public bool Delete(CompanyTutorDTO companyTutor)
        {
            return companyTutorRepo.Delete(companyTutor);
        }
    }
}
