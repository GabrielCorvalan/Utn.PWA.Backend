using System.Collections.Generic;
using Utn.PWA.DTOs;
using Utn.PWA.Repository.Interfaces;
using Utn.PWA.Services.Interfaces;

namespace Utn.PWA.Services.Services
{
    public class CompanyService : ICompanyService
    {
        readonly ICompanyRepository studentRepo;
        public CompanyService(ICompanyRepository pRepo)
        {
            studentRepo = pRepo;
        }

        public bool CreateOrUpdate(CompanyDTO student)
        {
            return studentRepo.CreateOrUpdate(student);
        }

        public List<CompanyDTO> GetAllCompanies()
        {
            return studentRepo.GetAllCompanies();
        }

        public CompanyDTO GetCompanyById(int Id)
        {
            return studentRepo.GetCompanyById(Id);
        }
        public bool Delete(CompanyDTO student)
        {
            return studentRepo.Delete(student);
        }
    }
}
