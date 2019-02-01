using System.Collections.Generic;
using Utn.PWA.DTOs;

namespace Utn.PWA.Services.Interfaces
{
    public interface IInternshipService
    {
        List<InternshipDTO> GetAllInternships();
        InternshipDTO GetInternshipById(int Id);
        bool CreateOrUpdate(InternshipDTO internship);
        bool Delete(InternshipDTO internship);
    }
}
