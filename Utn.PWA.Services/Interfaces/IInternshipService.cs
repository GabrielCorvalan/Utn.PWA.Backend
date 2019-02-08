using System;
using System.Collections.Generic;
using Utn.PWA.DTOs;

namespace Utn.PWA.Services.Interfaces
{
    public interface IInternshipService
    {
        List<InternshipDTO> GetAllInternships();
        InternshipDTO GetInternshipById(int Id);
        bool CreateOrUpdate(InternshipDTO internship, string token);
        bool Delete(InternshipDTO internship);
        bool CancelInternship(string cancelationDescription, int internshipId, int userId, DateTime? cancelationDate);
        bool RenoveInternship(int internshipId, int userId, DateTime? renovationDate);
    }
}
