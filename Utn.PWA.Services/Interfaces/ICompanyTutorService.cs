using System.Collections.Generic;
using Utn.PWA.DTOs;

namespace Utn.PWA.Services.Interfaces
{
    public interface ICompanyTutorService
    {
        List<CompanyTutorDTO> GetAllCompanyTutors();
        CompanyTutorDTO GetCompanyTutorById(int Id);
        bool CreateOrUpdate(CompanyTutorDTO companyTutor);
        bool Delete(CompanyTutorDTO companyTutor);
    }
}