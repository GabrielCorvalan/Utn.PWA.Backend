using System.Collections.Generic;
using Utn.PWA.DTOs;

namespace Utn.PWA.Repository.Interfaces
{
    public interface ICompanyRepository
    {
        List<CompanyDTO> GetAllCompanies();
        CompanyDTO GetCompanyById(int Id);
        bool CreateOrUpdate(CompanyDTO company);
        bool Delete(CompanyDTO company);
    }
}
