using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using Utn.PWA.DTOs;
using Utn.PWA.Services.Interfaces;

namespace Utn.PWA.Api.Controllers
{
    [EnableCors("AllowMyOrigin")]
    [Route("api/[controller]")]
    [ApiController]
    public class CareerController : ControllerBase
    {
        private readonly ICareerService careerService;

        public CareerController(ICareerService service)
        {
            careerService = service;
        }

        [HttpGet]
        [Produces("application/json", Type = typeof(IEnumerable<CareerDTO>))]
        public IActionResult GetAllCareers()
        {
            try
            {
                return Ok(careerService.GetAllCareers());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet("{id}")]
        [Produces("application/json", Type = typeof(CareerDTO))]
        public IActionResult GetCareerById(int id)
        {
            try
            {
                return Ok(careerService.GetCareerById(id));
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpDelete("{id}"), Authorize(Roles = "Administrador")]
        [Produces("application/json", Type = typeof(bool))]
        public IActionResult Delete(int Id)
        {
            try
            {
                var career = careerService.GetCareerById(Id);

                return Ok(careerService.Delete(career));
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        [HttpPost, Authorize(Roles = "Administrador")]
        [Produces("application/json", Type = typeof(bool))]
        public IActionResult Post([FromBody]CareerDTO career)
        {
            try
            {
                return Ok(careerService.CreateOrUpdate(career));
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}