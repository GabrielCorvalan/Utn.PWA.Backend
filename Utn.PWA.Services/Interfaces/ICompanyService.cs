using System.Collections.Generic;
using Utn.PWA.DTOs;

namespace Utn.PWA.Services.Interfaces
{
    public interface ICompanyService
    {
        List<CompanyDTO> GetAllCompanies();
        CompanyDTO GetCompanyById(int Id);
        bool CreateOrUpdate(CompanyDTO company);
        bool Delete(CompanyDTO company);
    }
}
