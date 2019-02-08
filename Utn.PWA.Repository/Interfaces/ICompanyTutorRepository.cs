using System;
using System.Collections.Generic;
using System.Text;
using Utn.PWA.DTOs;

namespace Utn.PWA.Repository.Interfaces
{
    public interface ICompanyTutorRepository
    {
        List<CompanyTutorDTO> GetAllCompanyTutors();
        CompanyTutorDTO GetCompanyTutorById(int Id);
        bool CreateOrUpdate(CompanyTutorDTO companyTutor);
        bool Delete(CompanyTutorDTO companyTutor);
    }
}
