using System.Collections.Generic;
using Utn.PWA.DTOs;

namespace Utn.PWA.Repository.Interfaces
{
    public interface IInternshipRepository
    {
        List<InternshipDTO> GetAllInternships();
        InternshipDTO GetInternshipById(int Id);
        bool CreateOrUpdate(InternshipDTO internship);
        bool Delete(InternshipDTO internship);
    }
}
