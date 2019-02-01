using System.Collections.Generic;
using Utn.PWA.DTOs;
using Utn.PWA.Repository.Interfaces;
using Utn.PWA.Services.Interfaces;

namespace Utn.PWA.Services.Services
{
    public class CareerService : ICareerService
    {
        readonly ICareerRepository studentRepo;
        public CareerService(ICareerRepository pRepo)
        {
            studentRepo = pRepo;
        }

        public bool CreateOrUpdate(CareerDTO student)
        {
            return studentRepo.CreateOrUpdate(student);
        }

        public List<CareerDTO> GetAllCareers()
        {
            return studentRepo.GetAllCareers();
        }

        public CareerDTO GetCareerById(int Id)
        {
            return studentRepo.GetCareerById(Id);
        }
        public bool Delete(CareerDTO student)
        {
            return studentRepo.Delete(student);
        }
    }
}
