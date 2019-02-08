using System;
using System.Collections.Generic;
using Utn.PWA.DTOs;

namespace Utn.PWA.Repository.Interfaces
{
    public interface IInternshipRepository
    {
        List<InternshipDTO> GetAllInternships();
        InternshipDTO GetInternshipById(int Id);
        bool CreateOrUpdate(InternshipDTO internship, int userId);
        bool Delete(InternshipDTO internship);
        bool CancelInternship(string cancelationDescription, int internshipId, int userId, DateTime? cancelationDate);
        bool RenoveInternship(int internshipId, int userId, DateTime? renovationDate);
    }
}
