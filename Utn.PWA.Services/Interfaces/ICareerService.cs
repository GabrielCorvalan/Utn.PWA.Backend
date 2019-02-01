using System.Collections.Generic;
using Utn.PWA.DTOs;

namespace Utn.PWA.Services.Interfaces
{
    public interface ICareerService
    {
        List<CareerDTO> GetAllCareers();
        CareerDTO GetCareerById(int Id);
        bool CreateOrUpdate(CareerDTO career);
        bool Delete(CareerDTO career);
    }
}
