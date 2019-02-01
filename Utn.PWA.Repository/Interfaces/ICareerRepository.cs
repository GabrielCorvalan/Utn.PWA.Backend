using System.Collections.Generic;
using Utn.PWA.DTOs;

namespace Utn.PWA.Repository.Interfaces
{
    public interface ICareerRepository
    {
        List<CareerDTO> GetAllCareers();
        CareerDTO GetCareerById(int Id);
        bool CreateOrUpdate(CareerDTO career);
        bool Delete(CareerDTO career);
    }
}
